using EquipmentRepairServiceCenter.ASP.ViewModels;
using EquipmentRepairServiceCenter.Domain.Extensions;
using EquipmentRepairServiceCenter.Domain.Models.Enums;
using EquipmentRepairServiceCenter.DTO.Employee;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesService _employeesService;
        private readonly IServicedStoresService _servicedStoresService;

        private static int _rowsCount = 0;
        private static int _cacheNumber = 0;
        private static bool isSurnameAscending = true;
        private static bool isNameAscending = true;

        public EmployeesController(IEmployeesService employeesService,
            IServicedStoresService servicedStoresService)
        {
            _employeesService = employeesService;
            _servicedStoresService = servicedStoresService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _rowsCount = 20;
            ViewData["e_surname"] = Request.Cookies["e_surname"];
            ViewData["e_name"] = Request.Cookies["e_name"];
            ViewData["e_middleName"] = Request.Cookies["e_middleName"];
            ViewData["e_workExperience"] = Request.Cookies["e_workExperience"];

            var employees = await _employeesService.Get(_rowsCount, $"Employees{_rowsCount}-{_cacheNumber}");

            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> GetMore()
        {
            _rowsCount += 20;
            ViewData["e_surname"] = Request.Cookies["e_surname"];
            ViewData["e_name"] = Request.Cookies["e_name"];
            ViewData["e_middleName"] = Request.Cookies["e_middleName"];
            ViewData["e_workExperience"] = Request.Cookies["e_workExperience"];

            var employees = await _employeesService.Get(_rowsCount, $"Employees{_rowsCount}-{_cacheNumber}");

            return View("GetAll", employees);
        }

        [HttpGet]
        public async Task<IActionResult> ClearCookie()
        {
            _rowsCount = 20;

            Response.Cookies.Delete("e_surname");
            Response.Cookies.Delete("e_name");
            Response.Cookies.Delete("e_middleName");
            Response.Cookies.Delete("e_workExperience");

            var employees = await _employeesService.Get(_rowsCount, $"Employees{_rowsCount}-{_cacheNumber}");

            return View("GetAll", employees);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int sortedFieldNumber)
        {
            var employees = await _employeesService.Get(_rowsCount, $"Employees{_rowsCount}-{_cacheNumber}");

            switch (sortedFieldNumber)
            {
                case 1:
                    if (isNameAscending)
                    {
                        isNameAscending = !isNameAscending;
                        return View("GetAll", employees.OrderBy(c => c.Name).ToList());
                    }
                    else
                    {
                        isNameAscending = !isNameAscending;
                        return View("GetAll", employees.OrderByDescending(c => c.Name).ToList());
                    }
                case 2:
                    if (isSurnameAscending)
                    {
                        isSurnameAscending = !isSurnameAscending;
                        return View("GetAll", employees.OrderBy(c => c.Surname).ToList());
                    }
                    else
                    {
                        isSurnameAscending = !isSurnameAscending;
                        return View("GetAll", employees.OrderByDescending(c => c.Surname).ToList());
                    }
                default:
                    return View("GetAll", employees);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByProps(string e_surname, string e_name, string e_middleName, int e_workExperience)
        {
            var employees = await _employeesService.GetAll();

            if (e_surname is not null)
                Response.Cookies.Append("e_surname", e_surname);
            if (e_name is not null)
                Response.Cookies.Append("e_name", e_name);
            if (e_middleName is not null)
                Response.Cookies.Append("e_middleName", e_middleName);
            if (e_workExperience != 0)
                Response.Cookies.Append("e_workExperience", e_workExperience.ToString());

            ViewData["e_surname"] = Request.Cookies["e_surname"];
            ViewData["e_name"] = Request.Cookies["e_name"];
            ViewData["e_middleName"] = Request.Cookies["e_middleName"];
            ViewData["e_workExperience"] = Request.Cookies["e_workExperience"];

            if (e_surname is null) e_surname = Guid.NewGuid().ToString();
            if (e_name is null) e_name = Guid.NewGuid().ToString();
            if (e_middleName is null) e_middleName = Guid.NewGuid().ToString();

            return View("GetAll", employees.Where(e =>
                e.Surname.Contains(e_surname, StringComparison.OrdinalIgnoreCase) ||
                e.Name.Contains(e_name, StringComparison.OrdinalIgnoreCase) ||
                e.MiddleName.Contains(e_middleName, StringComparison.OrdinalIgnoreCase) ||
                e.WorkExperienceInYears == e_workExperience).ToList());
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var employee = await _employeesService.GetById(id);
            var positions = new List<string>();
            var servicedStores = await _servicedStoresService.GetAll();
            var store = await _servicedStoresService.GetById(employee.ServicedStoreId);

            foreach (int i in Enum.GetValues(typeof(Position)))
                positions.Add(EnumExtensions.GetDisplayName((Position)Enum.GetValues(typeof(Position)).GetValue(i)));

            return View(new EmployeeUpdatedViewModel
            {
                Id = id,
                Surname = employee.Surname,
                Name = employee.Name,
                MiddleName = employee.MiddleName,
                Position = employee.Position,
                WorkExperienceInYears = employee.WorkExperienceInYears,
                ServicedStore = store.Name + "; " + store.Address,
                ServicedStores = servicedStores.ToList(),
                Positions = positions
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(EmployeeUpdatedViewModel employeeUpdated)
        {
            if (!ModelState.IsValid)
            {
                var employee = await _employeesService.GetById(employeeUpdated.Id);
                var positions = new List<string>();
                var servicedStores = await _servicedStoresService.GetAll();
                var store = await _servicedStoresService.GetById(employee.ServicedStoreId);

                foreach (int i in Enum.GetValues(typeof(Position)))
                    positions.Add(EnumExtensions.GetDisplayName((Position)Enum.GetValues(typeof(Position)).GetValue(i)));

                return View(new EmployeeUpdatedViewModel
                {
                    Id = employeeUpdated.Id,
                    Surname = employee.Surname,
                    Name = employee.Name,
                    MiddleName = employee.MiddleName,
                    Position = employee.Position,
                    WorkExperienceInYears = employee.WorkExperienceInYears,
                    ServicedStore = store.Name + "; " + store.Address,
                    ServicedStores = servicedStores.ToList(),
                    Positions = positions
                });
            }

            string[] servicedStoreInfo = employeeUpdated.ServicedStore.Split("; ");
            var servicedStore = await _servicedStoresService.GetByNameAndAddress(
                servicedStoreInfo[0], servicedStoreInfo[1]);

            bool isExists = await _employeesService.Update(new EmployeeForUpdateDto
            {
                Id = employeeUpdated.Id,
                Surname = employeeUpdated.Surname,
                Name = employeeUpdated.Name,
                MiddleName = employeeUpdated.MiddleName,
                Position = employeeUpdated.Position,
                WorkExperienceInYears = employeeUpdated.WorkExperienceInYears,
                ServicedStoreId = servicedStore.Id
            });

            if (!isExists)
            {
                return View();
            }

            _cacheNumber++;

            return View("InfoPage");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _employeesService.GetById(id);
            ViewData["Message"] = $"{entity.Surname} {entity.Name} {entity.MiddleName}";
            Response.Cookies.Append("employee_id", id.ToString());

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete()
        {
            Request.Cookies.TryGetValue("employee_id", out string id);

            bool isExists = await _employeesService.Delete(Guid.Parse(id));

            if (!isExists)
            {
                return View();
            }

            _cacheNumber++;

            return View("InfoPage");
        }
    }
}
