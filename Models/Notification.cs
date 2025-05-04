using System.ComponentModel.DataAnnotations;

namespace finance_tracker_iteration_0_dotnet_mvc.Models

{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        public bool Status { get; set; }

        public DateTime CreationDate { get; set; }

        [EnumDataType(typeof(NotificationTopic))]
        public NotificationTopic Topic { get; set; }

        public string RecordId { get; set; }

        public string Message { get; set; }
    }
}
