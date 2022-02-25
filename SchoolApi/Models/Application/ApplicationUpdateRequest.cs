namespace SchoolApi.Models.Application
{
    public class ApplicationUpdateRequest : ApplicationRequest
    {
        public long Id { get; set; }

        public int StatusId { get; set; }
    }
}
