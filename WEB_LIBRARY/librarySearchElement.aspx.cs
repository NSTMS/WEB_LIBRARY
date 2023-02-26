using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_LIBRARY;

namespace WEB_LIBRARY
{
    public partial class librarySearchElement : System.Web.UI.Page
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
                Application.Set("fromPage", "searchView");
                if (!IsPostBack)
                {
                    titleTb.Text = Application.Get("titleToLoad").ToString();
                    authorTb.Text = Application.Get("authorToLoad").ToString();
                    relaseDatetb.Text = Application.Get("dateToLoad").ToString();
                    ISBNtb.Text = Application.Get("ISBNToLoad").ToString();
                    formatTb.Text = Application.Get("formatToLoad").ToString();
                    pagesTb.Text = Application.Get("pagesToLoad").ToString();
                    descTb.Text = Application.Get("descToLoad").ToString();
                    showData();
                }
            }
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


        protected void showData()
        {
            MySqlConnection connection = new dataBaseConnection(
              Application.Get("host").ToString(),
              Application.Get("port").ToString(),
              Application.Get("database").ToString(),
              Application.Get("database_user").ToString(),
              Application.Get("database_password").ToString()
          ).connect();
            if (connection == null) return;
            MySqlCommand command = connection.CreateCommand();


            string commandText = "SELECT * FROM books WHERE ";

            if (authorTb.Text != "") commandText += $"`Authors` LIKE '%{authorTb.Text}%' AND ";
            if (titleTb.Text != "") commandText += $"`Title` LIKE '%{titleTb.Text}%' ";
            if (relaseDatetb.Text != "") commandText += $"`RelaseDate`='{relaseDatetb.Text}' AND ";
            if (ISBNtb.Text != "") commandText += $"`ISBN` LIKE '%{ISBNtb.Text}%' AND ";
            if (formatTb.Text != "") commandText += $"`Format` LIKE '%{formatTb.Text}%' AND ";
            if (pagesTb.Text != "") commandText += $"`Pages`={pagesTb.Text} AND ";
            if (descTb.Text != "") commandText += $"`Description` LIKE '%{descTb.Text}%' AND ";
            if (commandText.EndsWith("AND ")) commandText = commandText.Substring(0, commandText.Length - 4);
            
            command.CommandText = commandText;


            if(commandText == "SELECT * FROM books WHERE ")
            {
                gridViewInfo.Text = "No data to show";
                return;
            }
            MySqlDataReader reader = command.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Authors", typeof(string));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("RelaseDate", typeof(string));
            dt.Columns.Add("ISBN", typeof(string));
            dt.Columns.Add("Format", typeof(string));
            dt.Columns.Add("Pages", typeof(int));
            dt.Columns.Add("Description", typeof(string));

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

            gridView.DataSource = dt;
            gridView.DataBind();
            if (gridView.Rows.Count == 0) gridViewInfo.Text = "No data to show";
            else gridViewInfo.Text = "";
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

            Application.Set("authorToLoad", authorTb.Text);
            Application.Set("titleToLoad", titleTb.Text);
            Application.Set("dateToLoad", relaseDatetb.Text);
            Application.Set("ISBNToLoad", ISBNtb.Text);
            Application.Set("formatToLoad", formatTb.Text);
            Application.Set("pagesToLoad", pagesTb.Text);
            Application.Set("descToLoad", descTb.Text);

            Application.Set("fromPage", "searchView");
            Response.Redirect("libraryUpdateElement.aspx");
        }
        protected void searchInDataBase(object sender, EventArgs e)
        {
            showData();
        }


        
    }
}