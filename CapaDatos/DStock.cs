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
   public class DStock
    {
        private int _Codigo;
        private string _Marca;
        private string _Descripcion;
        private string _Contenido;
        private string _Categoria;
        private int _Cantidad_Ingreso;
        private int _Cantidad_Stock;
        private int _Cantidad_Venta;
        private string _TextoBuscar;

        public int Codigo { get => _Codigo; set => _Codigo = value; }
        public string Marca { get => _Marca; set => _Marca = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Contenido { get => _Contenido; set => _Contenido = value; }
        public string Categoria { get => _Categoria; set => _Categoria = value; }
        public int Cantidad_Ingreso { get => _Cantidad_Ingreso; set => _Cantidad_Ingreso = value; }
        public int Cantidad_Stock { get => _Cantidad_Stock; set => _Cantidad_Stock = value; }
        public int Cantidad_Venta { get => _Cantidad_Venta; set => _Cantidad_Venta = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }


        //Constructor sin parametros
        public DStock()
        {

        }
        //Constructor con parametros
        public DStock(int codigo, string marca, string descripcion, string contenido, string categoria, int cantidadingreso, int cantidadstock, int cantidadventa, string textobuscar)
        {
            Codigo = codigo;
            Marca = marca;
            Descripcion = descripcion;
            Contenido = contenido;
            Categoria = categoria;
            Cantidad_Ingreso = cantidadingreso;
            Cantidad_Stock = cantidadstock;
            Cantidad_Venta = cantidadventa;
            TextoBuscar = textobuscar;
        }

        //Método que muestra todos los articulos que existen en stock
        public DataTable Stock_Articulos()
        {
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spstock_articulos";
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
        //Método que busca los articulos en stock usando la descricpion
        public DataTable BuscarStockNombre(DStock Stock)
        {
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_stock_articulos_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Stock.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);


                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;
        }

        //Método que busca los articulos en stock usando el codigo de barras
        public DataTable BuscarStockCodigo(DStock Stock)
        {
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_stock_articulos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Stock.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);


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
