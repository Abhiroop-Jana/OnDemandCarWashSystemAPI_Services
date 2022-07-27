using Microsoft.AspNetCore.Mvc;
using OnDemandCarWashSystemAPI.DTOs;
using OnDemandCarWashSystemAPI.Interface;
using OnDemandCarWashSystemAPI.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnDemandCarWashSystemAPI.Repository
{
    public class RegisterRepository: IRegister<CreateUserDto, UserDetails>
    {
        CarWashContext _context;
        public RegisterRepository(CarWashContext context) => _context = context;

        #region RegisterUser
        /// <summary>
        /// this method is used to register User
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ActionResult<UserDetails>> CreateAsync(CreateUserDto userProfileDto)
        {
            try
            {

                using var hmac = new HMACSHA512();
                var user = new UserDetails
                {
                    UserName = userProfileDto.UserName,
                    UserEmail = userProfileDto.UserEmail,
                    UserPhnumber = userProfileDto.UserPhnumber,
                    Role = userProfileDto.Role,
                    UserStatus = userProfileDto.UserStatus,
                    UserPassword = userProfileDto.UserPassword,
                    UserPasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userProfileDto.UserPassword)),
                    UserPasswordSalt = hmac.Key
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }

        }

        public bool UserExists(CreateUserDto item)
        {
            return (_context.Users?.Any(e => e.UserEmail == item.UserEmail)).GetValueOrDefault();
        }
        #endregion
    }
}
