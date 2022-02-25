using SchoolApi.ApplicationLayer.Services.Models;
using SchoolApi.ApplicationLayer.Services.Models.Applicant;

namespace SchoolApi.ApplicationLayer.Services.Interfaces
{
    public interface IApplicationStatusService
    {
        Task<GenericResultView<ApplicationStatusViewModel>> AddApplicationStatus(string name);

        Task<GenericResultView<List<ApplicationStatusViewModel>>> GetAllApplicationStatuses();

        Task<GenericResultView<ApplicationStatusViewModel>> UpdateApplicationStatus(Int64 statusId, string name);
    }
}
