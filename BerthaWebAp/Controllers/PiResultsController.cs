using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BerthaWebAp.Models;

namespace BerthaWebAp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiResultsController : ControllerBase
    {
        private readonly DemoDbContext _context;

        public PiResultsController(DemoDbContext context)
        {
            _context = context;
        }

        // GET: api/PiResults
        [HttpGet]
        public IEnumerable<PiResults> GetPiResults()
        {
            return _context.PiResults;
        }

        // GET: api/PiResults/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPiResults([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var piResults = await _context.PiResults.FindAsync(id);

            if (piResults == null)
            {
                return NotFound();
            }

            return Ok(piResults);
        }

        // PUT: api/PiResults/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPiResults([FromRoute] int id, [FromBody] PiResults piResults)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != piResults.Id)
            {
                return BadRequest();
            }

            _context.Entry(piResults).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PiResultsExists(id))
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

        // POST: api/PiResults
        [HttpPost]
        public async Task<IActionResult> PostPiResults([FromBody] PiResults piResults)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PiResults.Add(piResults);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PiResultsExists(piResults.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPiResults", new { id = piResults.Id }, piResults);
        }

        // DELETE: api/PiResults/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePiResults([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var piResults = await _context.PiResults.FindAsync(id);
            if (piResults == null)
            {
                return NotFound();
            }

            _context.PiResults.Remove(piResults);
            await _context.SaveChangesAsync();

            return Ok(piResults);
        }

        private bool PiResultsExists(int id)
        {
            return _context.PiResults.Any(e => e.Id == id);
        }
    }
}