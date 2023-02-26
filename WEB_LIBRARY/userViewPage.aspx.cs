using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;
using WEB_LIBRARY;
using MySql.Data.MySqlClient;

namespace WEB_LIBRARY
{
    public partial class userViewPage : System.Web.UI.Page
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
                Application.Set("authorToChange", "");
                Application.Set("titleToChange", "");
                Application.Set("currentRecordId", "");
                Application.Set("titleToChange", "");
                Application.Set("authorToChange", "");
                Application.Set("dateToChange", "");
                Application.Set("ISBNToChange", "");
                Application.Set("formatToChange", "");
                Application.Set("pagesToChange", "");
                Application.Set("descToChange", "");
                Application.Set("fromPage", "userView");

                Application.Set("authorToLoad", "");
                Application.Set("titleToLoad", "");
                Application.Set("authorToLoad", "");
                Application.Set("dateToLoad", "");
                Application.Set("ISBNToLoad", "");
                Application.Set("formatToLoad", "");
                Application.Set("pagesToLoad", "");
                Application.Set("descToLoad", "");

                showData();
            }
        }
        protected void addBtnClick(object sender, EventArgs e)
        {
           Response.Redirect("libraryInsertElement.aspx");
        }
        protected void searchButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("librarySearchElement.aspx");
        }
        protected void logOut(object sender, EventArgs e)
        {
            Application.Set("username", "");
            Application.Set("password", "");
            Response.Redirect("userLoginFormPage.aspx");
        }
        
        protected void deleteRecord(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            MySqlConnection connection = new dataBaseConnection(
                Application.Get("host").ToString(),
                Application.Get("port").ToString(),
                Application.Get("database").ToString(),
                Application.Get("database_user").ToString(),
                Application.Get("database_password").ToString()
            ).connect();
            if (connection == null) return;
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM books WHERE ID={id}";
            command.ExecuteNonQuery();
            showData();
        }
        protected void updateRecord(object sender, EventArgs e) 
        { 
            string names = ((sender as LinkButton).CommandArgument).ToString();
            string[] values = names.Split(',');
            info.Text = values.ToString();
            info.Text = values[0];
            Application.Set("currentRecordId", values[0]);
            Application.Set("authorToChange", values[1]);
            Application.Set("titleToChange", values[2]);
            Application.Set("dateToChange", values[3]);
            Application.Set("ISBNToChange", values[4]);
            Application.Set("formatToChange", values[5]);
            Application.Set("pagesToChange", values[6]);
            Application.Set("descToChange", values[7]);
            Response.Redirect("libraryUpdateElement.aspx");
        }

        protected void showData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Authors", typeof(string));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("RelaseDate", typeof(string));
            dt.Columns.Add("ISBN", typeof(string));
            dt.Columns.Add("Format", typeof(string));
            dt.Columns.Add("Pages", typeof(int));
            dt.Columns.Add("Description", typeof(string));

            MySqlConnection connection = new dataBaseConnection().connect();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM books";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DataRow row = dt.NewRow();
                var id = reader["Id"];
                var authors = reader["Authors"];
                var title = reader["Title"];
                var RelaseDate = reader["RelaseDate"];
                var ISBN = reader["ISBN"];
                var format = reader["Format"];
                var pages = reader["Pages"];
                var description = reader["Description"];


                row["Id"] = id;
                row["Authors"] = authors;
                row["Title"] = title;
                row["RelaseDate"] = RelaseDate;
                row["ISBN"] = ISBN;
                row["Format"] = format;
                row["Pages"] = pages;
                row["Description"] = description;
                dt.Rows.Add(row);
            }
            databaseData.DataSource = dt;
            databaseData.DataBind();
            if (databaseData.Rows.Count == 0) validationInfo.Text = "No data to show";
            else validationInfo.Text = "";
        }

    }
}