using Microsoft.AspNetCore.Mvc;
using SchoolApi.ApplicationLayer.Services.Interfaces;
using SchoolApi.Models.Grade;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddGrade(GradeRequest grade)
        {
            var result = await _gradeService.AddSingleGrade(grade.Name, grade.GradeNumber, grade.Capacity);
            if (result.Success)
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
        public async Task<IActionResult> GetAllGrades()
        {
            var result = await _gradeService.GetAllGrades();
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
        public async Task<IActionResult> UpdateGrade(GradeUpdateRequest grade)
        {
            var result = await _gradeService.UpdateGrade(grade.Id, grade.Name, grade.GradeNumber, grade.Capacity);
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
