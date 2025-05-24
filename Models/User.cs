using Microsoft.AspNetCore.Identity;

namespace finance_tracker_iteration_0_dotnet_mvc.Models
{
    // Make sure User inherits from IdentityUser<int> to use int as the key type
    public class User : IdentityUser<int>
    {
        // Navigation properties
        public ICollection<Transaction> Transactions { get; set; } = [];
        public ICollection<Budget> Budgets { get; set; } = [];
        public ICollection<Notification> Notifications { get; set; } = [];
        public ICollection<PaymentMethod> PaymentMethods { get; set; } = [];
        public ICollection<Card> Cards { get; set; } = [];
        public ICollection<Category> Categories { get; set; } = [];
        // Add missing navigation property for Locations
        public ICollection<Location> Locations { get; set; } = [];

        public void Register() { }
        public void Login() { }
        public void Logout() { }
        public void ResetPassword() { }
        public void UpdateProfile() { }
    }
}