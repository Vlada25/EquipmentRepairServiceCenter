using EquipmentRepairServiceCenter.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.Interfaces.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> GetById(Guid id);
        Task<bool> Delete(Guid id);
    }
}
