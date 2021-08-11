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
            this.Ayuda.SetToolTip(this.textBox3, "Inserta el codigo ");
            this.Ayuda.SetToolTip(this.txtNombre, "Escribe tus dos nombres, en caso de tener uno escribelo ");
            this.Ayuda.SetToolTip(this.txtApellido, "Escribe tus dos apellidos, en caso de tener uno escribelo");
            this.Ayuda.SetToolTip(this.txtCedula, "Escribe los numeros de tu cedula sin espacios o guiones ");
            this.Ayuda.SetToolTip(this.dtFecha, "Fecha actual ");
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

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNombre.Focus();
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtApellido.Focus();
            }
        }

        private void txtApellido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCedula.Focus();
            }
        }
    }
}
