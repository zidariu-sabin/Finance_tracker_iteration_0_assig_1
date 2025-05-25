using finance_tracker_iteration_0_dotnet_mvc.Enums;

namespace finance_tracker_iteration_0_dotnet_mvc.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public int Amount { get; set; }
        public Currency Currency { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }


        public int? PaymentMethodId { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }

        public int LocationId { get; set; }
        public Location? Location { get; set; } = null!;

        public DateTime Date { get; set; }

        public void Create() { }
        public void Edit() { }
        public void Delete() { }
    }
}