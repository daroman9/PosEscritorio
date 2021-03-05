using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Office.Interop.Excel;

using CapaNegocio;

namespace CapaPresentacion.Consultas
{
    public partial class FrmConsulta_Ventas : Form
    {
        public FrmConsulta_Ventas()
        {
            InitializeComponent();
        }

        private void FrmConsulta_Ventas_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        //Método mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NConsultaVentas.Mostrar();
            //this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            this.exportarExcel(this.dataListado);
        }


        public void exportarExcel(DataGridView tabla)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Application.Workbooks.Add(true);

            int IndiceColumna = 0;

            foreach(DataGridViewColumn col in tabla.Columns) //Columnas
            {
                IndiceColumna++;
                excel.Cells[1, IndiceColumna] = col.Name;
            }

            int IndiceFila = 0;

            foreach(DataGridViewRow row in tabla.Rows) //Filas
            {
                IndiceFila++;
                IndiceColumna = 0;

                foreach(DataGridViewColumn col in tabla.Columns)
                {
                    IndiceColumna++;

                    excel.Cells[IndiceFila + 1, IndiceColumna] = row.Cells[col.Name].Value;

                }
            }

            excel.Visible = true;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarVentasFechas();
        }
        private void BuscarVentasFechas()
        {
            this.dataListado.DataSource = NConsultaVentas.BuscarVentasFechas(Convert.ToString(this.dtFecha1.Value), Convert.ToString(this.dtFecha2.Value));
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }
    }
}
