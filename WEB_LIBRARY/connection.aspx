<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="connection.aspx.cs" Inherits="WEB_LIBRARY.connection" %>
<!DOCTYPE html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>connection</title>
    <link href="css/main.css" rel="stylesheet" />
</head>
<body>
    <nav>
        <h3 >Web Library</h3>
    </nav >
    <form id="form1" runat="server">

        <h2>connection</h2>
        <div>
            <asp:TextBox ID="serverTb" runat="server" placeholder="server">localhost</asp:TextBox>
        </div>
        <div>
            <asp:TextBox ID="portTb" runat="server"  placeholder="Port"></asp:TextBox>
        </div>
        <div>
            <asp:TextBox ID="databaseTb" runat="server"  placeholder="database">library</asp:TextBox>
        </div>
        <div>
            <asp:TextBox ID="userTb" runat="server" placeholder="username">root</asp:TextBox>
        </div>
        <div>
            <asp:TextBox ID="passwordTb" runat="server" placeholder="password"></asp:TextBox>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="connectToDbBtn" Text="connect" />
    </form>
</body>
</html>
