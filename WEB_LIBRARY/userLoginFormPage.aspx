<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userLoginFormPage.aspx.cs" Inherits="WEB_LIBRARY.userLoginFormPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>login page</title>
    <link href="css/main.css" rel="stylesheet" />
</head>
<body>
 <nav>
    <h3 >Web Library</h3>
 </nav >
     <div id="failedLogin">
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/userLoginFormPage.aspx" Text="Back to connection!"></asp:HyperLink>
    </div>
 <form id="form1" runat="server">

    <h2>LOGIN</h2>
     <div>
         <asp:TextBox ID="userTb" runat="server" placeholder="Login"></asp:TextBox>
     </div>            
     <div>
        <asp:TextBox ID="passwordTb" runat="server" placeholder="Password"></asp:TextBox>
     </div>
    <asp:Label ID="info" runat="server" Text=""></asp:Label>
    <asp:Button ID="Button1" runat="server" OnClick="logUser" Text="Login" />
    <asp:HyperLink ID="userCreateAccountLink" runat="server" NavigateUrl="~/userCreateAccountPage.aspx">Not registered? Sign up now!</asp:HyperLink>
</form>
</body>
</html>
