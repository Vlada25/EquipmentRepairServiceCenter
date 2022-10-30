using EquipmentRepairServiceCenter.Database.Repositories.Base;
using EquipmentRepairServiceCenter.Domain.Models.People;
using EquipmentRepairServiceCenter.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRepairServiceCenter.Database.Repositories
{
    public class EmployeesRepository : RepositoryBase<Employee>, IEmployeesRepository
    {
        public EmployeesRepository(AppDbContext dbContext)
            : base(dbContext) { }

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
    }
}
