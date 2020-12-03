using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TercerParcial_Centurion.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            //String cotizacion_compra = await ObtenerCotizacion("compra");
            //String cotizacion_venta = await ObtenerCotizacion("venta");

            //ViewBag.Cotizacion_compra = cotizacion_compra;
            //ViewBag.Cotizacion_venta = cotizacion_venta;
            return View();
        }

        public static async Task<string> ObtenerCotizacion(string tipo)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage respuesta = await client.GetAsync("https://dolar.melizeche.com/api/1.0/");
                if (respuesta.IsSuccessStatusCode)
                {
                    var response = await respuesta.Content.ReadAsStringAsync();
                    JObject jObj = JObject.Parse(response);
                    return jObj["dolarpy"]["maxicambios"][tipo].ToString();
                }
                else
                {
                    return "No se pudo obtener la cotización";
                }
            }
        }

        public ActionResult Nosotros()
        {
            ViewBag.Message = "Hoja: Nosotros";

            return View();
        }

        public ActionResult Contacto()
        {
            ViewBag.Message = "Hoja: CONTACTO";

            return View();
        }

        private EL_LEEDOREntities1 db = new EL_LEEDOREntities1();

        public ActionResult Reporte()
        {
            var lista= db.GENERO.ToList().Take(10);
            return View(lista);
        }
    }
}