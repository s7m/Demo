using API.Dtos;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AccountController : BaseAPIController
    {
        private readonly CompanyContext _context;
        private readonly ITokenService _tokenService;

        public AccountController(CompanyContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(string userName, string password)
        {
            userName = userName.ToLower();
            if (await UserExists(userName))
            {
                return BadRequest("Username not available");
            }

            using (var hmac = new HMACSHA512())
            {
                var user = new AppUser
                {
                    UserName = userName,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                    PasswordSalt = hmac.Key
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return new UserDTO
                {
                    UserName = user.UserName,
                    Token = _tokenService.CreateToken(user)
                };

            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(string userName, string password)
        {
            userName = userName.ToLower();

            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == userName);

            if (user == null)
            {
                return Unauthorized("User not registered.");
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return Unauthorized("Invalid Username or Password");
                }
            }

            return new UserDTO
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string userName)
        {
            var isExists = await _context.Users.AnyAsync(x => x.UserName == userName.ToLower());
            return isExists;
        }
    }
}

