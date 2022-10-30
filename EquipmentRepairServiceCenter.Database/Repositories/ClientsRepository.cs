using EquipmentRepairServiceCenter.Database.Repositories.Base;
using EquipmentRepairServiceCenter.Domain.Models.People;
using EquipmentRepairServiceCenter.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRepairServiceCenter.Database.Repositories
{
    public class ClientsRepository : RepositoryBase<Client>, IClientsRepository
    {
        public ClientsRepository(AppDbContext dbContext)
            : base(dbContext) { }

        public async Task Create(Client entity) => await CreateEntity(entity);

        public async Task<IEnumerable<Client>> GetAll(bool trackChanges) =>
            await GetAllEntities(trackChanges).ToListAsync();

        public async Task<Client> GetById(Guid id, bool trackChanges) =>
            await GetByCondition(e => e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void Delete(Client entity) => DeleteEntity(entity);

        public void Update(Client entity) =>
            UpdateEntity(entity);

        public async Task<Client> GetByUserId(Guid userId, bool trackChanges) =>
            await GetByCondition(e => e.UserId.Equals(userId), trackChanges).SingleOrDefaultAsync();
    }
}
