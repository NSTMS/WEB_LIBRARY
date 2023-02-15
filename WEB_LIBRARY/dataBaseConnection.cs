using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Web.Security;
using System.Web.SessionState;

namespace WEB_LIBRARY
{
    public class dataBaseConnection : System.Web.HttpApplication
    {
        string server = "";
        string port = "";
        string databaseName = "";
        string user = "";
        string password = "";

        public dataBaseConnection()
        {
            this.server = "localhost";
            this.port = "";
            this.databaseName = "library";
            this.user = "root";
            this.password = "";
        }
        public dataBaseConnection(string server, string port, string databaseName, string user, string password)
        {
            this.server = server;
            this.port = port;
            this.databaseName = databaseName;
            this.user = user;
            this.password = password;
        }
        public MySqlConnection connect()
        {
            string myconnection = $"Server={server};Port={port};Database={databaseName};User={user};Password={password}";
            MySqlConnection connection = new MySqlConnection(myconnection);
            try
            {
                connection.Open();
                Console.WriteLine("Connected");
                return connection;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("error");
            }
            return null;
        }
    }
}