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

        public UserController(DbContext context)
        {
            _DbContext = (DbContext1)context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRto>>> GetUser() => await _DbContext.User.ToListAsync();
        
        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRto>> GetUser(string id)
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
        public async Task<ActionResult<UserRto>> PostUser(UserRto user)
        {
            _DbContext.User.Add(user);
            try
            {
                await _DbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        private bool UserExists(int id)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserRto>> DeleteUser(string id)
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

        private bool UserExists(string id)
        {
            return _DbContext.User.Any(e => e.Id = id);
        }
    }
}