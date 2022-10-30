using EquipmentRepairServiceCenter.Domain.Models.People;

namespace EquipmentRepairServiceCenter.Interfaces.Repositories
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<Employee>> GetAll(bool trackChanges);
        Task<Employee> GetById(Guid id, bool trackChanges);
        Task<Employee> GetByUserId(Guid userId, bool trackChanges);
        Task<Employee> GetByFullNameAndPosition(string surname, string name, string middleName, int position);
        Task Create(Employee entity);
        void Delete(Employee entity);
        void Update(Employee entity);
    }
}
