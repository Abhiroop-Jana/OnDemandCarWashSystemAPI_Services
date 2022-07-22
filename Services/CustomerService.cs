using OnDemandCarWashSystemAPI.Interface;
using OnDemandCarWashSystemAPI.Models;
using System.Collections.Generic;

namespace OnDemandCarWashSystemAPI.Services
{
    public class CustomerService
    {
        private ICustomer _ICustomer;
        public CustomerService(ICustomer Icustomer)
        {
            _ICustomer = Icustomer;
        }
        public List<Customer> GetAllCustomer()
        {
            return _ICustomer.GetAllCustomer();
        }
        public Customer GetCustomer(int id)
        {
            return _ICustomer.GetCustomer(id);
        }
        public string AddCustomer(Customer customer)
        {
            return _ICustomer.AddCustomer(customer);
        }
        public string UpdateCustomer(Customer customer)
        {
            return _ICustomer.UpdateCustomer(customer);
        }
        public string DeleteCustomer(int id)
        {
            return _ICustomer.DeleteCustomer(id);
        }
    }
}
