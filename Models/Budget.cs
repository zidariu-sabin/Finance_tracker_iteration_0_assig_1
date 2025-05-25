namespace finance_tracker_iteration_0_dotnet_mvc.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int Month { get; set; }
        public int Year { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public void CheckIfExceeded() { }
        public void Create() { }
        public void Edit() { }
        public void Delete() { }
    }
}