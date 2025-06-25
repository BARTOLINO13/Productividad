using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace Productividad
{
    public partial class logginAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String query = "select cAdmin, nombre from administrador where correo=? and contrasena=?";
            OdbcConnection conexion = new ConexionBD().conexion;
            OdbcCommand command = new OdbcCommand(query, conexion);
            String correo = TextBox1.Text;
            String passwd = TextBox2.Text;
            command.Parameters.AddWithValue("correo", correo);
            command.Parameters.AddWithValue("contrasena", passwd);
            OdbcDataReader lec= command.ExecuteReader();  
            if (lec.HasRows)
            {
                lec.Read();
                Session["claveAdmin"] = lec.GetInt32(0);
                Session["nomAdmin"] = lec.GetString(1);
                Session.Timeout = 10;
                Response.Redirect("panelAdmin.aspx");
                conexion.Close();
            }
            else
            {
                conexion.Close();
                Label1.Text="CREDENCIALES INCORRECTAS";
            }
        }
    }
}