using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using CRUD.Data;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class MusicoController : Controller
    {
        private CRUDContext db = new CRUDContext();

        public ActionResult Index()
        {
            var list = db.Musico.ToList();
            return View(list);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Musico model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                Musico m = new Musico();
                m.NomeMusico = model.NomeMusico;
                m.Idade = model.Idade;
                m.Categoria = model.Categoria;
                m.Email = model.Email;
                m.Senha = Crypto.HashPassword(model.Senha);
                db.Musico.Add(m);
                db.SaveChanges();
                ModelState.Clear();
                TempData["Alert"] = "Cadastro Efetuado!";
                return RedirectToAction("Index");
            }
        }




        public ActionResult Edit(int id)
        {
            var musico = db.Musico.Find(id);
            return View(musico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Musico model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var musico = db.Musico.Find(id);
                if (musico != null)
                {
                    musico.NomeMusico = model.NomeMusico;
                    musico.Idade = model.Idade;
                    musico.Email = model.Email;
                    musico.Categoria = model.Categoria;
                    musico.Senha = Crypto.HashPassword(model.Senha);
                    db.SaveChanges();
                    ModelState.Clear();
                    TempData["Alert"] = "Cadastro Editado!";
                    return RedirectToAction("Index");
                }
                else
                    return View();
            }
        }


        public ActionResult Details(int id)
        {
            var musico = db.Musico.Find(id);
            return View(musico);
        }



        public ActionResult Delete(int? id)
        {
            var musico = db.Musico.Find(id);
            return View(musico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var musico = db.Musico.Find(id);
            if (musico != null)
            {
                db.Musico.Remove(musico);
                db.SaveChanges();
                ModelState.Clear();
                TempData["Alert"] = "Cadastro Deletado!";
                return RedirectToAction("Index");
            }
            else
                return View();
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
