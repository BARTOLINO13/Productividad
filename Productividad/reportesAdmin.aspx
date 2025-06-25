<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reportesAdmin.aspx.cs" Inherits="Productividad.reportesAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="CERRAR" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="REGRESAR" />
            <br />
            REPORTES<br />
            <br />
            Reporte por app<br />
            <br />
            Selecciona una app
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="APLICAR" />
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="EXPORTAR A EXCEL" />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <hr />
            <br />
            <br />
            <asp:CheckBoxList ID="CheckBoxList1" runat="server">
            </asp:CheckBoxList>
            <br />
            FILTROS<br />
            <asp:CheckBox ID="CheckBox1" runat="server" />
            Empleado<asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
&nbsp;<asp:CheckBox ID="CheckBox2" runat="server" />
            Departamento<asp:DropDownList ID="DropDownList3" runat="server">
            </asp:DropDownList>
&nbsp;<asp:CheckBox ID="CheckBox3" runat="server" />
            App<asp:DropDownList ID="DropDownList4" runat="server">
            </asp:DropDownList>
&nbsp;<br />
            <asp:CheckBox ID="CheckBox4" runat="server" />
            Entre fechas:<br />
            Fecha inicio<asp:TextBox ID="TextBox1" runat="server" TextMode="Date"></asp:TextBox>
&nbsp;Fecha fin<asp:TextBox ID="TextBox2" runat="server" TextMode="Date"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" Text="GENERAR" OnClick="Button4_Click" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
