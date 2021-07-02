using API.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AccountController : BaseAPIController
    {
        private readonly IGenericRepository<AppUser> _context;
        private readonly ITokenService _tokenService;

        public AccountController(IGenericRepository<AppUser> context, ITokenService tokenService)
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

                await _context.Add(user);
                return new UserDTO
                {
                    UserName = user.UserName,
                    Token = _tokenService.CreateToken(user)
                };

            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(UserToLoginDTO userDTO)
        {
            string userName = userDTO.UserName.ToLower();
            var spec = new UseSpecification(userName);
            var user = await _context.GetEntityWithSpec(spec);

            if (user == null)
            {
                return Unauthorized("User not registered.");
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));

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
            var spec = new UseSpecification(userName);
            var user = await _context.GetEntityWithSpec(spec);
            var isExists = user == null ? false : true;
            return isExists;
        }
    }
}

