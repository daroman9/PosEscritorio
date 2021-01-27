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
        private DataTable dtPrecioReal;
        private decimal totalPagado = 0;
        private DataTable ultimaSerie;
        private DataTable ganancias;
        private bool listadoDetalle = true;
        public FrmIngreso()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtProveedor, "Seleccione el proveedor");
            this.ttMensaje.SetToolTip(this.txtSerie, "Ingrese la serie del comprobante");
            this.ttMensaje.SetToolTip(this.txtStockInicial, "Ingrese la cantidad de compra");
            this.txtIdArticulo.Visible = false;
            this.txtIdProveedor.Visible = false;
            this.txtArticulo.ReadOnly = true;
            this.txtProveedor.ReadOnly = true;
            this.txtPorcentaje.Enabled = false;
            this.txtPrecioVenta.Enabled = false;
            this.txtSerie.ReadOnly = true;
            this.txtUtilidad.ReadOnly = true;
            this.rdbPorcentaje.Checked = false;
            this.rdbPrecio.Checked = false;

        }

        private void FrmIngreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.CrearTabla();
            this.CrearTablaPrecios();
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
            this.CrearTablaPrecios();
        }
        private void LimpiarDetalle()
        {
            this.txtIdArticulo.Text = string.Empty;
            this.txtArticulo.Text = string.Empty;
            this.txtStockInicial.Text = string.Empty;
            this.txtPorcentaje.Text = string.Empty;
            this.txtUtilidad.Text = string.Empty;
            this.txtPrecioCompra.Text = string.Empty;
            this.txtUtilidad.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
        }
        //Método para habilitar los controles del formulario

        private void Habilitar(bool valor)
        {
            this.txtIdIngreso.Enabled = valor;
            this.dtFecha.Enabled = valor;
            this.txtStockInicial.Enabled = valor;
            this.txtPrecioCompra.Enabled = valor;
            this.dtFechaProduccion.Enabled = valor;
            this.dtFechaVencimiento.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            //this.btnQuitar.Enabled = valor;
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
            this.dtDetalle.Columns.Add("Precio_venta_real", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Porcentaje", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Utilidad", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Stock_inicial", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Fecha_produccion", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("Fecha_vencimiento", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("Subtotal", System.Type.GetType("System.Decimal"));
            //Relacionar nuestro DataGRidView con nuestro DataTable
            this.dataListadoDetalle.DataSource = this.dtDetalle;

        }
        private void CrearTablaPrecios()
        {
            this.dtPrecioReal = new DataTable("PrecioReal");
            this.dtPrecioReal.Columns.Add("idarticulo", System.Type.GetType("System.Int32"));
            this.dtPrecioReal.Columns.Add("precio_venta_real", System.Type.GetType("System.Decimal"));
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
                string updatePrecios = "";
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
                        if (dtDetalle.Rows.Count > 0)
                        {
                            rpta = NIngreso.Insertar(Idtrabajador, Convert.ToInt32(this.txtIdProveedor.Text), dtFecha.Value,
                                                this.txtSerie.Text, "EMITIDO", dtDetalle);

                            if (rpta.Equals("OK"))
                            {
                                updatePrecios = NIngreso.EditarPrecios(dtPrecioReal);
                            }
                        }
                        else
                        {
                            MensajeError("No ha adjuntado articulos en el ingreso ");
                        }
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

                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["idarticulo"]) == Convert.ToInt32(this.txtIdArticulo.Text))
                        {
                            registrar = false;
                            this.MensajeError("Ya se encuentra el articulo en el detalle");
                        }
                    }
                    if (registrar)
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
                        row["Precio_venta_real"] = Convert.ToDecimal(this.txtPrecioVenta.Text);
                        row["Stock_inicial"] = Convert.ToInt32(this.txtStockInicial.Text);
                        row["Porcentaje"] = Convert.ToDecimal(this.txtPorcentaje.Text);
                        row["Utilidad"] = Convert.ToDecimal(this.txtUtilidad.Text);
                        row["Fecha_produccion"] = dtFechaProduccion.Value;
                        row["Fecha_vencimiento"] = dtFechaVencimiento.Value;
                        row["Subtotal"] = subtotal;

                        this.dtDetalle.Rows.Add(row);

                        //Agregar el precio real en el datatable
                        DataRow fila = this.dtPrecioReal.NewRow();
                        fila["Idarticulo"] = Convert.ToInt32(this.txtIdArticulo.Text);
                        fila["Precio_venta_real"] = Convert.ToDecimal(this.txtPrecioVenta.Text);
                        this.dtPrecioReal.Rows.Add(fila);

                        this.LimpiarDetalle();

                        //Ocultar las columnas de detalle de ingreso
                        this.dataListadoDetalle.Columns[0].Visible = false;
                        this.dataListadoDetalle.Columns[4].Visible = false;
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

            if (this.dataListadoDetalle.Rows.Count > 0)
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
                catch (Exception ex)
                {
                    MensajeError("No hay fila para remover");
                }
            }
        }


        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            if (listadoDetalle)
            {
                this.txtIdIngreso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idingreso"].Value);
                this.txtProveedor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Proveedor"].Value);
                this.dtFecha.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["Fecha"].Value);
                this.txtSerie.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Serie"].Value);
                this.lblTotalPagado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Total"].Value);

                this.MostrarDetalle();

                this.chkEliminar.Visible = false;
                this.btnVolverDataListado.Visible = true;
                this.lblTotal.Text = Convert.ToString("Total de registros: " + dataListado.Rows.Count);
                this.listadoDetalle = false;
                this.dataListado.Columns[1].Visible = false;
                this.dataListado.Columns[2].Visible = false;
            }
            else
            {
                MostrarArticulos();
                this.tabControl1.SelectedIndex = 2;

            }
        }
        //Método para mostrar los articulos ingresados
        public void MostrarArticulos()
        {
            this.txtIddetalleIngreso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["iddetalle_ingreso"].Value);
            this.txtMarca.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["marca"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);
            this.txtContenido.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["contenido"].Value);
            this.txtPrecioCompraIngreso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["precio_compra"].Value);
            this.txtPrecioVentaIngreso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["precio_venta"].Value);
            this.txtPorcentajeIngreso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["porcentaje"].Value);
            this.txtUtilidadIngreso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["utilidad"].Value);
            this.txtStockInicialIngreso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["stock_inicial"].Value);
            this.dtFechaProduccionIngreso.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha_produccion"].Value);
            this.dtFechaVencimientoIngreso.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha_vencimiento"].Value);

            //Agregar el id del articulo
            this.txtIdArticulo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Id_articulo"].Value);
        }

        //Método para obtener la serie del último registro
        public void UltimaSerie()
        {
            int ultimoValor;
            this.ultimaSerie = NIngreso.UltimaSerie();
            if (this.ultimaSerie.Rows.Count == 0)
            {
                ultimoValor = 0;
            }
            else
            {
                ultimoValor = Convert.ToInt32(this.ultimaSerie.Rows[0]["Serie"].ToString().Substring(3));
            }
            ultimoValor++;
            this.txtSerie.Text = Convert.ToString("IN-" + ultimoValor);
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
            this.chkEliminar.Checked = false;
            this.OcultarColumnas();
        }

        private void rdbPorcentaje_CheckedChanged(object sender, EventArgs e)
        {
            if (this.txtPorcentaje.Enabled == false)
            {
                this.txtPorcentaje.Enabled = true;
                this.txtPrecioVenta.Enabled = false;
                this.txtPrecioVenta.Text = string.Empty;
                this.txtUtilidad.Text = string.Empty;
            }
            else
            {
                this.txtPorcentaje.Enabled = false;
                this.txtPrecioVenta.Enabled = true;
                this.txtPorcentaje.Text = string.Empty;
                this.txtPrecioVenta.Text = string.Empty;
                this.txtUtilidad.Text = string.Empty;
            }
        }

        private void rdbPrecio_CheckedChanged(object sender, EventArgs e)
        {
            if (this.txtProveedor.Enabled == true)
            {
                this.txtPorcentaje.Enabled = false;
                this.txtPrecioVenta.Enabled = true;
                this.txtPorcentaje.Text = string.Empty;
                this.txtPrecioVenta.Text = string.Empty;
                this.txtUtilidad.Text = string.Empty;
            }
            else
            {
                this.txtPorcentaje.Enabled = true;
                this.txtPrecioVenta.Enabled = false;
                this.txtPrecioVenta.Text = string.Empty;
                this.txtUtilidad.Text = string.Empty;
            }
        }

        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
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
        //Función para calcular el precio de venta basado en porcentaje
        public void calcularPrecioVenta()
        {
            decimal precioCompra;
            decimal porcentaje;
            decimal precioVenta;
            decimal utilidad;

            try
            {
                precioCompra = Convert.ToDecimal(this.txtPrecioCompra.Text);
                if (this.txtPorcentaje.Text != string.Empty)
                {
                    porcentaje = Convert.ToDecimal(this.txtPorcentaje.Text);
                    precioVenta = (precioCompra * porcentaje / 100) + precioCompra;
                    this.txtPrecioVenta.Text = Convert.ToString(precioVenta);
                    utilidad = (precioCompra * porcentaje / 100);
                    this.txtUtilidad.Text = Convert.ToString(utilidad);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Revise los valores ingresados");
            }
        }
        //Función para calcular el porcentaje usando el precio de venta manual

        public void calcularPorcentaje()
        {
            decimal precioCompra2 = 0;
            decimal porcentaje2 = 0;
            decimal precioVenta2;
            decimal utilidad2 = 0;

            try
            {
                if (this.txtPrecioVenta.Text != string.Empty)
                {
                    precioCompra2 = Convert.ToDecimal(this.txtPrecioCompra.Text);
                    precioVenta2 = Convert.ToDecimal(this.txtPrecioVenta.Text);
                    utilidad2 = precioVenta2 - precioCompra2;
                    // this.txtUtilidad.Text = Convert.ToString(utilidad2);


                    this.txtUtilidad.Text = utilidad2.ToString("N1");


                    porcentaje2 = (utilidad2 * 100) / precioCompra2;

                }

                if (porcentaje2 > 0)
                {
                    // this.txtPorcentaje.Text = Convert.ToString(porcentaje2);
                    this.txtPorcentaje.Text = porcentaje2.ToString("N1");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Revise los valores ingresados");
            }
        }
        private void txtCodigoBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (13))
            {

                this.dataListadoArticulos.DataSource = NArticulo.BuscarCodigoIngresos(this.txtCodigoBarras.Text);

            }

        }
        private void btnGuardarIngreso_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                string updatePrecios = "";

                //Agregar el precio real en el datatable
                DataRow fila = this.dtPrecioReal.NewRow();
                fila["Idarticulo"] = Convert.ToInt32(this.txtIdArticulo.Text);
                fila["Precio_venta_real"] = Convert.ToDecimal(this.txtPrecioVentaIngreso.Text);
                this.dtPrecioReal.Rows.Add(fila);

                rpta = NIngreso.Editar(Convert.ToInt32(this.txtIddetalleIngreso.Text), Convert.ToDecimal(this.txtPrecioCompraIngreso.Text), Convert.ToDecimal(this.txtPrecioVentaIngreso.Text),
                                       Convert.ToInt32(this.txtStockInicialIngreso.Text), Convert.ToDecimal(this.txtPorcentajeIngreso.Text), Convert.ToDecimal(this.txtUtilidadIngreso.Text),
                                       this.dtFechaProduccionIngreso.Value, this.dtFechaVencimientoIngreso.Value);
                if (rpta.Equals("OK"))
                {
                    //Actualizar el precio de los demas articulos
                    updatePrecios = NIngreso.EditarPrecios(dtPrecioReal);
                    if (this.IsNuevo)
                    {
                        this.MensajeOk("Se inserto correctamente en registro");
                    }
                    else
                    {
                        this.MensajeOk("Se actualizó correctamente en registro");
                    }
                }
                else
                {
                    this.MensajeError(rpta);
                }
                this.LimpiarArticulos();
                this.MostrarDetalle();
                this.MostrarArticulos();
                this.tabControl1.SelectedIndex = 1;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        private void btnEditarIngreso_Click(object sender, EventArgs e)
        {
            this.rdbPorcentajeIngreso.Enabled = true;
            this.rdbPrecioIngreso.Enabled = true;
            this.txtPrecioCompraIngreso.Enabled = true;
            this.txtStockInicialIngreso.Enabled = true;
            this.dtFechaProduccionIngreso.Enabled = true;
            this.dtFechaVencimientoIngreso.Enabled = true;
            this.btnGuardarIngreso.Enabled = true;
        }

        private void btnCancelarIngreso_Click(object sender, EventArgs e)
        {
            LimpiarArticulos();
            this.MostrarDetalle();
            this.MostrarArticulos();
            this.tabControl1.SelectedIndex = 1;
        }

        //Función para limpiar los campos de los articulos modificados
        public void LimpiarArticulos()
        {
            this.rdbPorcentajeIngreso.Enabled = false;
            this.rdbPrecioIngreso.Enabled = false;
            this.txtPrecioCompraIngreso.Enabled = false;
            this.txtStockInicialIngreso.Enabled = false;
            this.dtFechaProduccionIngreso.Enabled = false;
            this.dtFechaVencimientoIngreso.Enabled = false;
            this.btnGuardarIngreso.Enabled = false;

            this.txtMarca.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtContenido.Text = string.Empty;
            this.rdbPorcentajeIngreso.Checked = false;
            this.rdbPrecioIngreso.Checked = false;
            this.txtPrecioCompraIngreso.Text = string.Empty;
            this.txtPorcentajeIngreso.Text = string.Empty;
            this.txtPrecioVentaIngreso.Text = string.Empty;
            this.txtUtilidadIngreso.Text = string.Empty;
            this.txtStockInicialIngreso.Text = string.Empty;
            this.dtFechaProduccionIngreso.Value = DateTime.Now;
            this.dtFechaVencimientoIngreso.Value = DateTime.Now;
        }

        //Función para calcular el precio de venta basado en porcentaje
        public void calcularPrecioVentaIngreso()
        {
            decimal precioCompra;
            decimal porcentaje;
            decimal precioVenta;
            decimal utilidad;

            try
            {
                precioCompra = Convert.ToDecimal(this.txtPrecioCompraIngreso.Text);
                if (this.txtPorcentajeIngreso.Text != string.Empty)
                {
                    porcentaje = Convert.ToDecimal(this.txtPorcentajeIngreso.Text);
                    precioVenta = (precioCompra * porcentaje / 100) + precioCompra;
                    this.txtPrecioVentaIngreso.Text = Convert.ToString(precioVenta);
                    utilidad = (precioCompra * porcentaje / 100);
                    this.txtUtilidadIngreso.Text = Convert.ToString(utilidad);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Revise los valores ingresados");
            }
        }
        //Función para calcular el porcentaje usando el precio de venta manual

        public void calcularPorcentajeIngreso()
        {
            decimal precioCompra2 = 0;
            decimal porcentaje2 = 0;
            decimal precioVenta2;
            decimal utilidad2 = 0;

            try
            {
                if (this.txtPrecioVentaIngreso.Text != string.Empty)
                {
                    precioCompra2 = Convert.ToDecimal(this.txtPrecioCompraIngreso.Text);
                    precioVenta2 = Convert.ToDecimal(this.txtPrecioVentaIngreso.Text);
                    utilidad2 = precioVenta2 - precioCompra2;
                    // this.txtUtilidad.Text = Convert.ToString(utilidad2);


                    this.txtUtilidadIngreso.Text = utilidad2.ToString("N1");


                    porcentaje2 = (utilidad2 * 100) / precioCompra2;

                }

                if (porcentaje2 > 0)
                {
                    // this.txtPorcentaje.Text = Convert.ToString(porcentaje2);
                    this.txtPorcentajeIngreso.Text = porcentaje2.ToString("N1");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Revise los valores ingresados");
            }
        }
        private void rdbPorcentajeIngreso_CheckedChanged(object sender, EventArgs e)
        {
            if (this.txtPorcentajeIngreso.Enabled == false)
            {
                this.txtPorcentajeIngreso.Enabled = true;
                this.txtPrecioVentaIngreso.Enabled = false;
                this.txtPrecioVentaIngreso.Text = string.Empty;
                this.txtUtilidadIngreso.Text = string.Empty;
            }
            else
            {
                this.txtPorcentajeIngreso.Enabled = false;
                this.txtPrecioVentaIngreso.Enabled = true;
                this.txtPorcentajeIngreso.Text = string.Empty;
                this.txtPrecioVentaIngreso.Text = string.Empty;
                this.txtUtilidadIngreso.Text = string.Empty;
            }
        }

        private void rdbPrecioIngreso_CheckedChanged(object sender, EventArgs e)
        {
            if (this.txtPorcentajeIngreso.Enabled == true)
            {
                this.txtPorcentajeIngreso.Enabled = false;
                this.txtPrecioVentaIngreso.Enabled = true;
                this.txtPorcentajeIngreso.Text = string.Empty;
                this.txtPrecioVentaIngreso.Text = string.Empty;
                this.txtUtilidadIngreso.Text = string.Empty;
            }
            else
            {
                this.txtPorcentajeIngreso.Enabled = true;
                this.txtPrecioVentaIngreso.Enabled = false;
                this.txtPrecioVentaIngreso.Text = string.Empty;
                this.txtUtilidadIngreso.Text = string.Empty;
            }
        }
        private void btnCalcularIngreso_Click(object sender, EventArgs e)
        {
            if (rdbPorcentaje.Checked == true & rdbPrecio.Checked == false)
            {
                calcularPrecioVenta();
            }
            else if (rdbPorcentaje.Checked == false & rdbPrecio.Checked == true)
            {
                calcularPorcentaje();
            }
            compararPrecios();
        }
        private void compararPrecios()
        {
            //Traer el stock, el precio y el total de ganancias por cada artículo
            //string marca;
            //string descripcion;
            //string contenido;
            int cantidadStock = 0;
            decimal precioVentaReal = 0;
            decimal totalGanancias = 0;
            decimal precioVentaTemporal = 0;
            decimal precioVentaCalculado = 0;
            this.ganancias = NIngreso.MostrarDetalleGanancias(Convert.ToInt32(this.txtIdArticulo.Text));
            if (this.ganancias.Rows.Count == 0)
            {
                this.ganancias = null;
            }
            else
            {
                //marca = Convert.ToString(this.ganancias.Rows[0]["Marca"]);
                //descripcion = Convert.ToString(this.ganancias.Rows[0]["Descripcion"]);
                //contenido = Convert.ToString(this.ganancias.Rows[0]["Contenido"]);
                cantidadStock = Convert.ToInt32(this.ganancias.Rows[0]["Cantidad_Stock"]);
                precioVentaReal = Convert.ToDecimal(this.ganancias.Rows[0]["Precio_Venta_Real"]);
                totalGanancias = Convert.ToDecimal(this.ganancias.Rows[0]["Total_Ganancia"]);

            }
            //Comparar el precio anterior con el nuevo y mostrar las alertas correspondientes

            if (precioVentaReal > Convert.ToDecimal(this.txtPrecioVenta.Text))
            {

                precioVentaCalculado = (Convert.ToDecimal(this.txtPrecioVenta.Text) * cantidadStock);

                precioVentaTemporal = totalGanancias - precioVentaCalculado;

                string ttgan = string.Format("{0:n}", totalGanancias);
                string pventem = string.Format("{0:n}", precioVentaTemporal);
                string pventre = string.Format("{0:n}", precioVentaReal);

                MessageBox.Show("El valor de venta ingresado es inferior al valor de venta actual " + "Existen " + cantidadStock + " unidades del producto que representan un valor de " +
                ttgan + " con el valor de venta que quiere ingresar tendra una perdida de " + pventem +
                " el valor de venta actual es de " + pventre
                , "Disminución de utilidad",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (precioVentaReal < Convert.ToDecimal(this.txtPrecioVenta.Text))
            {
                precioVentaCalculado = (Convert.ToDecimal(this.txtPrecioVenta.Text) * cantidadStock);
                
                precioVentaTemporal = precioVentaCalculado - totalGanancias;

                string ttgan = string.Format("{0:n}", totalGanancias);
                string pventem = string.Format("{0:n}", precioVentaTemporal);
                string pventre = string.Format("{0:n}", precioVentaReal);

                MessageBox.Show("El valor de venta ingresado es superior al valor de venta actual " + "Existen " + cantidadStock + " unidades del producto que representan un valor de " +
                ttgan + " con el valor de venta que quiere ingresar tendra una ganancia de " + pventem +
                " el valor de venta actual es de " + pventre
                , "Aumento de utilidad",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void compararPreciosIngresos()
        {
            //Traer el stock, el precio y el total de ganancias por cada artículo
            int cantidadStock = 0;
            decimal precioVentaReal = 0;
            decimal totalGanancias = 0;
            decimal precioVentaTemporal = 0;
            decimal precioVentaCalculado = 0;
            this.ganancias = NIngreso.MostrarDetalleGanancias(Convert.ToInt32(this.txtIdArticulo.Text));
            if (this.ganancias.Rows.Count == 0)
            {
                this.ganancias = null;
            }
            else
            {
                cantidadStock = Convert.ToInt32(this.ganancias.Rows[0]["Cantidad_Stock"]);
                precioVentaReal = Convert.ToDecimal(this.ganancias.Rows[0]["Precio_Venta_Real"]);
                totalGanancias = Convert.ToDecimal(this.ganancias.Rows[0]["Total_Ganancia"]);

            }
            //Comparar el precio anterior con el nuevo y mostrar las alertas correspondientes

            if (precioVentaReal > Convert.ToDecimal(this.txtPrecioVentaIngreso.Text))
            {

                precioVentaCalculado = (Convert.ToDecimal(this.txtPrecioVentaIngreso.Text) * cantidadStock);
         
                precioVentaTemporal = totalGanancias - precioVentaCalculado;

                string ttgan = string.Format("{0:n}", totalGanancias);
                string pventem = string.Format("{0:n}", precioVentaTemporal);
                string pventre = string.Format("{0:n}", precioVentaReal);

                MessageBox.Show("El valor de venta ingresado es inferior al valor de venta actual " + "Existen " + cantidadStock + " unidades del producto que representan un valor de " +
                ttgan + " con el valor de venta que quiere ingresar tendra una perdida de " + pventem +
                " el valor de venta actual es de " + pventre
                , "Disminución de utilidad",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (precioVentaReal < Convert.ToDecimal(this.txtPrecioVentaIngreso.Text))
            {
                precioVentaCalculado = (Convert.ToDecimal(this.txtPrecioVentaIngreso.Text) * cantidadStock);
                
                precioVentaTemporal = precioVentaCalculado - totalGanancias;

                string ttgan = string.Format("{0:n}", totalGanancias);
                string pventem = string.Format("{0:n}", precioVentaTemporal);
                string pventre = string.Format("{0:n}", precioVentaReal);

                MessageBox.Show("El valor de venta ingresado es superior al valor de venta actual " + "Existen " + cantidadStock + " unidades del producto que representan un valor de " +
                ttgan + " con el valor de venta que quiere ingresar tendra una ganancia de " + pventem +
                " el valor de venta actual es de " + pventre
                , "Aumento de utilidad",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void btnCalcularArticulo_Click(object sender, EventArgs e)
        {
            if (rdbPorcentajeIngreso.Checked == true & rdbPrecioIngreso.Checked == false)
            {
                calcularPrecioVentaIngreso();
            }
            else if (rdbPorcentajeIngreso.Checked == false & rdbPrecioIngreso.Checked == true)
            {
                calcularPorcentajeIngreso();
            }

            compararPreciosIngresos();
        }

        private void txtBuscarNombreProveedores_TextChanged(object sender, EventArgs e)
        {
            this.dataListadoProveedores.DataSource = NProveedor.BuscarRazonSocial(this.txtBuscarNombreProveedores.Text);
            this.OcultarColumnas();
        }

        private void btnBuscarNombreArticulos_Click(object sender, EventArgs e)
        {
            this.dataListadoArticulos.DataSource = NArticulo.BuscarNombre(this.txtBuscarNombreArticulo.Text);
            this.OcultarColumnas();
        }

        private void btnBuscarProveedores_Click(object sender, EventArgs e)
        {
            this.dataListadoProveedores.DataSource = NProveedor.BuscarRazonSocial(this.txtBuscarNombreProveedores.Text);
            this.OcultarColumnas();
        }

        private void dataListadoDetalle_Click(object sender, EventArgs e)
        {
            this.btnQuitar.Enabled = true;
        }
    }
}
