using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmPrincipal : Form
    {
        FrmArticulo Articulo;
        FrmCategoria Categoria;
        FrmPresentacion Presentacion;
        FrmCliente Cliente;
        FrmIngreso Ingreso;
        FrmProveedor Proveedor;
        FrmTrabajador Trabajador;
        FrmVenta Venta;
        Consultas.FrmConsulta_Stock_Articulos Stock;
        private int childFormNumber = 0;
        public string Idtrabajador = "";
        public string Apellidos = "";
        public string Nombre = "";
        public string Acceso = "";
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Categoria == null)
            {
                Categoria = new FrmCategoria();
                Categoria.MdiParent = this;
                Categoria.FormClosed += new FormClosedEventHandler(CerrarCategoria);
                Categoria.Show();
            }
        }
        private void CerrarCategoria(object sender, EventArgs e)
        {
            Categoria = null;
        }
        private void presentacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Presentacion == null)
            {
                Presentacion = new FrmPresentacion();
                Presentacion.MdiParent = this;
                Presentacion.FormClosed += new FormClosedEventHandler(CerrarPresentacion);
                Presentacion.Show();
            }
        }
        private void CerrarPresentacion(object sender, EventArgs e)
        {
            Presentacion = null;
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Articulo == null)
            {
                Articulo = new FrmArticulo();
                Articulo.MdiParent = this;
                Articulo.FormClosed += new FormClosedEventHandler(CerrarArticulo);
                Articulo.Show();
            }
        }
        private void CerrarArticulo(object sender, EventArgs e)
        {
            Articulo = null;
        }
        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Ingreso == null)
            {
                Ingreso = new FrmIngreso();
                Ingreso.MdiParent = this;
                Ingreso.FormClosed += new FormClosedEventHandler(CerrarIngreso);
                Ingreso.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
                Ingreso.Show();
            }
        }
        private void CerrarIngreso(object sender, EventArgs e)
        {
            Ingreso = null;
        }
        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Proveedor == null)
            {
                Proveedor = new FrmProveedor();
                Proveedor.MdiParent = this;
                Proveedor.FormClosed += new FormClosedEventHandler(CerrarProveedor);
                Proveedor.Show();
            }
        }
        private void CerrarProveedor(object sender, EventArgs e)
        {
            Proveedor = null;
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Cliente == null)
            {
                Cliente = new FrmCliente();
                Cliente.MdiParent = this;
                Cliente.FormClosed += new FormClosedEventHandler(CerrarCliente);
                Cliente.Show();
            }

        }
        private void CerrarCliente(object sender, EventArgs e)
        {
            Cliente = null;
        }

        private void trabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Trabajador == null)
            {
                Trabajador = new FrmTrabajador();
                Trabajador.MdiParent = this;
                Trabajador.FormClosed += new FormClosedEventHandler(CerrarTrabajador);
                Trabajador.Show();
            }
        }
        private void CerrarTrabajador(object sender, EventArgs e)
        {
            Trabajador = null;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
           Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.White;
            this.GestionUsuario();
        }

        private void GestionUsuario()
        {
            //Controla los accesos
            if (Acceso=="ADMINISTRADOR")
            {
                this.MnuAlmacen.Enabled = true;
                this.MnuCompras.Enabled = true;
                this.MnuVentas.Enabled = true;
                this.MnuMantenimiento.Enabled = true;
                this.MnuConsultas.Enabled = true;
                this.MnuHerramientas.Enabled = true;
            }
           else if (Acceso == "VENDEDOR")
            {
                this.MnuAlmacen.Enabled = false;
                this.MnuCompras.Enabled = false;
                this.MnuVentas.Enabled = true;
                this.MnuMantenimiento.Enabled = false;
                this.MnuConsultas.Enabled = true;
                this.MnuHerramientas.Enabled = true;
        
            }
            else if (Acceso == "ALMACENERO")
            {
                this.MnuAlmacen.Enabled = true;
                this.MnuCompras.Enabled = true;
                this.MnuVentas.Enabled = false;
                this.MnuMantenimiento.Enabled = false;
                this.MnuConsultas.Enabled = true;
                this.MnuHerramientas.Enabled = true;
              
            }
            else
            {
                this.MnuAlmacen.Enabled = false;
                this.MnuCompras.Enabled = false;
                this.MnuVentas.Enabled = false;
                this.MnuMantenimiento.Enabled = false;
                this.MnuConsultas.Enabled = false;
                this.MnuHerramientas.Enabled = false;
            }
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Venta == null)
            {
                Venta = new FrmVenta();
                Venta.MdiParent = this;
                Venta.FormClosed += new FormClosedEventHandler(CerrarVenta);
                Venta.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
                Venta.nombreTrabajador = Convert.ToString(this.Nombre + " " + this.Apellidos);
                Venta.Show();
               
            }
        }
        private void CerrarVenta(object sender, EventArgs e)
        {
            Venta = null;
        }
        private void stockDeArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Stock == null)
            {
                Stock = new Consultas.FrmConsulta_Stock_Articulos();
                Stock.MdiParent = this;
                Stock.FormClosed += new FormClosedEventHandler(CerrarStock);
                Stock.Show();
            }
        }
        private void CerrarStock(object sender, EventArgs e)
        {
            Stock = null;
        }
    }
}
