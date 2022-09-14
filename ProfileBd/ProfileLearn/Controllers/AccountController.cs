using Microsoft.AspNetCore.Mvc;
using ProfileLearn.Data;
using ProfileLearn.Entities;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProfileLearn.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register(string username, string password)
        {
            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key,
                HistoryEntity = new HistoryEntity
                {
                    CreatedBy = username,
                    CreatedDate = DateTime.UtcNow,
                    LastUpdatedBy = username,
                    LastUpdatedDated = DateTime.UtcNow,
                    ExternalId = new Guid().ToString()
                }
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
