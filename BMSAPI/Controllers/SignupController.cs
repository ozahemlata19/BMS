using AutoMapper;
using BMSAPI.Model.Domains;
using BMSAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {

        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public SignupController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }


        //Post api<SignupController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDetail value)
        {
            bool response = await userRepository.SaveUserDetailAsync(value);
            if (response)
                return Ok("Added successfully");
            return BadRequest("User Already Exist");
        }









        /*
        // GET: api/<SignupController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SignupController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SignupController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SignupController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SignupController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    */
    }
}
