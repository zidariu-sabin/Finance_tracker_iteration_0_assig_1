using finance_tracker_iteration_0_dotnet_mvc.Enums;
using System.ComponentModel.DataAnnotations;

namespace finance_tracker_iteration_0_dotnet_mvc.Models
{
    public class Card
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [Required]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Card number must be exactly 16 digits.")]
        public string CardNumber { get; set; } = string.Empty;
        public Currency Currency { get; set; }
        public string Holder { get; set; } = string.Empty;
        public DateTime Expiry { get; set; }
        public string Cvv { get; set; } = string.Empty;

        public ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();

        public void Validate() { }
        public void Create() { }
        public void Edit() { }
        public void Delete() { }
    }
}