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

        public void ActualizarContraseña(string UserRequerido, string PasswordNuevo) {
            SqlCommand cmd = new SqlCommand("SP_UpdatePassword", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue("@Usuario", UserRequerido);
            cmd.Parameters.AddWithValue("@Mail", UserRequerido);
            cmd.Parameters.AddWithValue("@Password",PasswordNuevo);
            cmd.ExecuteNonQuery();
            connection.Close();

        }
        public string RecuperarContraseña(string UserRequerido)
        {
           SqlCommand cmd = new SqlCommand("SP_RECOVERPASS", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue("@Usuario", UserRequerido);
            cmd.Parameters.AddWithValue("@Mail", UserRequerido);
            SqlDataReader lector = cmd.ExecuteReader();
            if (lector.Read() == true)
            {
                string Linea = Environment.NewLine;
                string userName = lector.GetString(1) + " " + lector.GetString(2);
                string Email = lector.GetString(6);
                string Password = lector.GetString(4);
                string anio = DateTime.Now.Year.ToString();

                var ServicioCorreo = new EnviarCorreo.SoporteCorreos();
                ServicioCorreo.EnviarMensaje(
                    asunto: "SOLICITUD DE RESETEO CONTRASEÑA",
                    cuerpo:
                   "<table style = 'width:100%' bgcolor = '#0000'>" +
                   "<tr>" +
                   "<th bgcolor = '#000'>" +
                   "<img width='200px' height='200px' align ='center' src='https://dslv9ilpbe7p1.cloudfront.net/TRJSRS8aYRz6xsvyZ9PNnA_store_logo_image.jpeg' />" +
                   "</th>" +
                   "</tr>" +
                   "<tr>" +
                   "<td bgcolor='#fff'>" +
                   "<br>" +
                   "<p align=center>" +
                   "<font color='#2d8a13' size=5>" +
                   "<b> Saludos!,</b>" +
                   "</font>" +
                   "<br><br><font color='#299187' size=3><b>" +
                   userName+ " usted realizó una solicitud para recuperar su contraseña. La misma se le generara automaticamente y de manera aleatoria." +
                   "<br><br> Contraseña: " + Password+ "" +
                   "<br>" +
                   "<br>" +
                   "Desde que inicie en el sistema debe de colocar su nueva contraseña." +
                   "</b>" +
                   "</font>" +
                   "</p>" +
                   "<footer>" +
                   "<font color='#ccc'><i> © " +
                   anio+
                " Z3R0 COMPANY BY Randy Daniel Baldayaque and Jean Carlos Reyes" +
                "</font></i>" +
                   "</footer>" +
                   "<br>" +
                   "</td>" +
                   "</tr>" +
                   "</table>"
                    , CorreoDestinatario: new List<string>() { Email }
                    );
                return "Hola, " + "\nusted ha hecho una solicitud para un cambio de contraseña\n"
                    + "la misma se estara enviando a la dirección de correo " +
                    Email + " para que pueda ver la nueva contraseña" +
                    "\ndesde que entre al sistema debe cambiar dicha contraseña, ya que la misma se genera aleatoriamente.";
                connection.Close();

            }
           else
            {
                return "Lo sentimos, no existe una cuenta con este usuario o email.";
                connection.Close();
            }


        }
    }
}
