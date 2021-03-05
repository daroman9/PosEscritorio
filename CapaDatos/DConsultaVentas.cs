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
   public class DConsultaVentas
    {
        private string _Factura;
        private DateTime _Fecha;
        private decimal _Total;
        private decimal _Efectivo;
        private decimal _Tarjetas;
        private decimal _Iva5;
        private decimal _Iva19;
        private string _TextoBuscar;
        private string _TextoBuscar2;

        public string Factura { get => _Factura; set => _Factura = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public decimal Total { get => _Total; set => _Total = value; }
        public decimal Efectivo { get => _Efectivo; set => _Efectivo = value; }
        public decimal Tarjetas { get => _Tarjetas; set => _Tarjetas = value; }
        public decimal Iva5 { get => _Iva5; set => _Iva5 = value; }
        public decimal Iva19 { get => _Iva19; set => _Iva19 = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        public string TextoBuscar2 { get => _TextoBuscar2; set => _TextoBuscar2 = value; }

        //Constructor sin parametros
        public DConsultaVentas()
        {

        }

        //Constructor con parámetros
        public DConsultaVentas(string factura, DateTime fecha, decimal total, decimal efectivo, decimal tarjetas, decimal iva5, decimal iva19, string textobuscar, string textobuscar2)
        {
            this.Factura = factura;
            this.Fecha = fecha;
            this.Total = total;
            this.Efectivo = efectivo;
            this.Tarjetas = tarjetas;
            this.Iva5 = iva5;
            this.Iva19 = iva19;
            this.TextoBuscar = textobuscar;
            this.TextoBuscar2 = textobuscar2;
        }

        //Método que muestra todos los articulos que existen en stock
        public DataTable Ventas_Diarias()
        {
            DataTable DtResultado = new DataTable("ventas");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spventas_diarias";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;
        }
        //Método que busca los artículos en stock usando la descricpión
        public DataTable BuscarVentasFechas(DConsultaVentas ConsultasVentas)
        {
            DataTable DtResultado = new DataTable("ventas");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spventas_diarias_acumuladas";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = ConsultasVentas.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlParameter ParTextoBuscar2 = new SqlParameter();
                ParTextoBuscar2.ParameterName = "@textobuscar2";
                ParTextoBuscar2.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar2.Size = 50;
                ParTextoBuscar2.Value = ConsultasVentas.TextoBuscar2;
                SqlCmd.Parameters.Add(ParTextoBuscar2);


                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;
        }
    }
}
