using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TercerParcial_Centurion;

namespace TercerParcial_Centurion.Controllers
{
    public class CONTACTOController : Controller
    {
        private EL_LEEDOREntities1 db = new EL_LEEDOREntities1();

        // GET: CONTACTO
        public ActionResult Index()
        {
            return View(db.CONTACTO.ToList());
        }

        // GET: CONTACTO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTACTO cONTACTO = db.CONTACTO.Find(id);
            if (cONTACTO == null)
            {
                return HttpNotFound();
            }
            return View(cONTACTO);
        }

        // GET: CONTACTO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CONTACTO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,EMAIL,NUMERO,MENSAJE")] CONTACTO cONTACTO)
        {
            if (ModelState.IsValid)
            {
                db.CONTACTO.Add(cONTACTO);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");

                //return RedirectToAction("Index");
            }

            return View(cONTACTO);
        }

        // GET: CONTACTO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTACTO cONTACTO = db.CONTACTO.Find(id);
            if (cONTACTO == null)
            {
                return HttpNotFound();
            }
            return View(cONTACTO);
        }

        // POST: CONTACTO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,EMAIL,NUMERO,MENSAJE")] CONTACTO cONTACTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cONTACTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cONTACTO);
        }

        // GET: CONTACTO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTACTO cONTACTO = db.CONTACTO.Find(id);
            if (cONTACTO == null)
            {
                return HttpNotFound();
            }
            return View(cONTACTO);
        }

        // POST: CONTACTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CONTACTO cONTACTO = db.CONTACTO.Find(id);
            db.CONTACTO.Remove(cONTACTO);
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
