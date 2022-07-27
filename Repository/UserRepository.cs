using OnDemandCarWashSystemAPI.Models;
using OnDemandCarWashSystemAPI.Interface;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OnDemandCarWashSystemAPI.Repository
{
    public class UserRepository : IRepository<UserDetails, int>
    {
        CarWashContext _context;
        public UserRepository(CarWashContext context) => _context = context;
        public async Task<int> CreateAsync(UserDetails userDetails)
        {

            _context.Users.Add(userDetails);
            await _context.SaveChangesAsync();
            var response = StatusCodes.Status201Created;
            return response;

        }

        public async Task<int> DeleteAsync(UserDetails userDetails)
        {
            _context.Users.Remove(userDetails);
            await _context.SaveChangesAsync();
            var response = StatusCodes.Status200OK;
            return response;
        }

        public bool Exists(int id)
        {
            return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }

        public async Task<IEnumerable<UserDetails>> GetAsync()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<UserDetails> GetIdAsync(int id)
        {

            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.UserId == id);
        }

        public async Task<int> UpdateAsync(UserDetails item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var response = StatusCodes.Status200OK;
            return response;

        }


    }

}
