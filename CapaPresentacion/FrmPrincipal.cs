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

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
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
            Presentacion = null;
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
            FrmIngreso frm = new FrmIngreso();
            frm.MdiParent = this;
            frm.Show();
            frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }
        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProveedor frm = new FrmProveedor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCliente frm = new FrmCliente();
            frm.MdiParent = this;
            frm.Show();

        }

        private void trabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmTrabajador frm = new FrmTrabajador();
            frm.MdiParent = this;
            frm.Show();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.SlateBlue;
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
                this.TsCompras.Enabled = true;
                this.TsVentas.Enabled = true;
            }
           else if (Acceso == "VENDEDOR")
            {
                this.MnuAlmacen.Enabled = false;
                this.MnuCompras.Enabled = false;
                this.MnuVentas.Enabled = true;
                this.MnuMantenimiento.Enabled = false;
                this.MnuConsultas.Enabled = true;
                this.MnuHerramientas.Enabled = true;
                this.TsCompras.Enabled = false;
                this.TsVentas.Enabled = true;
            }
            else if (Acceso == "ALMACENERO")
            {
                this.MnuAlmacen.Enabled = true;
                this.MnuCompras.Enabled = true;
                this.MnuVentas.Enabled = false;
                this.MnuMantenimiento.Enabled = false;
                this.MnuConsultas.Enabled = true;
                this.MnuHerramientas.Enabled = true;
                this.TsCompras.Enabled = true;
                this.TsVentas.Enabled = false;
            }
            else
            {
                this.MnuAlmacen.Enabled = false;
                this.MnuCompras.Enabled = false;
                this.MnuVentas.Enabled = false;
                this.MnuMantenimiento.Enabled = false;
                this.MnuConsultas.Enabled = false;
                this.MnuHerramientas.Enabled = false;
                this.TsCompras.Enabled = false;
                this.TsVentas.Enabled = false;
            }
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmVenta frm =new FrmVenta();
            frm.MdiParent = this;
            frm.Show();
            frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }

        private void stockDeArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultas.FrmConsulta_Stock_Articulos frm = new Consultas.FrmConsulta_Stock_Articulos();
            frm.MdiParent = this;
            frm.Show();

        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
