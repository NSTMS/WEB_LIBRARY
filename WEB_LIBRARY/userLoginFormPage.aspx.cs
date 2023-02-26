using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_LIBRARY;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System.Collections;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;

namespace WEB_LIBRARY
{
    public partial class userLoginFormPage : System.Web.UI.Page
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
                Label1.Text = "";
                HyperLink2.Text = "";
                form1.Visible = true;
                HyperLink2.Visible = false;
                Application.Set("user_verification_code", "");
                Application.Set("visibility", false);
            }
        }
        protected void logUser(object sender, EventArgs e)
        {
            checkLoginData(userTb.Text, passwordTb.Text);
        }
        protected void checkLoginData(string login, string password)
        {
            if (login == "" || password == "")
            {
                info.Text = "Invalid login data!";
                return;
            }
            else
            {
                try
                {
                    MySqlConnection selectConnection = new dataBaseConnection().connect();
                    if (selectConnection == null) return;
                    var select = selectConnection.CreateCommand();
                    string inputString = password;
                    SHA256 sha256 = SHA256.Create();
                    byte[] inputBytes = Encoding.ASCII.GetBytes(inputString);
                    byte[] hashedBytes = sha256.ComputeHash(inputBytes);
                    string hashed_password = BitConverter.ToString(hashedBytes).Replace("-", "");
                    select.CommandText = $"SELECT user, password FROM `logins` WHERE user='{login}' AND password='{hashed_password}'";
                    MySqlDataReader reader = select.ExecuteReader();
                    string userData = "";
                    while (reader.Read())
                    {
                        userData = reader["user"].ToString();
                    }
                    selectConnection.Close();

                    if (userData != "")
                    {
                        Application.Set("username", login);
                        Response.Redirect("userViewPage.aspx");
                    }
                    else
                    {
                        info.Text = "Invalid login data!";
                        userTb.Text = "";
                        passwordTb.Text = "";
                    }
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    info.Text = "error: " + ex;
                }
            }
        }

    }
}