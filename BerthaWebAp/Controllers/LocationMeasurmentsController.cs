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
    public class LocationMeasurmentsController : ControllerBase
    {
        private readonly DemoDbContext _context;

        public LocationMeasurmentsController(DemoDbContext context)
        {
            _context = context;
        }

        // GET: api/LocationMeasurments
        [HttpGet]
        public IEnumerable<LocationMeasurments> GetLocationMeasurments()
        {
            return _context.LocationMeasurments;
        }

        // GET: api/LocationMeasurments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationMeasurments([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var locationMeasurments = await _context.LocationMeasurments.FindAsync(id);

            if (locationMeasurments == null)
            {
                return NotFound();
            }

            return Ok(locationMeasurments);
        }

        // PUT: api/LocationMeasurments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocationMeasurments([FromRoute] int id, [FromBody] LocationMeasurments locationMeasurments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != locationMeasurments.Id)
            {
                return BadRequest();
            }

            _context.Entry(locationMeasurments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationMeasurmentsExists(id))
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

        // POST: api/LocationMeasurments
        [HttpPost]
        public async Task<IActionResult> PostLocationMeasurments([FromBody] LocationMeasurments locationMeasurments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LocationMeasurments.Add(locationMeasurments);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LocationMeasurmentsExists(locationMeasurments.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLocationMeasurments", new { id = locationMeasurments.Id }, locationMeasurments);
        }

        // DELETE: api/LocationMeasurments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocationMeasurments([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var locationMeasurments = await _context.LocationMeasurments.FindAsync(id);
            if (locationMeasurments == null)
            {
                return NotFound();
            }

            _context.LocationMeasurments.Remove(locationMeasurments);
            await _context.SaveChangesAsync();

            return Ok(locationMeasurments);
        }

        private bool LocationMeasurmentsExists(int id)
        {
            return _context.LocationMeasurments.Any(e => e.Id == id);
        }
    }
}