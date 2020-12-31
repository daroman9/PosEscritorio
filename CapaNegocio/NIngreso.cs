using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NIngreso
    {
        //Método que llama al método insertar de la clase DIngreso de la capa datos

        public static string Insertar(int idtrabajador, int idproveedor, DateTime fecha, string tipo_comprobante,
            string serie, string correlativo, decimal igv, string estado, DataTable dtDetalles)
        {
            DIngreso Obj = new DIngreso();
            Obj.Idtrabajador = idtrabajador;
            Obj.Idproveedor = idproveedor;
            Obj.Fecha = fecha;
            Obj.Tipo_Comprobante = tipo_comprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Igv = igv;
            Obj.Estado = estado;
            List<DDetalle_Ingreso> detalles = new List<DDetalle_Ingreso>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_Ingreso detalle = new DDetalle_Ingreso();
                detalle.Idarticulo = Convert.ToInt32(row["idarticulo"].ToString());
                detalle.Precio_Compra = Convert.ToDecimal(row["precio_compra"].ToString());
                detalle.Precio_Venta= Convert.ToDecimal(row["precio:venta"].ToString());
                detalle.Stock_Inicial = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Stock_Actual = Convert.ToInt32(row["stock_actual"].ToString());
                detalle.Fecha_Produccion = Convert.ToDateTime(row["fecha_produccion"].ToString());
                detalle.Fecha_Vencimiento = Convert.ToDateTime(row["fecha_vencimiento"].ToString());

                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj, detalles);
        }
        //Método que llama al método anular de la clase DIngreso de la capa de datos
        public static string Anular(int idingreso)
        {
            DIngreso Obj = new DIngreso();
            Obj.Idingreso = idingreso;

            return Obj.Anular(Obj);
        }
        //Método que llama al método mostrar de la clase DIngreso de la capa de datos
        public static DataTable Mostrar()
        {
            return new DIngreso().Mostrar();
        }
        //Método que llama al método Buscar por fechas de la clase DIngreso de la capa de datos
        public static DataTable BuscarFechas(string textoBuscar, string textobuscar2)
        {
            DIngreso Obj = new DIngreso();
    
            return Obj.BuscarFechas(textoBuscar, textobuscar2);
        }
        //Método que llama al método Buscar detalle de la clase DIngreso de la capa de datos
        public static DataTable MostrarDetalle(string textoBuscar)
        {
            DIngreso Obj = new DIngreso();

            return Obj.MostrarDetalle(textoBuscar);
        }
    }
}
