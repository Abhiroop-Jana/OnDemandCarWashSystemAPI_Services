using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnDemandCarWashSystemAPI.Interface;
using OnDemandCarWashSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OnDemandCarWashSystemAPI.Repository
{
    public class TokenRepository:IToken
    {
        CarWashContext _context;
        private readonly IConfiguration _configuration;

        public TokenRepository(CarWashContext context, IConfiguration config)
        {
            _context = context;
            _configuration = config;
        }

        public string CreateToken(Login login)
        {
            try
            {
                List<Claim> claims = new List<Claim>
                {
                 new Claim(ClaimTypes.Email, login.Email),
                new Claim(ClaimTypes.Role, login.Role)
                 };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Token").Value));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds);

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;


            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }
    }
}
