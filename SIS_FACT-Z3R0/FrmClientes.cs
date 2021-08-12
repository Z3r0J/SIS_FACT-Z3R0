using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SIS_FACT_Z3R0
{
    public partial class FrmClientes : Form
    {
        DataContext context = new DataContext();
        public FrmClientes()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.button1, "Has click para añadir un nuevo cliente ");
            this.toolTip1.SetToolTip(this.textBox1, "Escribe la busqueda que deseas realizar ");

        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            MostrarClientes("");
            EstiloDataGridView();

        }

        private void MostrarClientes(string buscar)
        {
            dtgClientes.DataSource = BuscandoClientes(buscar);
        }
        public void EstiloDataGridView()
        {
            dtgClientes.Columns[0].Width = 40;
            dtgClientes.Columns[1].Width = 40;
            dtgClientes.Columns[0].DisplayIndex = 6;
            dtgClientes.Columns[1].DisplayIndex = 6;
        }

        public DataTable BuscandoClientes(string buscar)
        {
            ClassCliets Clientes = new ClassCliets();
            Clientes.Buscar = buscar;
            return context.BuscarClientes(Clientes);
        }

        private void dtgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgClientes.Rows[e.RowIndex].Cells["Delete"].Selected)
            {
                Form mensaje = new FrmPregunta("¿ESTAS SEGURO QUE DESEA ELIMINAR?");
                Form HechoMensaje = new FrmSucess("EL REGISTRO FUE ELIMINADO SASTIFACTORIAMENTE");
                DialogResult resultado = mensaje.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    int delete = Convert.ToInt32(dtgClientes.Rows[e.RowIndex].Cells[2].Value.ToString());
                    EliminandoClientes(delete);
                    HechoMensaje.ShowDialog();
                    MostrarClientes("");
                }
            }
            if (dtgClientes.Rows[e.RowIndex].Cells["Edit"].Selected)
            {
                FrmAddClientes frm = new FrmAddClientes();
                frm.Editar = true;
                frm.textBox3.Text = dtgClientes.Rows[e.RowIndex].Cells["ClientsId"].Value.ToString();
                frm.txtNombre.Text = dtgClientes.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                frm.txtApellido.Text = dtgClientes.Rows[e.RowIndex].Cells["LastName"].Value.ToString();
                frm.txtCedula.Text = dtgClientes.Rows[e.RowIndex].Cells["Documents"].Value.ToString();
                frm.dtFecha.Text = dtgClientes.Rows[e.RowIndex].Cells["FechaInicio"].Value.ToString();

                frm.ShowDialog();
                MostrarClientes("");
            }
        }

        public void EliminandoClientes(int delete)
        {
            DataContext data = new DataContext();
            data.EliminarClientes(delete);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            MostrarClientes(textBox1.Text);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAddClientes frm = new FrmAddClientes();
            frm.ShowDialog();
            frm.Editar = false;
            MostrarClientes("");

        }

        private void FrmClientes_KeyDown(object sender, KeyEventArgs e)
        {
            Validacion.CerrarConF10NoF4(e);
        }
    }
}
