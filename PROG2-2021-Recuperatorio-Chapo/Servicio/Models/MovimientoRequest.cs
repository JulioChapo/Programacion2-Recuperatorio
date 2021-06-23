using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logica;

namespace Servicio.Models
{
    public class MovimientoRequest
    {
        public int ID { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string Descripcion { get; set; }
        public double Monto { get; set; }

        public int DNIEnvia { get; set; }
        public int DNIRecibe { get; set; }


        public List<Movimiento> CrearMovimiento()
        {
            Usuario usuarioRecibe = Principal.Instancia.ObtenerUsuarioPorDNI(DNIRecibe);
            Usuario usuarioEnvia = Principal.Instancia.ObtenerUsuarioPorDNI(DNIEnvia);
            List<Movimiento> movimiento = Principal.Instancia.Movimiento(usuarioEnvia.DNI, usuarioRecibe.DNI, this.Descripcion, this.Monto);
            return movimiento;
        }

    }
}