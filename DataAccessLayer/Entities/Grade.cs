namespace SchoolApi.DataAccessLayer.Entities
{
    public class Grade
    {
        public Int64 Id { get; set; }

        public String Name { get; set; }

        public Int32 Number { get; set; }

        public Int32 Capacity { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }


        //When an application is filled out, the applciant needs to specify what grate they applying for.
        //therefore a grade is linked to multiple applications
        //but application can only have one grade specified to them at a time
        public ICollection<Application> Applications { get; set; }
    }
}
