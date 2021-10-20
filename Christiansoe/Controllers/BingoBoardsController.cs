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
    public class BingoBoardsController : ControllerBase
    {
        private readonly ChristiansoeContext _context;

        public BingoBoardsController(ChristiansoeContext context)
        {
            _context = context;
        }

        // GET: api/BingoBoards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BingoBoard>>> GetBingoBoard()
        {
            return await _context.BingoBoard.ToListAsync();
        }

        // GET: api/BingoBoards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BingoBoard>> GetBingoBoard(int id)
        {
            var bingoBoard = await _context.BingoBoard.FindAsync(id);

            if (bingoBoard == null)
            {
                return NotFound();
            }

            return bingoBoard;
        }

        // PUT: api/BingoBoards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBingoBoard(int id, BingoBoard bingoBoard)
        {
            if (id != bingoBoard.Id)
            {
                return BadRequest();
            }

            _context.Entry(bingoBoard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BingoBoardExists(id))
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

        // POST: api/BingoBoards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BingoBoard>> PostBingoBoard(BingoBoard bingoBoard)
        {
            _context.BingoBoard.Add(bingoBoard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBingoBoard", new { id = bingoBoard.Id }, bingoBoard);
        }

        // DELETE: api/BingoBoards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBingoBoard(int id)
        {
            var bingoBoard = await _context.BingoBoard.FindAsync(id);
            if (bingoBoard == null)
            {
                return NotFound();
            }

            _context.BingoBoard.Remove(bingoBoard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BingoBoardExists(int id)
        {
            return _context.BingoBoard.Any(e => e.Id == id);
        }
    }
}
