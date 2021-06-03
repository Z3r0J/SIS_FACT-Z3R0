using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIS_FACT_Z3R0
{
    public partial class Form1 : Form
    {
        int mouseX, mouseY;
        bool mouseM;
        public Form1()
        {
            InitializeComponent();
            lblKey.Text = "Z3R0 ENTERPRISE INC.";
            lblKey2.Text = "User: ";
            lblKey3.Text = "Password: ";
            btnUnique.Text = "Entrar";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

        private void btnUnique_Click(object sender, EventArgs e)
        {
            if ((txtUser.Text=="Admin")&&(txtPassword.Text=="1234"))
            {
                MessageBox.Show("Bienvenido: " + txtUser.Text + " a" + " Z3r0 Enterprise Inc.");
            }
            else
            {
                MessageBox.Show("¡Contraseña o Usuario incorrecto!");
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseM = false;
        }
    }
}
