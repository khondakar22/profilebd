using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileLearn.Data;
using ProfileLearn.Dto;
using ProfileLearn.Entities;
using ProfileLearn.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProfileLearn.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;

        public readonly ITokenService _tokenService;

        public AccountController(DataContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if(await UserExists(registerDto.Username)) return BadRequest("UserName Exists!!");
            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = registerDto.Username.Trim().ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key,
                HistoryEntity = new HistoryEntity
                {
                    CreatedBy = registerDto.Username.Trim().ToLower(),
                    CreatedDate = DateTime.UtcNow,
                    LastUpdatedBy = registerDto.Username.Trim().ToLower(),
                    LastUpdatedDated = DateTime.UtcNow,
                    ExternalId = new Guid().ToString()
                },
                ExternalId = new Guid().ToString()
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return new UserDto
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
          
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName.Trim().ToLower() == loginDto.Username.Trim().ToLower());
            if (user == null) return Unauthorized("Invalid Username");
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }
            return new UserDto
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }
        private async Task<bool> UserExists(string username)
        {
            if(!string.IsNullOrWhiteSpace(username))
            {
                return await _context.Users.AnyAsync(x => x.UserName.Trim().ToLower() == username.Trim().ToLower());
            }
            return false;
        }
    }
}
