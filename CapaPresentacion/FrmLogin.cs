﻿using System;
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
    public partial class FrmLogin : Form
    {
        public string Idtrabajador;
        public string nombreTrabajador;
        public FrmLogin()
        {
            InitializeComponent();
            lblHora.Text = DateTime.Now.ToString();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DataTable Datos = CapaNegocio.NTrabajador.Login(this.txtUsuario.Text, this.txtPassword.Text);
            //Evaluar si existe el usuario
            if (Datos.Rows.Count==0)
            {
                MessageBox.Show("No tiene acceso al sistema", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmPrincipal frm = new FrmPrincipal();
                frm.Idtrabajador = Datos.Rows[0][0].ToString();
                frm.Apellidos = Datos.Rows[0][1].ToString();
                frm.Nombre = Datos.Rows[0][2].ToString();
                frm.Acceso = Datos.Rows[0][3].ToString();

                frm.Show();
                this.Hide();

            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (13))
            {
                DataTable Datos = CapaNegocio.NTrabajador.Login(this.txtUsuario.Text, this.txtPassword.Text);
                //Evaluar si existe el usuario
                try
                {
                    if (Datos.Rows.Count == 0)
                    {
                        MessageBox.Show("No tiene acceso al sistema", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        FrmPrincipal frm = new FrmPrincipal();
                        frm.Idtrabajador = Datos.Rows[0][0].ToString();
                        frm.Apellidos = Datos.Rows[0][1].ToString();
                        frm.Nombre = Datos.Rows[0][2].ToString();
                        frm.Acceso = Datos.Rows[0][3].ToString();

                        frm.Show();
                        this.Hide();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No tiene conexión");
                }
            }
        }

    }
}
