using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
  public  class NStock
    {
        //Método que llama al método que consulta todos los articulos que se encuentran en stock
        public static DataTable Mostrar()
        {
            return new DStock().Stock_Articulos();
        }
        //Método que llama al método que busca los articulos en stock por la descripcion
        public static DataTable BuscarStockNombre(string textoBuscar)
        {
            DStock Obj = new DStock();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarStockNombre(Obj);
        }

        //Método que llama al método que buscar un articulo en stock usando el codigo de barras
        public static DataTable BuscarStockCodigo(string textoBuscar)
        {
            DStock Obj = new DStock();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarStockCodigo(Obj);
        }
    }
}
