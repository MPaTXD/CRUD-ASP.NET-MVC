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
    public class MusicoBandaController : Controller
    {
        private CRUDContext db = new CRUDContext();



        public ActionResult Index()
        {
            var relacoes = db.MusicoBandas.Include(m => m.Musico).Include(b => b.Banda).ToList();
            return View(relacoes);
        }


        public ActionResult Create()
        {
            ViewBag.MusicoId = new SelectList(db.Musico.ToList(), "MusicoId", "NomeMusico");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Banda banda, List<int> MusicoId)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                db.Bandas.Add(banda);
                foreach (var idMusico in MusicoId)
                {
                    MusicoBanda mb = new MusicoBanda();
                    Musico m = db.Musico.Find(idMusico);
                    mb.BandaId = banda.BandaId;
                    mb.MusicoId = m.MusicoId;
                    db.MusicoBandas.Add(mb);
                    banda.IntegrantesBanda += 1;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
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
