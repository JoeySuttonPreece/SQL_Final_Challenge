using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestsController : ControllerBase
    {
        private readonly FinalContext _context;

        public InterestsController(FinalContext context)
        {
            _context = context;
        }

        // GET: api/Interests
        [HttpGet]
        public IEnumerable<Interest> GetInterest()
        {
            return _context.Interest;
        }

        // GET: api/Interests/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInterest([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var interest = await _context.Interest.FindAsync(id);

            if (interest == null)
            {
                return NotFound();
            }

            return Ok(interest);
        }

        // PUT: api/Interests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInterest([FromRoute] string id, [FromBody] Interest interest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != interest.InterestCode)
            {
                return BadRequest();
            }

            _context.Entry(interest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterestExists(id))
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

        // POST: api/Interests
        [HttpPost]
        public async Task<IActionResult> PostInterest([FromBody] Interest interest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Interest.Add(interest);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InterestExists(interest.InterestCode))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInterest", new { id = interest.InterestCode }, interest);
        }

        // DELETE: api/Interests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterest([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var interest = await _context.Interest.FindAsync(id);
            if (interest == null)
            {
                return NotFound();
            }

            _context.Interest.Remove(interest);
            await _context.SaveChangesAsync();

            return Ok(interest);
        }

        private bool InterestExists(string id)
        {
            return _context.Interest.Any(e => e.InterestCode == id);
        }
    }
}