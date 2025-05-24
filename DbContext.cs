using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using finance_tracker_iteration_0_dotnet_mvc.Models;

namespace finance_tracker_iteration_0_dotnet_mvc
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; } = null!;
        public DbSet<Budget> Budgets { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public DbSet<Card> Cards { get; set; } = null!;
        public DbSet<Location> Locations { get; set; } = null!;
        public DbSet<Notification> Notifications { get; set; } = null!;
        public DbSet<RecurringTransaction> RecurringTransactions { get; set; } = null!;

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             base.OnModelCreating(modelBuilder);

            // Fix table name to match EF Core's default pluralization
            modelBuilder.Entity<User>().ToTable("AspNetUsers");

            // Configure the Budget-Category relationship
            modelBuilder.Entity<Budget>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Budgets)
                .HasForeignKey(b => b.CategoryId)
                .IsRequired(false); // No cascade delete

            // Configure the Budget-User relationship
            modelBuilder.Entity<Budget>()
                .HasOne(b => b.User)
                .WithMany(u => u.Budgets)
                .HasForeignKey(b => b.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction); // No cascade delete

            // Configure the PaymentMethod-User relationship
            modelBuilder.Entity<Card>()
                .HasOne<User>()
                .WithMany(u => u.Cards)
                .HasForeignKey("UserId")
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction); // No cascade delete

            // Configure the PaymentMethod-Card relationship
            modelBuilder.Entity<PaymentMethod>()
                .HasOne(p => p.Card)
                .WithMany(c => c.PaymentMethods)
                .HasForeignKey(p => p.CardId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction); // No cascade delete

            modelBuilder.Entity<PaymentMethod>()
                .HasOne(p => p.User)
                .WithMany(u => u.PaymentMethods)
                .HasForeignKey(p => p.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            // Configure the Transaction-Category relationship
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CategoryId)
                .IsRequired(false); // No cascade delete

            // Configure the Transaction-PaymentMethod relationship
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.PaymentMethod)
                .WithMany(p => p.Transactions)
                .HasForeignKey(t => t.PaymentMethodId)
                .IsRequired(false); // No cascade delete

            // Configure the Transaction-Location relationship
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Location)
                .WithMany(l => l.Transactions)
                .HasForeignKey(t => t.LocationId)
                .IsRequired(); // No cascade delete

            // Configure the Transaction-User relationship
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(t => t.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction); // No cascade delete
                
            // Configure Location-User relationship
            modelBuilder.Entity<Location>()
                .HasOne<User>()
                .WithMany(u => u.Locations)
                .HasForeignKey("UserId")
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction); // No cascade delete
                
            // Configure Card-User relationship if needed
            modelBuilder.Entity<Card>()
                .HasOne<User>()
                .WithMany(u => u.Cards)
                .HasForeignKey("UserId")
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction); // No cascade delete

            // Configure Category-User relationship
            modelBuilder.Entity<Category>()
                .HasOne<User>()
                .WithMany(u => u.Categories)
                .HasForeignKey("UserId")
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction); // No cascade delete
                
            // Configure Notification-User relationship
            modelBuilder.Entity<Notification>()
                .HasOne<User>()
                .WithMany(u => u.Notifications)
                .HasForeignKey("UserId")
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}   