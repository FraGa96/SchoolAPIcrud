using DataAccessLayer.CRUD;
using SchoolApi.ApplicationLayer.Services.Interfaces;
using SchoolApi.ApplicationLayer.Services.Models;
using SchoolApi.ApplicationLayer.Services.Models.Applicant;
using SchoolApi.DataAccessLayer.Entities;
using SchoolApi.DataAccessLayer.Interfaces;

namespace SchoolApi.ApplicationLayer.Services.Implementations
{
    public class ApplicantService : IApplicantService
    {
        private ICRUD _crud = new CRUD();

        public async Task<GenericResultView<ApplicantViewModel>> AddApplicant(string name, string surname, DateTime birthday, string email, string phoneNumber)
        {
            GenericResultView<ApplicantViewModel> result = new GenericResultView<ApplicantViewModel>();
            try
            {
                Applicant applicant = new Applicant
                {
                    Name = name,
                    Surname = surname,
                    BirthDate = birthday,
                    ContactEmail = email,
                    ContactNumber = phoneNumber,
                };

                applicant = await _crud.Create<Applicant>(applicant);

                //Manual mapping
                ApplicantViewModel applicantAdded = new ApplicantViewModel
                {
                    Id = applicant.Id,
                    Name = applicant.Name,
                    Surname = applicant.Surname,
                    Birthday = applicant.BirthDate,
                    Email = applicant.ContactEmail,
                    Phone = applicant.ContactNumber,
                    SubmissionDate = applicant.CreationDate,
                };

                //Set success result
                result.UserMessage = String.Format("The supplied applicant {0} was added successfully", name);
                result.InternalMessage = "MyAPI.Application.Implementation.ApplicantService: AddApplicant() method executed successfully";
                result.ResultSet = applicantAdded;
                result.Success = true;
            }
            catch (Exception ex)
            {
                //Set failed result
                result.Exception = ex;
                result.UserMessage = "We failed to register your information for the applicant supplied";
                result.InternalMessage = String.Format("MyAPI.Application.Implementation.ApplicantService:: AddApplicant(): {0}", ex.Message);
            }
            return result;
        }

        public async Task<GenericResultView<ApplicantViewModel>> GetApplicantById(long applicantId)
        {
            GenericResultView<ApplicantViewModel> result = new GenericResultView<ApplicantViewModel>();
            try
            {
                Applicant applicant = await _crud.Read<Applicant>(applicantId);

                //Manual mapping
                ApplicantViewModel applicantFound = new ApplicantViewModel
                {
                    Id = applicant.Id,
                    Name = applicant.Name,
                    Surname = applicant.Surname,
                    Birthday = applicant.BirthDate,
                    Email = applicant.ContactEmail,
                    Phone = applicant.ContactNumber,
                    SubmissionDate = applicant.CreationDate,
                };

                //Set success result
                result.UserMessage = String.Format("The applicant {0} was obtained successfully", applicantFound.Name);
                result.InternalMessage = "MyAPI.Application.Implementation.ApplicantService: GetApplicantById() method executed successfully";
                result.ResultSet = applicantFound;
                result.Success = true;
            }
            catch (Exception ex)
            {
                //Set failed result
                result.Exception = ex;
                result.UserMessage = "We failed to register your information for the applicant supplied";
                result.InternalMessage = String.Format("MyAPI.Application.Implementation.ApplicantService:: AddApplicant(): {0}", ex.Message);
            }
            return result;
        }

        public async Task<GenericResultView<ApplicantViewModel>> UpdateApplicant(long applicantId, string name, string surname, DateTime birthday, string email, string phoneNumber)
        {
            GenericResultView<ApplicantViewModel> result = new GenericResultView<ApplicantViewModel>();
            try
            {
                Applicant applicant = new Applicant
                {
                    Id = applicantId,
                    Name = name,
                    Surname = surname,
                    BirthDate = birthday,
                    ContactEmail = email,
                    ContactNumber = phoneNumber,
                    ModifiedDate = DateTime.UtcNow,
                };

                applicant = await _crud.Update<Applicant>(applicant, applicantId);

                //Manual mapping
                ApplicantViewModel applicantUpdated = new ApplicantViewModel
                {
                    Id = applicant.Id,
                    Name = applicant.Name,
                };

                //Set success result
                result.UserMessage = String.Format("The supplied applicant {0} was updated successfully", name);
                result.InternalMessage = "MyAPI.Application.Implementation.ApplicantService: UpdateApplicant() method executed successfully";
                result.ResultSet = applicantUpdated;
                result.Success = true;
            }
            catch (Exception ex)
            {
                //Set failed result
                result.Exception = ex;
                result.UserMessage = "We failed to update the grade supplied";
                result.InternalMessage = String.Format("MyAPI.Application.Implementation.ApplicantService: UpdateApplicant(): {0}", ex.Message);
            }
            return result;
        }
    }
}
