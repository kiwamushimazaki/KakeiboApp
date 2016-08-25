using System.Data.Entity;

namespace KakeiboApp.Models
{
    public class IncomeContext : DbContext
    {
        public DbSet<Income> Incomes { get; set; }
    }
}