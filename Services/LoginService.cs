using OnDemandCarWashSystemAPI.Interface;
using OnDemandCarWashSystemAPI.Models;
using System.Threading.Tasks;

namespace OnDemandCarWashSystemAPI.Services
{
    public class LoginService
    {
        ILogin<Login, int> _repository;
        public LoginService(ILogin<Login, int> repository)
        {
            _repository = repository;
        }

        public async Task<int> Login(Login login)
        {
            return await _repository.Login(login);
        }
    }
}
