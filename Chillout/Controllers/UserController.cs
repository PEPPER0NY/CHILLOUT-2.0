using Chillout.DataAccess.Context;
using Chillout.DataAccess.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chillout.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly DbContext1 _DbContext;

        public UserController(DbContext1 context)
        {
            _DbContext = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRto>>> GetUser() => await _DbContext.User.ToListAsync();

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRto>> GetUser(int id)
        {
            var user = await _DbContext.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserRto user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _DbContext.Entry(user).State = EntityState.Modified;

            try
            {
                await _DbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<UserRto> PostUser(UserRto user)
        {
            string login = user.Login;
            string password = user.PassWord;

            UserRto find = _DbContext.User.FirstOrDefault(t => t.Login == user.Login);
            if (find != default)
            {
                if (find.PassWord == user.PassWord)
                {
                    return Ok();
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserRto>> DeleteUser(int id)
        {
            var user = await _DbContext.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _DbContext.User.Remove(user);
            await _DbContext.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _DbContext.User.Any(e => e.Id == id);
        }
    }
} 
