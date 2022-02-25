using DataAccessLayer.CRUD;
using SchoolApi.ApplicationLayer.Services.Interfaces;
using SchoolApi.ApplicationLayer.Services.Models;
using SchoolApi.ApplicationLayer.Services.Models.Applicant;
using SchoolApi.DataAccessLayer.Entities;
using SchoolApi.DataAccessLayer.Interfaces;

namespace SchoolApi.ApplicationLayer.Services.Implementations
{
    public class ApplicationStatusService : IApplicationStatusService
    {
        private ICRUD _crud = new CRUD();

        public async Task<GenericResultView<ApplicationStatusViewModel>> AddApplicationStatus(string name)
        {
            GenericResultView<ApplicationStatusViewModel> result = new GenericResultView<ApplicationStatusViewModel>();
            try
            {
                ApplicationStatus appStatus = new ApplicationStatus
                {
                    Name = name
                };

                appStatus = await _crud.Create<ApplicationStatus>(appStatus);

                //Manual mapping
                ApplicationStatusViewModel appStatusAdded = new ApplicationStatusViewModel
                {
                    Id = appStatus.Id,
                    Name = appStatus.Name,
                };

                //Set success result
                result.UserMessage = String.Format("The supplied application status {0} was added successfully", name);
                result.InternalMessage = "MyAPI.Application.Implementation.ApplicationStatusService: AddApplicationStatus() method executed successfully";
                result.ResultSet = appStatusAdded;
                result.Success = true;
            }
            catch (Exception ex)
            {
                //Set failed result
                result.Exception = ex;
                result.UserMessage = "We failed to register your information for the application status supplied";
                result.InternalMessage = String.Format("MyAPI.Application.Implementation.ApplicationStatusService:: AddApplicationStatus(): {0}", ex.Message);
            }
            return result;
        }

        public async Task<GenericResultView<List<ApplicationStatusViewModel>>> GetAllApplicationStatuses()
        {
            GenericResultView<List<ApplicationStatusViewModel>> result = new GenericResultView<List<ApplicationStatusViewModel>>();
            try
            {
                List<ApplicationStatus> appStatuses = await _crud.ReadAll<ApplicationStatus>();
                //Map
                result.ResultSet = new List<ApplicationStatusViewModel>();
                appStatuses.ForEach(appStatus => result.ResultSet.Add(new ApplicationStatusViewModel
                {
                    Id = appStatus.Id,
                    Name = appStatus.Name
                }));
                //Set success result
                result.UserMessage = "Application statuses obtained successfully";
                result.InternalMessage = "MyAPI.Application.Implementation.ApplicationStatusService: GetAllApplicationStatuses() method executed successfully";
                result.Success = true;
            }
            catch (Exception ex)
            {
                //Set failed result
                result.Exception = ex;
                result.UserMessage = "We failed fetch all the required application statuses";
                result.InternalMessage = String.Format("MyAPI.Application.Implementation.ApplicationStatusService: GetAllApplicationStatuses(): {0}", ex.Message);
            }
            return result;
        }

        public async Task<GenericResultView<ApplicationStatusViewModel>> UpdateApplicationStatus(long statusId, string name)
        {
            GenericResultView<ApplicationStatusViewModel> result = new GenericResultView<ApplicationStatusViewModel>();
            try
            {
                ApplicationStatus appStatus = new ApplicationStatus
                {
                    Id = statusId,
                    Name = name,
                    ModifiedDate = DateTime.UtcNow,
                };

                appStatus = await _crud.Update<ApplicationStatus>(appStatus, statusId);

                //Manual mapping
                ApplicationStatusViewModel appStatusUpdated = new ApplicationStatusViewModel
                {
                    Id = appStatus.Id,
                    Name = appStatus.Name,
                };

                //Set success result
                result.UserMessage = String.Format("The supplied application status {0} was updated successfully", name);
                result.InternalMessage = "MyAPI.Application.Implementation.ApplicationStatusService: UpdateApplicationStatus() method executed successfully";
                result.ResultSet = appStatusUpdated;
                result.Success = true;
            }
            catch (Exception ex)
            {
                //Set failed result
                result.Exception = ex;
                result.UserMessage = "We failed to update the grade supplied";
                result.InternalMessage = String.Format("MyAPI.Application.Implementation.ApplicationStatusService: UpdateApplicationStatus(): {0}", ex.Message);
            }
            return result;
        }
    }
}
