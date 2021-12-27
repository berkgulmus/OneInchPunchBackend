using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using BusinessLayer.Repositories.UserRepository;
using BusinessLayer.Requests;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{    

    // Bizim Claslarımızın tipi ne olacak 
    // Status code olayları nasılacak
    // 3 abi Project Get,Post,Put,Delete
    // Repository ve Interface 


    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;


        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }




        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _userRepository.GetUser();

            if (response == null)
            {
                return NotFound("Kullanıcı listesi boş!");
            }
            return Ok( response);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _userRepository.GetUserById(id);

            if (response == null)
            {
                return NotFound("Verilen id ile kullanıcı bulunamadı!");
            }
            return Ok(response);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post(PostUserRequest loginRequest)
        {
            var response = await _userRepository.PostUser(loginRequest);

            if (response == null)
            {
                return NotFound("Hata oluştu");
            }
            return Created(response.Id.ToString(), response);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
