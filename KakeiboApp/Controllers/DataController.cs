using System.Linq;
using System.Web.Mvc;
using KakeiboApp.Models;
using System.Data;
using System.Collections.Generic;


namespace KakeiboApp.Controllers
{
    public class DataController : Controller
    {
        private SpendingContext dbs = new SpendingContext();
        private IncomeContext dbi = new IncomeContext();
        // GET: Data
        public ActionResult index()
        {
            var spendingsum = from a in dbs.Spendings
                              where a.UserName == User.Identity.Name
                              group a by a.UserName into agroup
                              select new
                              {
                                  UserName = agroup.Key,
                                  TotalSum = agroup.Sum(a => a.Price)
                              };
            var incomesum = from a in dbi.Incomes
                            where a.UserName == User.Identity.Name
                            group a by a.UserName into agroup
                            select new
                            {
                                UserName = agroup.Key,
                                TotalSum = agroup.Sum(a => a.Price)
                            };

            var spsum = spendingsum.FirstOrDefault();
            var insum = incomesum.FirstOrDefault();

            if(User.Identity.Name == "")
            {
                return RedirectToAction("Login", "Account");
            }

            var Data = new Dictionary<string, int>
            {
                {"sp" , spsum.TotalSum },
                {"ic" , insum.TotalSum }
            };
            return View(Data);
        }
        //public ActionResult IncomeSum()
        //{
        //    var incomesum = from a in dbi.Incomes
        //                    where a.UserName == User.Identity.Name
        //                    group a by a.UserName into agroup
        //                    select new
        //                    {
        //                        UserName = agroup.Key,
        //                        TotalSum = agroup.Sum(a => a.Price)
        //                    };
        //    return View(incomesum);
        //}

    }
}
