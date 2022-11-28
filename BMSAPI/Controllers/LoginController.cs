using AutoMapper;
using BMSAPI.Model.Domains;
using BMSAPI.Model.DTO;
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
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public LoginController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        //Getting User Deatils

        [HttpGet("{uname}")]
        public async Task<UserDetailDTO> Get(string uname)
        {
            UserDetail userdetail = await userRepository.GetUserAsync(uname);
            UserDetailDTO userDetailDTO = mapper.Map<UserDetailDTO>(userdetail);

            if(userDetailDTO!=null)
                userDetailDTO.Token = null;

            return userDetailDTO;
        }


        //Validate User
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginDetailDTO value)
        {
            int Role = await userRepository.ValidateUserCrudAsync(value.UserName, value.Password);

            if(Role==0)
            {
                return Ok("User");
            }
            else if(Role == 1)
            {
                return Ok("Admin");
            }
            else
            {
                return NotFound("UserNot Found");
            }
         
        }











        /*
        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
