namespace TokaWeb.APP.Models
{
    public class Response
    {
        public bool Status { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; } 
        public string ErrorMessage { get; set; } 
        public string Pathredirect { get; set; } 
    }
}