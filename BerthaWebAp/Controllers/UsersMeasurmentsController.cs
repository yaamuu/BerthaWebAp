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
    public class UsersMeasurmentsController : ControllerBase
    {
        private readonly DemoDbContext _context;

        public UsersMeasurmentsController(DemoDbContext context)
        {
            _context = context;
        }

        // GET: api/UsersMeasurments
        [HttpGet]
        public IEnumerable<UsersMeasurments> GetUsersMeasurments()
        {
            return _context.UsersMeasurments;
        }

        // GET: api/UsersMeasurments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsersMeasurments([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usersMeasurments = await _context.UsersMeasurments.FindAsync(id);

            if (usersMeasurments == null)
            {
                return NotFound();
            }

            return Ok(usersMeasurments);
        }

        // PUT: api/UsersMeasurments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsersMeasurments([FromRoute] int id, [FromBody] UsersMeasurments usersMeasurments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usersMeasurments.Id)
            {
                return BadRequest();
            }

            _context.Entry(usersMeasurments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersMeasurmentsExists(id))
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

        // POST: api/UsersMeasurments
        [HttpPost]
        public async Task<IActionResult> PostUsersMeasurments([FromBody] UsersMeasurments usersMeasurments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UsersMeasurments.Add(usersMeasurments);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsersMeasurmentsExists(usersMeasurments.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsersMeasurments", new { id = usersMeasurments.Id }, usersMeasurments);
        }

        // DELETE: api/UsersMeasurments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsersMeasurments([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usersMeasurments = await _context.UsersMeasurments.FindAsync(id);
            if (usersMeasurments == null)
            {
                return NotFound();
            }

            _context.UsersMeasurments.Remove(usersMeasurments);
            await _context.SaveChangesAsync();

            return Ok(usersMeasurments);
        }

        private bool UsersMeasurmentsExists(int id)
        {
            return _context.UsersMeasurments.Any(e => e.Id == id);
        }
    }
}