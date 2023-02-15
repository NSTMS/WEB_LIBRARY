using MySql.Data.MySqlClient;
using System;
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
                if (!Page.IsPostBack)
                {
                    string[] names = { "Id", "Authors", "Title", "RelaseDate", "ISBN", "Format", "Pages", "Description" };
                    dropDownList.Items.Clear();
                    for (int i = 0; i < names.Length; i++)
                    {
                        ListItem lst = new ListItem(names[i]);
                        dropDownList.Items.Insert(i, lst);
                    }
                }
            }

           
        }
        
        protected void searchInDataBase(object sender, EventArgs e)
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

            var dataBaseConnection = new dataBaseConnection(
                Application.Get("host").ToString(),
                Application.Get("port").ToString(),
                Application.Get("database").ToString(),
                Application.Get("database_user").ToString(),
                Application.Get("database_password").ToString()  
            );
            MySqlConnection connection = dataBaseConnection.connect();
            if (connection == null) return;
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = $"SELECT * FROM books WHERE {dropDownList.SelectedValue}='{searchTb.Text}'";
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

            gridView.DataSource = dt;
            gridView.DataBind();
            if (gridView.Rows.Count == 0) gridViewInfo.Text = "No data to show";
            else
            {
                searchTb.Text = "";
                gridViewInfo.Text = "";
            }
        }
    }
}