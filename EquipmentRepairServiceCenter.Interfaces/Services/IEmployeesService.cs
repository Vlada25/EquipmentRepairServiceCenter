using EquipmentRepairServiceCenter.Domain.Models.People;
using EquipmentRepairServiceCenter.DTO.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.Interfaces.Services
{
    public interface IEmployeesService
    {
        Task<IEnumerable<EmployeeDto>> GetAll();
        Task<EmployeeDto> GetById(Guid id);
        Task<EmployeeDto> Create(EmployeeForCreationDto entityForCreation);
        Task<bool> Delete(Guid id);
        Task<bool> Update(EmployeeForUpdateDto entityForUpdate);
    }
}
