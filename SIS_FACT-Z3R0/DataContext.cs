using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace SIS_FACT_Z3R0
{
   class DataContext
    {
        SqlConnection connection = new SqlConnection(
new SqlConnectionStringBuilder()
{
DataSource = "DESKTOP-PM985H2\\JEANCREYES",
InitialCatalog = "SIS_FACT_Z3R0",
UserID = "sa",
Password = "new",
IntegratedSecurity = true
}.ConnectionString
);
        public DataTable IniciarSesion(UserClass user)
        {
            SqlCommand cmd = new SqlCommand("SP_LOGIN", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@USUARIO", user.Username);
            cmd.Parameters.AddWithValue("@CLAVE", user.Password);
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connection.Close();
            return dt;
        }
    }
}
