﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Librerias que se deben  importar para poder trabajar con sql server
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class DTrabajador
    {
        private int _Idtrabajador;
        private string _Nombres;
        private string _Apellidos;
        private string _Sexo;
        private DateTime _Fecha_Nacimiento;
        private string _Num_Documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Acceso;
        private string _Usuario;
        private string _Password;
        private string _TextoBuscar;

        public int Idtrabajador { get => _Idtrabajador; set => _Idtrabajador = value; }
        public string Nombres { get => _Nombres; set => _Nombres = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public DateTime Fecha_Nacimiento { get => _Fecha_Nacimiento; set => _Fecha_Nacimiento = value; }
        public string Num_Documento { get => _Num_Documento; set => _Num_Documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Acceso { get => _Acceso; set => _Acceso = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }


        //Constructor vacio
        public DTrabajador()
        {

        }
        //Constructor con parametros
        public DTrabajador(int idtrabajador, string nombres, string apellidos, string sexo, DateTime fecha_nacimiento, string num_documento, string direccion, string telefono, string email, string acceso, string usuario, string password, string textobuscar)
        {
            Idtrabajador = idtrabajador;
            Nombres = nombres;
            Apellidos = apellidos;
            Sexo = sexo;
            Fecha_Nacimiento = fecha_nacimiento;
            Num_Documento = num_documento;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
            Acceso = acceso;
            Usuario = usuario;
            Password = password;
            TextoBuscar = textobuscar;
        }
        //Método Insertar
        public string Insertar(DTrabajador Trabajador)
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
                SqlCmd.CommandText = "spinsertar_trabajador";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros que se van a enviar al procedimiento almacenado
                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idtrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParNombres = new SqlParameter();
                ParNombres.ParameterName = "@nombres";
                ParNombres.SqlDbType = SqlDbType.VarChar;
                ParNombres.Size = 50;
                ParNombres.Value = Trabajador.Nombres;
                SqlCmd.Parameters.Add(ParNombres);

                SqlParameter ParApellidos = new SqlParameter();
                ParApellidos.ParameterName = "@apellidos";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 50;
                ParApellidos.Value = Trabajador.Apellidos;
                SqlCmd.Parameters.Add(ParApellidos);


                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 50;
                ParSexo.Value = Trabajador.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParFecha_Nacimiento = new SqlParameter();
                ParFecha_Nacimiento.ParameterName = "@fecha_nacimiento";
                ParFecha_Nacimiento.SqlDbType = SqlDbType.Date;
                ParFecha_Nacimiento.Value = Trabajador.Fecha_Nacimiento;
                SqlCmd.Parameters.Add(ParFecha_Nacimiento);

                SqlParameter ParNumDocumento = new SqlParameter();
                ParNumDocumento.ParameterName = "@num_documento";
                ParNumDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumDocumento.Size = 20;
                ParNumDocumento.Value = Trabajador.Num_Documento;
                SqlCmd.Parameters.Add(ParNumDocumento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Trabajador.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 50;
                ParTelefono.Value = Trabajador.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Trabajador.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@acceso";
                ParAcceso.SqlDbType = SqlDbType.VarChar;
                ParAcceso.Size = 20;
                ParAcceso.Value = Trabajador.Acceso;
                SqlCmd.Parameters.Add(ParAcceso);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Trabajador.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 50;
                ParPassword.Value = Trabajador.Password;
                SqlCmd.Parameters.Add(ParPassword);
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
        public string Editar(DTrabajador Trabajador)
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
                SqlCmd.CommandText = "speditar_trabajador";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros que se van a enviar al procedimiento almacenado
                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idtrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Trabajador.Idtrabajador;
                SqlCmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParNombres = new SqlParameter();
                ParNombres.ParameterName = "@nombres";
                ParNombres.SqlDbType = SqlDbType.VarChar;
                ParNombres.Size = 50;
                ParNombres.Value = Trabajador.Nombres;
                SqlCmd.Parameters.Add(ParNombres);

                SqlParameter ParApellidos = new SqlParameter();
                ParApellidos.ParameterName = "@apellidos";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 50;
                ParApellidos.Value = Trabajador.Apellidos;
                SqlCmd.Parameters.Add(ParApellidos);


                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 50;
                ParSexo.Value = Trabajador.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParFecha_Nacimiento = new SqlParameter();
                ParFecha_Nacimiento.ParameterName = "@fecha_nacimiento";
                ParFecha_Nacimiento.SqlDbType = SqlDbType.Date;
                ParFecha_Nacimiento.Value = Trabajador.Fecha_Nacimiento;
                SqlCmd.Parameters.Add(ParFecha_Nacimiento);

                SqlParameter ParNumDocumento = new SqlParameter();
                ParNumDocumento.ParameterName = "@num_documento";
                ParNumDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumDocumento.Size = 20;
                ParNumDocumento.Value = Trabajador.Num_Documento;
                SqlCmd.Parameters.Add(ParNumDocumento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Trabajador.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 50;
                ParTelefono.Value = Trabajador.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Trabajador.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@acceso";
                ParAcceso.SqlDbType = SqlDbType.VarChar;
                ParAcceso.Size = 20;
                ParAcceso.Value = Trabajador.Acceso;
                SqlCmd.Parameters.Add(ParAcceso);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Trabajador.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 50;
                ParPassword.Value = Trabajador.Password;
                SqlCmd.Parameters.Add(ParPassword);

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

        //Método Eliminar
        public string Eliminar(DTrabajador Trabajador)
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
                SqlCmd.CommandText = "speliminar_trabajador";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros que se van a enviar al procedimiento almacenado
                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idtrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Trabajador.Idtrabajador;
                SqlCmd.Parameters.Add(ParIdTrabajador);

                //Ejecutar el comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el registro";

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
            DataTable DtResultado = new DataTable("trabajador");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_trabajador";
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
        public DataTable BuscarApellidos(DTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_trabajador_apellidos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Trabajador.TextoBuscar;
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

        //Metodo para buscar por documento
        public DataTable BuscarNumDocumento(DTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_trabajador_num_documento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Trabajador.TextoBuscar;
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

        //Metodo para hacer el login
        public DataTable Login(DTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "splogin";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Trabajador.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 20;
                ParPassword.Value = Trabajador.Password;
                SqlCmd.Parameters.Add(ParPassword);


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
