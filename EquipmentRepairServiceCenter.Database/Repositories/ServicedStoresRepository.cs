using EquipmentRepairServiceCenter.Database.Repositories.Base;
using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRepairServiceCenter.Database.Repositories
{
    public class ServicedStoresRepository : RepositoryBase<ServicedStore>, IServicedStoresRepository
    {
        public ServicedStoresRepository(AppDbContext dbContext)
            : base(dbContext) { }

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
    }
}
