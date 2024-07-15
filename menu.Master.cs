using System;

namespace pet_shelter
{
    public partial class menu : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //קריאת הנתונים מה
            //Session
            string currentPage = (string)Session["currentPage"];
            string currentUser = (string)Session["user"];
            bool isLogin = (bool)Session["isLogin"];
            bool isAdmin = (bool)Session["isAdmin"];

            //הסתרת חלקים בתפריט, בהתאם להרשאות של המשתמש
            if (isAdmin == false)
            {
                liAdmin1.Visible = false;
                liAdmin2.Visible = false;
            }

            if (!isLogin)
            {
                liAdmin1.Visible = false;
                liAdmin2.Visible = false;
                liLogout.Visible = false;
            }

            //הדגשת הדף הנוכחי בתפריט
            if (currentPage == "Home")
                pgHome.Attributes["class"] = "active";
            else if (currentPage == "Puppies")
                pgPuppies.Attributes["class"] = "active";
            else if (currentPage == "Kittens")
                pgKittens.Attributes["class"] = "active";
            else if (currentPage == "Rodents")
                pgRodents.Attributes["class"] = "active";
            else if (currentPage == "Horses")
                pgHorses.Attributes["class"] = "active";
            else if (currentPage == "Turtles")
                pgTurtles.Attributes["class"] = "active";
            else if (currentPage == "Admin1")
                pgAdmin1.Attributes["class"] = "active";
            else if (currentPage == "Admin2")
                pgAdmin2.Attributes["class"] = "active";
            else if (currentPage == "Login" || currentPage == "Register" || currentPage == "Profile")
                aUser.Attributes["class"] = "active";

        }

        protected void aLogout_ServerClick(object sender, EventArgs e)
        {
            /*כאשר המשתמש לחץ על לוג-אאוט, סוגרים את ה  
             * Session
             * ומעבירים את המשתמש לדף הבית כמשתמש לא רשום
             */
            Application["loginCount"] = (int)Application["loginCount"] - 1;
            Session.Abandon();
            Response.Redirect("index.aspx");
        }

        protected void aUser_ServerClick(object sender, EventArgs e)
        {
            bool isLogin = Session["isLogin"] == null ? false :
                      (bool)Session["isLogin"];

            if (isLogin)
                Response.Redirect("Profile.aspx");
            else
                Response.Redirect("Login.aspx");
        }

    }
}