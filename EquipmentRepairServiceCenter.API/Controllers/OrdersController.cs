using EquipmentRepairServiceCenter.ASP.ViewModels;
using EquipmentRepairServiceCenter.Domain;
using EquipmentRepairServiceCenter.Domain.Extensions;
using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.Domain.Models.Enums;
using EquipmentRepairServiceCenter.Domain.Models.Users;
using EquipmentRepairServiceCenter.DTO.Fault;
using EquipmentRepairServiceCenter.DTO.Order;
using EquipmentRepairServiceCenter.DTO.RepairingModel;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;
        private readonly IClientsService _clientsService;
        private readonly IEmployeesService _employeesService;
        private readonly IServicedStoresService _servicedStoresService;
        private readonly IFaultsService _faultsService;
        private readonly IRepairingModelsService _repairingModelsService;
        private readonly UserManager<User> _userManager;
        private readonly HttpContext _httpContext;

        private static int _rowsCount = 0;
        private static int _cacheNumber = 0;
        private static bool isDateAscending = true;
        private static bool isSerialNumberAscending = true;
        private static bool isClientAscending = true;
        private static bool isFaultAscending = true;
        private static bool isServicedStoreAscending = true;
        private static bool isEmployeeAscending = true;
        private static bool isPriceAscending = true;
        private static bool isGuaranteeAscending = true;

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
            _rowsCount = 20;

            return Ok(await GetAllViewModel());
        }

        [HttpGet]
        public async Task<IActionResult> GetMore()
        {
            _rowsCount += 20;

            return Ok(await GetAllViewModel());
        }

        [HttpGet]
        public async Task<IActionResult> Get(int sortedFieldNumber)
        {
            var orders = await _ordersService.Get(_rowsCount, $"Orders{_rowsCount}-{_cacheNumber}");

            switch (sortedFieldNumber)
            {
                case 1:
                    if (isDateAscending)
                    {
                        isDateAscending = !isDateAscending;
                        return Ok(await GetAllViewModel(orders.OrderBy(c => c.OrderDate).ToList()));
                    }
                    else
                    {
                        isDateAscending = !isDateAscending;
                        return Ok(await GetAllViewModel(orders.OrderByDescending(c => c.OrderDate).ToList()));
                    }
                case 2:
                    if (isSerialNumberAscending)
                    {
                        isSerialNumberAscending = !isSerialNumberAscending;
                        return Ok(await GetAllViewModel(orders.OrderBy(c => c.EquipmentSerialNumber).ToList()));
                    }
                    else
                    {
                        isSerialNumberAscending = !isSerialNumberAscending;
                        return Ok(await GetAllViewModel(orders.OrderByDescending(c => c.EquipmentSerialNumber).ToList()));
                    }
                case 3:
                    if (isClientAscending)
                    {
                        isClientAscending = !isClientAscending;
                        return Ok(await GetAllViewModel(orders.OrderBy(c => $"{c.Client.Surname} {c.Client.Name} {c.Client.MiddleName}").ToList()));
                    }
                    else
                    {
                        isClientAscending = !isClientAscending;
                        return Ok(await GetAllViewModel(orders.OrderByDescending(c => $"{c.Client.Surname} {c.Client.Name} {c.Client.MiddleName}").ToList()));
                    }
                case 4:
                    if (isFaultAscending)
                    {
                        isFaultAscending = !isFaultAscending;
                        return Ok(await GetAllViewModel(orders.OrderBy(c => $"{c.Fault.Name} {c.Fault.RepairingModel.Name}").ToList()));
                    }
                    else
                    {
                        isFaultAscending = !isFaultAscending;
                        return Ok(await GetAllViewModel(orders.OrderByDescending(c => $"{c.Fault.Name} {c.Fault.RepairingModel.Name}").ToList()));
                    }
                case 5:
                    if (isServicedStoreAscending)
                    {
                        isServicedStoreAscending = !isServicedStoreAscending;
                        return Ok(await GetAllViewModel(orders.OrderBy(c => c.ServicedStore.Name).ToList()));
                    }
                    else
                    {
                        isServicedStoreAscending = !isServicedStoreAscending;
                        return Ok(await GetAllViewModel(orders.OrderByDescending(c => c.ServicedStore.Name).ToList()));
                    }
                case 6:
                    if (isEmployeeAscending)
                    {
                        isEmployeeAscending = !isEmployeeAscending;
                        return Ok(await GetAllViewModel(orders.OrderBy(c => $"{c.Employee.Surname} {c.Employee.Name} {c.Employee.MiddleName}").ToList()));
                    }
                    else
                    {
                        isEmployeeAscending = !isEmployeeAscending;
                        return Ok(await GetAllViewModel(orders.OrderByDescending(c => $"{c.Employee.Surname} {c.Employee.Name} {c.Employee.MiddleName}").ToList()));
                    }
                case 7:
                    if (isPriceAscending)
                    {
                        isPriceAscending = !isPriceAscending;
                        return Ok(await GetAllViewModel(orders.OrderBy(c => c.Price).ToList()));
                    }
                    else
                    {
                        isPriceAscending = !isPriceAscending;
                        return Ok(await GetAllViewModel(orders.OrderByDescending(c => c.Price).ToList()));
                    }
                case 8:
                    if (isGuaranteeAscending)
                    {
                        isGuaranteeAscending = !isGuaranteeAscending;
                        return Ok(await GetAllViewModel(orders.OrderBy(c => c.GuaranteePeriodInMonth).ToList()));
                    }
                    else
                    {
                        isGuaranteeAscending = !isGuaranteeAscending;
                        return Ok(await GetAllViewModel(orders.OrderByDescending(c => c.GuaranteePeriodInMonth).ToList()));
                    }
                default:
                    return Ok(orders);
            }
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

            return Ok(orders);
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

            return Ok(orders.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByProps(DateTime o_dateTime, string o_clientFio, string o_employeeFio)
        {
            var orders = await _ordersService.GetAll();
            var clients = await _clientsService.GetAll();
            var employees = await _employeesService.GetAll();

            if (o_dateTime > new DateTime(2016, 12, 12))
                orders = orders.Where(o => o.OrderDate.Equals(o_dateTime));

            if (o_clientFio != "Client" && o_employeeFio != "Employee")
            {
                var cFio = o_clientFio.Split(' ');
                var eFio = o_employeeFio.Split(' ');
                eFio[2] = eFio[2].Substring(0, eFio[2].Length - 1);

                orders = orders.Where(o =>
                    o.Client.Surname.Equals(cFio[0])
                    && o.Client.Name.Equals(cFio[1])
                    && o.Client.MiddleName.Equals(cFio[2])
                    && o.Employee.Surname.Equals(eFio[0])
                    && o.Employee.Name.Equals(eFio[1])
                    && o.Employee.MiddleName.Equals(eFio[2]));
            }
            else if (o_clientFio != "Client" && o_employeeFio == "Employee")
            {
                var cFio = o_clientFio.Split(' ');

                orders = orders.Where(o =>
                    o.Client.Surname.Equals(cFio[0])
                    && o.Client.Name.Equals(cFio[1])
                    && o.Client.MiddleName.Equals(cFio[2]));
            }
            else if (o_clientFio == "Client" && o_employeeFio != "Employee")
            {
                var eFio = o_employeeFio.Split(' ');
                eFio[2] = eFio[2].Substring(0, eFio[2].Length - 1);

                orders = orders.Where(o =>
                    o.Employee.Surname.Equals(eFio[0])
                    && o.Employee.Name.Equals(eFio[1])
                    && o.Employee.MiddleName.Equals(eFio[2]));
            }

            OrdersClientsEmployeesViewModel ordersClients = new OrdersClientsEmployeesViewModel
            {
                Orders = orders.ToList(),
                Clients = clients.ToList(),
                Employees = employees.ToList()
            };

            return Ok(ordersClients);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreatedViewModel orderCreated)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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

            _cacheNumber++;

            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> Update(OrderUpdatedViewModel orderUpdated)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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

            _cacheNumber++;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool isExists = await _faultsService.Delete(id);

            if (!isExists)
            {
                return NotFound();
            }

            _cacheNumber++;

            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateForAdmin(OrderAdminCreatedViewModel orderCreated)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string[] servicedStoreInfo = orderCreated.ServicedStore.Split("; ");
            var servicedStore = await _servicedStoresService.GetByNameAndAddress(
                servicedStoreInfo[0], servicedStoreInfo[1]);

            string[] employeeInfo = orderCreated.Employee.Split(", ");
            string[] employeeFullName = employeeInfo[0].Split(' ');
            var employee = await _employeesService.GetByFullNameAndPosition(
                employeeFullName[0], employeeFullName[1], employeeFullName[2], employeeInfo[1]);

            string[] clientInfo = orderCreated.Client.Split(": ");
            var client = await _clientsService.GetByUserId(Guid.Parse(clientInfo[1]));

            string[] faultInfo = orderCreated.Client.Split(": ");
            var fault = await _faultsService.GetById(Guid.Parse(faultInfo[1]));

            await _ordersService.Create(new OrderForCreationDto
            {
                OrderDate = DateTime.Now,
                EquipmentSerialNumber = orderCreated.EquipmentSerialNumber,
                EquipmentReturnDate = orderCreated.EquipmentReturnDate,
                ClientId = client.Id,
                FaultId = fault.Id,
                ServicedStoreId = servicedStore.Id,
                Guarantee = orderCreated.GuaranteePeriodInMonth == 0 ? false : true,
                GuaranteePeriodInMonth = orderCreated.GuaranteePeriodInMonth,
                Price = orderCreated.Price,
                EmployeeId = employee.Id
            });

            _cacheNumber++;

            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateForAdmin(OrderAdminUpdatedViewModel orderUpdated)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = await _ordersService.GetById(orderUpdated.Id);

            await _ordersService.Update(new OrderForUpdateDto
            {
                Id = order.Id,
                Price = orderUpdated.Price,
                EquipmentReturnDate = orderUpdated.EquipmentReturnDate,
                Guarantee = orderUpdated.GuaranteePeriodInMonth == 0 ? false : true,
                GuaranteePeriodInMonth = orderUpdated.GuaranteePeriodInMonth
            });

            _cacheNumber++;

            return NoContent();
        }

        private async Task<OrdersClientsEmployeesViewModel> GetAllViewModel()
        {
            var orders = await _ordersService.Get(_rowsCount, $"Orders{_rowsCount}-{_cacheNumber}");
            var clients = await _clientsService.GetAll();
            var employees = await _employeesService.GetAll();

            return new OrdersClientsEmployeesViewModel
            {
                Orders = orders.ToList(),
                Clients = clients.ToList(),
                Employees = employees.ToList()
            };
        }

        private async Task<OrdersClientsEmployeesViewModel> GetAllViewModel(List<Order> orders)
        {
            var clients = await _clientsService.GetAll();
            var employees = await _employeesService.GetAll();

            return new OrdersClientsEmployeesViewModel
            {
                Orders = orders,
                Clients = clients.ToList(),
                Employees = employees.ToList()
            };
        }
    }
}
