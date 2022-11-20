using EquipmentRepairServiceCenter.Database.Repositories.Base;
using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.Domain.Models.People;
using EquipmentRepairServiceCenter.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace EquipmentRepairServiceCenter.Database.Repositories
{
    public class ClientsRepository : RepositoryBase<Client>, IClientsRepository
    {
        public ClientsRepository(AppDbContext dbContext, IMemoryCache memoryCache)
            : base(dbContext, memoryCache) { }

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

        public async Task<IEnumerable<Client>> Get(int rowsCount, string cacheKey)
        {
            if (!memoryCache.TryGetValue(cacheKey, out IEnumerable<Client> entities))
            {
                entities = await dbContext.Set<Client>().Take(rowsCount).ToListAsync();
                if (entities != null)
                {
                    memoryCache.Set(cacheKey, entities,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(CachingTime)));
                }
            }
            return entities;
        }
    }
}
