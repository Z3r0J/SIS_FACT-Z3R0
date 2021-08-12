using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace SIS_FACT_Z3R0
{
    class Validacion
    {
        public static void SoloNumeros(KeyPressEventArgs a)
        {
            if (char.IsDigit(a.KeyChar))
            {
                a.Handled = false;
            }
            else if (char.IsControl(a.KeyChar))
            {
                a.Handled = false;
            }
            else
            {
                a.Handled = true;
            }
        }


        public static void SoloLetras(KeyPressEventArgs a)
        {
            if (Char.IsLetter(a.KeyChar))
            {
                a.Handled = false;
            }
            else if (Char.IsControl(a.KeyChar))
            {
                a.Handled = false;
            }
            else if (Char.IsSeparator(a.KeyChar))
            {
                a.Handled = false;
            }
            else
            {
                a.Handled = true;
            }
        }

        public static void CerrarConF10NoF4(KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                e.Handled = true;
            }

            if (e.KeyCode == Keys.F10)
            {
                Form mensaje =  new FrmPregunta("¿ESTAS SEGURO QUE DESEAS SALIR?");
                DialogResult resultado = mensaje.ShowDialog();
                if (resultado==DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }
    }
}
