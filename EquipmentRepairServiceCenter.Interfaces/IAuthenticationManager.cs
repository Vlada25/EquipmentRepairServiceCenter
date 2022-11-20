using EquipmentRepairServiceCenter.Domain.Models.Users;

namespace EquipmentRepairServiceCenter.Interfaces
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(LoginUser loginUser);
        Task<string> CreateToken();
    }
}
