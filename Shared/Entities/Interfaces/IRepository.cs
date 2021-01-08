using System.Threading.Tasks;

namespace Shared.Entities.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        Task AddAsync(TEntity entity);

        void Remove(TEntity entity);

        Task RemoveAsync(TEntity entity);
    }
}
