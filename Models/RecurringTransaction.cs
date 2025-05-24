using finance_tracker_iteration_0_dotnet_mvc.Enums;

namespace finance_tracker_iteration_0_dotnet_mvc.Models
{
    public class RecurringTransaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Frequency Frequency { get; set; }

        public void SetRecurrence() { }
        public void ModifyRecurrence() { }
    }
}