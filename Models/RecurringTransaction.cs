using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace finance_tracker_iteration_0_dotnet_mvc.Models
{
    public class RecurringTransaction
    {
        [Key]
        public int Id { get; set; }

        public float Value { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("WayOfPayment")]
        public int WayOfPaymentId { get; set; }
        public virtual WayOfPayment WayOfPayment { get; set; }

        [EnumDataType(typeof(RecurringFrequency))]
        public RecurringFrequency Frequency { get; set; }

        public DateTime NextDate { get; set; }
    }
}
