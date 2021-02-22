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

        public static string Insertar(int idcliente, int idtrabajador, DateTime fecha,
            string serie, string metodopago, decimal efectivo, decimal debito_credito, decimal devuelta, decimal totalpagado, DataTable dtDetalles)
        {
            DVenta Obj = new DVenta();
            if (idcliente ==0)
            {
               
                //Obj.Idcliente = idcliente;
                Obj.Idtrabajador = idtrabajador;
                Obj.Fecha = fecha;
                Obj.Serie = serie;
                Obj.MetodoPago = metodopago;
                Obj.Efectivo = efectivo;
                Obj.Debito_Credito = debito_credito;
                Obj.Devuelta = devuelta;
                Obj.Total_Pagado = totalpagado;
            }
            else
            {

                Obj.Idcliente = idcliente;
                Obj.Idtrabajador = idtrabajador;
                Obj.Fecha = fecha;
                Obj.Serie = serie;
                Obj.MetodoPago = metodopago;
                Obj.Efectivo = efectivo;
                Obj.Debito_Credito = debito_credito;
                Obj.Devuelta = devuelta;
                Obj.Total_Pagado = totalpagado;
            }

           
            List<DDetalle_Venta> detalles = new List<DDetalle_Venta>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_Venta detalle = new DDetalle_Venta();
                detalle.Idarticulo = Convert.ToInt32(row["idarticulo"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["cantidad"].ToString());
                detalle.Precio_Venta = Convert.ToDecimal(row["precio_venta"].ToString());
                detalle.Descuento = Convert.ToDecimal(row["descuento"].ToString());
                
                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj, detalles);
        }
        //Método para actualizar el stock de articulos despues de cada venta
        public static string updateStock(DataTable dtDetalles)
        {
            DDetalle_Ingreso Obj = new DDetalle_Ingreso();
            List<DDetalle_Ingreso> detalles = new List<DDetalle_Ingreso>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_Ingreso detalle = new DDetalle_Ingreso();
                detalle.Idarticulo = Convert.ToInt32(row["idarticulo"].ToString());
                detalle.Iddetalle_Ingreso = Convert.ToInt32(row["iddetalle_ingreso"].ToString());
                detalle.Stock_Actual = Convert.ToInt32(row["stock_actual"].ToString());

                detalles.Add(detalle);
            }
            return Obj.updateStock(detalles);
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
        public static DataTable BuscarFechas(int trabajador, string textoBuscar, string textobuscar2)
        {
            DVenta Obj = new DVenta();

            return Obj.BuscarFechas( trabajador, textoBuscar, textobuscar2);
        }

        //Método que llama al método Buscar por trabajador y  fecha de la clase DVenta de la capa de datos
        public static DataTable MostrarTrabajadorFecha(int idtrabajador, DateTime fecha)
        {
            DVenta Obj = new DVenta();

            return Obj.MostrarTrabajadorFecha(idtrabajador, fecha);
        }
        //Método que llama al método Buscar detalle de la clase DVenta de la capa de datos
        public static DataTable MostrarDetalle(string textoBuscar)
        {
            DVenta Obj = new DVenta();

            return Obj.MostrarDetalle(textoBuscar);
        }
        //Método que llama al método Buscar detalle de la clase DVenta de la capa de datos
        public static DataTable MostrarArticulo_Sin_Codigo(string textoBuscar)
        {
            DVenta Obj = new DVenta();

            return Obj.MostrarArticulo_Sin_Codigo(textoBuscar);
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
        //Método que llama el método que busca la serie del último registro
        public static DataTable UltimaSerie()
        {
            return new DVenta().UltimaSerie();
        }
    }
}