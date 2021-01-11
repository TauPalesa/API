using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Task_DetailController : ControllerBase
    {
        private readonly Context _context;

        public Task_DetailController(Context context)
        {
            _context = context;
        }

        // GET: api/Task_Detail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Task_Detail>>> GetTask_Details()
        {
            return await _context.Task_Details.ToListAsync();
        }

        // GET: api/Task_Detail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Task_Detail>> GetTask_Detail(int id)
        {
            var task_Detail = await _context.Task_Details.FindAsync(id);

            if (task_Detail == null)
            {
                return NotFound();
            }

            return task_Detail;
        }

        // PUT: api/Task_Detail/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask_Detail(int id, Task_Detail task_Detail)
        {
            if (id != task_Detail.Task_ID)
            {
                return BadRequest();
            }

            _context.Entry(task_Detail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Task_DetailExists(id))
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

        // POST: api/Task_Detail
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Task_Detail>> PostTask_Detail(Task_Detail task_Detail)
        {
            _context.Task_Details.Add(task_Detail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask_Detail", new { id = task_Detail.Task_ID }, task_Detail);
        }

        // DELETE: api/Task_Detail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Task_Detail>> DeleteTask_Detail(int id)
        {
            var task_Detail = await _context.Task_Details.FindAsync(id);
            if (task_Detail == null)
            {
                return NotFound();
            }

            _context.Task_Details.Remove(task_Detail);
            await _context.SaveChangesAsync();

            return task_Detail;
        }

        private bool Task_DetailExists(int id)
        {
            return _context.Task_Details.Any(e => e.Task_ID == id);
        }
    }
}
