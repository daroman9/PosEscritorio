using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NCliente
    {
        //Método que llama al método insertar de la clase DCliente de la capa datos

        public static string Insertar(string nombre, string apellidos, string sexo, DateTime fecha_nacimiento, string tipo_documento, string num_documento, string direccion, string telefono, string email)
        {
            DCliente Obj = new DCliente();
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;

            return Obj.Insertar(Obj);
        }
        //Método que llama al método editar de la clase DCliente de la capa de datos
        public static string Editar(int idcliente, string nombre, string apellidos, string sexo, DateTime fecha_nacimiento, string tipo_documento, string num_documento, string direccion, string telefono, string email)
        {
            DCliente Obj = new DCliente();
            Obj.Idcliente = idcliente;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;

            return Obj.Editar(Obj);
        }
        //Método que llama al método eliminar de la clase DCliente de la capa de datos
        public static string Eliminar(int idcliente)
        {
            DCliente Obj = new DCliente();
            Obj.Idcliente = idcliente;

            return Obj.Eliminar(Obj);
        }
        //Método que llama al método mostrar de la clase DCliente de la capa de datos
        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();
        }
        //Método que llama al método BuscarApellidos de la clase DCliente de la capa de datos
        public static DataTable BuscarApellidos(string textoBuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarApellidos(Obj);
        }
        //Método que llama al método BuscarNumDocumento de la clase DCliente de la capa de datos
        public static DataTable BuscarNumDocumento(string textoBuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNumDocumento(Obj);
        }
    }
}
