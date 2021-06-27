using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logica;
using WebApi.Models;

namespace Servicio.Controllers
{

    [RoutePrefix("Movimiento")]
    
    public class MovimientoController : ApiController
    {
        public IPrincipal principal { get; set; }
        
        //INNECESARIO
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //INNECESARIO
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Movimiento

        public IHttpActionResult Post([FromBody]MovimientoRequest value)
        {
            //ERROR DE DISEÑO, NO DEBERIA ENVIAR PARAMETROS POR SEPARADO
            List<Movimiento> movimiento = Principal.Instancia.Movimiento(value.DniEnvia, value.DniRecibe, value.Descripcion, value.Monto);
            if (movimiento != null)
                return Content(HttpStatusCode.Created, value);

            //NO DEBERIA RETORNAR LO MISMO QUE SE ENVIO.
            return Content(HttpStatusCode.BadRequest, value);
        }

        // INNECESARIO
        public void Put(int id, [FromBody]string value)
        {
        }

        //EL VERBO DEL METODO ES INCORRECTO
        [Route("Movimiento/{DNI}")]
        public IHttpActionResult Delete(int dni)
        {
            Usuario usuario = Principal.Instancia.ObtenerUsuarioPorDNI(dni);
            if (usuario != null)
            {
                if (usuario.HistorialMovimiento != null)
                {
                    List<Movimiento> movimientos = usuario.HistorialMovimiento;
                    return Ok(movimientos);
                }
            }
            return NotFound();

        }
    }
}
