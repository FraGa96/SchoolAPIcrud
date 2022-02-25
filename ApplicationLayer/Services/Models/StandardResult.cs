namespace SchoolApi.ApplicationLayer.Services.Models
{
    public class StandardResult
    {
        public bool Success {  get; set; }

        public string UserMessage { get; set; }

        internal string InternalMessage { get; set; }

        internal Exception Exception { get; set; }

        public StandardResult()
        {
            Success = false;
            UserMessage = string.Empty;
            InternalMessage = string.Empty;
            Exception = null;
        }
    }
}
