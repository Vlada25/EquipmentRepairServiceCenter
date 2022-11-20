using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.Domain.Models.People;

namespace EquipmentRepairServiceCenter.Interfaces.Repositories
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<Employee>> GetAll(bool trackChanges);
        Task<IEnumerable<Employee>> Get(int rowsCount, string cacheKey);
        Task<Employee> GetById(Guid id, bool trackChanges);
        Task<Employee> GetByUserId(Guid userId, bool trackChanges);
        Task<Employee> GetByFullNameAndPosition(string surname, string name, string middleName, int position);
        Task Create(Employee entity);
        void Delete(Employee entity);
        void Update(Employee entity);
    }
}
