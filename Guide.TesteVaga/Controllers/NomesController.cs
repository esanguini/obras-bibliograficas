using System;
using System.Linq;
using System.Threading.Tasks;
using Guide.TesteVaga.Models;
using Guide.TesteVaga.Context;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Guide.TesteVaga.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NomesController : ControllerBase
    {
        private readonly NomesDbContext _context;

        public NomesController(NomesDbContext context)
        {
            _context = context;
        }

        // GET: api/Nomes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nomes>>> GetNomes()
        {
            return await _context.Nomes.ToListAsync();
        }

        // GET: api/Nomes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nomes>> GetNomes(int id)
        {
            var nomes = await _context.Nomes.FindAsync(id);

            if (nomes == null)
            {
                return NotFound();
            }

            return nomes;
        }

        // PUT: api/Nomes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNomes(int id, Nomes nomes)
        {
            if (id != nomes.Id)
            {
                return BadRequest();
            }

            _context.Entry(nomes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NomesExists(id))
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

        // POST: api/Nomes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Nomes>> PostNomes(Nomes nomes)
        {
            _context.Nomes.Add(nomes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNomes", new { id = nomes.Id }, nomes);
        }

        // DELETE: api/Nomes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Nomes>> DeleteNomes(int id)
        {
            var nomes = await _context.Nomes.FindAsync(id);
            if (nomes == null)
            {
                return NotFound();
            }

            _context.Nomes.Remove(nomes);
            await _context.SaveChangesAsync();

            return nomes;
        }

        private bool NomesExists(int id)
        {
            return _context.Nomes.Any(e => e.Id == id);
        }
    }
}