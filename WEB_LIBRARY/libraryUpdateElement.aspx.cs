using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_LIBRARY;

namespace WEB_LIBRARY
{
    public partial class libraryUpdateElement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return; 
            if (Application.Get("host").ToString() == "")
            {
                Label1.Text = "You weren't connected to the database!";
                form1.Visible = false;
                HyperLink2.NavigateUrl = "~/connection.aspx";
                HyperLink2.Text = "Connect!";
                HyperLink2.Visible = true;
            }
            else if (Application.Get("username").ToString() == "")
            {
                Label1.Text = "You haven't logged in yet!";
                HyperLink2.Text = "Log In!";
                form1.Visible = false;
                HyperLink2.NavigateUrl = "~/userLoginFormPage.aspx";
                HyperLink2.Visible = true;
            }
            else
            {
                Label1.Text = "";
                form1.Visible = true;
                HyperLink2.Visible = false;
                if (Application.Get("fromPage").ToString() == "userView") HyperLink1.NavigateUrl="~/userViewPage.aspx";
                else if (Application.Get("fromPage").ToString() == "searchView") HyperLink1.NavigateUrl = "~/librarySearchElement.aspx";
                titleTb.Text = Application.Get("titleToChange").ToString();
                authorTb.Text = Application.Get("authorToChange").ToString();
                relaseDatetb.Text = Application.Get("dateToChange").ToString();
                ISBNtb.Text = Application.Get("ISBNToChange").ToString();
                formatTb.Text = Application.Get("formatToChange").ToString();
                pagesTb.Text = Application.Get("pagesToChange").ToString();
                descTb.Text = Application.Get("descToChange").ToString();
            }
        }

        protected void sumbitChanges(object sender, EventArgs e)
        {
            Application.Set("test", titleTb.Text);
            Application.Set("titleToChange", titleTb.Text);
            Application.Set("authorToChange", authorTb.Text);

            MySqlConnection connection = new dataBaseConnection(
                Application.Get("host").ToString(),
                Application.Get("port").ToString(),
                Application.Get("database").ToString(),
                Application.Get("database_user").ToString(),
                Application.Get("database_password").ToString()
            ).connect();
            if (connection == null) return;
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
                Application.Set("authorToChange", authorTb.Text);
                Application.Set("titleToChange", titleTb.Text);
                Application.Set("dateToChange", relaseDatetb.Text);
                Application.Set("ISBNToChange", ISBNtb.Text);
                Application.Set("formatToChange", formatTb.Text);
                Application.Set("pagesToChange", Convert.ToInt32(pagesTb.Text));
                Application.Set("descToChange", descTb.Text);

                command.CommandText = "UPDATE `books` SET Authors='" + authorTb.Text +
                  "', Title='" + titleTb.Text +
                  "', RelaseDate='" + relaseDatetb.Text +
                  "', ISBN='" + ISBNtb.Text +
                  "', Format='" + formatTb.Text +
                  "', Pages='" + Convert.ToInt32(pagesTb.Text) +
                  "', Description='" + descTb.Text +
                  "' WHERE ID=" + Application.Get("currentRecordId").ToString();

                command.ExecuteNonQuery();
                connection.Close();

                if (Application.Get("fromPage").ToString() == "searchView") Response.Redirect("~/librarySearchElement.aspx");
                else Response.Redirect("~/userViewPage.aspx");
            }
            else
            {
                validationInfo.Text = "Invalid data";
                return;
            }
        }
    }
}