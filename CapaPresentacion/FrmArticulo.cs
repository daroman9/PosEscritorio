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
    public partial class FrmArticulo : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FrmArticulo()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre del artículo");
            this.ttMensaje.SetToolTip(this.pxImagen, "Seleccione la imagen del artículo");
            this.ttMensaje.SetToolTip(this.cbIdPresentacion, "Seleccione la presentación del artículo");
            this.ttMensaje.SetToolTip(this.txtIdArticulo, "Seleccione la presentación del artículo");

            this.txtIdArticulo.Visible = false;
            this.txtCategoria.ReadOnly = true;
            this.LlenarComboPresentacion();
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
            this.txtCodigo.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtIdCategoria.Text = string.Empty;
            this.txtCategoria.Text = string.Empty;
            this.txtIdArticulo.Text = string.Empty;
            this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.file;

        }
        //Método para habilitar los controles del formulario

        private void Habilitar(bool valor)
        {
            this.txtCodigo.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.cbIdPresentacion.Enabled = valor;
            this.btnCargar.Enabled = valor;
            this.btnLimpiar.Enabled = valor;
            this.txtIdArticulo.ReadOnly = !valor;
        }
        //Método para habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }
        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
            this.dataListado.Columns[6].Visible = false;
            this.dataListado.Columns[8].Visible = false;

            //Ocultar columnas del grid de categorias
            this.dataListadoCategorias.Columns[0].Visible = false;
            this.dataListadoCategorias.Columns[1].Visible = false;
        }

        //Método mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NArticulo.Mostrar();
            this.dataListadoCategorias.DataSource = NCategoria.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        //Método para buscar por el nombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NArticulo.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void BuscarNombreCategorias()
        {
            this.dataListadoCategorias.DataSource = NCategoria.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        //Método para llenar el combo box con las presentaciones
        private void LlenarComboPresentacion()
        {
            cbIdPresentacion.DataSource = NPresentacion.Mostrar();
            cbIdPresentacion.ValueMember = "idPresentacion";
            cbIdPresentacion.DisplayMember = "nombre";
        }

        //Cargar la imagen en el picture box
        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            DialogResult result = dialog.ShowDialog();

            if(result== DialogResult.OK)
            {
                this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pxImagen.Image = Image.FromFile(dialog.FileName);
            }

        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.file;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }
        private void FrmArticulo_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                DataTable busquedaproducto;
                string articulo = "";
                if (this.txtNombre.Text == string.Empty || this.txtIdCategoria.Text==string.Empty || this.txtCodigo.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algun dato");
                    errorIcono.SetError(txtNombre, "Ingrese un valor");
                    errorIcono.SetError(txtCodigo, "Ingrese un valor");
                    errorIcono.SetError(txtCategoria, "Ingrese un valor");
                }
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                    byte[] imagen = ms.GetBuffer();

                    busquedaproducto = NArticulo.BuscarCodigo(this.txtCodigo.Text);

                    if(busquedaproducto.Rows.Count > 0)
                    {
                        articulo = "Articulo encontrado";
                    }
                    else
                    {
                        articulo = "Articulo no encontrado";
                    }

                    if (this.IsNuevo)
                    {
                        if(articulo == "Articulo no encontrado")
                        rpta = NArticulo.Insertar(this.txtCodigo.Text, this.txtNombre.Text.Trim().ToUpper(), this.txtDescripcion.Text.Trim().ToUpper(), 
                                                  imagen, Convert.ToInt32(this.txtIdCategoria.Text), Convert.ToInt32(this.cbIdPresentacion.SelectedValue));
                        else
                        {
                            this.MensajeError("No se puede registrar el Artículo ya existe");
                        }
                    }
                    else
                    {
                        rpta = NArticulo.Editar(Convert.ToInt32(this.txtIdArticulo.Text), this.txtCodigo.Text, this.txtNombre.Text.Trim().ToUpper(), this.txtDescripcion.Text.Trim().ToUpper(),
                                                imagen, Convert.ToInt32(this.txtIdCategoria.Text), Convert.ToInt32(this.cbIdPresentacion.SelectedValue));
                    }
                    if (rpta.Equals("OK"))
                    {
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
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdArticulo.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe seleccionar el registro a modificar");
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdArticulo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idarticulo"].Value);
            this.txtCodigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["codigo"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);

            byte[] imagenBuffer = (byte[])this.dataListado.CurrentRow.Cells["imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
            this.pxImagen.Image = Image.FromStream(ms);
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.txtIdCategoria.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idcategoria"].Value);
            this.txtCategoria.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["categoria"].Value);
            this.cbIdPresentacion.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["idpresentacion"].Value);




            this.tabControl1.SelectedIndex = 1;
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
                Opcion = MessageBox.Show("Desea eliminar los registros", "Sistema de ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NArticulo.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se elimino correctamente el registro");
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

        private void dataListadoCategorias_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdCategoria.Text = Convert.ToString(this.dataListadoCategorias.CurrentRow.Cells["idcategoria"].Value);
            this.txtCategoria.Text = Convert.ToString(this.dataListadoCategorias.CurrentRow.Cells["nombre"].Value);
        }

        private void txtBuscarNombreCategoria_TextChanged(object sender, EventArgs e)
        {
            BuscarNombreCategorias();
        }

        private void btnBuscarNombreCategorias_Click(object sender, EventArgs e)
        {
            BuscarNombreCategorias();
        }

        private void dataListadoCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
