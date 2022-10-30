using EquipmentRepairServiceCenter.Database.Repositories.Base;
using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRepairServiceCenter.Database.Repositories
{
    public class RepairingModelsRepository : RepositoryBase<RepairingModel>, IRepairingModelsRepository
    {
        public RepairingModelsRepository(AppDbContext dbContext)
            : base(dbContext) { }

        public async Task Create(RepairingModel entity) => await CreateEntity(entity);

        public async Task<IEnumerable<RepairingModel>> GetAll(bool trackChanges) =>
            await GetAllEntities(trackChanges).ToListAsync();

        public async Task<RepairingModel> GetById(Guid id, bool trackChanges) =>
            await GetByCondition(e => e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void Delete(RepairingModel entity) => DeleteEntity(entity);

        public void Update(RepairingModel entity) =>
            UpdateEntity(entity);
    }
}
