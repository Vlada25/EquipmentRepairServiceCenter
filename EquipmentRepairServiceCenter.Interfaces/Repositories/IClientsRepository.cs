using EquipmentRepairServiceCenter.Domain.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.Interfaces.Repositories
{
    public interface IClientsRepository
    {
        Task<IEnumerable<Client>> GetAll(bool trackChanges);
        Task<Client> GetById(Guid id, bool trackChanges);
        Task Create(Client entity);
        void Delete(Client entity);
        void Update(Client entity);
    }
}
