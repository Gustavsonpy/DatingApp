using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetUser()
        {
            var users = await context.Users.ToListAsync();

            return users;
        }

        [HttpGet("{id}")]
        public ActionResult<AppUser> GetOneUser(String id)
        {
            var user = context.Users.Find(id);

            if (user == null) return NotFound();

            return user;
        }
    }
}
