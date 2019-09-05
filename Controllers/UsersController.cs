using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIWithDotNet.Models;

namespace APIWithDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/users
        [HttpGet]
        public async Task<ActionResult> GetUsers([FromQuery]PagingParamaters pagingParamaters)
        {
            /** Get query */
            var query = _context.Users;

            /** total number of user */
            int totalCount = query.Count();

            /** get page */
            int page = pagingParamaters.page;

            /** get limit record in page */
            int limit = pagingParamaters.limit;

            /** get totalPage */
            int totalPage = (int)Math.Ceiling(totalCount / (double)limit);

            /** get data in page */
            var data = await query.Skip((page - 1) * limit).Take(limit).ToListAsync();

            /** total number of user in current page */
            var count = data.Count();

            var result = new
            {
                page,
                limit,
                totalPage,
                totalCount,
                count,
                data,
            };

            return Ok( new { success = true, result } );
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(long id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(new { success = true, user });
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult> PostUser(User item)
        {
            _context.Users.Add(item);
            await _context.SaveChangesAsync();
            // return Created("/api/users", item);
            return Ok( new { success = true, user = item } );
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutUser(long id, User item)
        {
            if (id != item.id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            /** I want an edited item  */
            // var editedItem = await _context.Users.FindAsync(id);
            // return Ok( new { success = true, user = editedItem } );

            /** Just edit, don't response anything */
            return NoContent();
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok( new { success = true } );
        }
    }
}
