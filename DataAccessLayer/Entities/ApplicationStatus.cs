namespace SchoolApi.DataAccessLayer.Entities
{
    public class ApplicationStatus
    {
        public Int64 Id { get; set; }

        public String Name { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }


        //An application status can be applied to multiple applications
        //An Application can only have one application status at a time
        public ICollection<Application> Applications { get; set; }
    }
}
