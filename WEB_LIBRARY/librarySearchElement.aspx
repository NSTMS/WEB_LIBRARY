<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="librarySearchElement.aspx.cs" Inherits="WEB_LIBRARY.librarySearchElement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>search element</title>
    <link href="css/main.css" rel="stylesheet" />
    <link href="css/userviewpage.css" rel="stylesheet" />

    <style>
        #form1{
            border:none;
            width:90%;
        }
        .searchSelection{
            display:flex;
            justify-content:center;
            flex-wrap:wrap;
            gap:20px;
        }
        textarea{
            height:auto;
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
        
        <div class="searchSelection">
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
        </div>

        <asp:Button ID="searchBtn" runat="server" Text="search" OnClick="searchInDataBase" />
        <asp:GridView ID="gridView" runat="server">
           <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="actions">
                            <asp:LinkButton ID="delete" Text="delete" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="deleteRecord"></asp:LinkButton> | 
                            <asp:LinkButton ID="update" Text="update" runat="server" CommandArgument='<%# Eval("Id")+","+Eval("Authors")+","+Eval("Title")+","+Eval("RelaseDate")+","+Eval("ISBN")+","+Eval("Format")+","+Eval("Pages")+","+Eval("Description") %>' OnClick="updateRecord"></asp:LinkButton>
                            </div>
                      </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        </asp:GridView>
         <asp:Label ID="gridViewInfo" runat="server" Text="No data to show"></asp:Label>

        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/userViewPage.aspx">back</asp:HyperLink>
    </form>
</body>
</html>
