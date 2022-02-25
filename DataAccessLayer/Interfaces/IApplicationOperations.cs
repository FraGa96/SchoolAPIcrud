using SchoolApi.DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IApplicationOperations
    {
        Task<Application> AddFullApplication(Int64 gradeId, Int64 applicationStatusId, Int32 schoolYear, string firstName, string surname, DateTime birthdate, string email, string contactNumber);
    }
}
