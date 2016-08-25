using System.Data.Entity;

namespace KakeiboApp.Models
{
    public class SpendingContext : DbContext
    {
        public DbSet<Spending> Spendings { get; set; }
    }
}