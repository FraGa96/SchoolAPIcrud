using DataAccessLayer.CRUD;
using SchoolApi.ApplicationLayer.Services.Interfaces;
using SchoolApi.ApplicationLayer.Services.Models;
using SchoolApi.ApplicationLayer.Services.Models.Applicant;
using SchoolApi.DataAccessLayer.Entities;
using SchoolApi.DataAccessLayer.Interfaces;

namespace SchoolApi.ApplicationLayer.Services.Implementations
{
    public class GradeService : IGradeService
    {
        private ICRUD _crud = new CRUD();

        public async Task<GenericResultView<GradeViewModel>> AddSingleGrade(string name, int gradeNumber, int capacity)
        {
            GenericResultView<GradeViewModel> resultSet = new GenericResultView<GradeViewModel>();
            try
            {
                Grade grade = new Grade
                {
                    Name = name,
                    Number = gradeNumber,
                    Capacity = capacity,
                };

                grade = await _crud.Create<Grade>(grade);

                //Manual mapping
                GradeViewModel gradeAdded = new GradeViewModel
                {
                    Id = grade.Id,
                    Name = grade.Name,
                    Number = grade.Number,
                    Capacity = grade.Capacity,
                };

                //Set success result
                resultSet.UserMessage = String.Format("The supplied grade {0} was added successfully", name);
                resultSet.InternalMessage = "MyAPI.Application.Implementation.GradeService: AddSingleGrade() method executed successfully";
                resultSet.ResultSet = gradeAdded;
                resultSet.Success = true;
            }
            catch (Exception ex)
            {
                //Set failed result
                resultSet.Exception = ex;
                resultSet.UserMessage = "We failed to register your information for the grade supplied";
                resultSet.InternalMessage = String.Format("MyAPI.Application.Implementation.GradeService: AddSingleGrade(): {0}", ex.Message);
            }
            return resultSet;
        }

        public async Task<GenericResultView<List<GradeViewModel>>> GetAllGrades()
        {
            GenericResultView<List<GradeViewModel>> resultSet = new GenericResultView<List<GradeViewModel>>();
            try
            {
                List<Grade> grades = await _crud.ReadAll<Grade>();
                //Map
                resultSet.ResultSet = new List<GradeViewModel>();
                grades.ForEach(grade => resultSet.ResultSet.Add(new GradeViewModel
                {
                    Id = grade.Id,
                    Name = grade.Name,
                    Number = grade.Number,
                    Capacity = grade.Capacity,
                }));
                //Set success result
                resultSet.UserMessage = "Grades obtained successfully";
                resultSet.InternalMessage = "MyAPI.Application.Implementation.GradeService: GetAllGrades() method executed successfully";
                resultSet.Success = true;
            }
            catch (Exception ex)
            {
                //Set failed result
                resultSet.Exception = ex;
                resultSet.UserMessage = "We failed fetch all the required grades";
                resultSet.InternalMessage = String.Format("MyAPI.Application.Implementation.GradeService: GetAllGrades(): {0}", ex.Message);
            }
            return resultSet;
        }

        public async Task<GenericResultView<GradeViewModel>> UpdateGrade(long id, string name, int gradeNumber, int capacity)
        {
            GenericResultView<GradeViewModel> resultSet = new GenericResultView<GradeViewModel>();
            try
            {
                Grade grade = new Grade
                {
                    Id = id,
                    Name = name,
                    Number = gradeNumber,
                    Capacity = capacity,
                    ModifiedDate = DateTime.UtcNow,
                };

                grade = await _crud.Update<Grade>(grade, id);

                //Manual mapping
                GradeViewModel gradeUpdated = new GradeViewModel
                {
                    Id = grade.Id,
                    Name = grade.Name,
                    Number = grade.Number,
                    Capacity = grade.Capacity,
                };

                //Set success result
                resultSet.UserMessage = String.Format("The supplied grade {0} was updated successfully", name);
                resultSet.InternalMessage = "MyAPI.Application.Implementation.GradeService: UpdateGrade() method executed successfully";
                resultSet.ResultSet = gradeUpdated;
                resultSet.Success = true;
            }
            catch (Exception ex)
            {
                //Set failed result
                resultSet.Exception = ex;
                resultSet.UserMessage = "We failed to update the grade supplied";
                resultSet.InternalMessage = String.Format("MyAPI.Application.Implementation.GradeService: UpdateGrade(): {0}", ex.Message);
            }
            return resultSet;
        }
    }
}
