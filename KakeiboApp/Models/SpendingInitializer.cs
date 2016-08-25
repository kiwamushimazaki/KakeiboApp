using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace KakeiboApp.Models
{
    public class SpendingInitializer : CreateDatabaseIfNotExists<SpendingContext>
    {
        protected override void Seed(SpendingContext context)
        {

        }
    }
}