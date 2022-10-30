using EquipmentRepairServiceCenter.Database.Repositories.Base;
using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRepairServiceCenter.Database.Repositories
{
    public class SparePartsRepository : RepositoryBase<SparePart>, ISparePartsRepository
    {
        public SparePartsRepository(AppDbContext dbContext)
            : base(dbContext) { }

        public async Task Create(SparePart entity) => await CreateEntity(entity);

        public async Task<IEnumerable<SparePart>> GetAll(bool trackChanges) =>
            await GetAllEntities(trackChanges).ToListAsync();

        public async Task<SparePart> GetById(Guid id, bool trackChanges) =>
            await GetByCondition(e => e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void Delete(SparePart entity) => DeleteEntity(entity);

        public void Update(SparePart entity) =>
            UpdateEntity(entity);
    }
}
