using System.ComponentModel.DataAnnotations;

namespace finance_tracker_iteration_0_dotnet_mvc.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }
        public virtual ICollection<RecurringTransaction> RecurringTransactions
        {
            get; set;
        }
    }
}
