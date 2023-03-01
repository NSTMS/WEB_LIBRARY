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
using System.Net.Mail;
using System.Net;

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
                Panel1.Visible = false;
            }
            else
            {
                form1.Visible = true;
                Label1.Text = "";
                HyperLink2.Visible = false;
                Application.Set("user_verification_code", "");
                Application.Set("user_email", "");
                Panel1.Visible = Convert.ToBoolean(Application.Get("visibility").ToString());
                Button1.Visible = !Convert.ToBoolean(Application.Get("visibility").ToString());
                Label2.Visible = true;
                passwordTb.Visible = true;
            }
        }


        protected void verifyUser(object sender, EventArgs e)
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
                Application.Set("visibility", false);
            }
            else
            {
                string code = GenerateVerificationCode();
                Cache["code"] = code;
                Application.Set("user_email", emailTb.Text);
                Cache["password"] = passwordTb.Text;
                SendVerificationCodeByEmail(code);

                Application.Set("visibility", true);
                Panel1.Visible = Convert.ToBoolean(Application.Get("visibility").ToString());

                Label2.Visible = false;
                passwordTb.Visible = false;
                info.Text = "Check your email for verification code!";
                Button1.Visible = false;
            }
        }
        protected void addUser(object sender, EventArgs e)
        {
                if (codeTb.Text == Cache["code"].ToString() && codeTb.Text != "")
                {
                    MySqlConnection insertConnection = new dataBaseConnection().connect();
                    if (insertConnection == null) return;
                    var insert = insertConnection.CreateCommand();

                    string inputString = Cache["password"].ToString();
                    SHA256 sha256 = SHA256.Create();
                    byte[] inputBytes = Encoding.ASCII.GetBytes(inputString);
                    byte[] hashedBytes = sha256.ComputeHash(inputBytes);
                    string password = BitConverter.ToString(hashedBytes).Replace("-", "");
                    insert.CommandText = "INSERT INTO `logins` (`user`, `password`, `email`) VALUES ('" + userTb.Text + "','" + password + "','" + emailTb.Text + "')";
                    insert.ExecuteNonQuery();
                    insertConnection.Close();
                    Application.Set("visibility", false);
                    Application.Set("user_email", "");
                    Cache.Remove("code");
                    Cache.Remove("password");
                    Response.Redirect("userLoginFormPage.aspx");
                }
                else
                {
                info.Text = "Invalid code! ";
                }
            
        }
        static string GenerateVerificationCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }
        public void SendVerificationCodeByEmail(string code)
        {
            try
            {
                string senderEmail = "";
                string senderPassword = "";

                if (senderEmail != "" && senderPassword != "")
                {
                    MailMessage message = new MailMessage(senderEmail, Application.Get("user_email").ToString());
                    message.Subject = "Verification Code";
                    message.Body = $"Your verification code is: {code}";

                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    client.Send(message);
                }
                else
                {
                    info.Text = "Insert mail sender data";
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}