using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace WEB_LIBRARY
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Application.Add("username", "");
            Application.Add("user_email", "");
            Application.Add("user_verification_code", "");
            Application.Add("visibility", false);




            Application.Add("fromPage", "searchView");

            Application.Add("host", "");
            Application.Add("port", "");
            Application.Add("database", "");
            Application.Add("database_user", "");
            Application.Add("database_password", "");

            Application.Add("authorToChange", "");
            Application.Add("titleToChange", "");
            Application.Add("currentRecordId", "");
            Application.Add("titleToChange", "");
            Application.Add("authorToChange", "");
            Application.Add("dateToChange", "");
            Application.Add("ISBNToChange", "");
            Application.Add("formatToChange", "");
            Application.Add("pagesToChange", "");
            Application.Add("descToChange", "");

            Application.Add("authorToLoad", "");
            Application.Add("titleToLoad", "");
            Application.Add("titleToLoad", "");
            Application.Add("authorToLoad", "");
            Application.Add("dateToLoad", "");
            Application.Add("ISBNToLoad", "");
            Application.Add("formatToLoad", "");
            Application.Add("pagesToLoad", "");
            Application.Add("descToLoad", "");



        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application.Set("username", "");
            Application.Set("user_email", "");
            Application.Set("user_verification_code", "");

            Application.Set("fromPage", "");

            Application.Set("host", "");
            Application.Set("port", "");
            Application.Set("database", "");
            Application.Set("database_user", "");
            Application.Set("database_password", "");

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

            Application.Set("authorToLoad", "");
            Application.Set("titleToLoad", "");
            Application.Set("authorToLoad", "");
            Application.Set("dateToLoad", "");
            Application.Set("ISBNToLoad", "");
            Application.Set("formatToLoad", "");
            Application.Set("pagesToLoad", "");
            Application.Set("descToLoad", "");
        }
    }
}