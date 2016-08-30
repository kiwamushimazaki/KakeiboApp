using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KakeiboApp.Models
{
    public class Data
    {
        public class Spending
        {
            public string UserName { get; set; }
            public int SpendingSum { get; set; }
            public int IncomeSum { get; set; }
        }
    }
}