using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestDeparmentController : ControllerBase
    {
        private readonly DataContext _context;

        public TestDeparmentController(DataContext context)
        {
            _context = context;
        }
        // GET: api/<TestDeparmentController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _context.Deparments
                .Include(d => d.Users)
                .ThenInclude(u=> u.Role)
                .ToListAsync();
            
            return Ok(response);
        }

        // GET api/<TestDeparmentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestDeparmentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestDeparmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestDeparmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
