using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
  public  class NTrabajador
    {
        //Método que llama al método insertar de la clase DTrabajador de la capa datos

        public static string Insertar(string nombres, string apellidos, string sexo, DateTime fecha_nacimiento, string num_documento, string direccion, string telefono, string email, string acceso, string usuario, string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Nombres = nombres;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;

            return Obj.Insertar(Obj);
        }
        //Método que llama al método editar de la clase DTrabajador de la capa de datos
        public static string Editar(int idtrabajador, string nombres, string apellidos, string sexo, DateTime fecha_nacimiento, string num_documento, string direccion, string telefono, string email, string acceso, string usuario, string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Idtrabajador = idtrabajador;
            Obj.Nombres = nombres;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;

            return Obj.Editar(Obj);
        }
        //Método que llama al método eliminar de la clase DTrabajador de la capa de datos
        public static string Eliminar(int idtrabajador)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Idtrabajador = idtrabajador;

            return Obj.Eliminar(Obj);
        }
        //Método que llama al método mostrar de la clase DTrabajador de la capa de datos
        public static DataTable Mostrar()
        {
            return new DTrabajador().Mostrar();
        }
        //Método que llama al método BuscarApellidos de la clase DTrabajador de la capa de datos
        public static DataTable BuscarApellidos(string textoBuscar)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarApellidos(Obj);
        }
        //Método que llama al método BuscarNumDocumento de la clase DCliente de la capa de datos
        public static DataTable BuscarNumDocumento(string textoBuscar)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNumDocumento(Obj);
        }

        //Método que llama al método Login de la clase DCliente de la capa de datos
        public static DataTable Login(string usuario, string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Login(Obj);
        }
    }
}
