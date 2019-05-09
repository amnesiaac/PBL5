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
    public class RemediosController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Remedios
        public ActionResult Index()
        {
            return View(db.RemedioSet.ToList());
        }

        // GET: Remedios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Remedio remedio = db.RemedioSet.Find(id);
            if (remedio == null)
            {
                return HttpNotFound();
            }
            return View(remedio);
        }

        // GET: Remedios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Remedios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Tarja,Dosagem,Intervalo,Comprado")] Remedio remedio)
        {
            if (ModelState.IsValid)
            {
                db.RemedioSet.Add(remedio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(remedio);
        }

        // GET: Remedios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Remedio remedio = db.RemedioSet.Find(id);
            if (remedio == null)
            {
                return HttpNotFound();
            }
            return View(remedio);
        }

        // POST: Remedios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Tarja,Dosagem,Intervalo,Comprado")] Remedio remedio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(remedio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(remedio);
        }

        // GET: Remedios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Remedio remedio = db.RemedioSet.Find(id);
            if (remedio == null)
            {
                return HttpNotFound();
            }
            return View(remedio);
        }

        // POST: Remedios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Remedio remedio = db.RemedioSet.Find(id);
            db.RemedioSet.Remove(remedio);
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
