using System.Linq.Expressions;

namespace EquipmentRepairServiceCenter.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAllEntities(bool trackChanges);
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        Task CreateEntity(T entity);
        void UpdateEntity(T entity);
        void DeleteEntity(T entity);
    }
}
