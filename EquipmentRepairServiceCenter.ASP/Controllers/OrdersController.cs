using EquipmentRepairServiceCenter.ASP.LocalDto;
using EquipmentRepairServiceCenter.Domain;
using EquipmentRepairServiceCenter.Domain.Extensions;
using EquipmentRepairServiceCenter.Domain.Models.Enums;
using EquipmentRepairServiceCenter.Domain.Models.User;
using EquipmentRepairServiceCenter.DTO.Fault;
using EquipmentRepairServiceCenter.DTO.Order;
using EquipmentRepairServiceCenter.DTO.RepairingModel;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService _ordersService;
        private readonly IClientsService _clientsService;
        private readonly IEmployeesService _employeesService;
        private readonly IServicedStoresService _servicedStoresService;
        private readonly IFaultsService _faultsService;
        private readonly IRepairingModelsService _repairingModelsService;
        private readonly UserManager<User> _userManager;
        private readonly HttpContext _httpContext;

        public OrdersController(IOrdersService ordersService,
            IClientsService clientsService,
            IEmployeesService employeesService,
            IHttpContextAccessor httpContextAccessor,
            IServicedStoresService servicedStoresService,
            IFaultsService faultsService,
            UserManager<User> userManager,
            IRepairingModelsService repairingModelsService)
        {
            _ordersService = ordersService;
            _clientsService = clientsService;
            _employeesService = employeesService;
            _httpContext = httpContextAccessor.HttpContext;
            _servicedStoresService = servicedStoresService;
            _faultsService = faultsService;
            _userManager = userManager;
            _repairingModelsService = repairingModelsService;
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
        public async Task<IActionResult> GetForEmployee()
        {
            var userName = _httpContext.User.Claims
                .Where(claim => claim.Type.Equals(ClaimTypes.Name))
                .Select(claim => claim.Value).SingleOrDefault();

            var user = await _userManager.FindByNameAsync(userName);
            var userRoles = await _userManager.GetRolesAsync(user);

            var employee = await _employeesService.GetByUserId(Guid.Parse(user.Id));

            var orders = await _ordersService.GetByEmployeeId(employee.Id);

            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> GetForEmployeeSearch(DateTime dateTime, string status)
        {
            var userName = _httpContext.User.Claims
                .Where(claim => claim.Type.Equals(ClaimTypes.Name))
                .Select(claim => claim.Value).SingleOrDefault();

            var user = await _userManager.FindByNameAsync(userName);
            var userRoles = await _userManager.GetRolesAsync(user);

            var employee = await _employeesService.GetByUserId(Guid.Parse(user.Id));

            var orders = await _ordersService.GetByEmployeeId(employee.Id);

            if (dateTime > new DateTime(2016, 12, 12))
                orders = orders.Where(o => o.OrderDate.Equals(dateTime));

            if (status != "All")
                orders = orders.Where(o => o.Price == 0);

            return View("GetForEmployee", orders.ToList());
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
                    Orders = orders.ToList(),
                    Clients = clients.ToList()
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
            var userName = _httpContext.User.Claims
                .Where(claim => claim.Type.Equals(ClaimTypes.Name))
                .Select(claim => claim.Value).SingleOrDefault();

            var user = await _userManager.FindByNameAsync(userName);
            var userRoles = await _userManager.GetRolesAsync(user);

            if (userRoles.Contains("Employee"))
            {
                return RedirectToRoute(new { controller = "Orders", action = "GetForEmployee" });
            }

            var employees = await _employeesService.GetAll();
            var eqTypes = new List<string>();
            var servicedStores = await _servicedStoresService.GetAll();

            foreach (int i in Enum.GetValues(typeof(EquipmentType)))
                eqTypes.Add(EnumExtensions.GetDisplayName((EquipmentType)Enum.GetValues(typeof(EquipmentType)).GetValue(i)));

            OrderCreatedForView orderCreated = new OrderCreatedForView
            {
                Employees = employees.ToList(),
                EquipmentTypes = eqTypes,
                Manufacturers = DbInitializer.Manufacturers.ToList(),
                ServicedStores = servicedStores.ToList(),
            };

            return View(orderCreated);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreatedForView orderCreated)
        {
            var userName = _httpContext.User.Claims
                .Where(claim => claim.Type.Equals(ClaimTypes.Name))
                .Select(claim => claim.Value).SingleOrDefault();

            var user = await _userManager.FindByNameAsync(userName);
            var client = await _clientsService.GetByUserId(Guid.Parse(user.Id));

            string[] servicedStoreInfo = orderCreated.ServicedStore.Split("; ");
            var servicedStore = await _servicedStoresService.GetByNameAndAddress(
                servicedStoreInfo[0], servicedStoreInfo[1]);

            string[] employeeInfo = orderCreated.EmployeeInfo.Split(", ");
            string[] employeeFullName = employeeInfo[0].Split(' ');
            var employee = await _employeesService.GetByFullNameAndPosition(
                employeeFullName[0], employeeFullName[1], employeeFullName[2], employeeInfo[1]);

            var repairingModel = await _repairingModelsService.Create(new RepairingModelForCreationDto
            {
                Name = orderCreated.RepairingModelType + " " + orderCreated.RepairingModelManufacturer,
                Type = orderCreated.RepairingModelType,
                Manufacturer = orderCreated.RepairingModelManufacturer,
                Specifications = orderCreated.RepairingModelSpecifications,
                ParticularQualities = orderCreated.RepairingModelParticularQualities,
                PhotoUrl = orderCreated.RepairingModelPhotoUrl
            });

            var fault = await _faultsService.Create(new FaultForCreationDto
            {
                Name = orderCreated.FaultName,
                RepairingModelId = repairingModel.Id,
                RepairingMethods = "-",
                Price = 0
            });

            var order = new OrderForCreationDto
            {
                OrderDate = DateTime.Now,
                EquipmentSerialNumber = new Random((int)DateTime.Now.Ticks).Next(1000000, 10000000),
                EquipmentReturnDate = new DateTime(),
                ClientId = client.Id,
                FaultId = fault.Id,
                ServicedStoreId = servicedStore.Id,
                Guarantee = false,
                GuaranteePeriodInMonth = 0,
                Price = 0,
                EmployeeId = employee.Id
            };

            await _ordersService.Create(order);

            return View("InfoPage");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid orderId)
        {
            var order = await _ordersService.GetById(orderId);

            return View(new OrderUpdatedForView
            {
                Id = orderId,
                RepairingModelName = order.Fault.RepairingModel.Name,
                RepairingModelSpecifications = order.Fault.RepairingModel.Specifications,
                RepairingModelParticularQualities = order.Fault.RepairingModel.ParticularQualities,
                FaultName = order.Fault.Name
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(OrderUpdatedForView orderUpdated)
        {
            var order = await _ordersService.GetById(orderUpdated.Id);

            await _faultsService.Update(new FaultForUpdateDto
            {
                Id = order.FaultId,
                RepairingMethods = orderUpdated.RepairingMethods,
                Price = orderUpdated.Price
            });

            await _ordersService.Update(new OrderForUpdateDto
            {
                Id = order.Id,
                Price = orderUpdated.Price,
                EquipmentReturnDate = order.OrderDate.AddDays(orderUpdated.RepairingTimeInDays),
                Guarantee = orderUpdated.GuaranteeInMonth == 0 ? false : true,
                GuaranteePeriodInMonth = orderUpdated.GuaranteeInMonth
            });

            return View("InfoPage");
        }
    }
}
