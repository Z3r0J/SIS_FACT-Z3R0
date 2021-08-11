using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SIS_FACT_Z3R0
{
    public partial class FrmDashboard : Form
    {

        bool btnselection=false;
        public FrmDashboard()
        {
            InitializeComponent();
            this.Ayuda.SetToolTip(this.btnhome, "Has click para ir a la ventana principal ");
            this.Ayuda.SetToolTip(this.btnProductos, "Has click para ir a seccion de producto ");
            this.Ayuda.SetToolTip(this.btnVentas, "Has click para ir a seccion de ventas ");
            this.Ayuda.SetToolTip(this.btnCompras, "Has click para ir a seccion de compras ");
            this.Ayuda.SetToolTip(this.btnTrabajadores, "Has click para ir a seccion de trabajadores ");
            this.Ayuda.SetToolTip(this.btnClientes, "Has click para ir a seccion de clientes ");
            this.Ayuda.SetToolTip(this.btnProveedores, "Has click para ir a seccion de p ");
            this.Ayuda.SetToolTip(this.btnGanancias, "Has click para ir a seccion de ganancias ");

        }
        string weekstr = "";

        public void SeleccionDeBoton(Button sender)
        {
            btnhome.ForeColor = Color.White;
            btnClientes.ForeColor = Color.White;
            btnCompras.ForeColor = Color.White;
            btnGanancias.ForeColor = Color.White;
            btnProductos.ForeColor = Color.White;
            btnProveedores.ForeColor = Color.White;
            btnTrabajadores.ForeColor = Color.White;
            btnVentas.ForeColor = Color.White;

            btnVentas.Image = Properties.Resources.invoice;
            btnProductos.Image = Properties.Resources.product;
            btnCompras.Image = Properties.Resources.shopping;


            btnselection = true;
            if (btnselection)
            {
                sender.ForeColor = Color.FromArgb(98, 195, 140);
            }
        }
        public void SiguiendoBoton(Button sender)
        {
            pbFlecha.Top = sender.Top;
        }
        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            lblname.Text = FrmLogin.name +" "+ FrmLogin.apellido;
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            timer1.Start();

            switch (DateTime.Now.DayOfWeek.ToString())
            {
                case "Monday": weekstr = "Lunes"; break;
                case "Tuesday": weekstr = "Martes"; break;
                case "Wednesday": weekstr = "Miercoles"; break;
                case "Thursday": weekstr = "Jueves"; break;
                case "Friday": weekstr = "Viernes"; break;
                case "Saturday": weekstr = "Sabado"; break;
                case "Sunday": weekstr = "Domingo"; break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LblHora.Text = weekstr+", " + DateTime.Now.ToString();


        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            SeleccionDeBoton((Button)sender);
            if (btnselection)
            {
                SiguiendoBoton((Button)sender);
                AbrirFormularioEnWrapper(new FrmSucess("Prueba abriendo un formulario"));
            }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            SeleccionDeBoton((Button)sender);
            if (btnselection)
            {
                btnProductos.Image = Properties.Resources.product_active;
                SiguiendoBoton((Button)sender);
            }
        }
        private Form FormActivado = null;
        private void AbrirFormularioEnWrapper(Form FormHijo)
        {
            if (FormActivado != null)
                FormActivado.Close();
            FormActivado = FormHijo;
            FormHijo.TopLevel = false;
            FormHijo.Dock = DockStyle.Fill;
            Wrapper.Controls.Add(FormHijo);
            Wrapper.Tag = FormHijo;
            FormHijo.BringToFront();
            FormHijo.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            SeleccionDeBoton((Button)sender);
            if (btnselection)
            {
                btnVentas.Image = Properties.Resources.invoice_active;
                SiguiendoBoton((Button)sender);
            }
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            SeleccionDeBoton((Button)sender);
            if (btnselection)
            {
                btnCompras.Image = Properties.Resources.shopping_active;
                SiguiendoBoton((Button)sender);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult resultado = new DialogResult();
            Form mensaje = new FrmPregunta("¡Oops, nos veremos mas tarde!, gracias por usar nuestra sistema " + lblname.Text);
            resultado = mensaje.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            SeleccionDeBoton((Button)sender);
            if (btnselection)
            {
                SiguiendoBoton((Button)sender);
                AbrirFormularioEnWrapper(new FrmClientes());
            }
        }
    }
}
