using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public interface IPrincipal
    {

        Usuario ObtenerUsuarioPorDNI(int dni);
        Resultado Movimiento(int dniEnvia, int dniRecibe, string descripcion, double monto);

        Resultado CancelarMovimiento(int idMovimientoEnvia, int idMovimientoRecibe);
        List<Movimiento> ObtenerHistorial(int dni);
        Movimiento ObtenerUsuarioPorDNI(string iD);
    }
}
