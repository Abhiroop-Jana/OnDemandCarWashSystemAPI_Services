using Microsoft.EntityFrameworkCore;
using OnDemandCarWashSystemAPI.Interface;
using OnDemandCarWashSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnDemandCarWashSystemAPI.Repository
{
    public class PackageRepository:IPackage
    {
        private CarWashContext _packageDb;
        public PackageRepository(CarWashContext packageDbContext)
        {
            _packageDb = packageDbContext;
        }
        public List<Package> GetAllPackage()
        {
            List<Package> packages = null;
            try
            {
                packages = _packageDb.Packages.ToList();
            }
            catch (Exception ex) { }
            return packages;
        }
        public Package GetPackage(int id)
        {
            Package package;
            try
            {
                package = _packageDb.Packages.Find(id);
                if (package != null)
                {
                    return package;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException();
            }
            finally
            {
                package = null;
            }
            return package;
        }
        public string AddPackage(Package package)
        {
            string result = string.Empty;
            try
            {
                _packageDb.Packages.Add(package);
                _packageDb.SaveChanges();
            }
            catch (Exception ex)
            {
                result = "400";
            }
            return result;
        }
        public string UpdatePackage(Package package)
        {
            string result = string.Empty;
            try
            {
                _packageDb.Entry(package).State = EntityState.Modified;
                _packageDb.SaveChanges();
                result = "200";
            }
            catch
            {
                result = "400";
            }
            return result;
        }
        public string DeletePackage(int id)
        {
            string result = string.Empty;
            Package package;
            try
            {
                package = _packageDb.Packages.Find(id);
                if (package != null)
                {
                    //package.Status = "In Active";
                    _packageDb.Packages.Remove(package);
                    _packageDb.SaveChanges();
                    result = "200";
                }
            }
            catch (Exception ex)
            {
                result = "400";
            }
            finally
            {
                package = null;
            }
            return result;
        }
    }
}
