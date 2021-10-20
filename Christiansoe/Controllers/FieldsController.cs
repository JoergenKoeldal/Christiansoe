using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Christiansoe.Data;
using Christiansoe.Models;

namespace Christiansoe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldsController : ControllerBase
    {
        private readonly ChristiansoeContext _context;

        public FieldsController(ChristiansoeContext context)
        {
            _context = context;
        }

        // GET: api/Fields
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Field>>> GetField()
        {
            return await _context.Field.ToListAsync();
        }

        // GET: api/Fields/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Field>> GetField(int id)
        {
            var @field = await _context.Field.FindAsync(id);

            if (@field == null)
            {
                return NotFound();
            }

            return @field;
        }

        // PUT: api/Fields/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutField(int id, Field @field)
        {
            if (id != @field.Id)
            {
                return BadRequest();
            }

            _context.Entry(@field).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FieldExists(id))
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

        // POST: api/Fields
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Field>> PostField(Field @field)
        {
            _context.Field.Add(@field);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetField", new { id = @field.Id }, @field);
        }

        // DELETE: api/Fields/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteField(int id)
        {
            var @field = await _context.Field.FindAsync(id);
            if (@field == null)
            {
                return NotFound();
            }

            _context.Field.Remove(@field);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FieldExists(int id)
        {
            return _context.Field.Any(e => e.Id == id);
        }
    }
}
