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
    public partial class FrmLogin : Form
    {
        int mouseX, mouseY;
        bool mouseM;
        UserClass userClass = new UserClass();
        DataContext data = new DataContext();
        FrmDashboard frm = new FrmDashboard();
        public FrmLogin()
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
            DataTable dt = new DataTable();
            userClass.Username = txtUser.Text;
            userClass.Password = txtPassword.Text;
           dt = IniciandoSesion(userClass);
            if (dt.Rows.Count > 0)
            {
                string Nombre;
                Nombre = dt.Rows[0][1].ToString();
                FrmSucess.confirmacionForm("Saludos, " + Nombre + " su accion fue completada correctamente. Puede seguir usando el sistema de Z3R0 ENTERPRISE INC.");
                frm.ShowDialog();
            }
            else
            {
                FrmError.confirmacionForm("¡Oops, ha ocurrido un error en el sistema intentelo de nuevo más tarde!");
            }
        }

        public DataTable IniciandoSesion(UserClass user)
        {
            return data.IniciarSesion(user);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        { 
            mouseM = false;
        }
    }
}
