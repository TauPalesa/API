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
    public class User_AccountController : ControllerBase
    {
        private readonly Context _context;

        public User_AccountController(Context context)
        {
            _context = context;
        }

        // GET: api/User_Account
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User_Account>>> GetUser_Accounts()
        {
            return await _context.User_Accounts.ToListAsync();
        }

        // GET: api/User_Account/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User_Account>> GetUser_Account(int id)
        {
            var user_Account = await _context.User_Accounts.FindAsync(id);

            if (user_Account == null)
            {
                return NotFound();
            }

            return user_Account;
        }

        // PUT: api/User_Account/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser_Account(int id, User_Account user_Account)
        {
            if (id != user_Account.Id)
            {
                return BadRequest();
            }

            _context.Entry(user_Account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_AccountExists(id))
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

        // POST: api/User_Account
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User_Account>> PostUser_Account(User_Account user_Account)
        {
            _context.User_Accounts.Add(user_Account);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser_Account", new { id = user_Account.Id }, user_Account);
        }

        // DELETE: api/User_Account/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User_Account>> DeleteUser_Account(int id)
        {
            var user_Account = await _context.User_Accounts.FindAsync(id);
            if (user_Account == null)
            {
                return NotFound();
            }

            _context.User_Accounts.Remove(user_Account);
            await _context.SaveChangesAsync();

            return user_Account;
        }

        private bool User_AccountExists(int id)
        {
            return _context.User_Accounts.Any(e => e.Id == id);
        }
    }
}
