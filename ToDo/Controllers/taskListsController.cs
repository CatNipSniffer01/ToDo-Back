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
    public class taskListsController : ControllerBase
    {
        private readonly ToDoContext _context;

        public taskListsController(ToDoContext context)
        {
            _context = context;
        }

        // GET: api/taskLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<taskList>>> GettaskList()
        {
            return await _context.taskList.ToListAsync();
        }

        // GET: api/taskLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<taskList>> GettaskList(int id)
        {
            var taskList = await _context.taskList.FindAsync(id);

            if (taskList == null)
            {
                return NotFound();
            }

            return taskList;
        }

        // PUT: api/taskLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttaskList(int id, taskList taskList)
        {
            if (id != taskList.List_Id)
            {
                return BadRequest();
            }

            _context.Entry(taskList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!taskListExists(id))
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

        // POST: api/taskLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<taskList>> PosttaskList(taskList taskList)
        {
            _context.taskList.Add(taskList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettaskList", new { id = taskList.List_Id }, taskList);
        }

        // DELETE: api/taskLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetaskList(int id)
        {
            var taskList = await _context.taskList.FindAsync(id);
            if (taskList == null)
            {
                return NotFound();
            }

            _context.taskList.Remove(taskList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool taskListExists(int id)
        {
            return _context.taskList.Any(e => e.List_Id == id);
        }
    }
}
