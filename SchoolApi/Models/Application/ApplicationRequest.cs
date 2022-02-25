using SchoolApi.Models.Applicant;

namespace SchoolApi.Models.Application
{
    public class ApplicationRequest
    {
        public long ApplicantId { get; set; }

        public long GradeId { get; set; }

        public long ApplicationStatusId { get; set; }

        public int SchoolYear { get; set; }

        public ApplicantRequest Applicant { get; set; }
    }
}
