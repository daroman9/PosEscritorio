using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NFruver
    {
        //Método que llama al método insertar de la clase DFruver de la capa datos
        public static string Insertar(string nombre, decimal precio_kilo)
        {
            DFruver Obj = new DFruver();
            Obj.Nombre = nombre;
            Obj.Precio_Kilo = precio_kilo;
            
            return Obj.Insertar(Obj);
        }
        //Método que llama al método editar de la clase DFruver de la capa de datos
        public static string Editar(int idfruver, string nombre, decimal precio_kilo)
        {
            DFruver Obj = new DFruver();
            Obj.Idfruver = idfruver;
            Obj.Nombre = nombre;
            Obj.Precio_Kilo = precio_kilo;
         
            return Obj.Editar(Obj);
        }
       
        //Método que llama al método mostrar de la clase DFruver de la capa de datos
        public static DataTable Mostrar()
        {
            return new DFruver().Mostrar();
        }
        //Método que llama al método BuscarNombre de la clase DFruver de la capa de datos
        public static DataTable BuscarNombre(string textoBuscar)
        {
            DFruver Obj = new DFruver();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}