using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace Productividad
{
    public partial class loggin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String query = "select cempleado, nombre from empleado where correo=? and contrasena=?";
            String correo = "";
            String contrasena = "";
            int claveEmpleado;
            String nomEmpleado="";

            correo = TextBox1.Text;
            contrasena = TextBox2.Text;

            //Nos conectamos usando helpper class ConxionBD
            OdbcConnection conexion = new ConexionBD().conexion;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("correo", correo);
            comando.Parameters.AddWithValue("contrasena", contrasena);
            try
            {
                OdbcDataReader lector = comando.ExecuteReader();
                if (lector.HasRows)
                {
                    lector.Read();
                    claveEmpleado = lector.GetInt32(0);
                    nomEmpleado = lector.GetString(1);
                    //Redireccionar al ususraio a la pg registroProd
                    Session.Timeout = 10; //hace session.abandon() automatico
                    Session["claveEmpleado"] = claveEmpleado;
                    Session["nomEmpleado"] = nomEmpleado;
                    Response.Redirect("RegistroProd.aspx");

                }
                else
                {
                    Label1.Text = " credenciales INVALIDAS";
                    Session.Abandon();//borra todas las variables de session y resetea todos los valores de configuracion
                }
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
            conexion.Close();
        }
    }
}