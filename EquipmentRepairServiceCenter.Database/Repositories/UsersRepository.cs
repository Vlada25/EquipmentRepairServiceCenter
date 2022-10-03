using EquipmentRepairServiceCenter.Database.Repositories.Base;
using EquipmentRepairServiceCenter.Domain.Models.User;
using EquipmentRepairServiceCenter.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.Database.Repositories
{
    public class UsersRepository : RepositoryBase<User>, IUsersRepository
    {
        public UsersRepository(AppDbContext dbContext)
            : base(dbContext) { }

        public async Task Create(User entity) => await CreateEntity(entity);

        public async Task<IEnumerable<User>> GetAll(bool trackChanges) =>
            await GetAllEntities(trackChanges).ToListAsync();

        public async Task<User> GetById(Guid id, bool trackChanges) =>
            await GetByCondition(e => e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void Delete(User entity) => DeleteEntity(entity);

        public void Update(User entity) =>
            UpdateEntity(entity);
    }
}
