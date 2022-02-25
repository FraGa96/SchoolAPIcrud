namespace SchoolApi.DataAccessLayer.Entities
{
    public class Application
    {
        public Int64 Id { get; set; } //PK

        public Int64 ApplicantId { get; set; } //FK

        public Int64 GradeId { get; set; } //FK

        public Int64 ApplicationStatusId { get; set; } //FK

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public Int32 SchoolYear { get; set; } //The year they applying to stat at the school for

        //Each application belongs to a specific applicant
        public Applicant Applicant { get; set; }

        //Each application is applying for a specific grade
        public Grade Grade { get; set; }

        //Eac application is in one status at a time
        //The status can be changed
        //but it can only never be linked to 1 at a time within an application: ApplicationStatusID
        public ApplicationStatus ApplicationStatus { get; set; }
    }
}
