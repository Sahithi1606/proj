using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DrugCRUD.Models;

namespace DrugCRUD.Controllers
{
    public class MyDrugsController : Controller
    {
        private DrugRegEntities db = new DrugRegEntities();

        // GET: MyDrugs
        public ActionResult Index()
        {
            return View(db.MyDrugs.ToList());
        }

        // GET: MyDrugs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyDrug myDrug = db.MyDrugs.Find(id);
            if (myDrug == null)
            {
                return HttpNotFound();
            }
            return View(myDrug);
        }

        // GET: MyDrugs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyDrugs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Drug_ID,Short_Name,Long_name,Description,Chemical_analysis")] MyDrug myDrug)
        {
            if (ModelState.IsValid)
            {
                db.MyDrugs.Add(myDrug);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(myDrug);
        }

        // GET: MyDrugs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyDrug myDrug = db.Drugs.Find(id);
            if (myDrug == null)
            {
                return HttpNotFound();
            }
            return View(myDrug);
        }

        // POST: MyDrugs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Drug_ID,Short_Name,Long_name,Description,Chemical_analysis")] MyDrug myDrug)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myDrug).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myDrug);
        }

        // GET: MyDrugs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyDrug myDrug = db.MyDrugs.Find(id);
            if (myDrug == null)
            {
                return HttpNotFound();
            }
            return View(myDrug);
        }

        // POST: MyDrugs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyDrug myDrug = db.MyDrugs.Find(id);
            db.MyDrugs.Remove(myDrug);
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
