using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PenaP5.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PenaP5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopEarnersController : Controller
    {
        private readonly TopEarnerContext _context;

        public TopEarnersController(TopEarnerContext context)
        {
            _context = context;

            if(_context.TopEarner.Count() == 0)
            {
                _context.TopEarner.Add(new TopEarners { name = "Perry,Robert" , department= "CAO", grade = "", JobTitle= "Chief Admin Officer", totalEarner = 145600});
                _context.SaveChanges();
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopEarners>>>GetTopEarners()
        {
            return await _context.TopEarner.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TopEarners>> GetTopEarner(long id)
        {
            var TopEarner = await _context.TopEarner.FindAsync(id);

            if (TopEarner == null)
            {
                return NotFound();
            }

            return TopEarner;
        }

        [HttpPost]
        public async Task<ActionResult<TopEarners>>PostTopEarners(TopEarners TopEarner)
        {
            _context.TopEarner.Add(TopEarner);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTopEarners), new { id = TopEarner.Id }, TopEarner);
        }

        public async Task<IActionResult>PutTopEarner(long id, TopEarners earners)
        {
            if (id!= earners.Id)
            {
                return BadRequest();
            }
            _context.Entry(earners).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        public async Task<IActionResult> DeletTopEarner(long id)
        {
            var topEarner = await _context.TopEarner.FindAsync(id);

            if(topEarner == null)
            {
                return NotFound();
            }

            _context.TopEarner.Remove(topEarner);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
