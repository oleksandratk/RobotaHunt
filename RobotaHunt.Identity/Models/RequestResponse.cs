namespace RobotaHunt.Identity.Models
{
    public class RequestResponse
    {
        public RequestResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }

    }
}