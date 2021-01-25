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
    public partial class FrmVenta : Form
    {
        private bool IsNuevo = false;
        public int Idtrabajador;
        private DataTable dtDetalle;
        public int codLength;
        public string codigoBarras;
        public string serie;
        public double totalcuenta = 0;
        public int totalArticulos = 0;

        public FrmVenta()
        {
            InitializeComponent();
            this.txtIdCliente.Visible = false;
            this.txtCliente.ReadOnly = true;
          
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.CrearTabla();
            this.alternarColores(this.dataListadoDetalle);

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
            this.txtCodigoBarras.Text = string.Empty;
            this.txtIdCliente.Text = string.Empty;
            this.txtIdCliente.Text = string.Empty;
            this.txtSerie.Text = string.Empty;
            this.txtIgv.Text = "19";
            this.lblTotalPagado.Text = "0.0";
            //this.CrearTabla();

        }
        private void LimpiarDetalle()
        {
           
            this.txtDescuento.Text = string.Empty;

        }
        //Método para habilitar los controles del formulario

        private void Habilitar(bool valor)
        {
            this.txtCodigoBarras.ReadOnly = !valor;
            this.txtSerie.ReadOnly = !valor;
            this.txtIgv.ReadOnly = !valor;
            this.dtFecha.Enabled = valor;
            this.txtCantidad.ReadOnly = !valor;
            this.txtDescuento.ReadOnly = !valor;
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

            //ocultar las columnas del listado de articulos
            this.dataListadoArticulos.Columns[0].Visible = false;
            this.dataListadoArticulos.Columns[1].Visible = false;

            //ocultar las columnas del listado de clientes
            this.dataListadoClientes.Columns[0].Visible = false;
            this.dataListadoClientes.Columns[1].Visible = false;
        }
        //Método para alternar los colores de las filas del datagrid
        public void alternarColores(DataGridView dgv)
        {
            dgv.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }
        //Método mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NVenta.MostrarTrabajadorFecha(Idtrabajador, DateTime.Today);
            this.dataListadoArticulos.DataSource = NVenta.MostrarArticulo_Venta_Nombre(this.txtBuscarNombreArticulo.Text);
            this.dataListadoClientes.DataSource = NCliente.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método para buscar por fechas
        private void BuscarFechas()
        {
            this.dataListado.DataSource = NVenta.BuscarFechas(this.dtFecha1.Value.ToString("dd/MM/yyyy"), this.dtFecha2.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método para buscar detalle
        private void MostrarDetalle()
        {
            this.dataListado.DataSource = NVenta.MostrarDetalle(this.txtCodigoBarras.Text);
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        //Método BuscarNombre
        private void MostrarArticulo_Venta_Nombre()
        {
            this.dataListadoArticulos.DataSource = NVenta.MostrarArticulo_Venta_Nombre(this.txtBuscarNombreArticulo.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void CrearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("Detalle_Ingreso", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Codigo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Descripción", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Marca", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Categoria", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Presentacion", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Stock", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Precio_Compra", System.Type.GetType("System.Double"));
            this.dtDetalle.Columns.Add("Precio_Venta", System.Type.GetType("System.Double"));
            this.dtDetalle.Columns.Add("Descuento", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Fecha_Vencimiento", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("Cantidad", System.Type.GetType("System.Int32"));
            //Relacionar nuestro DataGRidView con nuestro DataTable
            this.dataListadoDetalle.DataSource = this.dtDetalle;

        }
        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            this.BuscarFechas();
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
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Desea eliminar los ingresos", "Sistema de ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NVenta.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se elimino correctamente el ingreso");
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

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtCodigoBarras.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idventa"].Value);
            this.txtCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cliente"].Value);
            this.dtFecha.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha"].Value);
            this.txtSerie.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["serie"].Value);
            this.lblTotalPagado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["total"].Value);

            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.LimpiarDetalle();
            this.Habilitar(true);
            this.txtSerie.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.LimpiarDetalle();
            this.Habilitar(false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtSerie.Text == string.Empty || this.txtIgv.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algun dato");
                    errorIcono.SetError(txtSerie, "Ingrese un valor");
                    errorIcono.SetError(txtIgv, "Ingrese un valor");
                }
                else
                {

                    if (this.IsNuevo)
                    {

                        rpta = NVenta.Insertar(Convert.ToInt32(this.txtIdCliente.Text), Idtrabajador, dtFecha.Value,
                                                 this.txtSerie.Text, Convert.ToDecimal(this.txtIgv.Text), Convert.ToDecimal(this.lblTotalPagado.Text), dtDetalle);
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
      
        private void btnBuscarNombreArticulos_Click(object sender, EventArgs e)
        {
            this.MostrarArticulo_Venta_Nombre();
        }

        private void dataListadoArticulos_DoubleClick(object sender, EventArgs e)
        {
            int par1, par7 ;
            string par2, par3, par4, par5, par6;
            double par8, par9,par10, descuento, descuentoarticulo, preciodescuento;
            DateTime par11;
            par1 = Convert.ToInt32(this.dataListadoArticulos.CurrentRow.Cells["Detalle_Ingreso"].Value);
            par2 = Convert.ToString(this.dataListadoArticulos.CurrentRow.Cells["Codigo"].Value);
            par3 = Convert.ToString(this.dataListadoArticulos.CurrentRow.Cells["Descripción"].Value);
            par4 = Convert.ToString(this.dataListadoArticulos.CurrentRow.Cells["Marca"].Value);
            par5 = Convert.ToString(this.dataListadoArticulos.CurrentRow.Cells["Categoria"].Value);
            par6 = Convert.ToString(this.dataListadoArticulos.CurrentRow.Cells["Presentacion"].Value);
            par7 = Convert.ToInt32(this.dataListadoArticulos.CurrentRow.Cells["Stock"].Value);
            par8 = Convert.ToDouble(this.dataListadoArticulos.CurrentRow.Cells["Precio_Compra"].Value);
            par9 = Convert.ToDouble(this.dataListadoArticulos.CurrentRow.Cells["Precio_Venta"].Value);
            par10 = Convert.ToDouble(this.dataListadoArticulos.CurrentRow.Cells["Descuento"].Value);
            par11 = Convert.ToDateTime(this.dataListadoArticulos.CurrentRow.Cells["Fecha_Vencimiento"].Value);


            //Calculamos el descuento de cada articulo

            descuento = par10 / 100.0;

            descuentoarticulo = Convert.ToDouble(par9) * descuento;

            preciodescuento = par9 - Convert.ToDouble(descuentoarticulo);
           
            //Agregar al listado de articulos para la factura
            DataRow row = this.dtDetalle.NewRow();
            row["Detalle_Ingreso"] = par1;
            row["Codigo"] = par2;
            row["Descripción"] = par3;
            row["Marca"] = par4;
            row["Categoria"] = par5;
            row["Presentacion"] = par6;
            row["Stock"] = par7;
            row["Precio_Compra"] = par8;
            row["Precio_Venta"] = preciodescuento;
            row["Descuento"] = par10;
            row["Fecha_Vencimiento"] = par11;
            row["Cantidad"] = 1;

            this.dtDetalle.Rows.Add(row);

            lblArticulo.Text = par3 + " " + par4 + " " + par6;

            //Calcular el total de la cuenta
            totalcuenta = totalcuenta + preciodescuento;

            lblTotalPagado.Text = Convert.ToString(totalcuenta);

            //Calcular el total de items de cada compra
            cacularItems();
            //Limpar las variables
            par1 = 0;
            par2 = string.Empty;
            par3 = string.Empty;
            par4 = string.Empty;
            par5 = string.Empty;
            par6 = string.Empty;
            par7 = 0;
            par8 = 0;
            par9 = 0;
            par10 = 0;

            this.tabControl1.SelectedIndex = 1;
            this.txtCodigoBarras.Text = string.Empty;
            this.txtCodigoBarras.Focus();

        }

        private void dataListadoClientes_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdCliente.Text = Convert.ToString(this.dataListadoClientes.CurrentRow.Cells["idcliente"].Value);
            this.txtCliente.Text = Convert.ToString(this.dataListadoClientes.CurrentRow.Cells["nombre"].Value)  + ' ' + (this.dataListadoClientes.CurrentRow.Cells["apellidos"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void cacularItems()
        {
            int sumatoria = 0;

            foreach (DataGridViewRow row in dataListadoDetalle.Rows)
            {
                sumatoria += Convert.ToInt32(row.Cells["Cantidad"].Value);
            }
        
            lblTotalArticulos.Text = Convert.ToString(sumatoria);
        }
        private void txtCodigoBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (13))
            {
                DataTable articulo = NVenta.Mostrar_Articulo_Codigo(this.txtCodigoBarras.Text);
                dataArticulo.DataSource = articulo;

                if (articulo.Rows.Count != 0)
                {
                    int par1, par7;
                    string par2, par3, par4, par5, par6;
                    double par8, par9, par10, descuento, descuentoarticulo, preciodescuento;
                    DateTime par11;
                    par1 = Convert.ToInt32(this.dataArticulo.CurrentRow.Cells["Detalle_Ingreso"].Value);
                    par2 = Convert.ToString(this.dataArticulo.CurrentRow.Cells["Codigo"].Value);
                    par3 = Convert.ToString(this.dataArticulo.CurrentRow.Cells["Descripción"].Value);
                    par4 = Convert.ToString(this.dataArticulo.CurrentRow.Cells["Marca"].Value);
                    par5 = Convert.ToString(this.dataArticulo.CurrentRow.Cells["Categoria"].Value);
                    par6 = Convert.ToString(this.dataArticulo.CurrentRow.Cells["Presentacion"].Value);
                    par7 = Convert.ToInt32(this.dataArticulo.CurrentRow.Cells["Stock"].Value);
                    par8 = Convert.ToDouble(this.dataArticulo.CurrentRow.Cells["Precio_Compra"].Value);
                    par9 = Convert.ToDouble(this.dataArticulo.CurrentRow.Cells["Precio_Venta"].Value);
                    par10 = Convert.ToInt32(this.dataArticulo.CurrentRow.Cells["Descuento"].Value);
                    par11 = Convert.ToDateTime(this.dataArticulo.CurrentRow.Cells["Fecha_Vencimiento"].Value);

                    //Calculamos el descuento de cada articulo

                    descuento = par10 / 100.0;

                    descuentoarticulo = Convert.ToDouble(par9) * descuento;

                    preciodescuento = par9 - Convert.ToDouble(descuentoarticulo);


                    //Agregar al listado de articulos para la factura
                    DataRow row = this.dtDetalle.NewRow();
                    row["Detalle_Ingreso"] = par1;
                    row["Codigo"] = par2;
                    row["Descripción"] = par3;
                    row["Marca"] = par4;
                    row["Categoria"] = par5;
                    row["Presentacion"] = par6;
                    row["Stock"] = par7;
                    row["Precio_Compra"] = par8;
                    row["Precio_Venta"] = preciodescuento;
                    row["Descuento"] = par10;
                    row["Fecha_Vencimiento"] = par11;
                    row["Cantidad"] = 1;

                    this.dtDetalle.Rows.Add(row);

                    lblArticulo.Text = par3 + " " + par4 + " " + par6;

                    //Calcular el total de la cuenta
                    totalcuenta = totalcuenta + preciodescuento;

                    lblTotalPagado.Text = Convert.ToString(totalcuenta);

                    //Calcular el total de items de cada compra
                    cacularItems();

                    //Limpar las variables
                    par1 = 0;
                    par2 = string.Empty;
                    par3 = string.Empty;
                    par4 = string.Empty;
                    par5 = string.Empty;
                    par6 = string.Empty;
                    par7 = 0;
                    par8 = 0;
                    par9 = 0;
                    par10 = 0;

                    this.tabControl1.SelectedIndex = 1;
                    this.txtCodigoBarras.Text = string.Empty;
                    this.txtCodigoBarras.Focus();
                }
                else
                {
                    MensajeError("El articulo no existe");
                    this.txtCodigoBarras.Text = string.Empty;
                    this.txtCodigoBarras.Focus();
                }

            }
        }
       
        private void txtBuscarNombreArticulo_TextChanged(object sender, EventArgs e)
        {
            this.MostrarArticulo_Venta_Nombre();
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            this.MostrarArticulo_Venta_Nombre();
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            int ultimafila=0;
            decimal preciostandar;
            ultimafila = dtDetalle.Rows.Count;

            DataGridViewRow row = dataListadoDetalle.Rows[ultimafila -1];    
            if(Convert.ToInt32(this.txtCantidad.Text) > 1)
            {
                double valor = Convert.ToDouble(row.Cells["Precio_Venta"].Value) * Convert.ToDouble(this.txtCantidad.Text);
                row.Cells["Cantidad"].Value = this.txtCantidad.Text;
                preciostandar = Convert.ToDecimal(row.Cells["Precio_Venta"].Value);
                row.Cells["Precio_Venta"].Value = Convert.ToDecimal(valor);
                totalcuenta = totalcuenta +  Convert.ToDouble(valor) - Convert.ToDouble(preciostandar);
                lblTotalPagado.Text = Convert.ToString(totalcuenta);
                //Sumar los articulos multiplicados
                cacularItems();

                this.txtCantidad.Text = string.Empty;
                this.txtCantidad.ReadOnly = true;
                this.btnMultiplicar.Enabled = false;
            }
        }

        private void btnQuitar_Click_1(object sender, EventArgs e)
        {
            int indicefilaPrecio = 0;
            try
            {
                int indiceFila = this.dataListadoDetalle.CurrentCell.RowIndex;
                indicefilaPrecio = indiceFila;

                //Disminuir el totalPAgado
                DataGridViewRow rowPrecio = dataListadoDetalle.Rows[indicefilaPrecio];

                totalcuenta = totalcuenta - Convert.ToDouble(rowPrecio.Cells["Precio_Venta"].Value);
                this.lblTotalPagado.Text = Convert.ToString(totalcuenta);
                //Quitar el articulo del grid
                DataRow row = this.dtDetalle.Rows[indiceFila];
                this.dtDetalle.Rows.Remove(row);
                //Disminuir los items del total
                cacularItems();
            }
            
            catch (Exception ex)
            {
                MensajeError("No hay fila para remover");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
