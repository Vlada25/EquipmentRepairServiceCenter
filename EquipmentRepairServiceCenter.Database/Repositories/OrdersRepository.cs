using EquipmentRepairServiceCenter.Database.Repositories.Base;
using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace EquipmentRepairServiceCenter.Database.Repositories
{
    public class OrdersRepository : RepositoryBase<Order>, IOrdersRepository
    {
        public OrdersRepository(AppDbContext dbContext, IMemoryCache memoryCache)
            : base(dbContext, memoryCache) { }

        public async Task Create(Order entity) => await CreateEntity(entity);

        public async Task<IEnumerable<Order>> GetAll(bool trackChanges) =>
            await GetAllEntities(trackChanges)
                .Include(e => e.Fault).ThenInclude(e => e.RepairingModel)
                .Include(e => e.Client).Include(e => e.ServicedStore)
                .Include(e => e.Employee).ToListAsync();

        public async Task<Order> GetById(Guid id, bool trackChanges) =>
            await GetByCondition(e => e.Id.Equals(id), trackChanges)
                .Include(e => e.Fault).ThenInclude(e => e.RepairingModel)
                .Include(e => e.Client).Include(e => e.ServicedStore)
                .Include(e => e.Employee).SingleOrDefaultAsync();

        public void Delete(Order entity) => DeleteEntity(entity);

        public void Update(Order entity) =>
            UpdateEntity(entity);

        public async Task<IEnumerable<Order>> GetByEmployeeId(Guid employeeId) =>
            await GetByCondition(e => e.EmployeeId.Equals(employeeId), false)
                .Include(e => e.Fault).ThenInclude(e => e.RepairingModel)
                .Include(e => e.Client).Include(e => e.ServicedStore)
                .Include(e => e.Employee).ToListAsync();

        public async Task<IEnumerable<Order>> Get(int rowsCount, string cacheKey)
        {
            if (!memoryCache.TryGetValue(cacheKey, out IEnumerable<Order> entities))
            {
                entities = await dbContext.Orders.Take(rowsCount)
                    .Include(e => e.Fault).ThenInclude(e => e.RepairingModel)
                    .Include(e => e.Client).Include(e => e.ServicedStore)
                    .Include(e => e.Employee).ToListAsync();

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
