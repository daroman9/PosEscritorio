﻿namespace CapaPresentacion
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MnuVentanas = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuAlmacen = new System.Windows.Forms.ToolStripMenuItem();
            this.categoríasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presentacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.articulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuMantenimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.trabajadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuConsultas = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasPorFechasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasPorFechasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockDeArticulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuHerramientas = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.salirDelSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.White;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuVentanas,
            this.MnuAlmacen,
            this.MnuCompras,
            this.MnuVentas,
            this.MnuMantenimiento,
            this.MnuConsultas,
            this.MnuHerramientas,
            this.MnuAyuda,
            this.MnuSistema});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.MnuVentanas;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(151, 646);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // MnuVentanas
            // 
            this.MnuVentanas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeAllToolStripMenuItem});
            this.MnuVentanas.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MnuVentanas.Image = global::CapaPresentacion.Properties.Resources.web;
            this.MnuVentanas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MnuVentanas.Name = "MnuVentanas";
            this.MnuVentanas.Size = new System.Drawing.Size(138, 22);
            this.MnuVentanas.Text = "Ventanas";
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.closeAllToolStripMenuItem.Text = "C&errar todo";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
            // 
            // MnuAlmacen
            // 
            this.MnuAlmacen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoríasToolStripMenuItem,
            this.presentacionesToolStripMenuItem,
            this.articulosToolStripMenuItem});
            this.MnuAlmacen.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MnuAlmacen.Image = global::CapaPresentacion.Properties.Resources.productos_lacteos;
            this.MnuAlmacen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MnuAlmacen.Name = "MnuAlmacen";
            this.MnuAlmacen.Size = new System.Drawing.Size(138, 22);
            this.MnuAlmacen.Text = "Artículos";
            // 
            // categoríasToolStripMenuItem
            // 
            this.categoríasToolStripMenuItem.Name = "categoríasToolStripMenuItem";
            this.categoríasToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.categoríasToolStripMenuItem.Text = "Crear Categoría";
            this.categoríasToolStripMenuItem.Click += new System.EventHandler(this.categoríasToolStripMenuItem_Click);
            // 
            // presentacionesToolStripMenuItem
            // 
            this.presentacionesToolStripMenuItem.Name = "presentacionesToolStripMenuItem";
            this.presentacionesToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.presentacionesToolStripMenuItem.Text = "Crear Presentación";
            this.presentacionesToolStripMenuItem.Click += new System.EventHandler(this.presentacionesToolStripMenuItem_Click);
            // 
            // articulosToolStripMenuItem
            // 
            this.articulosToolStripMenuItem.Name = "articulosToolStripMenuItem";
            this.articulosToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.articulosToolStripMenuItem.Text = "Crear Artículo";
            this.articulosToolStripMenuItem.Click += new System.EventHandler(this.articulosToolStripMenuItem_Click);
            // 
            // MnuCompras
            // 
            this.MnuCompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresosToolStripMenuItem,
            this.proveedorToolStripMenuItem});
            this.MnuCompras.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MnuCompras.Image = global::CapaPresentacion.Properties.Resources.cesta_de_la_compra;
            this.MnuCompras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MnuCompras.Name = "MnuCompras";
            this.MnuCompras.Size = new System.Drawing.Size(138, 22);
            this.MnuCompras.Text = "Compras";
            // 
            // ingresosToolStripMenuItem
            // 
            this.ingresosToolStripMenuItem.Name = "ingresosToolStripMenuItem";
            this.ingresosToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.ingresosToolStripMenuItem.Text = "Ingresos";
            this.ingresosToolStripMenuItem.Click += new System.EventHandler(this.ingresosToolStripMenuItem_Click);
            // 
            // proveedorToolStripMenuItem
            // 
            this.proveedorToolStripMenuItem.Name = "proveedorToolStripMenuItem";
            this.proveedorToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.proveedorToolStripMenuItem.Text = "Proveedor";
            this.proveedorToolStripMenuItem.Click += new System.EventHandler(this.proveedorToolStripMenuItem_Click);
            // 
            // MnuVentas
            // 
            this.MnuVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasToolStripMenuItem1,
            this.clientesToolStripMenuItem});
            this.MnuVentas.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MnuVentas.Image = global::CapaPresentacion.Properties.Resources.ventas;
            this.MnuVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MnuVentas.Name = "MnuVentas";
            this.MnuVentas.Size = new System.Drawing.Size(138, 22);
            this.MnuVentas.Text = "Ventas";
            // 
            // ventasToolStripMenuItem1
            // 
            this.ventasToolStripMenuItem1.Name = "ventasToolStripMenuItem1";
            this.ventasToolStripMenuItem1.Size = new System.Drawing.Size(141, 22);
            this.ventasToolStripMenuItem1.Text = "Ventas";
            this.ventasToolStripMenuItem1.Click += new System.EventHandler(this.ventasToolStripMenuItem1_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // MnuMantenimiento
            // 
            this.MnuMantenimiento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trabajadoresToolStripMenuItem});
            this.MnuMantenimiento.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MnuMantenimiento.Image = global::CapaPresentacion.Properties.Resources.empleados;
            this.MnuMantenimiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MnuMantenimiento.Name = "MnuMantenimiento";
            this.MnuMantenimiento.Size = new System.Drawing.Size(138, 22);
            this.MnuMantenimiento.Text = "Empleados";
            // 
            // trabajadoresToolStripMenuItem
            // 
            this.trabajadoresToolStripMenuItem.Name = "trabajadoresToolStripMenuItem";
            this.trabajadoresToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.trabajadoresToolStripMenuItem.Text = "Crear empleado";
            this.trabajadoresToolStripMenuItem.Click += new System.EventHandler(this.trabajadoresToolStripMenuItem_Click);
            // 
            // MnuConsultas
            // 
            this.MnuConsultas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasPorFechasToolStripMenuItem,
            this.comprasPorFechasToolStripMenuItem,
            this.stockDeArticulosToolStripMenuItem});
            this.MnuConsultas.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MnuConsultas.Image = global::CapaPresentacion.Properties.Resources.reporte;
            this.MnuConsultas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MnuConsultas.Name = "MnuConsultas";
            this.MnuConsultas.Size = new System.Drawing.Size(138, 22);
            this.MnuConsultas.Text = "Consultas";
            // 
            // ventasPorFechasToolStripMenuItem
            // 
            this.ventasPorFechasToolStripMenuItem.Name = "ventasPorFechasToolStripMenuItem";
            this.ventasPorFechasToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.ventasPorFechasToolStripMenuItem.Text = "Ventas por fechas";
            this.ventasPorFechasToolStripMenuItem.Click += new System.EventHandler(this.ventasPorFechasToolStripMenuItem_Click);
            // 
            // comprasPorFechasToolStripMenuItem
            // 
            this.comprasPorFechasToolStripMenuItem.Name = "comprasPorFechasToolStripMenuItem";
            this.comprasPorFechasToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.comprasPorFechasToolStripMenuItem.Text = "Compras por fechas";
            this.comprasPorFechasToolStripMenuItem.Click += new System.EventHandler(this.comprasPorFechasToolStripMenuItem_Click);
            // 
            // stockDeArticulosToolStripMenuItem
            // 
            this.stockDeArticulosToolStripMenuItem.Name = "stockDeArticulosToolStripMenuItem";
            this.stockDeArticulosToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.stockDeArticulosToolStripMenuItem.Text = "Stock de articulos";
            this.stockDeArticulosToolStripMenuItem.Click += new System.EventHandler(this.stockDeArticulosToolStripMenuItem_Click);
            // 
            // MnuHerramientas
            // 
            this.MnuHerramientas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.MnuHerramientas.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MnuHerramientas.Image = global::CapaPresentacion.Properties.Resources.configuraciones;
            this.MnuHerramientas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MnuHerramientas.Name = "MnuHerramientas";
            this.MnuHerramientas.Size = new System.Drawing.Size(138, 22);
            this.MnuHerramientas.Text = "Herramientas";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backUpToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.optionsToolStripMenuItem.Text = "&BD";
            // 
            // backUpToolStripMenuItem
            // 
            this.backUpToolStripMenuItem.Name = "backUpToolStripMenuItem";
            this.backUpToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.backUpToolStripMenuItem.Text = "Back Up BD";
            // 
            // MnuAyuda
            // 
            this.MnuAyuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.indexToolStripMenuItem,
            this.toolStripSeparator8,
            this.aboutToolStripMenuItem});
            this.MnuAyuda.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MnuAyuda.Image = global::CapaPresentacion.Properties.Resources.apoyo_tecnico;
            this.MnuAyuda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MnuAyuda.Name = "MnuAyuda";
            this.MnuAyuda.Size = new System.Drawing.Size(138, 22);
            this.MnuAyuda.Text = "Ayuda";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("indexToolStripMenuItem.Image")));
            this.indexToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.indexToolStripMenuItem.Text = "&Índice";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(190, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.aboutToolStripMenuItem.Text = "&Acerca de... ...";
            // 
            // MnuSistema
            // 
            this.MnuSistema.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirDelSistemaToolStripMenuItem});
            this.MnuSistema.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MnuSistema.Image = global::CapaPresentacion.Properties.Resources.opciones;
            this.MnuSistema.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MnuSistema.Name = "MnuSistema";
            this.MnuSistema.Size = new System.Drawing.Size(138, 22);
            this.MnuSistema.Text = "Opciones";
            // 
            // salirDelSistemaToolStripMenuItem
            // 
            this.salirDelSistemaToolStripMenuItem.Name = "salirDelSistemaToolStripMenuItem";
            this.salirDelSistemaToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.salirDelSistemaToolStripMenuItem.Text = "Salir del sistema";
            this.salirDelSistemaToolStripMenuItem.Click += new System.EventHandler(this.salirDelSistemaToolStripMenuItem_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.Logo_la_39_sin_fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1044, 646);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FrmPrincipal";
            this.Text = "Sistema de ventas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuHerramientas;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuAyuda;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem MnuSistema;
        private System.Windows.Forms.ToolStripMenuItem salirDelSistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuAlmacen;
        private System.Windows.Forms.ToolStripMenuItem articulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoríasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presentacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuCompras;
        private System.Windows.Forms.ToolStripMenuItem ingresosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuVentas;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuMantenimiento;
        private System.Windows.Forms.ToolStripMenuItem trabajadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuConsultas;
        private System.Windows.Forms.ToolStripMenuItem ventasPorFechasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasPorFechasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockDeArticulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuVentanas;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
    }
}



