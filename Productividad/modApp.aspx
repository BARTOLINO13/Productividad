<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modApp.aspx.cs" Inherits="Productividad.modApp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="SALIR" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="REGRESAR" />
            <br />
            <br />
            MODIFICACIÓN DE APLICACIONES<br />
            <br />
            <br />
            APLICACIÓN:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="BUSCAR" />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            Clave APP: <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            Nuevo nombre:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="MODIFICAR" />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
