using ComputerClub.Interfaces;
using ComputerClub.Models;
using ComputerClub.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerClub.Controllers
{
    [ApiController]
    [Route("/api/statuses")]
    public class StatusesController : ControllerBase
    {
        private readonly IDbContext _context;
        public StatusesController(IDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Status>>> GetAll()
        {
            try
            {
                return Ok(await _context.Statuses.ToListAsync());
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> GetById(int id)
        {
            try
            {
                var status = await _context.Statuses.FindAsync(id);
                if (status == null)
                {
                    return NotFound();
                }
                return Ok(status);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Status>> Create([FromBody] CreateStatusRequest request)
        {
            try
            {
                var status = new Status() { Name = request.Name };
                var entry = await _context.Statuses.AddAsync(status);
                await _context.SaveChangesAsync();

                return Created($"api/statuses/{entry.Entity.Id}", entry.Entity);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var status = await _context.Statuses.FindAsync(id);
                if (status == null)
                {
                    return NotFound();
                }

                _context.Statuses.Remove(status);
                await _context.SaveChangesAsync();

                return NoContent();

            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Status>> Update([FromBody] UpdateStatusRequest request)
        {
            try
            {
                var status = await _context.Statuses.FindAsync(request.Id);
                if (status == null)
                {
                    return NotFound();
                }
                status.Name = request.NewName;
                await _context.SaveChangesAsync();

                return Created($"api/statuses/{status.Id}", status);


            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
