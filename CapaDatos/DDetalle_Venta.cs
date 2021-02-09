using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Librerias que se deben  importar para poder trabajar con sql server
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
   public class DDetalle_Venta
    {
        private int _Iddetalle_Venta;
        private int _Idventa;
        private int _Idarticulo;
        private int _Cantidad;
        private decimal _Precio_Venta;
        private decimal _Descuento;
        private decimal _Total;

        public int Iddetalle_Venta { get => _Iddetalle_Venta; set => _Iddetalle_Venta = value; }
        public int Idventa { get => _Idventa; set => _Idventa = value; }
        public int Idarticulo { get => _Idarticulo; set => _Idarticulo = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public decimal Precio_Venta { get => _Precio_Venta; set => _Precio_Venta = value; }
        public decimal Descuento { get => _Descuento; set => _Descuento = value; }
        public decimal Total { get => _Total; set => _Total = value; }

        //Constructo vacio
        public DDetalle_Venta()
        {

        }
        //Constuctor con parametros
        public DDetalle_Venta(int iddetalle_venta, int idventa, int idarticulo, int cantidad, decimal precio_venta, decimal total, decimal descuento)
        {
            this.Iddetalle_Venta = iddetalle_venta;
            this.Idventa = idventa;
            this.Idarticulo = idarticulo;
            this.Cantidad = cantidad;
            this.Precio_Venta = precio_venta;
            this.Total = total;
            this.Descuento = descuento;
        }

        //Método Insertar
        public string Insertar(DDetalle_Venta Detalle_Venta, ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {
                //Establecer comando para ejecutar sentencias sql
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_detalle_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros que se van a enviar al procedimiento almacenado
                SqlParameter ParIddetalle_venta = new SqlParameter();
                ParIddetalle_venta.ParameterName = "@iddetalle_venta";
                ParIddetalle_venta.SqlDbType = SqlDbType.Int;
                ParIddetalle_venta.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIddetalle_venta);

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@idventa";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Value = Detalle_Venta.Idventa;
                SqlCmd.Parameters.Add(ParIdventa);

                SqlParameter ParIdarticulo = new SqlParameter();
                ParIdarticulo.ParameterName = "@idarticulo";
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                ParIdarticulo.Value = Detalle_Venta.Idarticulo;
                SqlCmd.Parameters.Add(ParIdarticulo);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = Detalle_Venta.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParPrecio_Venta = new SqlParameter();
                ParPrecio_Venta.ParameterName = "@precio_venta";
                ParPrecio_Venta.SqlDbType = SqlDbType.Money;
                ParPrecio_Venta.Value = Detalle_Venta.Precio_Venta;
                SqlCmd.Parameters.Add(ParPrecio_Venta);

                SqlParameter ParDescuento = new SqlParameter();
                ParDescuento.ParameterName = "@descuento";
                ParDescuento.SqlDbType = SqlDbType.Money;
                ParDescuento.Value = Detalle_Venta.Descuento;
                SqlCmd.Parameters.Add(ParDescuento);

                //Ejecutar el comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;
        }
    }
}
