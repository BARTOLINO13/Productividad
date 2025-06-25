<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroProd.aspx.cs" Inherits="Productividad.RegistroProd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="SALIR DEL SITIO" />
            <br />
            <br />
            Bienvenido sea
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            REGISTRO DE APLICACIÓN
            <br />
            <br />
            Selecciona la aplicación
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            Fecha inicio:
            <asp:TextBox ID="TextBox1" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
            <br />
            <br />
            Fecha fin: <asp:TextBox ID="TextBox2" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="REGISTRAR" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
