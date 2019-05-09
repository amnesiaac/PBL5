using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PBL5;

namespace PBL5.Controllers
{
    public class DoençaController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Doença
        public ActionResult Index()
        {
            return View(db.DoençaSet.ToList());
        }

        // GET: Doença/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doença doença = db.DoençaSet.Find(id);
            if (doença == null)
            {
                return HttpNotFound();
            }
            return View(doença);
        }

        // GET: Doença/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doença/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] Doença doença)
        {
            if (ModelState.IsValid)
            {
                db.DoençaSet.Add(doença);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doença);
        }

        // GET: Doença/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doença doença = db.DoençaSet.Find(id);
            if (doença == null)
            {
                return HttpNotFound();
            }
            return View(doença);
        }

        // POST: Doença/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] Doença doença)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doença).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doença);
        }

        // GET: Doença/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doença doença = db.DoençaSet.Find(id);
            if (doença == null)
            {
                return HttpNotFound();
            }
            return View(doença);
        }

        // POST: Doença/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doença doença = db.DoençaSet.Find(id);
            db.DoençaSet.Remove(doença);
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
