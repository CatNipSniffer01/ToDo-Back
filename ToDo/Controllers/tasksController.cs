using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Data;
using ToDo.modells;

namespace ToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tasksController : ControllerBase
    {
        private readonly ToDoContext _context;

        public tasksController(ToDoContext context)
        {
            _context = context;
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tasks>>> Gettasks()
        {
            return await _context.tasks.ToListAsync();
        }

        // GET: api/tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tasks>> Gettasks(int id)
        {
            var tasks = await _context.tasks.FindAsync(id);

            if (tasks == null)
            {
                return NotFound();
            }

            return tasks;
        }

        // PUT: api/tasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttasks(int id, tasks tasks)
        {
            if (id != tasks.Task_Id)
            {
                return BadRequest();
            }

            _context.Entry(tasks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tasksExists(id))
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

        // POST: api/tasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tasks>> Posttasks(tasks tasks)
        {
            _context.tasks.Add(tasks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettasks", new { id = tasks.Task_Id }, tasks);
        }

        // DELETE: api/tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetasks(int id)
        {
            var tasks = await _context.tasks.FindAsync(id);
            if (tasks == null)
            {
                return NotFound();
            }

            _context.tasks.Remove(tasks);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tasksExists(int id)
        {
            return _context.tasks.Any(e => e.Task_Id == id);
        }
    }
}
