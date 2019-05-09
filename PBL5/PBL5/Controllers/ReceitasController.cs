using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PBL5;
using System.Threading.Tasks;

namespace PBL5.Controllers
{
    public class ReceitasController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Receitas
            public async Task<ActionResult> ViewPesquisaFodase(string searchString)
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    var receitas = from i in db.Receitas
                                  orderby i.InsumoNome
                                  where i.InsumoNome == searchString
                                  select i;
                    return View(await receitas.ToListAsync());
                }
                else
                {
                    var receitas = from i in db.Receitas
                                  orderby i.InsumoId
                                  select i;
                    return View(await receitas.ToListAsync());
                }
            }
            

        // GET: Receitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receita receita = db.ReceitaSet.Find(id);
            if (receita == null)
            {
                return HttpNotFound();
            }
            return View(receita);
        }

        // GET: Receitas/Create
        public ActionResult Create()
        {
            ViewBag.RemedioId = new SelectList(db.RemedioSet, "Id", "Nome");
            ViewBag.MedicoId = new SelectList(db.MedicoSet, "Id", "Nome");
            ViewBag.DoençaId = new SelectList(db.DoençaSet, "Id", "Nome");
            return View();
        }

        // POST: Receitas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Data,ClinicaHospital,RemedioId,MedicoId,DoençaId")] Receita receita)
        {
            if (ModelState.IsValid)
            {
                db.ReceitaSet.Add(receita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RemedioId = new SelectList(db.RemedioSet, "Id", "Nome", receita.RemedioId);
            ViewBag.MedicoId = new SelectList(db.MedicoSet, "Id", "Nome", receita.MedicoId);
            ViewBag.DoençaId = new SelectList(db.DoençaSet, "Id", "Nome", receita.DoençaId);
            return View(receita);
        }

        // GET: Receitas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receita receita = db.ReceitaSet.Find(id);
            if (receita == null)
            {
                return HttpNotFound();
            }
            ViewBag.RemedioId = new SelectList(db.RemedioSet, "Id", "Nome", receita.RemedioId);
            ViewBag.MedicoId = new SelectList(db.MedicoSet, "Id", "Nome", receita.MedicoId);
            ViewBag.DoençaId = new SelectList(db.DoençaSet, "Id", "Nome", receita.DoençaId);
            return View(receita);
        }

        // POST: Receitas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Data,ClinicaHospital,RemedioId,MedicoId,DoençaId")] Receita receita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RemedioId = new SelectList(db.RemedioSet, "Id", "Nome", receita.RemedioId);
            ViewBag.MedicoId = new SelectList(db.MedicoSet, "Id", "Nome", receita.MedicoId);
            ViewBag.DoençaId = new SelectList(db.DoençaSet, "Id", "Nome", receita.DoençaId);
            return View(receita);
        }

        // GET: Receitas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receita receita = db.ReceitaSet.Find(id);
            if (receita == null)
            {
                return HttpNotFound();
            }
            return View(receita);
        }

        // POST: Receitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Receita receita = db.ReceitaSet.Find(id);
            db.ReceitaSet.Remove(receita);
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
