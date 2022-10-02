using EquipmentRepairServiceCenter.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetAll(bool trackChanges);
        Task<User> GetById(Guid id, bool trackChanges);
        Task Create(User entity);
        Task Create(IEnumerable<User> entities);
        Task Delete(User entity);
        Task Update(User entity);
    }
}
