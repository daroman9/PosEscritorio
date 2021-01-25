﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NIngreso
    {
        //Método que llama al método insertar de la clase DIngreso de la capa datos

        public static string Insertar(int idtrabajador, int idproveedor, DateTime fecha,
            string serie, string estado, DataTable dtDetalles)
        {
            DIngreso Obj = new DIngreso();
            Obj.Idtrabajador = idtrabajador;
            Obj.Idproveedor = idproveedor;
            Obj.Fecha = fecha;
            Obj.Serie = serie;
            Obj.Estado = estado;
            List<DDetalle_Ingreso> detalles = new List<DDetalle_Ingreso>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_Ingreso detalle = new DDetalle_Ingreso();
                detalle.Idarticulo = Convert.ToInt32(row["idarticulo"].ToString());
                detalle.Precio_Compra = Convert.ToDecimal(row["precio_compra"].ToString());
                detalle.Precio_Venta= Convert.ToDecimal(row["precio_venta"].ToString());
                detalle.Stock_Inicial = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Stock_Actual = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Porcentaje = Convert.ToDecimal(row["porcentaje"].ToString());
                detalle.Utilidad = Convert.ToDecimal(row["utilidad".ToString()]);
                detalle.Fecha_Produccion = Convert.ToDateTime(row["fecha_produccion"].ToString());
                detalle.Fecha_Vencimiento = Convert.ToDateTime(row["fecha_vencimiento"].ToString());

                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj, detalles);
        }
        //Método que llama el método editat de la clase DDetalle_Ingreso de la capa de datos
        public static string Editar(int iddetalleingreso, decimal precio_compra, decimal precio_venta, int stock_inicial, decimal porcentaje, decimal utilidad, DateTime fecha_produccion, DateTime fecha_vencimiento)
        {
            DDetalle_Ingreso Obj = new DDetalle_Ingreso();
            Obj.Iddetalle_Ingreso = iddetalleingreso;
            Obj.Precio_Compra = precio_compra;
            Obj.Precio_Venta = precio_venta;
            Obj.Stock_Inicial = stock_inicial;
            Obj.Porcentaje = porcentaje;
            Obj.Utilidad = utilidad;
            Obj.Fecha_Produccion = fecha_produccion;
            Obj.Fecha_Vencimiento = fecha_vencimiento;
            
            return Obj.Editar(Obj);
        }
        //Método que llama al método anular de la clase DIngreso de la capa de datos
        public static string Anular(int idingreso)
        {
            DIngreso Obj = new DIngreso();
            Obj.Idingreso = idingreso;

            return Obj.Anular(Obj);
        }
        //Método que llama al método mostrar de la clase DIngreso de la capa de datos
        public static DataTable Mostrar()
        {
            return new DIngreso().Mostrar();
        }
        //Método que llama al método Buscar por fechas de la clase DIngreso de la capa de datos
        public static DataTable BuscarFechas(string textoBuscar, string textobuscar2)
        {
            DIngreso Obj = new DIngreso();
    
            return Obj.BuscarFechas(textoBuscar, textobuscar2);
        }
        //Método que llama al método Buscar detalle de la clase DIngreso de la capa de datos
        public static DataTable MostrarDetalle(string textoBuscar)
        {
            DIngreso Obj = new DIngreso();

            return Obj.MostrarDetalle(textoBuscar);
        }

        //Método que llama el método que busca la serie del último registro
        public static DataTable UltimaSerie()
        {
            return new DIngreso().UltimaSerie();
        }
    }
}
