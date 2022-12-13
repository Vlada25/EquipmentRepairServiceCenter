using EquipmentRepairServiceCenter.ASP.Services;
using EquipmentRepairServiceCenter.ASP.ViewModels;
using EquipmentRepairServiceCenter.Domain.Extensions;
using EquipmentRepairServiceCenter.Domain.Models.Enums;
using EquipmentRepairServiceCenter.Domain.Models.Users;
using EquipmentRepairServiceCenter.DTO.Employee;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.API.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class EmployeesController : ControllerBase
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

            var employees = await _employeesService.Get(_rowsCount, $"Employees{_rowsCount}-{_cacheNumber}");

            return Ok(employees);
        }

        [HttpGet]
        public async Task<IActionResult> GetMore()
        {
            _rowsCount += 20;

            var employees = await _employeesService.Get(_rowsCount, $"Employees{_rowsCount}-{_cacheNumber}");

            return Ok(employees);
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
                        return Ok(employees.OrderBy(c => c.Name).ToList());
                    }
                    else
                    {
                        isNameAscending = !isNameAscending;
                        return Ok(employees.OrderByDescending(c => c.Name).ToList());
                    }
                case 2:
                    if (isSurnameAscending)
                    {
                        isSurnameAscending = !isSurnameAscending;
                        return Ok(employees.OrderBy(c => c.Surname).ToList());
                    }
                    else
                    {
                        isSurnameAscending = !isSurnameAscending;
                        return Ok(employees.OrderByDescending(c => c.Surname).ToList());
                    }
                default:
                    return Ok(employees);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByProps(string e_surname, string e_name, string e_middleName, int e_workExperience)
        {
            var employees = await _employeesService.GetAll();

            e_surname ??= Guid.NewGuid().ToString();
            e_name ??= Guid.NewGuid().ToString();
            e_middleName ??= Guid.NewGuid().ToString();

            return Ok(employees.Where(e =>
                e.Surname.Contains(e_surname, StringComparison.OrdinalIgnoreCase) ||
                e.Name.Contains(e_name, StringComparison.OrdinalIgnoreCase) ||
                e.MiddleName.Contains(e_middleName, StringComparison.OrdinalIgnoreCase) ||
                e.WorkExperienceInYears == e_workExperience).ToList());
        }

        [HttpPut]
        public async Task<IActionResult> Update(EmployeeUpdatedViewModel employeeUpdated)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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
                return NotFound();
            }

            _cacheNumber++;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool isExists = await _employeesService.Delete(id);

            if (!isExists)
            {
                return NotFound();
            }

            _cacheNumber++;

            return NoContent();
        }
    }
}
