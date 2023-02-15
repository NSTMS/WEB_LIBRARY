<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="libraryUpdateElement.aspx.cs" Inherits="WEB_LIBRARY.libraryUpdateElement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title> update element</title>
   <link href="css/main.css" rel="stylesheet" />
    <style>
        #form1{
            margin-top:0;
            border:none;
            width:80%;
            margin-top:120px;
        }
        input[type="text"]{
            width:300px;
        }
        #validationInfo{
            color:red;
        }
    </style>
</head>
<body>
    <nav >
        <h3 >Web Library</h3>
    </nav >
     <div id="failedLogin">
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/userLoginFormPage.aspx" Text="Back to connection!"></asp:HyperLink>
    </div>
    <form id="form1" runat="server">
        <h2>UPDATE ELEMENT IN LIBRARY</h2>
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
         <asp:Label ID="validationInfo" runat="server" Text=""></asp:Label>

        <asp:Button ID="Button1" runat="server" Text="submit" OnClick="sumbitChanges" />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/userViewPage.aspx">back</asp:HyperLink>

    </form>
</body>
</html>
