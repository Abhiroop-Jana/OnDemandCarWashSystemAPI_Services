using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnDemandCarWashSystemAPI.Interface
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetIdAsync(TKey id);
        Task<int> CreateAsync(TEntity item);
        Task<int> UpdateAsync(TEntity item);
        Task<int> DeleteAsync(TEntity item);
        bool Exists(TKey id);
    }
}
