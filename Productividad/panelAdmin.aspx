<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="panelAdmin.aspx.cs" Inherits="Productividad.panelAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="SALIR" />
            <br />
            <br />
            BIENVENIDO ADMINISTRADOR
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="AGREGAR APP" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="MODIFICAR APP" />
            <asp:Button ID="Button4" runat="server" Text="BORRAR APP" OnClick="Button4_Click" />
            <asp:Button ID="Button5" runat="server" Text="REPORTES" OnClick="Button5_Click" />
        </div>
    </form>
</body>
</html>
