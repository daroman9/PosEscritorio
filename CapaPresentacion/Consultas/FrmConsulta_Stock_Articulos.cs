using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;

namespace CapaPresentacion.Consultas
{
    public partial class FrmConsulta_Stock_Articulos : Form
    {
        public FrmConsulta_Stock_Articulos()
        {
            InitializeComponent();
        }

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[6].Visible = false;
        }

        //Método mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NStock.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void FrmConsulta_Stock_Articulos_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        private void BuscarNombre()
        {
            this.dataListado.DataSource = NStock.BuscarStockNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (13))
            {
                this.dataListado.DataSource = NStock.BuscarStockCodigo(this.txtCodigo.Text);
                this.OcultarColumnas();
                lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
            }
        }
    }
}
