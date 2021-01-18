using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
  public  class NCategoria
    {
        //Método que llama al método insertar de la clase DCategoria de la capa datos

        public static string Insertar (string nombre, string descripcion, int impuesto)
        {
            DCategoria Obj = new DCategoria();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Impuesto = impuesto;

            return Obj.Insertar(Obj);
        }
        //Método que llama al método editar de la clase DCategoria de la capa de datos
        public static string Editar(int idcategoria, string nombre, string descripcion, int impuesto)
        {
            DCategoria Obj = new DCategoria();
            Obj.Idcategoria = idcategoria;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Impuesto = impuesto;

            return Obj.Editar(Obj);
        }
        //Método que llama al método eliminar de la clase DCategoria de la capa de datos
        public static string Eliminar(int idcategoria)
        {
            DCategoria Obj = new DCategoria();
            Obj.Idcategoria = idcategoria;

            return Obj.Eliminar(Obj);
        }
        //Método que llama al método mostrar de la clase DCategoria de la capa de datos
        public static DataTable Mostrar()
        {
            return new DCategoria().Mostrar();
        }
        //Método que llama al método BuscarNombre de la clase DCategoria de la capa de datos
        public static DataTable BuscarNombre(string textoBuscar)
        {
            DCategoria Obj = new DCategoria();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNombre(Obj);
        }

    }
}
