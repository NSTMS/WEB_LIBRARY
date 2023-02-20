using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB_LIBRARY
{
    public partial class twoStepVerificationPage : System.Web.UI.Page
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
                form1.Visible = true;
                HyperLink2.Visible = false;
                if (Application.Get("user_verification_code").ToString() == "")
                {
                    string code = GenerateVerificationCode();
                    Application.Set("user_verification_code", code);
                    SendVerificationCodeByEmail(code);
                }
            }
        }

        protected void verifyCode(object sender, EventArgs e)
        {

            if (codeTb.Text == Application.Get("user_verification_code").ToString())
            {
                Response.Redirect("userLoginFormPage.aspx");
            }
            else
            {
                info.Text = "Invalid code!";
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

                MailMessage message = new MailMessage(senderEmail, Application.Get("user_email").ToString());
                message.Subject = "Verification Code";
                message.Body = $"Your verification code is: {code}";

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }
}