<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userViewPage.aspx.cs" Inherits="WEB_LIBRARY.userViewPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>user view</title>
    <link href="css/main.css" rel="stylesheet" />
    <link href="css/userviewpage.css" rel="stylesheet" />
</head>
<body>
    <nav>
        <h3>Web Library</h3 >
    </nav >
    <div id="failedLogin">
        <asp:Label ID="info" runat="server" Text=""></asp:Label>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/userLoginFormPage.aspx">Log in!</asp:HyperLink>
    </div>

    <form id="form1" runat="server">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/gfx/logout.png"  Text="log out" OnClick="logOut"/>
    <h2>database data</h2>
            <asp:GridView ID="databaseData" runat="server">
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
                <asp:Label ID="validationInfo" runat="server" Text=""></asp:Label>

        <div class="buttons">
            <asp:Button class="btn" ID="addBtn" runat="server" Text="Add" OnClick="addBtnClick" />
            <asp:Button class="btn" ID="searchBtn" runat="server" Text="Search" OnClick="searchButtonClick" />
        </div>
    </form>
</body>
</html>
