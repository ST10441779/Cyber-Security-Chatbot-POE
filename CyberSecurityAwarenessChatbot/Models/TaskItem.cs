namespace CyberSecurityAwarenessChatbot.Models
{
    public class TaskItem
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? ReminderDate { get; set; }

        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            string status = IsCompleted
                ? "Completed"
                : "Pending";

            string reminder = ReminderDate.HasValue
                ? ReminderDate.Value.ToShortDateString()
                : "No Reminder";

            return $"{Title} | {status} | {reminder}";
        }
    }
}