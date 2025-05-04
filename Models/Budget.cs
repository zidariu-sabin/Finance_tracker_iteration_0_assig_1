using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace finance_tracker_iteration_0_dotnet_mvc.Models
{
    public class Budget
    {
        [Key]
        public int BudgetId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int Value { get; set; }

        [EnumDataType(typeof(BudgetFrequency))]
        public BudgetFrequency Frequency { get; set; }

        public string Description { get; set; }
    }
}
