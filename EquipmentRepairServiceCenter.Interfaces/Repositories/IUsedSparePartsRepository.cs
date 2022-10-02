using EquipmentRepairServiceCenter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.Interfaces.Repositories
{
    public interface IUsedSparePartsRepository
    {
        Task<IEnumerable<UsedSparePart>> GetAll(bool trackChanges);
        Task<UsedSparePart> GetById(Guid id, bool trackChanges);
        Task Create(UsedSparePart entity);
        Task Create(IEnumerable<UsedSparePart> entities);
        Task Delete(UsedSparePart entity);
        Task Update(UsedSparePart entity);
    }
}
