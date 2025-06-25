using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace Productividad
{
    public partial class panelAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["claveAdmin"] == null || Session["nomAdmin"] == null){
                Session.Abandon();
                Response.Redirect("logginAdmin.aspx");
            }
            Label1.Text= Session["nomAdmin"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("logginAdmin.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("modApp.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("borrarApp.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("reportesAdmin.aspx");
        }
    }
}