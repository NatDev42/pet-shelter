using System;
using System.Data.SqlClient;

namespace pet_shelter
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["usersCount"] = 0; // סגרתי ופתחתי את הויסואל סטודיו פעמיים
            Application["loginCount"] = 0;
            Application["adminsCount"] = 0;
            Application["guestsCount"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            /*איפוס המשתנים שנרצה לרשום ב
           * Session
           */
            Session["i"] = 0;
            Session["isAdmin"] = false;
            Session["isLogin"] = false;
            Session["user"] = "Guest";
            Session["adopterId"] = null;
            Application["usersCount"] = (int)Application["usersCount"] + 1;
            Application["guestsCount"] = (int)Application["guestsCount"] + 1;

            const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\Data.mdf;Integrated Security=True";

            SqlConnection conection = new SqlConnection(connectionString);

            conection.Open();

            // השמת הערכים בטבלה
            string commandStr = $"update entries set EntriesIncludingGuests += '1' where Id = '1'";
            SqlCommand cmd = new SqlCommand(commandStr, conection);
            cmd.ExecuteNonQuery();

            conection.Close();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application["usersCount"] = (int)Application["usersCount"] - 1;

            if ((bool)Session["isAdmin"])
                Application["adminsCount"] = (int)Application["adminsCount"] - 1;

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}