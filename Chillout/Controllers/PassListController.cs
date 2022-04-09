using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chillout.DataAccess.Context;
using Chillout.DataAccess.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PassListController
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly DbContext1 _context;

        public NotesController(DbContext1 context)
        {
            _context = context;
        }

        // GET: api/Notes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PassListRto>>> GetNotes()
        {
            return await _context.PassList.ToListAsync();
        }

        // GET: api/Notes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PassListRto>> GetNote(int id)
        {
            var list = await _context.PassList.FindAsync(id);

            if (list == null)
            {
                return NotFound();
            }

            return list;
        }

        // PUT: api/Notes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNote(int id, PassListRto list)
        {
            list.CreateTime = DateTime.UtcNow;
            if (id != list.Id)
            {
                return BadRequest();
            }

            _context.Entry(list).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteExists(id))
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

        // POST: api/Notes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PassListRto>> PostNote(PassListRto list)
        {
            list.CreateTime = DateTime.UtcNow;
            _context.PassList.Add(list);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNote", new { id = list.Id }, list);
        }

        // DELETE: api/Notes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PassListRto>> DeleteNote(int id)
        {
            var list = await _context.PassList.FindAsync(id);
            if (list == null)
            {
                return NotFound();
            }

            _context.PassList.Remove(list);
            await _context.SaveChangesAsync();

            return list;
        }

        private bool NoteExists(int id)
        {
            return _context.PassList.Any(e => e.Id == id);
        }

    }
}