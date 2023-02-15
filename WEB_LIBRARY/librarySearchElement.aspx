<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="librarySearchElement.aspx.cs" Inherits="WEB_LIBRARY.librarySearchElement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>search element</title>
    <link href="css/main.css" rel="stylesheet" />
    <link href="css/searchpage.css" rel="stylesheet" />
    <style>
        #form1{
            border:none;
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
        <h2>SEARCH IN LIBRARY</h2>
        <asp:DropDownList ID="dropDownList" runat="server"></asp:DropDownList>
        <asp:TextBox ID="searchTb" runat="server"></asp:TextBox>
        <asp:Button ID="searchBtn" runat="server" Text="search" OnClick="searchInDataBase" />
        <asp:GridView ID="gridView" runat="server"></asp:GridView>
         <asp:Label ID="gridViewInfo" runat="server" Text=""></asp:Label>

        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/userViewPage.aspx">back</asp:HyperLink>
    </form>
</body>
</html>
