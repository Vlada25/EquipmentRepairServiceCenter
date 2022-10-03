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
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(Guid id);
        Task<UserDto> GetByLoginAsync(string login);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<UserDto>> GetAllEmployeesAsync();
    }
}
