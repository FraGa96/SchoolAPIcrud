using DataAccessLayer.CRUD;
using DataAccessLayer.Implementations;
using DataAccessLayer.Interfaces;
using SchoolApi.ApplicationLayer.Services.Interfaces;
using SchoolApi.ApplicationLayer.Services.Models;
using SchoolApi.ApplicationLayer.Services.Models.Applicant;
using SchoolApi.DataAccessLayer.Entities;
using SchoolApi.DataAccessLayer.Interfaces;

namespace SchoolApi.ApplicationLayer.Services.Implementations
{
    public class ApplicationService : IApplicationService
    {
        private ICRUD _crud = new CRUD();
        private IApplicationOperations _applicationOperations = new ApplicationOperations();

        public async Task<GenericResultView<ApplicationApplicantViewModel>> AddApplicationApplicant(long gradeId, long applicationStatusId, int schoolYear, string name, string surname, DateTime birthday, string email, string contactNumber)
        {
            GenericResultView<ApplicationApplicantViewModel> result = new GenericResultView<ApplicationApplicantViewModel>();
            result.ResultSet = new ApplicationApplicantViewModel();
            try
            {
                Application applicationAdded = await _applicationOperations.AddFullApplication(gradeId, applicationStatusId, schoolYear, name, surname, birthday, email, contactNumber);

                //Manual mapping
                result.ResultSet.ApplicantResultSet = new ApplicantViewModel
                {
                    Id = applicationAdded.Applicant.Id,
                    Name = applicationAdded.Applicant.Name,
                    Surname = applicationAdded.Applicant.Surname,
                    Birthday = applicationAdded.Applicant.BirthDate,
                    Email = applicationAdded.Applicant.ContactEmail,
                    Phone = applicationAdded.Applicant.ContactNumber,
                    SubmissionDate = applicationAdded.Applicant.CreationDate,
                };

                result.ResultSet.ApplicationResultSet = new ApplicationViewModel
                {
                    Id = applicationAdded.Applicant.Id,
                    ApplicantId = applicationAdded.ApplicantId,
                    GradeId = applicationAdded.GradeId,
                    StatusId = applicationAdded.ApplicationStatusId,
                    SchoolYear = applicationAdded.SchoolYear,
                    SubmissionDate = applicationAdded.CreationDate,
                };

                //Set success result
                result.UserMessage = String.Format("The supplied application for {0} was added successfully", name);
                result.InternalMessage = "MyAPI.Application.Implementation.ApplicationService: AddApplicationApplicant() method executed successfully";
                result.Success = true;
            }
            catch (Exception ex)
            {
                //Set failed result
                result.Exception = ex;
                result.UserMessage = "We failed to register your information for the application supplied";
                result.InternalMessage = String.Format("MyAPI.Application.Implementation.ApplicationService:: AddApplicationApplicant(): {0}", ex.Message);
            }
            return result;
        }

        public async Task<GenericResultView<ApplicationViewModel>> GetApplicationById(long applicationId)
        {
            GenericResultView<ApplicationViewModel> result = new GenericResultView<ApplicationViewModel>();
            try
            {
                Application applicationFound = await _crud.Read<Application>(applicationId);

                //Manual mapping
                ApplicationViewModel applicationReturned = new ApplicationViewModel
                {
                    Id = applicationFound.Id,
                    ApplicantId = applicationFound.ApplicantId,
                    GradeId = applicationFound.GradeId,
                    StatusId = applicationFound.ApplicationStatusId,
                    SchoolYear = applicationFound.SchoolYear,
                    SubmissionDate = applicationFound.CreationDate,
                };

                //Set success result
                result.UserMessage = "The application was obtained successfully";
                result.InternalMessage = "MyAPI.Application.Implementation.ApplicationService: GetApplicationById() method executed successfully";
                result.ResultSet = applicationReturned;
                result.Success = true;
            }
            catch (Exception ex)
            {
                //Set failed result
                result.Exception = ex;
                result.UserMessage = "We failed to obtain the application supplied";
                result.InternalMessage = String.Format("MyAPI.Application.Implementation.ApplicationService:: GetApplicationById(): {0}", ex.Message);
            }
            return result;
        }

        public Task<GenericResultView<List<ApplicationViewModel>>> GetApplicationsByApplicantId(long applicant)
        {
            throw new NotImplementedException();
        }

        public async Task<GenericResultView<ApplicationViewModel>> UpdateApplication(long applicationId, long gradeId, long applicationStatusId, int schoolYear, long applicantId)
        {
            GenericResultView<ApplicationViewModel> result = new GenericResultView<ApplicationViewModel>();
            try
            {
                Application application = new Application
                {
                    Id = applicationId,
                    ApplicantId = applicantId,
                    GradeId = gradeId,
                    ApplicationStatusId = applicationStatusId,
                    SchoolYear = schoolYear,
                    ModifiedDate = DateTime.UtcNow,
                };

                application = await _crud.Update(application, applicationId);

                //Manual mapping
                ApplicationViewModel applicationUpdated = new ApplicationViewModel
                {
                    Id = application.Id,
                    ApplicantId = application.ApplicantId,
                    GradeId = application.GradeId,
                    StatusId = application.ApplicationStatusId,
                    SchoolYear = application.SchoolYear,
                    SubmissionDate = application.CreationDate,
                };

                //Set success result
                result.UserMessage = "The supplied application was updated successfully";
                result.InternalMessage = "MyAPI.Application.Implementation.ApplicationService: UpdateApplication() method executed successfully";
                result.ResultSet = applicationUpdated;
                result.Success = true;
            }
            catch (Exception ex)
            {
                //Set failed result
                result.Exception = ex;
                result.UserMessage = "We failed to update the application supplied";
                result.InternalMessage = String.Format("MyAPI.Application.Implementation.ApplicationService: UpdateApplication(): {0}", ex.Message);
            }
            return result;
        }
    }
}
