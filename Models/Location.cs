using System.ComponentModel.DataAnnotations;

namespace finance_tracker_iteration_0_dotnet_mvc.Models
{
    public class Location
    {

        [Key]
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
