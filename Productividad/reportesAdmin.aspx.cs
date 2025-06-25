using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Core;
using excel = Microsoft.Office.Interop.Excel;


namespace Productividad
{
    public partial class reportesAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["claveAdmin"] == null || Session["nomAdmin"] == null)
            {
                Session.Abandon();
                Response.Redirect("logginAdmin.aspx");
            }
            if (DropDownList1.Items.Count == 0)
            {
                cargarDrop();
            }
            String query= "select Empleado.nombre as Empleado, empleado.correo as Correo, Departamento.nombre as Departamento, Aplicacion.nombre as App, fechaIni as Inicio, fechaFin as Fin from Departamento inner join Empleado on Departamento.cDepto=Empleado.cDepto inner join usa on Empleado.cEmpleado=usa.cEmpleado inner join Aplicacion on Aplicacion.cAplicacion=usa.cAplicacion join Historial on Historial.folio=usa.folio";
            OdbcConnection con = new ConexionBD().conexion;
            OdbcCommand cmd= new OdbcCommand(query, con);
            OdbcDataReader lec= cmd.ExecuteReader();
            GridView2.DataSource = lec;
            GridView2.DataBind();
            
            if (CheckBoxList1.Items.Count == 0)
            {
                CheckBoxList1.Items.Add(new ListItem("Nombre del empleado", " Empleado.nombre as Empleado "));
                CheckBoxList1.Items.Add(new ListItem("Correo", " empleado.correo as Correo "));
                CheckBoxList1.Items.Add(new ListItem("Departamento", " Departamento.nombre as Departamento "));
                CheckBoxList1.Items.Add(new ListItem("App", " Aplicacion.nombre as App "));
                CheckBoxList1.Items.Add(new ListItem("Inicio", " fechaIni as Inicio "));
                CheckBoxList1.Items.Add(new ListItem("Fin", " fechaFin as Fin "));
            }
           
            if (DropDownList2.Items.Count == 0)
            {
                String queryEmp = "select cempleado, nombre from Empleado";
                OdbcCommand cmd1 = new OdbcCommand(queryEmp, con);
                lec= cmd1.ExecuteReader();
                DropDownList2.DataSource= lec;
                DropDownList2.DataTextField = "nombre";
                DropDownList2.DataValueField = "cempleado";
                DropDownList2.DataBind();
            }
            if (DropDownList3.Items.Count == 0)
            {
                String queryEmp = "select cDepto, nombre from Departamento";
                OdbcCommand cmd1 = new OdbcCommand(queryEmp, con);
                lec = cmd1.ExecuteReader();
                DropDownList3.DataSource = lec;
                DropDownList3.DataTextField = "nombre";
                DropDownList3.DataValueField = "cDepto";
                DropDownList3.DataBind();
            }
            if (DropDownList4.Items.Count == 0)
            {
                String queryEmp = "select caplicacion, nombre from Aplicacion";
                OdbcCommand cmd1 = new OdbcCommand(queryEmp, con);
                lec = cmd1.ExecuteReader();
                DropDownList4.DataSource = lec;
                DropDownList4.DataTextField = "nombre";
                DropDownList4.DataValueField = "caplicacion";
                DropDownList4.DataBind();
            }
            lec.Close();
        }
        private void cargarDrop()
        {   
            String query = "select cAplicacion, nombre from Aplicacion";
            OdbcConnection con = new ConexionBD().conexion;
            OdbcCommand comando = new OdbcCommand(query, con);
            OdbcDataReader lector = comando.ExecuteReader();

            DropDownList1.DataSource = lector;
            DropDownList1.DataTextField = "nombre";
            DropDownList1.DataValueField = "cAplicacion";
            DropDownList1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("mainAdmin.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("logginAdmin.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String query = "select Empleado.nombre as Empleado, Departamento.nombre as Departamento, fechaIni as Inicio, fechaFin as Fin from Departamento inner join Empleado on Departamento.cDepto=Empleado.cDepto inner join usa on Empleado.cEmpleado=usa.cEmpleado inner join Historial on Historial.folio=usa.folio where usa.cAplicacion=?";
            OdbcConnection con = new ConexionBD().conexion;
            OdbcCommand cmd= new OdbcCommand(query, con);
            cmd.Parameters.AddWithValue("cAplicacion", DropDownList1.SelectedValue);
            OdbcDataReader lec= cmd.ExecuteReader();
            //CONFIG GRID VIEW
            GridView1.DataSource= lec;
            GridView1.DataBind();

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            String select = "select distinct";
            String from = " from Departamento inner join Empleado on Departamento.cDepto=Empleado.cDepto inner join usa on Empleado.cEmpleado=usa.cEmpleado inner join Aplicacion on Aplicacion.cAplicacion=usa.cAplicacion join Historial on Historial.folio=usa.folio";
            String where = " where 1=1 ";
            String query = "";
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected == true)
                {
                    select = select + CheckBoxList1.Items[i].Value + ",";
                }
            }
            if (select == "select distinct")
            {
                Label2.Text = "NO SE ELIGIÓ NINGUN CAMPO";
                GridView2.DataSource = null;
                GridView2.DataBind();
            }
            else
            {
                Label2.Text = "";
                if (CheckBox1.Checked == true)
                {
                    where = where + " and empleado.cempleado=?";
                }
                if(CheckBox2.Checked== true)
                {
                    where = where + " and departamento.cDepto=?";
                }
                if (CheckBox3.Checked == true) {
                    where = where + " and aplicacion.cAplicacion=?";
                }
                if (CheckBox4.Checked == true)
                {
                    where = where + " and fechaIni=? and fechaFin=?";
                }
                select = select.Trim(',');
                query = select + from + where;
                OdbcConnection con = new ConexionBD().conexion;
                OdbcCommand cmd = new OdbcCommand(query, con);
                if (CheckBox1.Checked == true)
                {
                    cmd.Parameters.AddWithValue("cempleado", DropDownList2.SelectedValue);
                }
                if (CheckBox2.Checked == true)
                {
                    cmd.Parameters.AddWithValue("cDepto", DropDownList3.SelectedValue);
                }
                if (CheckBox3.Checked == true)
                {
                    cmd.Parameters.AddWithValue("cAplicacion", DropDownList4.SelectedValue);
                }
                if(CheckBox4.Checked== true)
                {
                    DateTime fecha1 = DateTime.Parse(TextBox1.Text);
                    DateTime fecha2 = DateTime.Parse(TextBox2.Text);
                    cmd.Parameters.AddWithValue("fechaIni", fecha1);
                    cmd.Parameters.AddWithValue("fechaFin", fecha2);
                }
                OdbcDataReader lec = cmd.ExecuteReader();
                GridView2.DataSource = lec;
                GridView2.DataBind();
                lec.Close();
                con.Close();
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            excel.Application ex= new excel.Application();
            excel.Workbook wb = ex.Workbooks.Add();
            excel.Worksheet ws = wb.Worksheets[1];
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                for (int j = 0; j < GridView1.Rows[i].Cells.Count; j++)
                {
                    ws.Cells[i+1, j+1] = GridView1.Rows[i].Cells[j].Text;
                }

            }
            ws.Cells[5, 5] = "HOLA";
            String nomLibro = "Reporte" + ".xlsx";
            wb.SaveAs(@"C:\Users\patri\Desktop\CUARTO_SEMESTRE\DAI\Productividad\Productividad\Reportes\" + nomLibro);
            ex.Quit();
            //Redireccionar al usuario al reporte
            Response.Redirect("Reportes/" + nomLibro);
        }
    }
}