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
    }
}
