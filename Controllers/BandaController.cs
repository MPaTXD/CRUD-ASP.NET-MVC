using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUD.Data;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class BandaController : Controller
    {
        private CRUDContext db = new CRUDContext();


        public ActionResult Index()
        {
            var listBandas = db.Bandas.ToList();
            return View(listBandas);
        }


        public ActionResult Details(int id)
        {
            var banda = db.Bandas.Find(id);
            ViewBag.Musicos = db.MusicoBandas.Where(b => b.BandaId == id).Include(m => m.Musico);
            return View(banda);
        }


        public ActionResult Edit(int id)
        {
            var banda = db.Bandas.Find(id);
            return View(banda);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Banda model)
        {
            if (ModelState.IsValid)
            {
                Banda b = db.Bandas.Find(id);
                b.NomeBanda = model.NomeBanda;
                b.EstiloBanda = model.EstiloBanda;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Banda/Delete/5
        public ActionResult Delete(int id)
        {
            var banda = db.Bandas.Find(id);
            return View(banda);
        }

        // POST: Banda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Banda banda = db.Bandas.Find(id);
            db.Bandas.Remove(banda);
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
