using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Principal: IPrincipal
    {

        public List<Usuario> Usuarios { get; set; }

        public List<Movimiento> Movimientos { get; set; }


        private readonly static Principal _instance = new Principal();

        private Principal()
        {
            if (Usuarios == null)
            {
                Usuarios = new List<Usuario>();
            }
            if (Movimientos == null)
            {
                Movimientos = new List<Movimiento>();
            }
        }

        public static Principal Instancia
        {
            get
            {
                return _instance;
            }
        }

        //INNECESARIO, SE RESUELVE EN UNA LINEA
        public Usuario ObtenerUsuarioPorDNI(int dni)
        {
            Usuario usuarioencontrado = Usuarios.Find(x => x.DNI == dni);
            if (usuarioencontrado == null)
            {
                return null;
            }
            return usuarioencontrado;
        }

        //NO USA RESULTADO, PODRIA USARLO PARA RETORNAR LA VALIDACION
        public List<Movimiento> Movimiento(int dniEnvia, int dniRecibe, string descripcion, double monto)
        {
            Usuario usuarioenvia = ObtenerUsuarioPorDNI(dniEnvia);
            Usuario usuariorecibe = ObtenerUsuarioPorDNI(dniRecibe);
            if (usuarioenvia == null || usuariorecibe == null)
            {
                return null;
            }
            if (usuarioenvia.SaldoDinero >= monto)
            {
                usuariorecibe.SaldoDinero += monto;
                usuarioenvia.SaldoDinero -= monto;

                Movimiento nuevo = new Movimiento(descripcion, -monto);
                usuarioenvia.HistorialMovimiento.Add(nuevo);
                Movimiento nuevo2 = new Movimiento(descripcion, monto);
                usuariorecibe.HistorialMovimiento.Add(nuevo2);
                Movimientos.Add(nuevo);
                Movimientos.Add(nuevo2);

                //ERROR DE DISEÑO, HACE 2 ACCIONES RELACIONADAS POR SEPARADO.
                //DEBERIA TENER UN METODO "CREARTRANASACCION" DENTRO DE USUARIO QUE HAGA LAS 2 COSAS
                //SUMAR AL LISTA Y VOLVER A CALCULAR EL SALDO
                return Movimientos;
            }
            return null;
        }

        public Resultado CancelarMovimiento(int idMovimientoEnvia, int idMovimientoRecibe)
        {
            Movimiento movimiento1 = Movimientos.Find(x => x.ID == idMovimientoEnvia);

            if (movimiento1 != null)
            {
                Movimiento movimiento2 = Movimientos.Find(x => x.ID == idMovimientoRecibe);
                if (movimiento2 != null)
                {
                    movimiento1 = new Movimiento(movimiento1.Descripcion, movimiento1.Monto * -1);
                    movimiento2 = new Movimiento(movimiento2.Descripcion, movimiento2.Monto * -1);
                    Movimientos.Add(movimiento1);
                    Movimientos.Add(movimiento2);

                    //NO ACTUALIZA LOS SALDOS

                    return new Resultado(true, "Exito");
                }

            }
            return new Resultado("El id es inexistente", false);
        }

        //NO SE USA EN EL SERVICIO
        public List<Movimiento> ObtenerHistorial(int dni)
        {
            Usuario usuario = ObtenerUsuarioPorDNI(dni);
            if (usuario != null)
            {
                usuario.HistorialMovimiento.OrderByDescending(x => x.FechaMovimiento);
                return usuario.HistorialMovimiento;
            }
            return null;
        }



    }
}
