using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileLearn.Data;
using ProfileLearn.Dto;
using ProfileLearn.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProfileLearn.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetUsers()
        {
            return await _context.Users.Include(x => x.HistoryEntity)
               .Select(x =>
                  new UserResponse
                  {
                      Id = x.Id,
                      UserName = x.UserName,
                      CreationModificationHistory = x.HistoryEntity
                  }
             ).ToListAsync(CancellationToken.None);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> Getuser(int id)
        {
            return await _context.Users.FindAsync(id);
        }

    }
}
