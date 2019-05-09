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
    public class CompraRemediosController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: CompraRemedios
        public ActionResult Index()
        {
            var compraRemediosSet = db.CompraRemediosSet.Include(c => c.Receita);
            return View(compraRemediosSet.ToList());
        }

        // GET: CompraRemedios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompraRemedios compraRemedios = db.CompraRemediosSet.Find(id);
            if (compraRemedios == null)
            {
                return HttpNotFound();
            }
            return View(compraRemedios);
        }

        // GET: CompraRemedios/Create
        public ActionResult Create()
        {
            ViewBag.ReceitaId = new SelectList(db.ReceitaSet, "Id", "Data");
            return View();
        }

        // POST: CompraRemedios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ReceitaId")] CompraRemedios compraRemedios)
        {
            if (ModelState.IsValid)
            {
                Receita receita = db.Receitas.Find(compraRemedios.ReceitaId);
                compraRemedios.ReceitaId = receita;
                if (receita.Remedio == "Preta")
                {
                    receita = db.ReceitaSet.Find(receita.RemedioId);
                    db.CompraRemediosSet.Remove(receita.Remedio);
                }
                receita.Remedio.Comprado == true;
                db.Entry(receita.Remedio).State = EntityState.Modified;
                db.CompraRemediosSet.Add(compraRemedios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReceitaId = new SelectList(db.ReceitaSet, "Id", "Data", compraRemedios.ReceitaId);
            return View(compraRemedios);
        }

        // GET: CompraRemedios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompraRemedios compraRemedios = db.CompraRemediosSet.Find(id);
            if (compraRemedios == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReceitaId = new SelectList(db.ReceitaSet, "Id", "Data", compraRemedios.ReceitaId);
            return View(compraRemedios);
        }

        // POST: CompraRemedios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ReceitaId")] CompraRemedios compraRemedios)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(compraRemedios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReceitaId = new SelectList(db.ReceitaSet, "Id", "Data", compraRemedios.ReceitaId);
            return View(compraRemedios);
        }
        
        // GET: CompraRemedios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompraRemedios compraRemedios = db.CompraRemediosSet.Find(id);
            if (compraRemedios == null)
            {
                return HttpNotFound();
            }
            return View(compraRemedios);
        }

        // POST: CompraRemedios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompraRemedios compraRemedios = db.CompraRemediosSet.Find(id);
            db.CompraRemediosSet.Remove(compraRemedios);
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
