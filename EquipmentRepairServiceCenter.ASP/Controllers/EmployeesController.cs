using EquipmentRepairServiceCenter.ASP.Services;
using EquipmentRepairServiceCenter.ASP.ViewModels;
using EquipmentRepairServiceCenter.Domain.Extensions;
using EquipmentRepairServiceCenter.Domain.Models.Enums;
using EquipmentRepairServiceCenter.Domain.Models.Users;
using EquipmentRepairServiceCenter.DTO.Employee;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesService _employeesService;
        private readonly IServicedStoresService _servicedStoresService;

        public EmployeesController(IEmployeesService employeesService,
            IServicedStoresService servicedStoresService)
        {
            _employeesService = employeesService;
            _servicedStoresService = servicedStoresService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeesService.GetAll();

            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByProps(string surname, string name, string middleName, int workExperience)
        {
            var employees = await _employeesService.GetAll();

            if (surname is null) surname = Guid.NewGuid().ToString();
            if (name is null) name = Guid.NewGuid().ToString();
            if (middleName is null) middleName = Guid.NewGuid().ToString();

            return View("GetAll", employees.Where(e =>
                e.Surname.Contains(surname, StringComparison.OrdinalIgnoreCase) ||
                e.Name.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                e.MiddleName.Contains(middleName, StringComparison.OrdinalIgnoreCase) ||
                e.WorkExperienceInYears == workExperience).ToList());
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

            return View("InfoPage");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            ViewData["Message"] = id.ToString();
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

            return View("InfoPage");
        }
    }
}
