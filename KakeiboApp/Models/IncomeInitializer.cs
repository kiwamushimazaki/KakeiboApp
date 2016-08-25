using System.Data.Entity;

namespace KakeiboApp.Models
{
    public class IncomeInitializer : CreateDatabaseIfNotExists<IncomeContext>
    {
        protected override void Seed(IncomeContext context)
        {

        }
    }
}