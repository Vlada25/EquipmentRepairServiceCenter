using EquipmentRepairServiceCenter.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.Database.Repositories.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppDbContext dbContext;

        public RepositoryBase(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateEntity(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
        }

        public void DeleteEntity(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAllEntities(bool trackChanges)
        {
            return !trackChanges ? dbContext.Set<T>().AsNoTracking() : dbContext.Set<T>();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ?
                dbContext.Set<T>().Where(expression).AsNoTracking() :
                dbContext.Set<T>().Where(expression);
        }

        public void UpdateEntity(T entity)
        {
            dbContext.Set<T>().Update(entity);
        }
    }
}
