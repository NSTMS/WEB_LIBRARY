<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="libraryInsertElement.aspx.cs" Inherits="WEB_LIBRARY.libraryInsertElement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>insert element</title>
     <link href="css/main.css" rel="stylesheet" />
    <style>
        #form1{
            margin-top:40px;
            width:80%;
            border:none;
        }
        input{
            width:300px;
        }
    </style>
</head>
<body>
    <nav>
        <h3>Web Library</h3>
    </nav>
    <div id="failedLogin">
        <asp:Label ID="info" runat="server" Text=""></asp:Label>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/userLoginFormPage.aspx">Log in!</asp:HyperLink>
    </div>
    <form id="form1" runat="server">
        <h2>Add element to library</h2>
        <div>
            <asp:TextBox ID="authorTb" runat="server" placeholder="Author"></asp:TextBox>
        </div>
        <div>
            <asp:TextBox ID="titleTb" runat="server" placeholder="Title"></asp:TextBox>
        </div>
        <div>
            <asp:TextBox ID="relaseDatetb" runat="server" placeholder="Relase date"></asp:TextBox>
        </div>
        <div>
            <asp:TextBox ID="ISBNtb" runat="server" placeholder="ISBN"></asp:TextBox>
        </div>
        <div>
            <asp:TextBox ID="formatTb" runat="server" placeholder="Format"></asp:TextBox>
        </div>
        <div>
            <asp:TextBox ID="pagesTb" runat="server" placeholder="Pages"></asp:TextBox>
        </div>
        <div>
            <asp:TextBox ID="descTb" runat="server" placeholder="Description"  TextMode="MultiLine"></asp:TextBox>
        </div>

        <asp:Label ID="gridViewInfo" runat="server" Text=""></asp:Label>
        <asp:Button ID="Button1" runat="server" Text="add" OnClick="submitInsert" />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/userViewPage.aspx">back</asp:HyperLink>

    </form>
</body>
</html>
