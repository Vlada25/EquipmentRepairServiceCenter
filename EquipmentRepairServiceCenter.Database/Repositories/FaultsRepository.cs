using EquipmentRepairServiceCenter.Database.Repositories.Base;
using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace EquipmentRepairServiceCenter.Database.Repositories
{
    public class FaultsRepository : RepositoryBase<Fault>, IFaultsRepository
    {
        public FaultsRepository(AppDbContext dbContext, IMemoryCache memoryCache)
            : base(dbContext, memoryCache) { }

        public async Task Create(Fault entity) => await CreateEntity(entity);

        public async Task<IEnumerable<Fault>> GetAll(bool trackChanges) =>
            await GetAllEntities(trackChanges).Include(f => f.RepairingModel).ToListAsync();

        public async Task<Fault> GetById(Guid id, bool trackChanges) =>
            await GetByCondition(e => e.Id.Equals(id), trackChanges).Include(f => f.RepairingModel).SingleOrDefaultAsync();

        public void Delete(Fault entity) => DeleteEntity(entity);

        public void Update(Fault entity) =>
            UpdateEntity(entity);

        public async Task<IEnumerable<Fault>> Get(int rowsCount, string cacheKey)
        {
            if (!memoryCache.TryGetValue(cacheKey, out IEnumerable<Fault> entities))
            {
                entities = await dbContext.Faults.Take(rowsCount).Include(e => e.RepairingModel).ToListAsync();
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
