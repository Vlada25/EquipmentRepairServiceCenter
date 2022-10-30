using EquipmentRepairServiceCenter.Domain.Models.User;

namespace EquipmentRepairServiceCenter.Interfaces
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(LoginUser loginUser);
        Task<string> CreateToken();
    }
}
