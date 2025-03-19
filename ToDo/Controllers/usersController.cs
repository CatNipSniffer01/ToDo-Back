using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ToDo.Data;
using ToDo.modells;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Configuration;

namespace ToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {
        private readonly ToDoContext _context;
        private readonly IConfiguration _configuration;

        public usersController(ToDoContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<users>>> Getusers()
        {
            return await _context.users.ToListAsync();
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<users>> Getusers(int id)
        {
            var users = await _context.users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // PUT: api/users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putusers(int id, users users)
        {
            if (id != users.User_Id)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!usersExists(id))
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

        // POST: api/users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] users user)
        {
            if (string.IsNullOrWhiteSpace(user.UserName) || string.IsNullOrWhiteSpace(user.Password))
                return BadRequest("Username and password are required.");

            // Hash the password before storing it
            user.Password= PasswordHasher.HashPassword(user.Password);

            _context.users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User registered successfully!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] users user)
        {
            var existingUser = _context.users.FirstOrDefault(u => u.Email == user.Email);
            if (existingUser.Email != user.Email || !PasswordHasher.VerifyPassword(user.Password, existingUser.Password))
            {
                return Unauthorized("Invalid username or password.");
            }

            var token = GenerateJwtToken(existingUser);
            if (user.IsAdmin == true)
            {
                return Ok(new{ message = "ADMIN Login successful! " + token, user = existingUser});
            }
            else
            {
                return Ok(new {message = "Login successful! " + token, user = existingUser});
            }
        }

        private string GenerateJwtToken(users User)
        {
            var jwtKey = _configuration["JWT:Key"];
            if (string.IsNullOrWhiteSpace(jwtKey))
            {
                throw new Exception("JWT Key is not configured in appsettings.json");
            }
            var key = Encoding.UTF8.GetBytes(jwtKey);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, User.User_Id.ToString()),
                new Claim(ClaimTypes.Name, User.UserName),
                new Claim("IsAdmin", User.IsAdmin.ToString())
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2), // make it non-timed
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }



        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteusers(int id)
        {
            var users = await _context.users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.users.Remove(users);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool usersExists(int id)
        {
            return _context.users.Any(e => e.User_Id == id);
        }
    }
}
