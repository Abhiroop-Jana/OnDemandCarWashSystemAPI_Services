using Microsoft.AspNetCore.Mvc;
using OnDemandCarWashSystemAPI.Models;
using System.Threading.Tasks;

namespace OnDemandCarWashSystemAPI.Interface
{
    public interface IRegister<TEntity, TKey> where TEntity : class
    {
        Task<ActionResult<UserDetails>> CreateAsync(TEntity item);
        bool UserExists(TEntity item);
    }
}
