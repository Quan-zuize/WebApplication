namespace WebApplication2.Models
{
    public class Mail
    {
        public int mailId { get; set; }
        public string From { get; set; }
        public string Password { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}