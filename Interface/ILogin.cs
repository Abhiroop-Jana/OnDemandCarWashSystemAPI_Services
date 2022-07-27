using System.Threading.Tasks;

namespace OnDemandCarWashSystemAPI.Interface
{
    public interface ILogin<TEntity, TKey> where TEntity : class
    {
        Task<int> Login(TEntity item);
    }
}
