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
    public class NACIONALIDADController : Controller
    {
        private EL_LEEDOREntities1 db = new EL_LEEDOREntities1();

        // GET: NACIONALIDAD
        public ActionResult Index()
        {
            return View(db.NACIONALIDAD.ToList());
        }

        // GET: NACIONALIDAD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NACIONALIDAD nACIONALIDAD = db.NACIONALIDAD.Find(id);
            if (nACIONALIDAD == null)
            {
                return HttpNotFound();
            }
            return View(nACIONALIDAD);
        }

        // GET: NACIONALIDAD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NACIONALIDAD/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DESCRIPCION")] NACIONALIDAD nACIONALIDAD)
        {
            if (ModelState.IsValid)
            {
                db.NACIONALIDAD.Add(nACIONALIDAD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nACIONALIDAD);
        }

        // GET: NACIONALIDAD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NACIONALIDAD nACIONALIDAD = db.NACIONALIDAD.Find(id);
            if (nACIONALIDAD == null)
            {
                return HttpNotFound();
            }
            return View(nACIONALIDAD);
        }

        // POST: NACIONALIDAD/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DESCRIPCION")] NACIONALIDAD nACIONALIDAD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nACIONALIDAD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nACIONALIDAD);
        }

        // GET: NACIONALIDAD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NACIONALIDAD nACIONALIDAD = db.NACIONALIDAD.Find(id);
            if (nACIONALIDAD == null)
            {
                return HttpNotFound();
            }
            return View(nACIONALIDAD);
        }

        // POST: NACIONALIDAD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NACIONALIDAD nACIONALIDAD = db.NACIONALIDAD.Find(id);
            db.NACIONALIDAD.Remove(nACIONALIDAD);
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
