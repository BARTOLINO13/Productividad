using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace Productividad
{
    public partial class RegistroProd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // Verificar que las variables de session de session existan
            // Si existen, el ususario hizo loggin
            if (Session["claveEmpleado"]== null || Session["nomEmpleado"] == null)
            {
              Session.Abandon();
              Response.Redirect("loggin.aspx");

            }
            Label1.Text="BIENVENDIO SEA: " + Session["nomEmpleado"].ToString();
            String query = "select cAplicacion, nombre from Aplicacion";
            OdbcConnection con = new ConexionBD().conexion;
            OdbcCommand comando = new OdbcCommand(query, con);
            OdbcDataReader lector = comando.ExecuteReader();
            if (DropDownList1.Items.Count == 0)
            {
                DropDownList1.DataSource = lector;
                DropDownList1.DataTextField = "nombre";
                DropDownList1.DataValueField = "cAplicacion";
                DropDownList1.DataBind();  
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("loggin.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //1 registarar el histroial
            //2 registrar la actividad en usa con la llave primaria del empleado
            if(TextBox1.Text=="" || TextBox2.Text == "")
            {
                Session.Abandon();
                Response.Redirect("loggin.aspx");
            }
            DateTime fecha1 = DateTime.Parse(TextBox1.Text);
            DateTime fecha2 = DateTime.Parse(TextBox2.Text);
            String query = "insert into Historial values(?,?)";
            OdbcConnection conexion = new ConexionBD().conexion;
            OdbcCommand comando= new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("fechaIni", fecha1);
            comando.Parameters.AddWithValue("fechaFin", fecha2);
            try
            {
                //usmaaos ExecuteNonQuery porque es insert
                comando.ExecuteNonQuery();
                query = "insert into usa values(?,?, (select max(folio) from Historial))";
                comando = new OdbcCommand(query, conexion);
                comando.Parameters.AddWithValue("cEmpleado", Session["claveEmpleado"].ToString());
                comando.Parameters.AddWithValue("cAplicacion", DropDownList1.SelectedValue.ToString());
                Label2.Text = "APLICACION REGISTRADA CORRECTAMENTE";
                TextBox1.Text = "";
                TextBox2.Text = "";
                comando.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Label2.Text = ex.Message;
            }
        }
    }
}