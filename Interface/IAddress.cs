using OnDemandCarWashSystemAPI.Models;
using System.Collections.Generic;

namespace OnDemandCarWashSystemAPI.Interface
{
    public interface IAddress
    {
        List<Address> GetAllAddress();
        Address GetAddress(int id);
        public string AddAddress(Address address);
        public string UpdateAddress(Address address);
        public string DeleteAddress(int id);
    }
}
