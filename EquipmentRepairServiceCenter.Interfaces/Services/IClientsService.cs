using EquipmentRepairServiceCenter.Domain.Models.People;
using EquipmentRepairServiceCenter.Domain.Models.User;
using EquipmentRepairServiceCenter.DTO.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.Interfaces.Services
{
    public interface IClientsService
    {
        Task<IEnumerable<Client>> GetAll();
        Task<Client> GetById(Guid id);
        Task<Client> Create(ClientForCreationDto entityForCreation);
        Task CreateByUsers();
        Task<bool> Delete(Guid id);
        Task<bool> Update(ClientForUpdateDto entityForUpdate);
    }
}
