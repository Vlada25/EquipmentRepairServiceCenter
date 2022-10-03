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
        void Delete(Fault entity);
        void Update(Fault entity);
    }
}
