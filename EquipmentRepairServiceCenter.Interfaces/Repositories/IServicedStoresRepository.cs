using EquipmentRepairServiceCenter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.Interfaces.Repositories
{
    public interface IServicedStoresRepository
    {
        Task<IEnumerable<ServicedStore>> GetAll(bool trackChanges);
        Task<ServicedStore> GetById(Guid id, bool trackChanges);
        Task Create(ServicedStore entity);
        void Delete(ServicedStore entity);
        void Update(ServicedStore entity);
    }
}
