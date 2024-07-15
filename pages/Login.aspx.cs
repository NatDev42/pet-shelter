using System;
using System.Data;
using System.Data.SqlClient;

namespace pet_shelter.pages
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["currentPage"] = "Login";

        }

        protected void lgSubmit_ServerClick(object sender, EventArgs e)
        {
            //איפוס משתנים 
            Session["isAdmin"] = false;
            Session["isLogin"] = false;
            

            const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\Data.mdf;Integrated Security=True";

            SqlConnection conection = new SqlConnection(connectionString);

            conection.Open();

            // השמת הערכים בטבלה
            string commandStr = $"update entries set Entries += '1' where Id = '1'";
            SqlCommand cmd = new SqlCommand(commandStr, conection);
            cmd.ExecuteNonQuery();

            conection.Close();

            string username = lgUsername.Value;
            string password = lgPassword.Value;
            //בדיקה ראשונה: שם משתמש + סיסמא
            string command = $"select * from userData where username='{username}' and password ='{password}'";
            SqlDataAdapter adapter = new SqlDataAdapter(command, connectionString);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            //פעולה אשר בודקת את הסדות שהכניס המשתמש ופועלת בהתאם
            void authorize()
            {
                adapter = new SqlDataAdapter(command, connectionString);
                dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //שמירת שם המשתמש כדי שנוכל להשתמש בו לאחר מכן בדפים אחרים
                    Session["user"] = lgUsername.Value;
                    Application["loginCount"] = (int)Application["loginCount"] + 1;
                    Application["guestsCount"] = (int)Application["guestsCount"] - 1;


                    //שמירת הנתון שהמשתמש שגולש עכשיו הוא משתמש רשום בעל הרשאות
                    Session["isLogin"] = true;

                    if (dt.Rows[0]["isAdmin"] == DBNull.Value)
                        Session["isAdmin"] = false;
                    else
                    {
                        Session["isAdmin"] = (bool)dt.Rows[0]["isAdmin"];
                        Application["adminsCount"] = (int)Application["adminsCount"] + 1;
                    }

                    Response.Redirect("index.aspx");
                }
                //אם הקלט לא נכון מציגים הודעת שגיאה
                else
                    lgErrors.Style["display"] = "block";
            }
            authorize();
            //בדיקה שניה: אימייל + סיסמא
            command = $"select * from userData where email='{username}' and password ='{password}'";


        }
    }
}