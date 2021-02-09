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
        private DataTable ultimaSerie;
        public int codLength;
        public string codigoBarras;
        public string serie;
        public double totalcuenta = 0;
        public int totalArticulos = 0;
        private DataTable listadoDisminucion;
        public FrmVenta()
        {
            InitializeComponent();
           // this.txtIdCliente.Visible = false;
            this.txtCliente.ReadOnly = true;
            this.txtEfectivo.Enabled = false;
            this.txtDebito.Enabled = false;
            this.txtDevuelta.Enabled = false;
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
            this.lblTotalPagado.Text = "0.0";
            //this.CrearTabla();

        }
      
        //Método para habilitar los controles del formulario

        private void Habilitar(bool valor)
        {
            this.txtCodigoBarras.ReadOnly = !valor;
            this.dtFecha.Enabled = valor;
            this.txtCantidad.ReadOnly = !valor;
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
            this.dtDetalle.Columns.Add("IdArticulo", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Codigo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Descripción", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Marca", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Categoria", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Presentacion", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Contenido", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Precio_Venta", System.Type.GetType("System.Double"));
            this.dtDetalle.Columns.Add("Descuento", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Cantidad", System.Type.GetType("System.Int32"));
            
            //Relacionar nuestro DataGRidView con nuestro DataTable
            this.dataListadoDetalle.DataSource = this.dtDetalle;

            this.dataListadoDetalle.Columns[0].Visible = false;


            //Crear tabla para disminucion del stock
            this.listadoDisminucion = new DataTable("Disminucion");

            this.listadoDisminucion.Columns.Add("IdArticulo", System.Type.GetType("System.String"));
            this.listadoDisminucion.Columns.Add("Stock_Actual", System.Type.GetType("System.Int32"));
            this.listadoDisminucion.Columns.Add("IdDetalle_Ingreso", System.Type.GetType("System.Int32"));

            //Relacionar nuestro DataGRidView con nuestro DataTable
            this.dataListadoDisminucion.DataSource = this.listadoDisminucion;


        }
        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.UltimaSerie();
            this.Habilitar(true);
            //this.txtSerie.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Método que calcula cuantos items de cada articulo se encuentran en cada venta
            calcularTotalItems();
            //Método que crea una tabla con los valores a actualizar en el stock de artículos
            disminuirArticulosStock();
            //Método para calcular la devuelta de la venta
            if (calcularVenta())
            {
                ejecutarGuardado();
            }
                
           
            //Método que realiza el guardado de la venta
          
        }

        //Método para calcular el precio y la devuelta de cada venta
        private bool calcularVenta()
        {
            decimal total = 0;
            decimal totalIngreso= 0;
            decimal efectivo = 0;
            decimal debito =0;
            decimal devuelta =0;

            total = Convert.ToDecimal(lblTotalPagado.Text);

            if (this.txtEfectivo.Text == string.Empty || this.txtEfectivo.Text =="" || this.txtEfectivo.Text ==null)
            {
                efectivo = 0;
            }
            else
            {
                efectivo = Convert.ToDecimal(this.txtEfectivo.Text);
               
            }

            if(this.txtDebito.Text == string.Empty || this.txtDebito.Text =="" || this.txtDebito.Text == null)
            {
                debito = 0;
            }
            else
            {
                debito = Convert.ToDecimal(this.txtDebito.Text);
               
            }
            totalIngreso = efectivo + debito;
             
            if(total > totalIngreso)
            {
                MensajeError("El pago es inferior al total de la compra");
                return false;
            }
            else
            {
                devuelta = totalIngreso - total;

                this.txtDevuelta.Text = Convert.ToString(devuelta);
                 
                return true;
            }
        }


        private void ejecutarGuardado()
        {
            try
            {
                string rpta = "";
                string updateStock = "";
                if (this.txtSerie.Text == string.Empty || this.txtDevuelta.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algun dato");
                    errorIcono.SetError(txtDevuelta, "Revise los valores de pago");
                    errorIcono.SetError(txtSerie, "Ingrese un valor");
                }
                else
                {

                    if (this.IsNuevo)
                    {
                        //Validar que el cliente exista    

                        if (dtDetalle.Rows.Count > 0)
                        {
                            rpta = NVenta.Insertar(Convert.ToInt32(this.txtIdCliente.Text), Idtrabajador, this.dtFecha.Value, this.txtSerie.Text, 
                                                   this.cmbMetodoPago.Text , Convert.ToDecimal(this.txtEfectivo.Text), Convert.ToDecimal(this.txtDebito.Text), Convert.ToDecimal(this.txtDevuelta.Text),
                                                   Convert.ToDecimal(this.lblTotalPagado.Text), dtDetalle);

                            if (rpta.Equals("OK"))
                            {
                                updateStock = NVenta.updateStock(listadoDisminucion);
                            }
                        }
                        else
                        {
                            MensajeError("No ha adjuntado articulos en el ingreso ");
                        }
                    }

                    if (rpta.Equals("OK"))
                    {
                       // if (this.IsNuevo)
                        //{
                          //  updateStock = NIngreso.EditarPrecios(dtPrecioReal);
                          this.MensajeOk("Se inserto correctamente en registro");
                       // }

                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.IsNuevo = false;
                    this.Botones();
                    this.Limpiar();
                    //this.LimpiarDetalle();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        //Método para obtener la serie del último registro
        public void UltimaSerie()
        {
            int ultimoValor;
            this.ultimaSerie = NVenta.UltimaSerie();
            if (this.ultimaSerie.Rows.Count == 0)
            {
                ultimoValor = 0;
            }
            else
            {
                ultimoValor = Convert.ToInt32(this.ultimaSerie.Rows[0]["Serie"].ToString().Substring(3));
            }
            ultimoValor++;
            this.txtSerie.Text = Convert.ToString("VN-" + ultimoValor);
        }


        //Calcular la cantidad de articulos presentes en cada venta
        private void calcularTotalItems()
        {
      
            try
            {
                DataTable items = dataListadoDetalle.DataSource as DataTable;

                var result = (from a in items.AsEnumerable()
                              group a by new { id = a.Field<string>("Codigo") } into g
                              select new
                              {
                                  Codigo = g.Key.id,
                                  Cantidad = g.Sum(x => x.Field<int>("Cantidad"))
                              });

                DataTable totales = new DataTable();
                //definir las columnas del datatable
                totales.Columns.Add("Codigo");
                totales.Columns.Add("Cantidad");

                foreach (var item in result)
                {
                    //creas una nueva row
                    DataRow row = totales.NewRow();
                    //asignas el dato a cada columna de la row
                    row["Codigo"] = item.Codigo;
                    row["Cantidad"] = item.Cantidad;

                    totales.Rows.Add(row);
                }

                dataPrueba.DataSource = totales;

            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
        private void disminuirArticulosStock()
        {
            //El ciclo for se encarga de recorrer cada fila del datatable donde se tienen los totales de cada articulo por cada venta

            int totalFilas = dataPrueba.Rows.Count - 1;
          
            for (int i=0; i <= totalFilas; i++)
            {
                int cantidad = Convert.ToInt32(dataPrueba.Rows[i].Cells["Cantidad"].Value);
                this.dataDisminuirStock.DataSource = NStock.BuscarArticuloStock(Convert.ToString(dataPrueba.Rows[i].Cells["Codigo"].Value));
                int sumaStock = 0;
                int posiciones = 0;
                //Primera posición del datatable con los articulos y su stock
                int primerPosicion = Convert.ToInt32(this.dataDisminuirStock.Rows[0].Cells["stock_actual"].Value);

                while (sumaStock < cantidad)
                {
              
                    if (primerPosicion >= cantidad)
                    {
                        int disminuirStock;
                        
                        disminuirStock = Convert.ToInt32(this.dataDisminuirStock.Rows[0].Cells["stock_actual"].Value) - cantidad;

                        asignarDisminuirStock(this.dataDisminuirStock.Rows[posiciones].Cells["IdArticulo"].Value.ToString(), disminuirStock, this.dataDisminuirStock.Rows[posiciones].Cells["iddetalle_ingreso"].Value.ToString());

                        sumaStock = cantidad;
                    }
                    else
                    {
                        //Aca se deben disminuir los articulos de cada ingreso
                        int disminuirStock = cantidad;
                        int residuo;
                     
                        while(disminuirStock > 0)
                        {
                            if(disminuirStock >= Convert.ToInt32(this.dataDisminuirStock.Rows[posiciones].Cells["stock_actual"].Value))
                            {
                               asignarDisminuirStock(this.dataDisminuirStock.Rows[posiciones].Cells["IdArticulo"].Value.ToString(), 0, this.dataDisminuirStock.Rows[posiciones].Cells["iddetalle_ingreso"].Value.ToString());
                               disminuirStock = disminuirStock - Convert.ToInt32(this.dataDisminuirStock.Rows[posiciones].Cells["stock_actual"].Value);
                               sumaStock = sumaStock + Convert.ToInt32(this.dataDisminuirStock.Rows[posiciones].Cells["stock_actual"].Value);
                            }
                            else
                            {
                                residuo = Convert.ToInt32(this.dataDisminuirStock.Rows[posiciones].Cells["stock_actual"].Value) - disminuirStock;

                                asignarDisminuirStock(this.dataDisminuirStock.Rows[posiciones].Cells["IdArticulo"].Value.ToString(), residuo, this.dataDisminuirStock.Rows[posiciones].Cells["iddetalle_ingreso"].Value.ToString());

                                sumaStock = sumaStock + disminuirStock;

                                disminuirStock = disminuirStock - disminuirStock;


                            }
                            posiciones++;
                        }
                    }
                }

            }
        }

        private void asignarDisminuirStock(string codigo, int cantidad, string idingreso)
        {
           
            //Agregar al listado de articulos para la factura
            DataRow row = this.listadoDisminucion.NewRow();
            row["IdArticulo"] = codigo;
            row["Stock_Actual"] = cantidad;
            row["IdDetalle_Ingreso"] = idingreso;
            this.listadoDisminucion.Rows.Add(row);
            this.dataListadoDisminucion.DataSource = this.listadoDisminucion;

        }

        private void btnBuscarNombreArticulos_Click(object sender, EventArgs e)
        {
            this.MostrarArticulo_Venta_Nombre();
        }

        private void dataListadoArticulos_DoubleClick(object sender, EventArgs e)
        {
            int  par1, par7 ;
            string par2, par3, par4, par5, par6;
            double  par9,par10, descuento, descuentoarticulo, preciodescuento;
            par1 = Convert.ToInt32(this.dataListadoArticulos.CurrentRow.Cells["IdArticulo"].Value);
            par2 = Convert.ToString(this.dataListadoArticulos.CurrentRow.Cells["Codigo"].Value);
            par3 = Convert.ToString(this.dataListadoArticulos.CurrentRow.Cells["Descripción"].Value);
            par4 = Convert.ToString(this.dataListadoArticulos.CurrentRow.Cells["Marca"].Value);
            par5 = Convert.ToString(this.dataListadoArticulos.CurrentRow.Cells["Categoria"].Value);
            par6 = Convert.ToString(this.dataListadoArticulos.CurrentRow.Cells["Presentacion"].Value);
            par7 = Convert.ToInt32(this.dataListadoArticulos.CurrentRow.Cells["Stock"].Value);
            par9 = Convert.ToDouble(this.dataListadoArticulos.CurrentRow.Cells["Precio_Venta"].Value);
            par10 = Convert.ToDouble(this.dataListadoArticulos.CurrentRow.Cells["Descuento"].Value);

            //Calculamos el descuento de cada articulo

            descuento = par10 / 100.0;

            descuentoarticulo = Convert.ToDouble(par9) * descuento;

            preciodescuento = par9 - Convert.ToDouble(descuentoarticulo);

            //Agregar al listado de articulos para la factura
            DataRow row = this.dtDetalle.NewRow();
            row["IdArticulo"] = par1;
            row["Codigo"] = par2;
            row["Descripción"] = par3;
            row["Marca"] = par4;
            row["Categoria"] = par5;
            row["Presentacion"] = par6;
            row["Precio_Venta"] = preciodescuento;
            row["Descuento"] = par10;
            row["Cantidad"] = 1;

            this.dtDetalle.Rows.Add(row);

            lblArticulo.Text = par3 + " " + par4 + " " + par6;

            //Calcular el total de la cuenta
            totalcuenta = totalcuenta + preciodescuento;

            lblTotalPagado.Text = Convert.ToString(totalcuenta);

            //Calcular el total de items de cada compra
            cacularItems();
            //Limpar las variables
            par2 = string.Empty;
            par3 = string.Empty;
            par4 = string.Empty;
            par5 = string.Empty;
            par6 = string.Empty;
            par7 = 0;
            par9 = 0;
            par10 = 0;

            this.tabControl1.SelectedIndex = 0;
            this.txtCodigoBarras.Text = string.Empty;
            this.txtCodigoBarras.Focus();

        }

        private void dataListadoClientes_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdCliente.Text = Convert.ToString(this.dataListadoClientes.CurrentRow.Cells["idcliente"].Value);
            this.txtCliente.Text = Convert.ToString(this.dataListadoClientes.CurrentRow.Cells["nombre"].Value)  + ' ' + (this.dataListadoClientes.CurrentRow.Cells["apellidos"].Value);

            this.tabControl1.SelectedIndex = 0;
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
                    string par2, par3, par4, par5, par6, par8;
                    double par9, par10, descuento, descuentoarticulo, preciodescuento;
      
                    par2 = Convert.ToString(this.dataArticulo.CurrentRow.Cells["Codigo"].Value);
                    par3 = Convert.ToString(this.dataArticulo.CurrentRow.Cells["Descripción"].Value);
                    par4 = Convert.ToString(this.dataArticulo.CurrentRow.Cells["Marca"].Value);
                    par5 = Convert.ToString(this.dataArticulo.CurrentRow.Cells["Categoria"].Value);
                    par6 = Convert.ToString(this.dataArticulo.CurrentRow.Cells["Presentacion"].Value);
                    par8 = Convert.ToString(this.dataArticulo.CurrentRow.Cells["Contenido"].Value);
                    par9 = Convert.ToDouble(this.dataArticulo.CurrentRow.Cells["Precio_Venta"].Value);
                    par10 = Convert.ToInt32(this.dataArticulo.CurrentRow.Cells["Descuento"].Value);
                    //Calculamos el descuento de cada articulo

                    descuento = par10 / 100.0;

                    descuentoarticulo = Convert.ToDouble(par9) * descuento;

                    preciodescuento = par9 - Convert.ToDouble(descuentoarticulo);


                    //Agregar al listado de articulos para la factura
                    DataRow row = this.dtDetalle.NewRow();
                    row["Codigo"] = par2;
                    row["Descripción"] = par3;
                    row["Marca"] = par4;
                    row["Categoria"] = par5;
                    row["Presentacion"] = par6;
                    row["Contenido"] = par8;
                    row["Precio_Venta"] = preciodescuento;
                    row["Descuento"] = par10;
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
                    par8 = string.Empty;
                    par7 = 0;
                    par9 = 0;
                    par10 = 0;

                    //this.tabControl1.SelectedIndex = 1;
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

        private void cmbMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMetodoPago.SelectedIndex == 0)
            {
                //Efectivo
                this.txtEfectivo.Enabled = true;
                this.txtDebito.Enabled = false;
                this.txtDebito.Text = string.Empty;
            }
            else if(cmbMetodoPago.SelectedIndex == 1)
            {
                this.txtDebito.Enabled = true;
                this.txtEfectivo.Enabled = false;
                this.txtEfectivo.Text = string.Empty;
            }
            else
            {
                //Mixto
                this.txtEfectivo.Enabled = true;
                this.txtDebito.Enabled = true;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDebito_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
