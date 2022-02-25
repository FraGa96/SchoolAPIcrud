namespace SchoolApi.ApplicationLayer.Services.Models.Applicant
{
    public class ApplicantViewModel
    {
        public Int64 Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

        public String Email { get; set; }

        public String Phone { get; set; }

        public DateTime SubmissionDate { get; set; }
    }
}
