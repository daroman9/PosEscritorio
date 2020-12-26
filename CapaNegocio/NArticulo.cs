using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NArticulo
    {
        //Método que llama al método insertar de la clase DArticulo de la capa datos

        public static string Insertar(string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion)
        {
            DArticulo Obj = new DArticulo();
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Imagen = imagen;
            Obj.IdCategoria = idcategoria;
            Obj.IdPresentacion = idpresentacion;

            return Obj.Insertar(Obj);
        }
        //Método que llama al método editar de la clase DArticulo de la capa de datos
        public static string Editar(int idarticulo, string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion)
        {
            DArticulo Obj = new DArticulo();
            Obj.IdArticulo = idarticulo;
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Imagen = imagen;
            Obj.IdCategoria = idcategoria;
            Obj.IdPresentacion = idpresentacion;

            return Obj.Editar(Obj);
        }
        //Método que llama al método eliminar de la clase DArticulo de la capa de datos
        public static string Eliminar(int idarticulo)
        {
            DArticulo Obj = new DArticulo();
            Obj.IdArticulo = idarticulo;

            return Obj.Eliminar(Obj);
        }
        //Método que llama al método mostrar de la clase DArticulo de la capa de datos
        public static DataTable Mostrar()
        {
            return new DArticulo().Mostrar();
        }
        //Método que llama al método BuscarNombre de la clase DArticulo de la capa de datos
        public static DataTable BuscarNombre(string textoBuscar)
        {
            DArticulo Obj = new DArticulo();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
