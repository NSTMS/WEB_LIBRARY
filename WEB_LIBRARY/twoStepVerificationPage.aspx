<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="twoStepVerificationPage.aspx.cs" Inherits="WEB_LIBRARY.twoStepVerificationPage" %>
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
    <div id="failedLogin">
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/userLoginFormPage.aspx">Log in!</asp:HyperLink>
    </div>
    <form id="form1" runat="server">
        <h2>Two steps veryfication</h2>
        <div>
            <asp:TextBox ID="codeTb" runat="server" placeholder="veryfication code"></asp:TextBox>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="verifyCode"  Text="verify" />
        <asp:Label ID="info" runat="server" Text="Check your email for verification code!"></asp:Label>
    </form>
</body>
</html>
