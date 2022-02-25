using SchoolApi.ApplicationLayer.Services.Models;
using SchoolApi.ApplicationLayer.Services.Models.Applicant;

namespace SchoolApi.ApplicationLayer.Services.Interfaces
{
    public interface IApplicantService
    {
        Task<GenericResultView<ApplicantViewModel>> AddApplicant(string name, string surname, DateTime birthday, string email, string phoneNumber);

        Task<GenericResultView<ApplicantViewModel>> GetApplicantById(Int64 applicantId);

        Task<GenericResultView<ApplicantViewModel>> UpdateApplicant(Int64 applicantId, string name, string surname, DateTime birthday, string email, string phoneNumber);
    }
}
