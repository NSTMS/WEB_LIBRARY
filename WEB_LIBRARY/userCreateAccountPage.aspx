<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userCreateAccountPage.aspx.cs" Inherits="WEB_LIBRARY.userCreateAccountPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>create account</title>
    <link href="css/main.css" rel="stylesheet" />
</head>
<body>
     <nav>
        <h3>Web Library</h3>
    </nav>
   <div id="failedLogin">
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/userLoginFormPage.aspx" Text="Back to connection!"></asp:HyperLink>
    </div>
    <form id="form1" runat="server">
        <h2>CREATE ACCOUNT</h2>

        <div>
            <asp:Label ID="Label3" runat="server" Text="Login"></asp:Label>
            <asp:TextBox ID="userTb" runat="server"></asp:TextBox>
        </div> 
        <div>
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="passwordTb" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="emailTb" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="addUser" Text="Sign In" />
         <asp:Label ID="info" runat="server" Text=""></asp:Label>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/userLoginFormPage.aspx">back</asp:HyperLink>
    </form>
</body>
</html>
