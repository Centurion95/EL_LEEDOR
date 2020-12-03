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

        //rc95 20/11/2020 02:21 - https://stackoverflow.com/questions/17617594/how-to-get-some-values-from-a-json-string-in-c
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

        // rc95 19/11/2020 23:32
        public ActionResult CaracteristicasCenturion()
        {
            ViewBag.Message = "Caracteristicas";

            //https://stackoverflow.com/questions/7285790/how-can-i-show-a-viewbag-as-html
            ViewBag.Caracteristicas =
            "<div class='w3-container'>" +
            "<div class='w3-card-4' style='width:50%'>" +
            "   <img src='https://cdn.pixabay.com/photo/2017/07/31/11/21/people-2557396_960_720.jpg' alt='caracteristica' style='width:100%'/> " +
            "   <div class='w3-container w3-center'>" +
            "       <p>La red social mas importante de la universidad!</p>" +
            "   </div>" +
            "</div>" +
            "</div>" +
            "<br><br>" +
            "<div class='w3-container'>" +
            "<div class='w3-card-4' style='width:50%'>" +
            "   <img src='https://cdn.pixabay.com/photo/2015/02/13/21/54/corporate-635886_960_720.jpg' alt='caracteristica' style='width:100%'/> " +
            "   <div class='w3-container w3-center'>" +
            "       <p>Cuenta con el apoyo del centro de estudiantes</p>" +
            "   </div>" +
            "</div>" +
            "</div>" +
            "<br><br>" +
            "<div class='w3-container'>" +
            "<div class='w3-card-4' style='width:50%'>" +
            "   <img src='https://cdn.pixabay.com/photo/2019/06/16/21/48/cups-4278774_960_720.jpg' alt='caracteristica' style='width:100%'/> " +
            "   <div class='w3-container w3-center'>" +
            "       <p>Ha recibido varios premios a nivel nacional e internacional</p>" +
            "   </div>" +
            "</div>" +
            "</div>" +
            "<br><br>" +
            "<div class='w3-container'>" +
            "<div class='w3-card-4' style='width:50%'>" +
            "   <img src='https://cdn.pixabay.com/photo/2016/12/13/07/25/facebook-1903445_960_720.jpg' alt='caracteristica' style='width:100%'/> " +
            "   <div class='w3-container w3-center'>" +
            "       <p>Proximamente será adquirida por el gigante Facebook</p>" +
            "   </div>" +
            "</div>" +
            "</div>";

            return View();
        }
    }
}