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

namespace CapaPresentacion
{
    public partial class FrmIngreso : Form
    {
        public int Idtrabajador;
        private bool IsNuevo;
        private DataTable dtDetalle;
        private decimal totalPagado = 0;
        private DataTable ultimaSerie;
        private bool listadoDetalle = true;
        public FrmIngreso()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtProveedor,"Seleccione el proveedor");
            this.ttMensaje.SetToolTip(this.txtSerie, "Ingrese la serie del comprobante");
            this.ttMensaje.SetToolTip(this.txtStockInicial, "Ingrese la cantidad de compra");
            this.txtIdArticulo.Visible = false;
            this.txtIdProveedor.Visible = false;
            this.txtArticulo.ReadOnly = true;
            this.txtProveedor.ReadOnly = true;
            this.txtSerie.ReadOnly = true;
          
        }

        private void FrmIngreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.CrearTabla();
        }
        //Mostrar mensaje de confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Mostrar mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //Método para limpiar los controles del formulario
        private void Limpiar()
        {
            this.txtIdIngreso.Text = string.Empty;
            this.txtIdProveedor.Text = string.Empty;
            this.txtProveedor.Text = string.Empty;
            this.txtSerie.Text = string.Empty;
            this.lblTotalPagado.Text = "0.0";
            this.ultimaSerie = null;
            this.CrearTabla();
        }
        private void LimpiarDetalle()
        {
            this.txtIdArticulo.Text = string.Empty;
            this.txtArticulo.Text = string.Empty;
            this.txtStockInicial.Text = string.Empty;
            this.txtPrecioCompra.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
        }
        //Método para habilitar los controles del formulario

        private void Habilitar(bool valor)
        {
            this.txtIdIngreso.Enabled = valor;
            this.dtFecha.Enabled = valor;
            this.txtStockInicial.Enabled = valor;
            this.txtPrecioCompra.Enabled = valor;
            this.txtPrecioVenta.Enabled = valor;
            this.dtFechaProduccion.Enabled = valor;
            this.dtFechaVencimiento.Enabled = valor;

            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
        }
        //Método para habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }
        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
 

            //Ocultar columnas del grid de Articulos
            this.dataListadoArticulos.Columns[0].Visible = false;
            this.dataListadoArticulos.Columns[6].Visible = false;
            this.dataListadoArticulos.Columns[8].Visible = false;
            this.dataListadoArticulos.Columns[9].Visible = false;
            this.dataListadoArticulos.Columns[10].Visible = false;
      
            //Ocultar columnas del grid de Proveedores
            this.dataListadoProveedores.Columns[0].Visible = false;
            this.dataListadoProveedores.Columns[5].Visible = false;
            this.dataListadoProveedores.Columns[6].Visible = false;
            this.dataListadoProveedores.Columns[7].Visible = false;
            this.dataListadoProveedores.Columns[8].Visible = false;
        }
        //Método mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NIngreso.Mostrar();
            this.dataListadoArticulos.DataSource = NArticulo.Mostrar();
            this.dataListadoProveedores.DataSource = NProveedor.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
            lblTotalArticulos.Text = "Total de registros: " + Convert.ToString(dataListadoArticulos.Rows.Count);
            lblTotalProveedores.Text = "Total de registros: " + Convert.ToString(dataListadoProveedores.Rows.Count);
        }
        //Método para buscar por fechas
        private void BuscarFechas()
        {
            this.dataListado.DataSource = NIngreso.BuscarFechas(this.dtFecha1.Value.ToString("dd/MM/yyyy"), this.dtFecha2.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método para buscar detalle
        private void MostrarDetalle()
        {
            this.dataListado.DataSource = NIngreso.MostrarDetalle(this.txtIdIngreso.Text);

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Desea anular los ingresos", "Sistema de ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NIngreso.Anular(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se anulo correctamente el ingreso");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.chkEliminar.Checked = false;
                    this.Mostrar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void CrearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("Idarticulo", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Articulo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Precio_compra", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Precio_venta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Stock_inicial", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Fecha_produccion", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("Fecha_vencimiento", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("Subtotal", System.Type.GetType("System.Decimal"));
            //Relacionar nuestro DataGRidView con nuestro DataTable
            this.dataListadoDetalle.DataSource = this.dtDetalle;

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.UltimaSerie();
            this.txtStockInicial.Focus();
            this.LimpiarDetalle();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.LimpiarDetalle();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtIdProveedor.Text == string.Empty || this.txtSerie.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algun dato");
                    errorIcono.SetError(txtIdProveedor, "Ingrese un valor");
                    errorIcono.SetError(txtSerie, "Ingrese un valor");
                }
                else
                {
                   
                    if (this.IsNuevo)
                    {
             
                        rpta = NIngreso.Insertar(Idtrabajador, Convert.ToInt32(this.txtIdProveedor.Text), dtFecha.Value,
                                                 this.txtSerie.Text, "EMITIDO", dtDetalle);
                    }
                   
                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se inserto correctamente en registro");
                        }
                  
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.IsNuevo = false;
                    this.Botones();
                    this.Limpiar();
                    this.LimpiarDetalle();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
        
                if (this.txtIdArticulo.Text == string.Empty || this.txtStockInicial.Text == string.Empty || this.txtPrecioCompra.Text == string.Empty || this.txtPrecioVenta.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algun dato");
                    errorIcono.SetError(txtIdArticulo, "Ingrese un valor");
                    errorIcono.SetError(txtStockInicial, "Ingrese un valor");
                    errorIcono.SetError(txtPrecioCompra, "Ingrese un valor");
                    errorIcono.SetError(txtPrecioVenta, "Ingrese un valor");
                }
                else
                {
                    bool registrar = true;

                    foreach(DataRow row in dtDetalle.Rows)
                    {
                        if(Convert.ToInt32(row["idarticulo"])== Convert.ToInt32(this.txtIdArticulo.Text))
                        {
                            registrar = false;
                            this.MensajeError("Ya se encuentra el articulo en el detalle");
                        }
                    }
                    if(registrar)
                    {
                        decimal subtotal = Convert.ToDecimal(this.txtStockInicial.Text) * Convert.ToDecimal(this.txtPrecioCompra.Text);
                        totalPagado = totalPagado + subtotal;
                        this.lblTotalPagado.Text = totalPagado.ToString("#0.00#");
                        //Agregar detalle al datalistadoDetalle
                        DataRow row = this.dtDetalle.NewRow();
                        row["Idarticulo"] = Convert.ToInt32(this.txtIdArticulo.Text);
                        row["Articulo"] = this.txtArticulo.Text;
                        row["Precio_compra"] = Convert.ToDecimal(this.txtPrecioCompra.Text);
                        row["Precio_venta"] = Convert.ToDecimal(this.txtPrecioVenta.Text);
                        row["Stock_inicial"] = Convert.ToInt32(this.txtStockInicial.Text);
                        row["Fecha_produccion"] = dtFechaProduccion.Value;
                        row["Fecha_vencimiento"] = dtFechaVencimiento.Value;
                        row["Subtotal"] = subtotal;

                        this.dtDetalle.Rows.Add(row);

                        this.LimpiarDetalle();
                    }
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceFila = this.dataListadoDetalle.CurrentCell.RowIndex;
                DataRow row = this.dtDetalle.Rows[indiceFila];
                //Disminuir el total pagado
                this.totalPagado = this.totalPagado - Convert.ToDecimal(row["subtotal"].ToString());
                this.lblTotalPagado.Text = totalPagado.ToString("#0.00#");
                //Removemos la fila
                this.dtDetalle.Rows.Remove(row);

            }
            catch(Exception ex)
            {
                MensajeError("No hay fila para remover");
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            if(listadoDetalle)
            {
                this.txtIdIngreso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idingreso"].Value);
                this.txtProveedor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Proveedor"].Value);
                this.dtFecha.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["Fecha"].Value);
                this.txtSerie.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Serie"].Value);
                this.lblTotalPagado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Total"].Value);

                this.MostrarDetalle();
                //this.tabControl1.SelectedIndex = 0;
                this.chkEliminar.Visible = false;
                this.btnVolverDataListado.Visible = true;
                this.lblTotal.Text = Convert.ToString("Total de registros: " + dataListado.Rows.Count);
                this.listadoDetalle = false;
            }
            else
            {

                // this.chkEliminar.Visible = true;
                MessageBox.Show("Hola");
               
            }
        }
        //Método para obtener la serie del último registro
        public void UltimaSerie()
        {
            int ultimoValor;
            this.ultimaSerie = NIngreso.UltimaSerie();
            ultimoValor = Convert.ToInt32(this.ultimaSerie.Rows[0]["Serie"].ToString().Substring(3));
            ultimoValor++;
            this.txtSerie.Text = Convert.ToString("IN-"+ultimoValor);
        }
        private void dataListadoArticulos_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdArticulo.Text = Convert.ToString(this.dataListadoArticulos.CurrentRow.Cells["idarticulo"].Value);
            this.txtArticulo.Text = Convert.ToString(this.dataListadoArticulos.CurrentRow.Cells["descripcion"].Value + " " +
            this.dataListadoArticulos.CurrentRow.Cells["marca"].Value + " " + "X" + " " + this.dataListadoArticulos.CurrentRow.Cells["contenido"].Value);
        }

        private void dataListadoProveedores_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdProveedor.Text = Convert.ToString(this.dataListadoProveedores.CurrentRow.Cells["idproveedor"].Value);
            this.txtProveedor.Text = Convert.ToString(this.dataListadoProveedores.CurrentRow.Cells["razon_social"].Value);
        }

        private void txtBuscarNombreArticulo_TextChanged(object sender, EventArgs e)
        {
            this.dataListadoArticulos.DataSource = NArticulo.BuscarNombre(this.txtBuscarNombreArticulo.Text);
            this.OcultarColumnas();
            this.lblTotalArticulos.Text = "Total de registros: " + Convert.ToString(dataListadoArticulos.Rows.Count);
        }

        private void txtStockInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnVolverDataListado_Click(object sender, EventArgs e)
        {
            this.dataListado.DataSource = NIngreso.Mostrar();
            this.chkEliminar.Visible = true;
            this.lblTotal.Text = Convert.ToString("Total de registros: " + dataListado.Rows.Count);
            this.listadoDetalle = true;
        }
    }
}
