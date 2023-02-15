using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB_LIBRARY
{
    public partial class userCreateAccountPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application.Get("host").ToString() == "")
            {
                Label1.Text = "You weren't connected to the database!";
                form1.Visible = false;
                HyperLink2.NavigateUrl = "~/connection.aspx";
                HyperLink2.Text = "Connect!";
                HyperLink2.Visible = true;
            }
            else
            {
                form1.Visible = true;
                Label1.Text = "";
                HyperLink2.Visible = false;
            }
        }
        protected void addUser(object sender, EventArgs e)
        {
            if (userTb.Text == "" || passwordTb.Text == "")
            {
                info.Text = "Invalid login data!";
                userTb.Text = "";
                passwordTb.Text = "";
            }
            else
            {
                MySqlConnection insertConnection = new dataBaseConnection().connect();
                if (insertConnection == null) return;
                var insert = insertConnection.CreateCommand();
                insert.CommandText = "INSERT INTO `logins` (`user`, `password`) VALUES ('" + userTb.Text + "','" + passwordTb.Text + "')";
                insert.ExecuteNonQuery();
                Response.Redirect("userLoginFormPage.aspx");
            }

        }
    }
}