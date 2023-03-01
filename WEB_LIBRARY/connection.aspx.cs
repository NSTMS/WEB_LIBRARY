using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_LIBRARY;

namespace WEB_LIBRARY
{
    public partial class connection : System.Web.UI.Page
    {
        protected void connectToDbBtn(object sender, EventArgs e)
        {
            var connection = new dataBaseConnection(serverTb.Text, portTb.Text, databaseTb.Text, userTb.Text, passwordTb.Text);
            if (connection.connect() != null)
            {
                info.Text = "";
                Application.Set("host", serverTb.Text);
                Application.Set("port", portTb.Text);
                Application.Set("database", databaseTb.Text);
                Application.Set("database_user", userTb.Text);
                Application.Set("database_password", passwordTb.Text);
                Response.Redirect("userLoginFormPage.aspx");
            }
            else
            {
                info.Text = "invalid data";
            }
        }
    }
}