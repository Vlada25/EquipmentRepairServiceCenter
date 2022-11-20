using EquipmentRepairServiceCenter.Database.Repositories.Base;
using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace EquipmentRepairServiceCenter.Database.Repositories
{
    public class UsedSparePartsRepository : RepositoryBase<UsedSparePart>, IUsedSparePartsRepository
    {
        public UsedSparePartsRepository(AppDbContext dbContext, IMemoryCache memoryCache)
            : base(dbContext, memoryCache) { }

        public async Task Create(UsedSparePart entity) => await CreateEntity(entity);

        public async Task<IEnumerable<UsedSparePart>> GetAll(bool trackChanges) =>
            await GetAllEntities(trackChanges).Include(u => u.SparePart).Include(u => u.Fault).ToListAsync();

        public async Task<UsedSparePart> GetById(Guid id, bool trackChanges) =>
            await GetByCondition(e => e.Id.Equals(id), trackChanges)
                .Include(u => u.SparePart).Include(u => u.Fault).SingleOrDefaultAsync();

        public void Delete(UsedSparePart entity) => DeleteEntity(entity);

        public void Update(UsedSparePart entity) =>
            UpdateEntity(entity);

        public async Task<IEnumerable<UsedSparePart>> Get(int rowsCount, string cacheKey)
        {
            if (!memoryCache.TryGetValue(cacheKey, out IEnumerable<UsedSparePart> entities))
            {
                entities = await dbContext.UsedSpareParts.Take(rowsCount).Include(u => u.SparePart).Include(u => u.Fault).ToListAsync();
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
