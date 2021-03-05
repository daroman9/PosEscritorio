using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
   public class NConsultaVentas
    {
        //Método que llama al método que consulta las ultimas 1000 ventas realizadas
        public static DataTable Mostrar()
        {
            return new DConsultaVentas().Ventas_Diarias();
        }
        //Método que llama al método que busca las ventas por fechas
        public static DataTable BuscarVentasFechas(string textoBuscar, string textoBuscar2)
        {
            DConsultaVentas Obj = new DConsultaVentas();
            Obj.TextoBuscar = textoBuscar;
            Obj.TextoBuscar2 = textoBuscar2;
            return Obj.BuscarVentasFechas(Obj);
        }
    }
}
