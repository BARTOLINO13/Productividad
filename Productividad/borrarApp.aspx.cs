using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Productividad
{
    public partial class borrarApp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["claveAdmin"] == null || Session["nomAdmin"] == null)
            {
                Session.Abandon();
                Response.Redirect("logginAdmin.aspx");
            }
            cargarDrop();
        }
        private void cargarDrop()
        {
            DropDownList1.Items.Clear();

            String query = "select cAplicacion, nombre from Aplicacion";
            OdbcConnection con = new ConexionBD().conexion;
            OdbcCommand comando = new OdbcCommand(query, con);
            OdbcDataReader lector = comando.ExecuteReader();
            
                DropDownList1.DataSource = lector;
                DropDownList1.DataTextField = "nombre";
                DropDownList1.DataValueField = "cAplicacion";
                DropDownList1.DataBind();

            
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
            string query = "delete from usa where cAplicacion=?;"
                + "delete from Historial where folio not in(select folio from usa);"
                + "delete from Aplicacion where cAplicacion=?;";
            OdbcConnection con = new ConexionBD().conexion;
            OdbcCommand cmd=new OdbcCommand(query, con);
            cmd.Parameters.AddWithValue("cAplicacion1", DropDownList1.SelectedValue);
            cmd.Parameters.AddWithValue("cAplicacion2", DropDownList1.SelectedValue);
            try
            {
                cmd.ExecuteNonQuery();
                Label1.Text = "APP BORRADA";
                cargarDrop();
                con.Close();
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
                con.Close();
            }
        }
    }
}