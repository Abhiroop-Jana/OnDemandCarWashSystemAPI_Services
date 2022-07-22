using OnDemandCarWashSystemAPI.Models;
using System.Collections.Generic;

namespace OnDemandCarWashSystemAPI.Interface
{
    public interface ICustomer
    {
        List<Customer> GetAllCustomer();
        Customer GetCustomer(int id);
        public string AddCustomer(Customer customer);
        public string UpdateCustomer(Customer customer);
        public string DeleteCustomer(int id);
    }
}
