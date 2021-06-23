using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Usuario
    {
        public string NombreYApellido { get; set; }
        public int DNI { get; set; }
        public double SaldoDinero { get; set; }
        public List<Movimiento> HistorialMovimiento { get; set; }
    }
}
