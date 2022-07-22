using OnDemandCarWashSystemAPI.Models;
using System.Collections.Generic;

namespace OnDemandCarWashSystemAPI.Interface
{
    public interface IPackage
    {
        List<Package> GetAllPackage();
        Package GetPackage(int id);
        public string AddPackage(Package package);
        public string UpdatePackage(Package package);
        public string DeletePackage(int id);
    }
}
