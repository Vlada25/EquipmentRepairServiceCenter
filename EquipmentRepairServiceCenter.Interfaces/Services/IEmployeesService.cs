using EquipmentRepairServiceCenter.Domain.Models.People;
using EquipmentRepairServiceCenter.DTO.Employee;

namespace EquipmentRepairServiceCenter.Interfaces.Services
{
    public interface IEmployeesService
    {
        Task<IEnumerable<EmployeeDto>> GetAll();
        Task<IEnumerable<EmployeeDto>> Get(int rowsCount, string cacheKey);
        Task<EmployeeDto> GetById(Guid id);
        Task<Employee> GetByUserId(Guid userId);
        Task<Employee> GetByFullNameAndPosition(string surname, string name, string middleName, string position);
        Task<EmployeeDto> Create(EmployeeForCreationDto entityForCreation);
        Task CreateByUsers();
        Task<bool> Delete(Guid id);
        Task<bool> Update(EmployeeForUpdateDto entityForUpdate);
    }
}
