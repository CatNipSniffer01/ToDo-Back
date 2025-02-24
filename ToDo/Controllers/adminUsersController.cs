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
    public class adminUsersController : ControllerBase
    {
        private readonly ToDoContext _context;

        public adminUsersController(ToDoContext context)
        {
            _context = context;
        }

        // GET: api/adminUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<adminUsers>>> GetadminUsers()
        {
            return await _context.adminUsers.ToListAsync();
        }

        // GET: api/adminUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<adminUsers>> GetadminUsers(int id)
        {
            var adminUsers = await _context.adminUsers.FindAsync(id);

            if (adminUsers == null)
            {
                return NotFound();
            }

            return adminUsers;
        }

        // PUT: api/adminUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutadminUsers(int id, adminUsers adminUsers)
        {
            if (id != adminUsers.AdminUser_Id)
            {
                return BadRequest();
            }

            _context.Entry(adminUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!adminUsersExists(id))
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

        // POST: api/adminUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<adminUsers>> PostadminUsers(adminUsers adminUsers)
        {
            _context.adminUsers.Add(adminUsers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetadminUsers", new { id = adminUsers.AdminUser_Id }, adminUsers);
        }

        // DELETE: api/adminUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteadminUsers(int id)
        {
            var adminUsers = await _context.adminUsers.FindAsync(id);
            if (adminUsers == null)
            {
                return NotFound();
            }

            _context.adminUsers.Remove(adminUsers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool adminUsersExists(int id)
        {
            return _context.adminUsers.Any(e => e.AdminUser_Id == id);
        }
    }
}
