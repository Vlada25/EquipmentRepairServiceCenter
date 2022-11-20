using EquipmentRepairServiceCenter.Database.Repositories.Base;
using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace EquipmentRepairServiceCenter.Database.Repositories
{
    public class SparePartsRepository : RepositoryBase<SparePart>, ISparePartsRepository
    {
        public SparePartsRepository(AppDbContext dbContext, IMemoryCache memoryCache)
            : base(dbContext, memoryCache) { }

        public async Task Create(SparePart entity) => await CreateEntity(entity);

        public async Task<IEnumerable<SparePart>> GetAll(bool trackChanges) =>
            await GetAllEntities(trackChanges).ToListAsync();

        public async Task<SparePart> GetById(Guid id, bool trackChanges) =>
            await GetByCondition(e => e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void Delete(SparePart entity) => DeleteEntity(entity);

        public void Update(SparePart entity) =>
            UpdateEntity(entity);

        public async Task<IEnumerable<SparePart>> Get(int rowsCount, string cacheKey)
        {
            if (!memoryCache.TryGetValue(cacheKey, out IEnumerable<SparePart> entities))
            {
                entities = await dbContext.SpareParts.Take(rowsCount).ToListAsync();
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
