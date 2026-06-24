namespace CyberSecurityAwarenessChatbot.Models
{
    public class ActivityLog
    {
        public DateTime TimeStamp { get; set; }

        public string Action { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{TimeStamp:G} - {Action}";
        }
    }
}