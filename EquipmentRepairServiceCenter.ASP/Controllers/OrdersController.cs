using EquipmentRepairServiceCenter.ASP.LocalDto;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService _ordersService;
        private readonly IClientsService _clientsService;
        private readonly IEmployeesService _employeesService;

        public OrdersController(IOrdersService ordersService,
            IClientsService clientsService,
            IEmployeesService employeesService)
        {
            _ordersService = ordersService;
            _clientsService = clientsService;
            _employeesService = employeesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _ordersService.GetAll();
            var clients = await _clientsService.GetAll();
            var employees = await _employeesService.GetAll();

            OrdersClientsEmployees ordersClients = new OrdersClientsEmployees
            {
                Orders = orders.ToList(),
                Clients = clients.ToList(),
                Employees = employees.ToList()
            };

            return View(ordersClients);
        }

        [HttpGet]
        public async Task<IActionResult> GetFaultsByClient()
        {
            var orders = await _ordersService.GetAll();
            var clients = await _clientsService.GetAll();

            OrdersClientsEmployees ordersClients = new OrdersClientsEmployees
            {
                Orders = orders.ToList(),
                Clients = clients.ToList()
            };

            return View(ordersClients);
        }

        [HttpGet]
        public async Task<IActionResult> GetFaultsByClientFio(string clientFio)
        {
            var fio = clientFio.Split(' ');

            var orders = await _ordersService.GetAll();
            var clients = await _clientsService.GetAll();

            OrdersClientsEmployees ordersClients = new OrdersClientsEmployees
            {
                Orders = orders.Where(o => 
                    o.Client.Surname.Equals(fio[0])
                    && o.Client.Name.Equals(fio[1])
                    && o.Client.MiddleName.Equals(fio[2])).ToList(),
                Clients = clients.ToList()
            };

            return View("GetFaultsByClient", ordersClients);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllByProps(DateTime dateTime, string clientFio, string employeeFio)
        {
            var orders = await _ordersService.GetAll();
            var clients = await _clientsService.GetAll();
            var employees = await _employeesService.GetAll();

            if (dateTime > new DateTime(2016, 12, 12))
                orders = orders.Where(o => o.OrderDate.Equals(dateTime));

            if (clientFio is not null && employeeFio is not null)
            {
                var cFio = clientFio.Split(' ');
                var eFio = employeeFio.Split(' ');
                eFio[2] = eFio[2].Substring(0, eFio[2].Length - 1);

                orders = orders.Where(o =>
                    o.Client.Surname.Equals(cFio[0])
                    && o.Client.Name.Equals(cFio[1])
                    && o.Client.MiddleName.Equals(cFio[2])
                    && o.Employee.Surname.Equals(eFio[0])
                    && o.Employee.Name.Equals(eFio[1])
                    && o.Employee.MiddleName.Equals(eFio[2]));
            }
            else if (clientFio is not null && employeeFio is null)
            {
                var cFio = clientFio.Split(' ');

                orders = orders.Where(o =>
                    o.Client.Surname.Equals(cFio[0])
                    && o.Client.Name.Equals(cFio[1])
                    && o.Client.MiddleName.Equals(cFio[2]));
            }
            else if (clientFio is null && employeeFio is not null)
            {
                var eFio = employeeFio.Split(' ');
                eFio[2] = eFio[2].Substring(0, eFio[2].Length - 1);

                orders = orders.Where(o =>
                    o.Employee.Surname.Equals(eFio[0])
                    && o.Employee.Name.Equals(eFio[1])
                    && o.Employee.MiddleName.Equals(eFio[2]));
            }

            OrdersClientsEmployees ordersClients = new OrdersClientsEmployees
            {
                Orders = orders.ToList(),
                Clients = clients.ToList(),
                Employees = employees.ToList()
            };

            return View("GetAll", ordersClients);
        }
    }
}
