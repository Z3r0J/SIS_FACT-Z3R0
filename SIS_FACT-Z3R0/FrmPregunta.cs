using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SIS_FACT_Z3R0
{
    public partial class FrmPregunta : Form
    {
        int mouseX, mouseY;
        bool mouseM;
        public FrmPregunta(string mensaje)
        {
            InitializeComponent();
            label1.Text = mensaje;
            lblMensaje.Text = "¿Quieres Salir?";
            btnOK.Text = "Aceptar";
            btnCancel.Text = "Cancelar";
            this.Ayuda.SetToolTip(this.btnOK, "Has click para salir.");
            this.Ayuda.SetToolTip(this.btnCancel, "Has click para cancelar.");

        }

        private void FrmPregunta_Load(object sender, EventArgs e)
        {

        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
            mouseM = true;
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseM = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseM)
            {
                SetDesktopLocation(MousePosition.X - mouseX, MousePosition.Y - mouseY);
            }
        }
    }
}
