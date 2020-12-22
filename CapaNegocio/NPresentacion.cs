using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NPresentacion
    {
        //Método que llama al método insertar de la clase DPresentacion de la capa datos

        public static string Insertar(string nombre, string descripcion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;

            return Obj.Insertar(Obj);
        }
        //Método que llama al método editar de la clase DPresentacion de la capa de datos
        public static string Editar(int idpresentacion, string nombre, string descripcion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.IdPresentacion = idpresentacion;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;

            return Obj.Editar(Obj);
        }
        //Método que llama al método eliminar de la clase DPresentacion de la capa de datos
        public static string Eliminar(int idpresentacion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.IdPresentacion = idpresentacion;

            return Obj.Eliminar(Obj);
        }
        //Método que llama al método mostrar de la clase DPresentacion de la capa de datos
        public static DataTable Mostrar()
        {
            return new DPresentacion().Mostrar();
        }
        //Método que llama al método BuscarNombre de la clase DPresentacion de la capa de datos
        public static DataTable BuscarNombre(string textoBuscar)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
