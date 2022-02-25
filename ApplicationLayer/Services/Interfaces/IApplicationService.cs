using SchoolApi.ApplicationLayer.Services.Models;
using SchoolApi.ApplicationLayer.Services.Models.Applicant;

namespace SchoolApi.ApplicationLayer.Services.Interfaces
{
    public interface IApplicationService
    {
        Task<GenericResultView<ApplicationApplicantViewModel>> AddApplicationApplicant(Int64 gradeId, Int64 applicationStatusId, Int32 schoolYear, string name, string surname, DateTime birthdate, string email, string contactNumber);

        Task<GenericResultView<ApplicationViewModel>> GetApplicationById(Int64 applicationId);

        Task<GenericResultView<ApplicationViewModel>> UpdateApplication(Int64 applicationId, Int64 gradeId, Int64 applicationStatusId, Int32 schoolYear, Int64 applicantIdr);

        Task<GenericResultView<List<ApplicationViewModel>>> GetApplicationsByApplicantId(Int64 applicant);

    }
}
