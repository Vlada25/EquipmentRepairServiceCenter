using EquipmentRepairServiceCenter.ASP.LocalDto;
using EquipmentRepairServiceCenter.Domain;
using EquipmentRepairServiceCenter.Domain.Extensions;
using EquipmentRepairServiceCenter.Domain.Models.Enums;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService _ordersService;
        private readonly IClientsService _clientsService;
        private readonly IEmployeesService _employeesService;
        private readonly HttpContext _httpContext;

        public OrdersController(IOrdersService ordersService,
            IClientsService clientsService,
            IEmployeesService employeesService,
            IHttpContextAccessor httpContextAccessor)
        {
            _ordersService = ordersService;
            _clientsService = clientsService;
            _employeesService = employeesService;
            _httpContext = httpContextAccessor.HttpContext;
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
            var orders = await _ordersService.GetAll();
            var clients = await _clientsService.GetAll();

            if (clientFio == null)
            {
                return View("GetFaultsByClient", new OrdersClientsEmployees
                {
                    Orders= orders.ToList(),
                    Clients= clients.ToList()
                });
            }

            var fio = clientFio.Split(' ');

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

            if (clientFio != "Client" && employeeFio != "Employee")
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
            else if (clientFio != "Client" && employeeFio == "Employee")
            {
                var cFio = clientFio.Split(' ');

                orders = orders.Where(o =>
                    o.Client.Surname.Equals(cFio[0])
                    && o.Client.Name.Equals(cFio[1])
                    && o.Client.MiddleName.Equals(cFio[2]));
            }
            else if (clientFio == "Client" && employeeFio != "Employee")
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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var employees = await _employeesService.GetAll();
            var eqTypes = new List<string>();
            var faultNames = new List<string>();

            foreach (int i in Enum.GetValues(typeof(EquipmentType)))
                eqTypes.Add(EnumExtensions.GetDisplayName((EquipmentType)Enum.GetValues(typeof(EquipmentType)).GetValue(i)));

            foreach (var val in DbInitializer.FaultsRepairingMethods.Values)
            {

            }

            OrderCreatedForView orderCreated = new OrderCreatedForView
            {
                Employees = employees.ToList(),
                EquipmentTypes = eqTypes,
                Manufacturers = DbInitializer.Manufacturers.ToList(),
                 
            };

            return View(orderCreated);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreatedForView orderCreated)
        {
            var userName = _httpContext.User.Claims
                .Where(claim => claim.Type.Equals(ClaimTypes.Name))
                .Select(claim => claim.Value).SingleOrDefault();

            return View();
        }
    }
}
