using OnDemandCarWashSystemAPI.Models;

namespace OnDemandCarWashSystemAPI.Interface
{
    public interface IToken
    {
        public string CreateToken(Login login);
    }
}
