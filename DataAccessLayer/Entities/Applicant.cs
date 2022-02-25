namespace SchoolApi.DataAccessLayer.Entities
{
    public class Applicant
    {
        public Int64 Id { get; set; }

        public String Name { get; set; }

        public String Surname { get; set; }

        public DateTime BirthDate { get; set; } 

        public String ContactEmail { get; set; }

        public String ContactNumber { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }


        //An applicant can have many applications, the could applay every year and never get in
        //An Application though belongs to only 1 applicant at a time
        public ICollection<Application> Applications { get; set; }
    }
}
