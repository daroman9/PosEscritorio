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
   public class DDetalle_Ingreso
    {
        private int _Iddetalle_Ingreso;
        private int _Idingreso;
        private int _Idarticulo;
        private decimal _Precio_Compra;
        private decimal _Precio_Venta;
        private int _Stock_Inicial;
        private int _Stock_Actual;
        private DateTime _Fecha_Produccion;
        private DateTime _Fecha_Vencimiento;

        public int Iddetalle_Ingreso { get => _Iddetalle_Ingreso; set => _Iddetalle_Ingreso = value; }
        public int Idingreso { get => _Idingreso; set => _Idingreso = value; }
        public int Idarticulo { get => _Idarticulo; set => _Idarticulo = value; }
        public decimal Precio_Compra { get => _Precio_Compra; set => _Precio_Compra = value; }
        public decimal Precio_Venta { get => _Precio_Venta; set => _Precio_Venta = value; }
        public int Stock_Inicial { get => _Stock_Inicial; set => _Stock_Inicial = value; }
        public int Stock_Actual { get => _Stock_Actual; set => _Stock_Actual = value; }
        public DateTime Fecha_Produccion { get => _Fecha_Produccion; set => _Fecha_Produccion = value; }
        public DateTime Fecha_Vencimiento { get => _Fecha_Vencimiento; set => _Fecha_Vencimiento = value; }

        //Constructor vacio
        public DDetalle_Ingreso()
        {

        }

        //Constructor con parametros
        public DDetalle_Ingreso(int iddetalle_ingreso, int idingreso, int idarticulo, decimal precio_compra, decimal precio_venta, int stock_inicial, int stock_actual, DateTime fecha_produccion, DateTime fecha_vencimiento)
        {
            this.Iddetalle_Ingreso = iddetalle_ingreso;
            this.Idingreso = idingreso;
            this.Idarticulo = idarticulo;
            this.Precio_Compra = precio_compra;
            this.Precio_Venta = precio_venta;
            this.Stock_Inicial = stock_inicial;
            this.Stock_Actual = stock_actual;
            this.Fecha_Produccion = fecha_produccion;
            this.Fecha_Vencimiento = fecha_vencimiento;   
        }
        //Método Insertar
        public string Insertar(DDetalle_Ingreso Detalle_Ingreso, ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {
            
                //Establecer comando para ejecutar sentencias sql
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_detalle_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros que se van a enviar al procedimiento almacenado
                SqlParameter ParIddetalle_ingreso = new SqlParameter();
                ParIddetalle_ingreso.ParameterName = "@iddetalle_ingreso";
                ParIddetalle_ingreso.SqlDbType = SqlDbType.Int;
                ParIddetalle_ingreso.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIddetalle_ingreso);

                SqlParameter ParIdingreso = new SqlParameter();
                ParIdingreso.ParameterName = "@idingreso";
                ParIdingreso.SqlDbType = SqlDbType.Int;
                ParIdingreso.Value = Detalle_Ingreso.Idingreso;
                SqlCmd.Parameters.Add(ParIdingreso);

                SqlParameter ParIdarticulo = new SqlParameter();
                ParIdarticulo.ParameterName = "@idarticulo";
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                ParIdarticulo.Value = Detalle_Ingreso.Idarticulo;
                SqlCmd.Parameters.Add(ParIdarticulo);

                SqlParameter ParPrecio_Compra = new SqlParameter();
                ParPrecio_Compra.ParameterName = "@precio_compra";
                ParPrecio_Compra.SqlDbType = SqlDbType.Money;
                ParPrecio_Compra.Value = Detalle_Ingreso.Precio_Compra;
                SqlCmd.Parameters.Add(ParPrecio_Compra);

                SqlParameter ParPrecio_Venta = new SqlParameter();
                ParPrecio_Venta.ParameterName = "@precio_venta";
                ParPrecio_Venta.SqlDbType = SqlDbType.Money;
                ParPrecio_Venta.Value = Detalle_Ingreso.Precio_Venta;
                SqlCmd.Parameters.Add(ParPrecio_Venta);

                SqlParameter ParStock_Inicial = new SqlParameter();
                ParStock_Inicial.ParameterName = "@stock_inicial";
                ParStock_Inicial.SqlDbType = SqlDbType.Int;
                ParStock_Inicial.Value = Detalle_Ingreso.Stock_Inicial;
                SqlCmd.Parameters.Add(ParStock_Inicial);

                SqlParameter ParStock_Actual = new SqlParameter();
                ParStock_Actual.ParameterName = "@stock_actual";
                ParStock_Actual.SqlDbType = SqlDbType.Int;
                ParStock_Actual.Value = Detalle_Ingreso.Stock_Actual;
                SqlCmd.Parameters.Add(ParStock_Actual);

                SqlParameter ParFecha_Produccion = new SqlParameter();
                ParFecha_Produccion.ParameterName = "@fecha_produccion";
                ParFecha_Produccion.SqlDbType = SqlDbType.Date;
                ParFecha_Produccion.Value = Detalle_Ingreso.Fecha_Produccion;
                SqlCmd.Parameters.Add(ParFecha_Produccion);

                SqlParameter ParFecha_Vencimiento = new SqlParameter();
                ParFecha_Vencimiento.ParameterName = "@fecha_vencimiento";
                ParFecha_Vencimiento.SqlDbType = SqlDbType.Date;
                ParFecha_Vencimiento.Value = Detalle_Ingreso.Fecha_Vencimiento;
                SqlCmd.Parameters.Add(ParFecha_Vencimiento);

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
