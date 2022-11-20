using EquipmentRepairServiceCenter.DTO.User;

namespace EquipmentRepairServiceCenter.Interfaces.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<IEnumerable<UserDto>> Get(int rowsCount, string cacheKey);
        Task<UserDto> GetByIdAsync(Guid id);
        Task<UserDto> GetByLoginAsync(string login);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<UserDto>> GetAllEmployeesAsync();
    }
}
