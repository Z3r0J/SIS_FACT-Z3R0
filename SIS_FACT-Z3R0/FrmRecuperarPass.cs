using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SIS_FACT_Z3R0
{
    public partial class FrmRecuperarPass : Form
    {
        public string PasswordNuevo = "";
        public string Usuario_Email = "";
        DataContext Context = new DataContext();
        public FrmRecuperarPass()
        {
            InitializeComponent();
            this.Ayuda.SetToolTip(this.textBox1, "Escribe el correo para la verificacion.");
            this.Ayuda.SetToolTip(this.button1, "Has click para enviar el restablecimiento.");

        }

        private void FrmRecuperarPass_Load(object sender, EventArgs e)
        {

        }

        public static string PasswordAleatoria()
        {
            Random random = new Random();
            string container = "";

            for (int i = 0; i < 8; i++)
            {
                int ran = random.Next(0, 61);
                char[] password = {'1','2','3','4','5','6','7','8','9','a','b','c','d','e','f','g','h','i','j','k','l','m',
                'n','o','p','q','r','s','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I','J','K','L','M',
                'N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
                container += password[ran];
            }
            return container;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PasswordNuevo = PasswordAleatoria();
            Usuario_Email = textBox1.Text;
            Context.ActualizarContraseña(Usuario_Email, PasswordNuevo);
            string resultado = RecuperandoContraseña(Usuario_Email);
            lblmensaje.Text = resultado;

       }
        public string RecuperandoContraseña(string Usuario_Email)
        {
            return Context.RecuperarContraseña(Usuario_Email);
        }
    }
}
