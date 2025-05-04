using System.ComponentModel.DataAnnotations.Schema;

namespace finance_tracker_iteration_0_dotnet_mvc.Models;

public class Transaction {
    
    public int Id { get; set; }
    public int Value { get; set; }

    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }

    [ForeignKey("WayOfPayment")]
    public int WayOfPaymentId { get; set; }
    public virtual WayOfPayment WayOfPayment { get; set; }

    [ForeignKey("Location")]
    public int LocationId { get; set; }
    public virtual Location Location { get; set; }
    public string Description { get; set; } = null!;

    public DateTime Date { get; set; } = DateTime.Now;

   
}