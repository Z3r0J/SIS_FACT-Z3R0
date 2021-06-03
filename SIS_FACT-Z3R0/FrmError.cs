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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
