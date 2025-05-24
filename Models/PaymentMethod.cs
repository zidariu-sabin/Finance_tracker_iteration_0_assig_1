using finance_tracker_iteration_0_dotnet_mvc.Enums;
namespace finance_tracker_iteration_0_dotnet_mvc.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public string Name { get; set; }
        public PaymentMethodType Type { get; set; }
        public int? CardId { get; set; }
        public Card? Card { get; set; }

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

        public void Create() { }
        public void Edit() { }
        public void Delete() { }
    }
}