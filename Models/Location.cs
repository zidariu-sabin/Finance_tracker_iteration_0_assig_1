
namespace finance_tracker_iteration_0_dotnet_mvc.Models
{
    public class Location
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

        public void Create() { }
        public void Edit() { }
        public void Delete() { }
    }
}