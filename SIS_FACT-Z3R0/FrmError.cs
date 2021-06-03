using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SIS_FACT_Z3R0
{
    public partial class FrmError : Form
    {
        int mouseX, mouseY;
        bool mouseM;
        public FrmError(string mensaje)
        {
            InitializeComponent();
            label1.Text = mensaje;
            lblMensaje.Text = "MENSAJE";
            btnClose.Text = "Cerrar";
        }

        private void FrmError_Load(object sender, EventArgs e)
        {

        }
        public static void confirmacionForm(string mensaje)
        {
            FrmError frm = new FrmError(mensaje);
            frm.ShowDialog();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
            mouseM = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseM)
            {
                SetDesktopLocation(MousePosition.X - mouseX, MousePosition.Y - mouseY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseM = false;
        }
    }
}
