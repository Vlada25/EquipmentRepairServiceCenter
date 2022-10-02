using EquipmentRepairServiceCenter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.Interfaces.Repositories
{
    public interface IFaultsRepository
    {
        Task<IEnumerable<Fault>> GetAll(bool trackChanges);
        Task<Fault> GetById(Guid id, bool trackChanges);
        Task Create(Fault entity);
        Task Create(IEnumerable<Fault> entities);
        Task Delete(Fault entity);
        Task Update(Fault entity);
    }
}
