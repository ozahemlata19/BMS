using AutoMapper;
using BMSAPI.Controllers;
using BMSAPI.Model.Domains;
using BMSAPI.Model.DTO;
using BMSAPI.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSTest
{
    [TestFixture]
    class ApplyLoanControllerTest
    {

        private Mock<IApplyLoanRepository> applyLoanRepository;
        private ApplyLoanController applyLoanController;
        private LoanDetail loanDetail_one;
        private Mock<IMapper> mapper;

        public ApplyLoanControllerTest()
        {
            loanDetail_one = new LoanDetail()
            {
                LoanId = 1,
                LoanAmount = 100000,
                LoanDate = new DateTime(2022, 1, 1),
                LoanDuration = 6,
                LoanType = "Car",
                RateOfInterest = 10,
                Status = "Pending",
                UserName = "test"
            };

        }

        [SetUp]
        public void Setup()
        {
            applyLoanRepository = new Mock<IApplyLoanRepository>();
            mapper = new Mock<IMapper>();
            applyLoanController = new ApplyLoanController(applyLoanRepository.Object, mapper.Object);
        }

        [Test]
        public void CallRequest_VerifyGetByIdInvoked()
        {
            applyLoanRepository.Setup(x => x.GetLoanAsync(It.IsAny<int>()))
                .ReturnsAsync(new LoanDetail()
                {
                    LoanId = loanDetail_one.LoanId,
                    LoanAmount = loanDetail_one.LoanAmount,
                    LoanDate = loanDetail_one.LoanDate,
                    LoanDuration = loanDetail_one.LoanDuration,
                    LoanType = loanDetail_one.LoanType,
                    RateOfInterest = loanDetail_one.RateOfInterest,
                    Status = loanDetail_one.Status,
                    UserName = loanDetail_one.UserName

                });

            mapper.Setup(x => x.Map<LoanDetail, LoanDetailDTO>(It.IsAny<LoanDetail>()))
                .Returns((LoanDetail loan) => new LoanDetailDTO { LoanId = loan.LoanId });

            _ = applyLoanController.Get(loanDetail_one.LoanId);
            applyLoanRepository.Verify(x => x.GetLoanAsync(loanDetail_one.LoanId), Times.Once);
        }

        [Test]
        public void CallRequest_VerifyPost_Success()
        {
            applyLoanRepository.Setup(x => x.SaveLoanDetailAsync(It.IsAny<LoanDetail>()))
                .ReturnsAsync(true);

            var res = applyLoanController.Post(loanDetail_one);

            Assert.AreEqual(true, res.IsCompleted);

        }
    }
}

