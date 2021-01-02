using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;


namespace CapaNegocio
{
  public  class NVenta
    {
        //Método que llama al método insertar de la clase DVenta de la capa datos

        public static string Insertar(int idcliente, int idtrabajador, DateTime fecha, string tipo_comprobante,
            string serie, string correlativo, decimal igv, DataTable dtDetalles)
        {
            DVenta Obj = new DVenta();
            Obj.Idcliente = idcliente;
            Obj.Idtrabajador = idtrabajador;
            Obj.Fecha = fecha;
            Obj.Tipo_Comprobante = tipo_comprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Igv = igv;
            List<DDetalle_Venta> detalles = new List<DDetalle_Venta>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_Venta detalle = new DDetalle_Venta();
                detalle.Iddetalle_ingreso = Convert.ToInt32(row["iddetalle_ingreso"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["cantidad"].ToString());
                detalle.Precio_Venta = Convert.ToDecimal(row["precio_venta"].ToString());
                detalle.Descuento = Convert.ToDecimal(row["descuento"].ToString());
               
                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj, detalles);
        }
        //Método que llama al método eliminar de la clase DVenta de la capa de datos
        public static string Eliminar(int idventa)
        {
            DVenta Obj = new DVenta();
            Obj.Idventa = idventa;

            return Obj.Eliminar(Obj);
        }
        //Método que llama al método mostrar de la clase DVenta de la capa de datos
        public static DataTable Mostrar()
        {
            return new DVenta().Mostrar();
        }
        //Método que llama al método Buscar por fechas de la clase DVenta de la capa de datos
        public static DataTable BuscarFechas(string textoBuscar, string textobuscar2)
        {
            DVenta Obj = new DVenta();

            return Obj.BuscarFechas(textoBuscar, textobuscar2);
        }
        //Método que llama al método Buscar detalle de la clase DVenta de la capa de datos
        public static DataTable MostrarDetalle(string textoBuscar)
        {
            DVenta Obj = new DVenta();

            return Obj.MostrarDetalle(textoBuscar);
        }
        //Método que llama al método Buscar detalle de la clase DVenta de la capa de datos
        public static DataTable MostrarArticulo_Venta_Nombre(string textoBuscar)
        {
            DVenta Obj = new DVenta();

            return Obj.MostrarArticulo_Venta_Nombre(textoBuscar);
        }
        //Método que llama al método Buscar detalle de la clase DVenta de la capa de datos
        public static DataTable Mostrar_Articulo_Codigo(string textoBuscar)
        {
            DVenta Obj = new DVenta();

            return Obj.MostrarArticulo_Venta_codigo(textoBuscar);
        }
    }
}
