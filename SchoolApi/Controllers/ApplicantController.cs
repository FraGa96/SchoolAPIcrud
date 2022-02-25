using Microsoft.AspNetCore.Mvc;
using SchoolApi.ApplicationLayer.Services.Interfaces;
using SchoolApi.Models.Applicant;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private IApplicantService _applicantService;

        public ApplicantController(IApplicantService applicantService)
        {
            this._applicantService = applicantService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddApplicant(ApplicantRequest applicant)
        {
            var result = await _applicantService.AddApplicant(applicant.Name, applicant.Surname, applicant.Birthday, applicant.Email, applicant.Phone);
            if(result.Success)
            {
                return Ok(result);
            } 
            else
            {
                return StatusCode(500, result);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetApplicantById(long id)
        {
            var result = await _applicantService.GetApplicantById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500, result);
            }
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateApplicant(ApplicantUpdateRequest applicant)
        {
            var result = await _applicantService.UpdateApplicant(applicant.Id, applicant.Name, applicant.Surname, applicant.Birthday, applicant.Email, applicant.Phone);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500, result);
            }
        }

    }
}
