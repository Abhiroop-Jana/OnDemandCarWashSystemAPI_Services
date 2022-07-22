using Microsoft.EntityFrameworkCore;
using OnDemandCarWashSystemAPI.Interface;
using OnDemandCarWashSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnDemandCarWashSystemAPI.Repository
{
    public class CustomerRepository : ICustomer
    {
        private CarWashContext _customerDb;
        public CustomerRepository(CarWashContext customerDbContext)
        {
            _customerDb = customerDbContext;
        }
        public List<Customer> GetAllCustomer()
        {
            List<Customer> customers = null;
            try
            {
                customers = _customerDb.Customers.ToList();
            }
            catch (Exception ex) { }
            return customers;
        }
        public Customer GetCustomer(int id)
        {
            Customer customer;
            try
            {
                customer = _customerDb.Customers.Find(id);
                if (customer != null)
                {
                    return customer;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException();
            }
            finally
            {
                customer = null;
            }
            return customer;
        }
        public string AddCustomer(Customer customer)
        {
            string result = string.Empty;
            try
            {
                _customerDb.Customers.Add(customer);
                _customerDb.SaveChanges();
            }
            catch (Exception ex)
            {
                result = "400";
            }
            return result;
        }
        public string UpdateCustomer(Customer customer)
        {
            string result = string.Empty;
            try
            {
                _customerDb.Entry(customer).State = EntityState.Modified;
                _customerDb.SaveChanges();
                result = "200";
            }
            catch
            {
                result = "400";
            }
            return result;
        }
        public string DeleteCustomer(int id)
        {
            string result = string.Empty;
            Customer customer;
            try
            {
                customer = _customerDb.Customers.Find(id);
                if (customer != null)
                { 
                    _customerDb.Customers.Remove(customer);
                    _customerDb.SaveChanges();
                    result = "200";
                }
            }
            catch (Exception ex)
            {
                result = "400";
            }
            finally
            {
                customer = null;
            }
            return result;
        }
    }
}
