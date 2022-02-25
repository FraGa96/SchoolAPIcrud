using SchoolApi.ApplicationLayer.Services.Models;
using SchoolApi.ApplicationLayer.Services.Models.Applicant;

namespace SchoolApi.ApplicationLayer.Services.Interfaces
{
    public interface IGradeService
    {
        Task<GenericResultView<GradeViewModel>> AddSingleGrade(string name, int gradeNumber, int capacity);

        Task<GenericResultView<List<GradeViewModel>>> GetAllGrades();

        Task<GenericResultView<GradeViewModel>> UpdateGrade(Int64 id, string name, int gradeNumber, int capacity);
    }
}
