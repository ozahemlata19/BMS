using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BMSAPI.Model.Domains;
using BMSAPI.Model.DTO;
using BMSAPI.Repositories;

namespace BMSAPI.Controllers
{
    
    [ApiController]
    public class ApplyLoanController : ControllerBase
    {
        private readonly IApplyLoanRepository loanRepository;
        private readonly IMapper mapper;

        public ApplyLoanController(IApplyLoanRepository loanRepository, IMapper mapper)
        {
            this.loanRepository = loanRepository;
            this.mapper = mapper;
        }

        // GET: api/<ApplyLoanController>
        [Route("api/[controller]/{loanId}")]
        [HttpGet]
        public async Task<LoanDetailDTO> Get(int loanId)
        {
            LoanDetail loanDetail = await loanRepository.GetLoanAsync(loanId);
            LoanDetailDTO loanDetailDTO = mapper.Map<LoanDetailDTO>(loanDetail);

            return loanDetailDTO;
        }

        // GET: api/<ApplyLoanController>
        [Route("api/[controller]/all/{userName}")]
        [HttpGet]
        public async Task<List<LoanDetailDTO>> Get(string userName)
        {
            List<LoanDetail> loanDetails = await loanRepository.GetAllLoansAsync(userName);
            List<LoanDetailDTO> loanDetailDTO = mapper.Map<List<LoanDetailDTO>>(loanDetails);
            return loanDetailDTO;
        }

        // GET: api/<ApplyLoanController>
        [Route("api/[controller]/all")]
        [HttpGet]
        public async Task<List<LoanDetailDTO>> Get()
        {
            List<LoanDetail> loanDetails = await loanRepository.GetAllAdminLoanAsync();
            List<LoanDetailDTO> loanDetailDTO = mapper.Map<List<LoanDetailDTO>>(loanDetails);
            return loanDetailDTO;
        }

        // POST api/<ApplyLoanController>
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Post([FromBody] LoanDetail value)
        {
            bool response = await loanRepository.SaveLoanDetailAsync(value);

            if (response)
                return Ok("Applied Succesfully");

            return BadRequest("Something Went Wrong");

        }


    }
}
