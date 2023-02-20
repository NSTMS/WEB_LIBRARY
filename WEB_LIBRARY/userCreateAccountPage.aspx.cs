using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

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

            MySqlConnection checkUserConnection = new dataBaseConnection().connect();
            if (checkUserConnection == null) return;

            var checkUser = checkUserConnection.CreateCommand();
            checkUser.CommandText = $"SELECT user FROM `logins` WHERE user='{userTb.Text}'";
            MySqlDataReader reader = checkUser.ExecuteReader();
            string temp_user = "";
            while (reader.Read())
            {
                temp_user = reader["user"].ToString();
            }
            if (temp_user != "")
            {
                info.Text = "User already exists!";
                return;
            }
  
            checkUserConnection.Close();

            if (userTb.Text == "" || passwordTb.Text == "" || emailTb.Text == "" || !(new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$")).IsMatch(emailTb.Text))
            {
                info.Text = "Invalid login data!";
                userTb.Text = "";
                passwordTb.Text = "";
                emailTb.Text = "";
            }
            else
            {
                Console.WriteLine(temp_user);
                MySqlConnection insertConnection = new dataBaseConnection().connect();
                if (insertConnection == null) return;
                var insert = insertConnection.CreateCommand();

                string inputString = passwordTb.Text;
                SHA256 sha256 = SHA256.Create();
                byte[] inputBytes = Encoding.ASCII.GetBytes(inputString);
                byte[] hashedBytes = sha256.ComputeHash(inputBytes);
                string password = BitConverter.ToString(hashedBytes).Replace("-", "");
                insert.CommandText = "INSERT INTO `logins` (`user`, `password`, `email`) VALUES ('" + userTb.Text + "','" + password + "','" +emailTb.Text + "')";
                insert.ExecuteNonQuery();
                insertConnection.Close();
                Application.Set("user_email", emailTb.Text);
                Response.Redirect("twoStepVerificationPage.aspx");
            }

        }
    }
}