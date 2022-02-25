namespace SchoolApi.ApplicationLayer.Services.Models.Applicant
{
    public class ApplicationViewModel
    {
        public Int64 Id { get; set; }

        public Int64 ApplicantId { get; set; }

        public Int64 GradeId { get; set; }

        public Int64 StatusId { get; set; }

        public DateTime SubmissionDate { get; set; }

        public Int32 SchoolYear { get; set; }
    }
}
