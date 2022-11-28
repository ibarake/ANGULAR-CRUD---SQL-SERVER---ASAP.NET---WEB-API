using back_platos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace back_platos.Controllers
{
    [EnableCors(origins: "*", headers:"*", methods:"GET, POST, PUT, DELETE, OPTIONS")]
    public class PlatosController : ApiController
    {
        // GET: api/Platos
        public IEnumerable<Platos> Get()
        {
            GestorPlatos gestorPlatos= new GestorPlatos();
            return gestorPlatos.getPlatos();
        }

        // GET: api/Platos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Platos
        public bool Post([FromBody]Platos plato)
        {
            GestorPlatos gestorPlatos = new GestorPlatos();
            bool res = gestorPlatos.addPlato(plato);

            return res;
        }

        // PUT: api/Platos/5
        public bool Put(int id, [FromBody]Platos plato)
        {
            GestorPlatos gestorPlatos = new GestorPlatos();
            bool res = gestorPlatos.updatePlato(id, plato);

            return res;
        }

        // DELETE: api/Platos/5
        public bool Delete(int id)
        {
            GestorPlatos gestorPlatos = new GestorPlatos();
            bool res = gestorPlatos.deletePlato(id);

            return res;
        }
    }
}
