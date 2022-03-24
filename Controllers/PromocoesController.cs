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
    public class PromocoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Promocoes
        public ActionResult Index()
        {
            return View(db.Promocoes.ToList());
        }

        // GET: Promocoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocoes promocoes = db.Promocoes.Find(id);
            if (promocoes == null)
            {
                return HttpNotFound();
            }
            return View(promocoes);
        }

        // GET: Promocoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Promocoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "promocoesId,lugar,valor")] Promocoes promocoes)
        {
            if (ModelState.IsValid)
            {
                db.Promocoes.Add(promocoes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(promocoes);
        }

        // GET: Promocoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocoes promocoes = db.Promocoes.Find(id);
            if (promocoes == null)
            {
                return HttpNotFound();
            }
            return View(promocoes);
        }

        // POST: Promocoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "promocoesId,lugar,valor")] Promocoes promocoes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promocoes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(promocoes);
        }

        // GET: Promocoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocoes promocoes = db.Promocoes.Find(id);
            if (promocoes == null)
            {
                return HttpNotFound();
            }
            return View(promocoes);
        }

        // POST: Promocoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Promocoes promocoes = db.Promocoes.Find(id);
            db.Promocoes.Remove(promocoes);
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
