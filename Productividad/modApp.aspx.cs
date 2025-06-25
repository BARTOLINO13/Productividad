using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using static System.Net.Mime.MediaTypeNames;

namespace Productividad
{
    public partial class modApp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["claveAdmin"] == null || Session["nomAdmin"] == null)
            {
                Session.Abandon();
                Response.Redirect("logginAdmin.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("logginAdmin.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("panelAdmin.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String query = "select cAplicacion, nombre from Aplicacion where nombre like ?";
            OdbcConnection conexion = new ConexionBD().conexion;
            OdbcCommand command = new OdbcCommand(query, conexion);
            command.Parameters.AddWithValue("busca", "%" + TextBox1.Text + "%");
            OdbcDataReader lec = command.ExecuteReader();
            if (lec.HasRows && TextBox1.Text != "")
            {
                Label1.Text = "";
                lec.Read();
                Label2.Text = lec.GetInt32(0).ToString();
                TextBox2.Text = lec.GetString(1).ToString();

            }
            else
            {
                Label1.Text = "NO SE ECNOTRÖ UNA APP";
                TextBox1.Text = "";
            }
            conexion.Close();

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            String query = "update Aplicacion set nombre=? where  cAplicacion=?";
            if (TextBox2.Text != "")
            {
                OdbcConnection conexion = new ConexionBD().conexion;
                OdbcCommand command = new OdbcCommand(query, conexion);
                command.Parameters.AddWithValue("nombre", TextBox2.Text);
                command.Parameters.AddWithValue("cAplicacion", Label2.Text);
                try
                {
                    command.ExecuteNonQuery();

                    Label3.Text = "LA APP FUE MODIFICADA A: " + TextBox2.Text;
                }
                catch (Exception ex)
                {
                    Label3.Text = ex.Message;
                }
                conexion.Close();
            }
        }
    }
}