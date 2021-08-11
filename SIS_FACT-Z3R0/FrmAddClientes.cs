using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SIS_FACT_Z3R0
{
    public partial class FrmAddClientes : Form
    {
        public bool Editar = false;
        ClassCliets clients = new ClassCliets();
        DataContext Contenedor = new DataContext();
        public FrmAddClientes()
        {
            InitializeComponent();
            this.TipAyuda.SetToolTip(this.textBox3, "Ingresa tu codigo.");
            this.TipAyuda.SetToolTip(this.txtNombre, "Escribe tus dos nombre. En caso de tener solo uno, escribelo.");
            this.TipAyuda.SetToolTip(this.txtApellido, "Escribe tus dos apellidos. En caso de tener solo uno, escribelo. ");
            this.TipAyuda.SetToolTip(this.txtCedula, "Ingresa tu numero cedula sin espacios ni guiones.");
            this.TipAyuda.SetToolTip(this.dtFecha, "Esta es la fecha actual.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Editar==false)
            {
                try
                {
                    if (txtApellido.Text=="")
                    {
                        MessageBox.Show("Favor digitar el Apellido");
                        txtApellido.Focus();
                    }
                    else if (txtNombre.Text == "")
                    {
                        MessageBox.Show("Favor digitar el Nombre");
                        txtNombre.Focus();
                    }
                    else if (txtCedula.Text == "")
                    {
                        MessageBox.Show("Favor digitar la Cedula");
                        txtCedula.Focus();
                    }
                    else
                    {
                        FrmSucess mensaje = new FrmSucess("INSERTADO CORRECTAMENTE");
                        clients.Name = txtNombre.Text;
                        clients.LastName = txtApellido.Text;
                        clients.Documents = txtCedula.Text;
                        clients.DateOfAdmission = Convert.ToDateTime(dtFecha.Text);
                        InsertandoClientes(clients);
                        mensaje.ShowDialog();
                        Close();
                        

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("NO SE PUDO GUARDAR " + ex);

                }
            }
            if (Editar == true)
            {
                if (txtApellido.Text == "")
                {
                    MessageBox.Show("Favor digitar el Apellido");
                    txtApellido.Focus();
                }
                else if (txtNombre.Text == "")
                {
                    MessageBox.Show("Favor digitar el Nombre");
                    txtNombre.Focus();
                }
                else if (txtCedula.Text == "")
                {
                    MessageBox.Show("Favor digitar la Cedula");
                    txtCedula.Focus();
                }
                else
                {
                    FrmSucess mensaje = new FrmSucess("EDITADO CORRECTAMENTE");
                    clients.ID = Convert.ToInt32(textBox3.Text);
                    clients.Name = txtNombre.Text;
                    clients.LastName = txtApellido.Text;
                    clients.Documents = txtCedula.Text;
                    clients.DateOfAdmission = Convert.ToDateTime(dtFecha.Text);
                    EditandoClientes(clients);
                    mensaje.ShowDialog();
                    Close();
                    Editar = false;


                }
            }
        }
        public static void InsertandoClientes(ClassCliets clientes)
        {
            DataContext data = new DataContext();
            data.InsertarClientes(clientes);
        }

        public static void EditandoClientes(ClassCliets clientes)
        {
            DataContext data = new DataContext();
            data.EditarClientes(clientes);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
