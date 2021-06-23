using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logica;

namespace Servicio.Models
{
    public class MovimientoResponse
    {
        public string Codigo { get; set; }

        public MovimientoResponse(Movimiento movimiento)
        {
            this.Codigo = $"Codigo: {movimiento.ID}";
        }
    }
}