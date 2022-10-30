using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesService _employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
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
    }
}
