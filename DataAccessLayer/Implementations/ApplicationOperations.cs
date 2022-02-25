using DataAccessLayer.DataContext;
using DataAccessLayer.Interfaces;
using SchoolApi.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementations
{
    public class ApplicationOperations : IApplicationOperations
    {
        public async Task<Application> AddFullApplication(long gradeId, long applicationStatusId, int schoolYear, string firstName, string surname, DateTime birthdate, string email, string contactNumber)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    using (var transaction = await context.Database.BeginTransactionAsync())
                    {
                        //Transaction try-catch
                        try
                        {
                            var applicant = new Applicant
                            {
                                Name = firstName,
                                Surname = surname,
                                BirthDate = birthdate,
                                ContactEmail = email,
                                ContactNumber = contactNumber,
                            };
                            var trackingApplicant = await context.Applicants.AddAsync(applicant);
                            //Get new applicant PK
                            await context.SaveChangesAsync();

                            var application = new Application
                            {
                                ApplicantId = applicant.Id,
                                ApplicationStatusId = applicationStatusId,
                                GradeId = gradeId,
                                SchoolYear = schoolYear,
                            };
                            var trackingApplication = await context.Applications.AddAsync(application);
                            await context.SaveChangesAsync();

                            //Confirm changes
                            await transaction.CommitAsync();
                            application.Applicant = applicant;
                            return application;
                        }
                        catch
                        {
                            await transaction.RollbackAsync();
                            throw;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
