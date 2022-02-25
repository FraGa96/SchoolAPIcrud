namespace SchoolApi.Models.Applicant
{
    public class ApplicantRequest
    {
        public String Name { get; set; }

        public String Surname { get; set; }

        public DateTime Birthday { get; set; }

        public String Email { get; set; }

        public String Phone { get; set; }
    }
}
