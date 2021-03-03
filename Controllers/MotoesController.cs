using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Italika_Ramiro.Models;

namespace Italika_Ramiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoesController : ControllerBase
    {
        private readonly ItalikaContext _context;

        public MotoesController(ItalikaContext context)
        {
            _context = context;
        }

        // GET: api/Motoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moto>>> GetMoto()
        {
            return await _context.Moto.ToListAsync();
        }

        // GET: api/Motoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Moto>> GetMoto(int id)
        {
            var moto = await _context.Moto.FindAsync(id);

            if (moto == null)
            {
                return NotFound();
            }

            return moto;
        }

        // PUT: api/Motoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoto(int id, Moto moto)
        {
            if (id != moto.IdMoto)
            {
                return BadRequest();
            }

            _context.Entry(moto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotoExists(id))
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

        // POST: api/Motoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Moto>> PostMoto(Moto moto)
        {
            _context.Moto.Add(moto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMoto", new { id = moto.IdMoto }, moto);
        }

        // DELETE: api/Motoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Moto>> DeleteMoto(int id)
        {
            var moto = await _context.Moto.FindAsync(id);
            if (moto == null)
            {
                return NotFound();
            }

            _context.Moto.Remove(moto);
            await _context.SaveChangesAsync();

            return moto;
        }

        private bool MotoExists(int id)
        {
            return _context.Moto.Any(e => e.IdMoto == id);
        }
    }
}
