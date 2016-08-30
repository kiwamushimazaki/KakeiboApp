using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KakeiboApp.Models;

namespace KakeiboApp.Controllers
{
    public class IncomesController : Controller
    {
        private IncomeContext db = new IncomeContext();

        // GET: Incomes
        public ActionResult Index()
        {

            if (User.Identity.Name == "")
            {
                return RedirectToAction("Login", "Account");
            }

            return View(db.Incomes.Where(s => s.UserName == User.Identity.Name).ToList());
        }
        // GET: Incomes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Incomes/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Name,Date,Price,Memo")] Income income)
        {
            if (ModelState.IsValid)
            {
                db.Incomes.Add(income);
                income.UserName = User.Identity.Name;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(income);
        }

        // GET: Incomes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Income income = db.Incomes.Find(id);
            if (income == null)
            {
                return HttpNotFound();
            }
            return View(income);
        }

        // POST: Incomes/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Name,Date,Price,Memo")] Income income)
        {
            if (ModelState.IsValid)
            {
                db.Entry(income).State = EntityState.Modified;
                income.UserName = User.Identity.Name;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(income);
        }

        // GET: Incomes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Income income = db.Incomes.Find(id);
            if (income == null)
            {
                return HttpNotFound();
            }
            return View(income);
        }

        // POST: Incomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Income income = db.Incomes.Find(id);
            db.Incomes.Remove(income);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
