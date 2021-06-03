using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SIS_FACT_Z3R0
{
    public partial class FrmSucess : Form
    {
        int mouseX, mouseY;
        bool mouseM;
        public FrmSucess(string mensaje)
        {
            InitializeComponent();
            label1.Text = mensaje;
            btnClose.Text = "Cerrar";
            lblMensaje.Text = "MENSAJE";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public static void confirmacionForm(string mensaje)
        {
            FrmSucess frm = new FrmSucess(mensaje);
            frm.ShowDialog();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSucess_Load(object sender, EventArgs e)
        {

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
