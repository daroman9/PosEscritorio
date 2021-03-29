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
   public class DFruver
    {
        private int _Idfruver;
        private string _Nombre;
        private decimal _Precio_Kilo;
        private string _TextoBuscar;

        public int Idfruver { get => _Idfruver; set => _Idfruver = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public decimal Precio_Kilo { get => _Precio_Kilo; set => _Precio_Kilo = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructor vacio

        public DFruver()
        {

        }
         
        //Constructor con parámetros

        public DFruver(int idfruver, string nombre, decimal precio_kilo, string textobuscar)
        {
            this.Idfruver = idfruver;
            this.Nombre = nombre;
            this.Precio_Kilo = precio_kilo;
            this.TextoBuscar = textobuscar;
        }

        //Método Insertar
        public string Insertar(DFruver Fruver)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código para insertar registros
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer comando para ejecutar sentencias sql
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_fruver";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros que se van a enviar al procedimiento almacenado
                SqlParameter ParIdFruver = new SqlParameter();
                ParIdFruver.ParameterName = "@idfruver";
                ParIdFruver.SqlDbType = SqlDbType.Int;
                ParIdFruver.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdFruver);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Fruver.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParPrecio_Kilo = new SqlParameter();
                ParPrecio_Kilo.ParameterName = "@precio_kilo";
                ParPrecio_Kilo.SqlDbType = SqlDbType.Decimal;
                ParPrecio_Kilo.Value = Fruver.Precio_Kilo;
                SqlCmd.Parameters.Add(ParPrecio_Kilo);

                //Ejecutar el comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        //Método Editar
        public string Editar(DFruver Fruver)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer comando para ejecutar sentencias sql
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_fruver";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros que se van a enviar al procedimiento almacenado
                SqlParameter ParIdFruver = new SqlParameter();
                ParIdFruver.ParameterName = "@idfruver";
                ParIdFruver.SqlDbType = SqlDbType.Int;
                ParIdFruver.Value = Fruver.Idfruver;
                SqlCmd.Parameters.Add(ParIdFruver);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Fruver.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParPrecio_Kilo = new SqlParameter();
                ParPrecio_Kilo.ParameterName = "@precio_kilo";
                ParPrecio_Kilo.SqlDbType = SqlDbType.Decimal;
                ParPrecio_Kilo.Value = Fruver.Precio_Kilo;
                SqlCmd.Parameters.Add(ParPrecio_Kilo);

                //Ejecutar el comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se actualizo el registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;

        }

        //Método Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("fruver");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_fruver";
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

        //Método BuscarNombre
        public DataTable BuscarNombre(DFruver Fruver)
        {
            DataTable DtResultado = new DataTable("fruver");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_fruver";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Fruver.TextoBuscar;
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
