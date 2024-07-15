using System;
using System.Data;
using System.Data.SqlClient;

namespace pet_shelter
{
    public partial class ProfileGuest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // שליחה לעמוד שגיאה במקרה והמשתמש לא מחובר
            //aka pug protection
            bool isLogin = (bool)Session["isLogin"];

            if (!isLogin)
                Response.Redirect("error/pug.html");

            // העמוד הנוכחי 
            Session["currentPage"] = "Guest_Profile";

            int userId = (int)Session["adopterId"];

            //===========================================================



            // databaseלקיחת מידע מתוך ה
            const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\Data.mdf;Integrated Security=True";
            SqlConnection conection = new SqlConnection(connectionString);

            string command = $"select * from userData where Id='{userId}'";
            SqlDataAdapter adapter = new SqlDataAdapter(command, connectionString);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            //===========================================================

            string username = (string)dt.Rows[0]["username"];
            pfUsername.InnerHtml = username;


            // database של התמונה מה url לקיחת ה
            string picUrl = pfp.Src;
            if (dt.Rows[0]["picurl"] != DBNull.Value)
            {
                picUrl = (string)dt.Rows[0]["picurl"];
                pfp.Attributes.Add("class", "newPic");
            }
            pfp.Src = picUrl;

            // database של התמונה מה description לקיחת ה
            string description = "";
            if (dt.Rows[0]["description"] != DBNull.Value)
                description = (string)dt.Rows[0]["description"];

            pfDescriptionText.InnerHtml = description;


            //חישוב גיל
            string birthDate = (string)dt.Rows[0]["birthDate"];
            string[] date_as_arr = birthDate.Split('-');
            DateTime birthday = new DateTime(int.Parse(date_as_arr[0]), int.Parse(date_as_arr[1]), int.Parse(date_as_arr[2]));
            TimeSpan ts = DateTime.Today - birthday;
            int age = (int)ts.TotalDays / 365;

            // המידע מימין לתמונה 
            string location = (string)dt.Rows[0]["location"];
            string pronouns = (string)dt.Rows[0]["pronouns"];
            pfAge_Pronouns.InnerHtml = $"{age} year old, {pronouns}";
            pfLocation.InnerHtml = location;

            // מספר החיות שיש למשתמש
            string animals_owned = (string)dt.Rows[0]["animals"];
            int owned = 0;
            foreach (char ch in animals_owned)
                if (ch == ',')
                    owned++;


            if (animals_owned == "")
            {
                pfOwnerOf.Style.Add("display", "none");
                pfLine.Style.Add("display", "none");
            }

            else
            {
                pfOwnerOf.InnerHtml = "Proud owner of " + animals_owned;
                owned = owned + 1;

            }

            // id מציאת כל החיות של המשתמש עם אותו וספירתן
            string commandStr = $"select * from animalData where shelterer='{userId}'";

            SqlDataAdapter adapter1 = new SqlDataAdapter(commandStr, connectionString);
            DataTable dtAnimals = new DataTable();
            adapter1.Fill(dtAnimals);

            int n = dtAnimals.Rows.Count;

            int adopted = 0;
            int sheltering = n;
            if (dt.Rows[0]["adopted"] != DBNull.Value)
                adopted = (int)dt.Rows[0]["adopted"];


            pfOwned.InnerHtml = "" + owned;
            pfAdopted.InnerHtml = "" + adopted;
            pfSheltetring.InnerHtml = "" + sheltering;



            //הצגת הנתונים של החיות של המשתמש 
            PresentShelteringAnimals();

        }


        //==================================================================================================


        protected void PresentShelteringAnimals()
        {
            int userId = (int)Session["adopterId"];

            const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\Data.mdf;Integrated Security=True";

            SqlConnection conection = new SqlConnection(connectionString);
            conection.Open();


            // וספירתן id מציאת כל החיות של המשתמש עם אותו
            string commandStr = $"select * from animalData where shelterer='{userId}'";

            SqlDataAdapter adapter1 = new SqlDataAdapter(commandStr, connectionString);
            DataTable dtAnimals = new DataTable();
            adapter1.Fill(dtAnimals);

            //=========================================================


            // לכל חיה שמוצאים בטבלה div יצירת 
            int n = dtAnimals.Rows.Count;
            ownedAnimals.InnerHtml = "";
            for (int i = 0; i < n; i++)
            {
                // הקופסא הסופית
                string output1 = "";

                // נתונים של החיה
                string animalPicUrl = (string)dtAnimals.Rows[i]["picurl"];
                string animalName = (string)dtAnimals.Rows[i]["name"];
                int applicant = (int)dtAnimals.Rows[i]["applicant"];
                string adopterInfo = "";

                // מציאת הטקסט והצבע של הסטטוס
                string status;
                string color;

                if (applicant > 0)
                {
                    color = "orange";
                    status = "Pending";
                }
                else if (applicant == -1)
                {
                    color = "green";
                    status = "Adopted";
                }
                else
                {
                    color = "red";
                    status = "Not Adopted";
                }

                // הקופסא הסופית
                output1 = $"<div class='ownedDiv'>" +
                          $"<table class='ownedT'>" +
                          $"<tr>" +
                          $"<td><img class='newAnimalPic' src='{animalPicUrl}'</td>" +
                          $"<td class='leftText'> " +
                          $"<div class='textLeft' style='font-size: 24px; margin-left:30px;'> " +
                          $"<br /><label style='font-weight:600;font-size:26px;'>{animalName}</label> " +
                          $"<br /><label style='font-weight:400;'>Status:</label> <label style='color:{color}'>{status}</label>" +
                          $"" +
                          $"{adopterInfo}" +
                          $"</div>" +
                          $"</td>" +
                          $"</tr>" +
                          $"</table>" +
                          $"</div>";


                ownedAnimals.InnerHtml += output1;
            }
        }
    }
}