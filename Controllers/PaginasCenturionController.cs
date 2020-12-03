using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TercerParcial_Centurion.Controllers
{
    public class PaginasCenturionController : Controller
    {
        private OrkutUAAEntities db = new OrkutUAAEntities();

        public ActionResult ListaCenturion()
        {
            var listaPaginas = db.Pagina.ToList().Take(10);
            return View(listaPaginas);
        }

        //rc95 20/11/2020 03:03 - https://localhost:44316/PaginasCenturion/ParaTiCenturion
        public ActionResult ParaTiCenturion()
        {
            ViewBag.mayor_MeGusta = db.Pagina.OrderByDescending(pagina => pagina.CantidadLikes).First().Nombre;

            ViewBag.cant_Programacion = db.Pagina.Where(pagina => pagina.Categoria.Equals("Programación")).Count();

            var result = db.Pagina.Where(pagina => pagina.Ciudad.Equals("Asuncion"));
            ViewBag.promedioLikesAsuncion = result.Average(pagina => pagina.CantidadLikes);

            var listaPaginas = db.Pagina.ToList().Take(10);
            return View();
        }
    }
}