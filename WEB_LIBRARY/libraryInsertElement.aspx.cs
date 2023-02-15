using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_LIBRARY;
using MySql.Data.MySqlClient;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace WEB_LIBRARY
{
    public partial class libraryInsertElement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application.Get("host").ToString() == "")
            {
                info.Text = "You weren't connected to the database!";
                form1.Visible = false;
                HyperLink2.NavigateUrl = "~/connection.aspx";
                HyperLink2.Text = "Connect!";
                HyperLink2.Visible = true;
            }
            else if (Application.Get("username").ToString() == "")
            {
                info.Text = "You haven't logged in yet!";
                HyperLink2.Text = "Log In!";
                form1.Visible = false;
                HyperLink2.NavigateUrl = "~/userLoginFormPage.aspx";
                HyperLink2.Visible = true;
            }
            else
            {
                info.Text = "";
                form1.Visible = true;
                HyperLink2.Visible = false;
            }
        }

        protected void submitInsert(object sender, EventArgs e)
        {
            var connection = new dataBaseConnection(
                Application.Get("host").ToString(),
                Application.Get("port").ToString(),
                Application.Get("database").ToString(),
                Application.Get("database_user").ToString(),
                Application.Get("database_password").ToString()
            ).connect();
            MySqlCommand command = connection.CreateCommand();
            if ((new Regex(@"^[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ]{1,255}")).IsMatch(authorTb.Text) &&
                (new Regex(@"^[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ]{1,255}")).IsMatch(titleTb.Text) &&
                (new Regex(@"^\d{2}\.\d{2}\.\d{1,4}$")).IsMatch(relaseDatetb.Text) &&
                (new Regex(@"^[\d-]{1,20}")).IsMatch(ISBNtb.Text) &&
                (new Regex(@"^[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ]{1,3}")).IsMatch(formatTb.Text) &&
                (new Regex(@"^\d{1,3}$")).IsMatch(pagesTb.Text) &&
                authorTb.Text != "" && titleTb.Text != "" && relaseDatetb.Text != "" && ISBNtb.Text != "" && formatTb.Text != "" && pagesTb.Text != ""
                && descTb.Text != ""
                )
            {
                try
                {
                    command.CommandText = "INSERT INTO books(`Authors`, `Title`,`RelaseDate`,`ISBN`,`Format`,`Pages`,`Description`) VALUES ('" +
                    authorTb.Text + "','" +
                    titleTb.Text + "','" +
                    relaseDatetb.Text + "','" +
                    ISBNtb.Text + "','" +
                    formatTb.Text + "','" +
                    Convert.ToInt32(pagesTb.Text) + "','" +
                    descTb.Text + "')";
                    command.ExecuteNonQuery();
                    connection.Close();
                    Response.Redirect("userViewPage.aspx");
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    gridViewInfo.Text = "error: " + ex;
                }
            }
            else
            {
                gridViewInfo.Text = "Invalid data";
                return;
            }


        }
    }
}