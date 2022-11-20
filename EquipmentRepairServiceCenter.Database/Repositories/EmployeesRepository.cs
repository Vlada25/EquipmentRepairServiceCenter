using EquipmentRepairServiceCenter.Database.Repositories.Base;
using EquipmentRepairServiceCenter.Domain.Models.People;
using EquipmentRepairServiceCenter.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace EquipmentRepairServiceCenter.Database.Repositories
{
    public class EmployeesRepository : RepositoryBase<Employee>, IEmployeesRepository
    {
        public EmployeesRepository(AppDbContext dbContext, IMemoryCache memoryCache)
            : base(dbContext, memoryCache) { }

        public async Task Create(Employee entity) => await CreateEntity(entity);

        public async Task<IEnumerable<Employee>> GetAll(bool trackChanges) =>
            await GetAllEntities(trackChanges).ToListAsync();

        public async Task<Employee> GetById(Guid id, bool trackChanges) =>
            await GetByCondition(e => e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void Delete(Employee entity) => DeleteEntity(entity);

        public void Update(Employee entity) =>
            UpdateEntity(entity);

        public async Task<Employee> GetByFullNameAndPosition(string surname, string name, string middleName, int position) =>
            await GetByCondition(e => e.Surname.Equals(surname) && e.Name.Equals(name) &&
                e.MiddleName.Equals(middleName) && (int)e.Position == position, false).FirstOrDefaultAsync();

        public async Task<Employee> GetByUserId(Guid userId, bool trackChanges) =>
            await GetByCondition(e => e.UserId.Equals(userId), trackChanges).FirstOrDefaultAsync();

        public async Task<IEnumerable<Employee>> Get(int rowsCount, string cacheKey)
        {
            if (!memoryCache.TryGetValue(cacheKey, out IEnumerable<Employee> entities))
            {
                entities = await dbContext.Set<Employee>().Take(rowsCount).ToListAsync();
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
