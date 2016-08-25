using System.Web.Mvc;
using KakeiboApp.Models;
using System.Diagnostics;

namespace KakeiboApp.Controllers
{
    public class BginController : Controller
    {
        private SpendingContext db = new SpendingContext();
        private IncomeContext dbi = new IncomeContext();

        public ActionResult List()
        {
            return View(db.Spendings);
        }
        public ActionResult IncomeList()
        {
            return View(dbi.Incomes);
        }
    }
}