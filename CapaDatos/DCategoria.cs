using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Librerias que se deben  importar para poder trabajar con sql server
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    class DCategoria
    {
        private int _Idcategoria;
        private string _Nombre;
        private string _Descripcion;
        private string _TextoBuscar;

        public int Idcategoria { get => _Idcategoria; set => _Idcategoria = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructor vacio 
        public DCategoria()
        {

        }

        //Constructor con parámetros

        public DCategoria(int idcategoria, string nombre, string descripcion, string textobuscar)
        {
            this.Idcategoria = idcategoria;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;
        }

        //Método Insertar
        public string Insertar(DCategoria Categoria)
        {

        }

        //Método Editar
        public string Editar (DCategoria Categoria)
        {

        }

        //Método Eliminar
        public string Eliminar(DCategoria Categoria)
        {

        }

        //Método Mostrar
        public DataTable Mostrar()
        {

        }

        //Método BuscarNombre
        public DataTable BuscarNombre(DCategoria Categoria)
        {

        }


    }
}
