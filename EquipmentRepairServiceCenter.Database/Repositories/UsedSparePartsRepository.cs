using EquipmentRepairServiceCenter.Database.Repositories.Base;
using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRepairServiceCenter.Database.Repositories
{
    public class UsedSparePartsRepository : RepositoryBase<UsedSparePart>, IUsedSparePartsRepository
    {
        public UsedSparePartsRepository(AppDbContext dbContext)
            : base(dbContext) { }

        public async Task Create(UsedSparePart entity) => await CreateEntity(entity);

        public async Task<IEnumerable<UsedSparePart>> GetAll(bool trackChanges) =>
            await GetAllEntities(trackChanges).ToListAsync();

        public async Task<UsedSparePart> GetById(Guid id, bool trackChanges) =>
            await GetByCondition(e => e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void Delete(UsedSparePart entity) => DeleteEntity(entity);

        public void Update(UsedSparePart entity) =>
            UpdateEntity(entity);
    }
}
