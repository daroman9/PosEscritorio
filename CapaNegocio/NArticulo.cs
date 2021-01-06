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

        public static string Insertar(string codigo, string marca, string descripcion, byte[] imagen, int idcategoria, int idpresentacion, string contenido)
        {
            DArticulo Obj = new DArticulo();
            Obj.Codigo = codigo;
            Obj.Marca = marca;
            Obj.Descripcion = descripcion;
            Obj.Imagen = imagen;
            Obj.IdCategoria = idcategoria;
            Obj.IdPresentacion = idpresentacion;
            Obj.Contenido = contenido;

            return Obj.Insertar(Obj);
        }
        //Método que llama al método editar de la clase DArticulo de la capa de datos
        public static string Editar(int idarticulo, string codigo, string marca, string descripcion, byte[] imagen, int idcategoria, int idpresentacion, string contenido)
        {
            DArticulo Obj = new DArticulo();
            Obj.IdArticulo = idarticulo;
            Obj.Codigo = codigo;
            Obj.Marca = marca;
            Obj.Descripcion = descripcion;
            Obj.Imagen = imagen;
            Obj.IdCategoria = idcategoria;
            Obj.IdPresentacion = idpresentacion;
            Obj.Contenido = contenido;

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

        //Método que llama al método Buscar por codigo de la clase DArticulo de la capa de datos
        public static DataTable BuscarCodigo(string textoBuscar)
        {
            DArticulo Obj = new DArticulo();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarCodigo(Obj);
        }

        //Método que llama al método mostrar stock de la clase DArticulo de la capa de datos
        public static DataTable Stock_Articulos()
        {
            return new DArticulo().Stock_Articulos();
        }
    }
}
