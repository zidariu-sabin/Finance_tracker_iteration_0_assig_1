using finance_tracker_iteration_0_dotnet_mvc.Enums;

namespace finance_tracker_iteration_0_dotnet_mvc.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; } = string.Empty;
        public NotificationStatus Status { get; set; }
        public string Type { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }

        public void MarkAsRead() => Status = NotificationStatus.Read;
    }
}