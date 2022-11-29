﻿using BMSAPI.Model.Domains;
using BMSAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSAPI.Controllers
{
    public class UpdateController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IApplyLoanRepository loanRepository;

        public UpdateController(IUserRepository userRepository, IApplyLoanRepository loanRepository)
        {
            this.userRepository = userRepository;
            this.loanRepository = loanRepository;
        }

        /*[Route("api/[controller]/loan/{id}")]
        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] LoanDetail value)
        {
            bool res = await loanRepository.UpdateLoanDeatilAsync(id, value);

            if (res)
                return Ok("Updated Successfully");
            else
                return BadRequest("Something Went Wrong");
        }

        [Route("api/[controller]/user/{uname}")]
        [HttpPut]
        public async Task<IActionResult> Put(string uname, [FromBody] UserDetail value)
        {
            bool res = await userRepository.UpdateUserDeatilAsync(uname, value);

            if (res)
                return Ok("Updated Successfully");
            else
                return BadRequest("Something Went Wrong");
        }
        */
        [Route("api/[controller]/status/{id}")]
        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {
            bool res = await loanRepository.UpdateLoanStatusAsync(id, value);

            if (res)
                return Ok("Updated Successfully");
            else
                return BadRequest("Something Went Wrong");
        }

        /*[Route("api/[controller]/comment/{id}")]
        [HttpPut]
        public async Task<IActionResult> Put(long id, [FromBody] string value)
        {
            bool res = await loanRepository.UpdateLoanCommentAsync((int)id, value);

            if (res)
                return Ok("Updated Successfully");
            else
                return BadRequest("Something Went Wrong");
        }
    }*/
    }
}
