using AutoMapper;
using BMSAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BMSAPI.Controllers
{
    
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public SessionController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("api/Validate/{uname}")]
        public async Task<bool> Get(string uname)
        {
            bool sessionValidate = await userRepository.ValidateUserSessionAsync(uname);
            return sessionValidate;
        }

        [Route("api/Logout")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string uname)
        {
            bool response = await userRepository.EndSessionAsync(uname);
            if (response)
                return Ok("Logout successfully");
            return BadRequest("Bad request");
        }





        /*// GET: api/<SessionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SessionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SessionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SessionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SessionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
