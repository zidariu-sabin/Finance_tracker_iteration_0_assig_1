namespace finance_tracker_iteration_0_dotnet_mvc.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<Budget> Budgets { get; set; } = new List<Budget>();

        public void Create() { }
        public void Edit() { }
        public void Delete() { }
    }
}