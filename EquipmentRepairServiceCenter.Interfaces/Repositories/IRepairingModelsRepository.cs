using EquipmentRepairServiceCenter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.Interfaces.Repositories
{
    public interface IRepairingModelsRepository
    {
        Task<IEnumerable<RepairingModel>> GetAll(bool trackChanges);
        Task<RepairingModel> GetById(Guid id, bool trackChanges);
        Task Create(RepairingModel entity);
        void Delete(RepairingModel entity);
        void Update(RepairingModel entity);
    }
}
