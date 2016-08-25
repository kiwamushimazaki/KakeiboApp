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
    public class SpendingsController : Controller
    {
        private SpendingContext db = new SpendingContext();

        // GET: Spendings
        public ActionResult Index()
        {
            return View(db.Spendings.Where(s => s.UserName == User.Identity.Name).ToList());
        }

        // GET: Spendings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Spendings/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Name,Date,Price,Memo")] Spending spending)
        {
            if (ModelState.IsValid)
            {
                db.Spendings.Add(spending);
                spending.UserName = User.Identity.Name;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(spending);
        }

        // GET: Spendings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spending spending = db.Spendings.Find(id);
            if (spending == null)
            {
                return HttpNotFound();
            }
            return View(spending);
        }

        // POST: Spendings/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Name,Date,Price,Memo")] Spending spending)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spending).State = EntityState.Modified;
                spending.UserName = User.Identity.Name;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(spending);
        }

        // GET: Spendings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spending spending = db.Spendings.Find(id);
            if (spending == null)
            {
                return HttpNotFound();
            }
            return View(spending);
        }

        // POST: Spendings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Spending spending = db.Spendings.Find(id);
            db.Spendings.Remove(spending);
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
