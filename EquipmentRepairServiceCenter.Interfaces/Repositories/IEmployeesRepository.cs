using EquipmentRepairServiceCenter.Domain.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.Interfaces.Repositories
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<Employee>> GetAll(bool trackChanges);
        Task<Employee> GetById(Guid id, bool trackChanges);
        Task Create(Employee entity);
        Task Create(IEnumerable<Employee> entities);
        Task Delete(Employee entity);
        Task Update(Employee entity);
    }
}
