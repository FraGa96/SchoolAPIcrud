namespace SchoolApi.ApplicationLayer.Services.Models
{
    public class GenericResultView<T> : StandardResult
    {
        public T ResultSet { get; set; }
    }
}
