using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TercerParcial_Centurion.Controllers
{
    public class PublicacionesCenturionController : Controller
    {
        private OrkutUAAEntities db = new OrkutUAAEntities();
        
        [Authorize]
        public ActionResult Index()
        {
            var listaPublicaciones = db.Publicacion.ToList();
            return View(listaPublicaciones);
        }

        
        [Authorize]
        public ActionResult Crear()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Publicacion publicacion)
        {
            if (ModelState.IsValid)
            {
                //rc95 03/12/2020 01:09 - sobreescribimos el campo fecha y el mes con la fecha del equipo
                publicacion.Fecha = DateTime.Now;
                publicacion.Mes = DateTime.Now.Month;

                db.Publicacion.Add(publicacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publicacion);
        }

        [Authorize]
        public ActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicacion publicacion = db.Publicacion.Find(id);
            if (publicacion == null)
            {
                return HttpNotFound();
            }
            return View(publicacion);
        }

        [Authorize]
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicacion publicacion = db.Publicacion.Find(id);
            if (publicacion == null)
            {
                return HttpNotFound();
            }
            return View(publicacion);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Publicacion publicacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publicacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publicacion);
        }

        [Authorize]
        public ActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicacion publicacion = db.Publicacion.Find(id);
            if (publicacion == null)
            {
                return HttpNotFound();
            }
            return View(publicacion);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Borrar(int id)
        {
            Publicacion publicacion = db.Publicacion.Find(id);
            db.Publicacion.Remove(publicacion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //https://localhost:44316/PublicacionesCenturion/MesCenturion?mes=9
        //https://localhost:44316/PublicacionesCenturion/MesCenturion?mes=10
        //https://localhost:44316/PublicacionesCenturion/MesCenturion?mes=11
        [Authorize]
        public ActionResult MesCenturion(int? mes)
        {
            if (mes == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var listaPublicaciones = db.Publicacion.Where(publicacion => publicacion.Mes == mes);

            return View(listaPublicaciones);
        }
    }
}