using Microsoft.EntityFrameworkCore;
using OnDemandCarWashSystemAPI.Interface;
using OnDemandCarWashSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnDemandCarWashSystemAPI.Repository
{
    public class AdminRepository:IAdmin
    {
        private CarWashContext _adminDb;
        public AdminRepository(CarWashContext adminDbContext)
        {
            _adminDb = adminDbContext;
        }
        public List<Admin> GetAllAdmin()
        {
            List<Admin> admins = null;
            try
            {
                admins = _adminDb.Admins.ToList();
            }
            catch (Exception ex) { }
            return admins;
        }
        public Admin GetAdmin(int id)
        {
            Admin admin;
            try
            {
                admin = _adminDb.Admins.Find(id);
                if (admin != null)
                {
                    return admin;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException();
            }
            finally
            {
                admin = null;
            }
            return admin;
        }
        public string AddAdmin(Admin admin)
        {
            string result = string.Empty;
            try
            {
                _adminDb.Admins.Add(admin);
                _adminDb.SaveChanges();
            }
            catch (Exception ex)
            {
                result = "400";
            }
            return result;
        }
        public string UpdateAdmin(Admin admin)
        {
            string result = string.Empty;
            try
            {
                _adminDb.Entry(admin).State = EntityState.Modified;
                _adminDb.SaveChanges();
                result = "200";
            }
            catch
            {
                result = "400";
            }
            return result;
        }
        public string DeleteAdmin(int id)
        {
            string result = string.Empty;
            Admin admin;
            try
            {
                admin = _adminDb.Admins.Find(id);
                if (admin != null)
                {
                    //package.Status = "In Active";
                    _adminDb.Admins.Remove(admin);
                    _adminDb.SaveChanges();
                    result = "200";
                }
            }
            catch (Exception ex)
            {
                result = "400";
            }
            finally
            {
                admin = null;
            }
            return result;
        }
    }
}
