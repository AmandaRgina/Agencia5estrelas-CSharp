using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DestinoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Destinoes
        public ActionResult Index()
        {
            return View(db.Destinoes.ToList());
        }

        // GET: Destinoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = db.Destinoes.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(destino);
        }

        // GET: Destinoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Destinoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "destinoId,lugar,valor")] Destino destino)
        {
            if (ModelState.IsValid)
            {
                db.Destinoes.Add(destino);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(destino);
        }

        // GET: Destinoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = db.Destinoes.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(destino);
        }

        // POST: Destinoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "destinoId,lugar,valor")] Destino destino)
        {
            if (ModelState.IsValid)
            {
                db.Entry(destino).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(destino);
        }

        // GET: Destinoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = db.Destinoes.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(destino);
        }

        // POST: Destinoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Destino destino = db.Destinoes.Find(id);
            db.Destinoes.Remove(destino);
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
