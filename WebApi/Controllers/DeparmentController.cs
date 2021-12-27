using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Repositories.DeparmentRepositories;
using BusinessLayer.Requests;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeparmentController : ControllerBase
    {
   
        private readonly IDeparmentRepository _deparmentRepository;

        public DeparmentController(IDeparmentRepository deparmentRepository)
        {
            _deparmentRepository = deparmentRepository;
        }

        // GET: api/<DeparmentController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _deparmentRepository.GetDeparment();
            if (response == null)
            {
                return NotFound("Bulunamadı");
            }
            return Ok(response);
        }

        // GET api/<DeparmentController>/5
        [HttpGet("deparmentWithUser/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _deparmentRepository.GetDeparmentByIdWithUser(id);
            if (response == null)
            {
                return NotFound("Bulunamadı");
            }
            return Ok(response);
        }

        [HttpGet("/getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _deparmentRepository.GetDeparmentById(id);
            if (response == null)
            {
                return NotFound("Bulunamadı");
            }

            return Ok(response);
        }

        // POST api/<DeparmentController>
        [HttpPost]
        public async Task<IActionResult> Post(PostDeparmentRequest postDeparmentRequest)
        {
            
            var response = await _deparmentRepository.PostDepartment(postDeparmentRequest);
            if (response == null)
            {
                return NotFound("Hata oluştu");
            }
            return Created(response.Id.ToString() ,response);
        }

        // PUT api/<DeparmentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(PutDeparmentRequest putDeparmentRequest, int id)
        {
            var response = await _deparmentRepository.PutDeparment(putDeparmentRequest, id);
            if (response == null)
            {
                return NotFound("Bulunamadı");
            }

            return Ok(response);
        }

        // DELETE api/<DeparmentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _deparmentRepository.DeleteDeparment(id);
            if (response)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
