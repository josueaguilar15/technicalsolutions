namespace TechnicalSolution.WEB.Models
{
    public class ErrorDetails
    {
        public string TraceId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Errors { get; set; }
    }

    public class StatusOperation
    {
        public ErrorDetails Error { get; set; }
        public bool IsError { get; set; }
    }
}
