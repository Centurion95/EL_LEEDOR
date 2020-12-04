using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace TercerParcial_Centurion
{
    public class GenerosController : ApiController
    {
        private EL_LEEDOREntities1 db = new EL_LEEDOREntities1();

        // GET: api/generos - https://localhost:44316/api/generos
        public IQueryable<GENERO> Get()
        {
            return db.GENERO;
        }

        // GET api/<controller>/5
        //https://localhost:44316/api/generos/1
        //https://localhost:44316/api/generos/2
        //https://localhost:44316/api/generos/3
        public GENERO Get(int id)
        {
            GENERO genero = db.GENERO.Find(id);
            return genero;
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }


        // DELETE: api/Marcas/5
        [ResponseType(typeof(GENERO))]
        public IHttpActionResult DeleteGenero(int id)
        {
            GENERO registro = db.GENERO.Find(id);
            if (registro == null)
            {
                return NotFound();
            }

            db.GENERO.Remove(registro);
            db.SaveChanges();

            return Ok(registro);
        }

        //// DELETE api/<controller>/5
        //[HttpPost, ActionName("Delete")]
        //public void DeleteConfirmed(int id)
        //{
        //    GENERO genero = db.GENERO.Find(id);
        //    db.GENERO.Remove(genero);
        //    db.SaveChanges();
        //}
    }
}