using EquipmentRepairServiceCenter.Database.Repositories.Base;
using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace EquipmentRepairServiceCenter.Database.Repositories
{
    public class ServicedStoresRepository : RepositoryBase<ServicedStore>, IServicedStoresRepository
    {
        public ServicedStoresRepository(AppDbContext dbContext, IMemoryCache memoryCache)
            : base(dbContext, memoryCache) { }

        public async Task Create(ServicedStore entity) => await CreateEntity(entity);

        public async Task<IEnumerable<ServicedStore>> GetAll(bool trackChanges) =>
            await GetAllEntities(trackChanges).ToListAsync();

        public async Task<ServicedStore> GetById(Guid id, bool trackChanges) =>
            await GetByCondition(e => e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void Delete(ServicedStore entity) => DeleteEntity(entity);

        public void Update(ServicedStore entity) =>
            UpdateEntity(entity);

        public async Task<ServicedStore> GetByNameAndAddress(string name, string address) =>
            await GetByCondition(e => e.Name.Equals(name) && e.Address.Equals(address), false).SingleOrDefaultAsync();

        public async Task<IEnumerable<ServicedStore>> Get(int rowsCount, string cacheKey)
        {
            if (!memoryCache.TryGetValue(cacheKey, out IEnumerable<ServicedStore> entities))
            {
                entities = await dbContext.ServicedStores.Take(rowsCount).ToListAsync();
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
