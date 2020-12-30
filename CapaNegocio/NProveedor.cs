using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
     public class NProveedor
    {
        //Método que llama al método insertar de la clase DProveedor de la capa datos

        public static string Insertar(string razon_social, string sector_comercial, string tipo_documento, string num_documento, string direccion, string telefono, string email, string url)
        {
            DProveedor Obj = new DProveedor();
            Obj.Razon_Social = razon_social;
            Obj.Sector_Comercial = sector_comercial;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Url = url;
     
            return Obj.Insertar(Obj);
        }
        //Método que llama al método editar de la clase DProveedor de la capa de datos
        public static string Editar(int idproveedor, string razon_social, string sector_comercial, string tipo_documento, string num_documento, string direccion, string telefono, string email, string url)
        {
            DProveedor Obj = new DProveedor();
            Obj.Idproveedor = idproveedor;
            Obj.Razon_Social = razon_social;
            Obj.Sector_Comercial = sector_comercial;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Url = url;

            return Obj.Editar(Obj);
        }
        //Método que llama al método eliminar de la clase DProveedor de la capa de datos
        public static string Eliminar(int idprovedor)
        {
            DProveedor Obj = new DProveedor();
            Obj.Idproveedor = idprovedor;

            return Obj.Eliminar(Obj);
        }
        //Método que llama al método mostrar de la clase DProveedor de la capa de datos
        public static DataTable Mostrar()
        {
            return new DProveedor().Mostrar();
        }
        //Método que llama al método Buscar por razon social de la clase DProveedor de la capa de datos
        public static DataTable BuscarRazonSocial(string textoBuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarRazonSocial(Obj);
        }
        //Método que llama al método Buscar por documento de la clase DProveedor de la capa de datos
        public static DataTable BuscarNumDocumento(string textoBuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNumDocumento(Obj);
        }
    }
}
