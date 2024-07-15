using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;


namespace pet_shelter.pages
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           

            string adopterId = adopterId_Html.Value;
            string animalApplied4 = animalId_Html.Value;
            if (adopterId != null && adopterId != "" && (animalApplied4 == null || animalApplied4 == ""))
            {
                Session["adopterId"] = int.Parse(adopterId);
                Response.Redirect("GuestProfile.aspx");
            }

            // העמוד הנוכחי =======================================================
            Session["currentPage"] = "Profile";

            bool isLogin = (bool)Session["isLogin"];
            string username = (string)Session["user"];

            // שליחה לעמוד שגיאה במקרה והמשתמש לא מחובר ==========================
            if (!isLogin)
                Response.Redirect("error/pug.html");

            //=====================================================================


            // databaseלקיחת מידע מתוך ה ==========================================
            const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\Data.mdf;Integrated Security=True";
            SqlConnection conection = new SqlConnection(connectionString);

            string command = $"select * from userData where username='{username}'";
            SqlDataAdapter adapter = new SqlDataAdapter(command, connectionString);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            //======================================================================

            string picUrl = pfp.Src;
            if (dt.Rows[0]["picurl"] != DBNull.Value)
            {
                picUrl = (string)dt.Rows[0]["picurl"];
                pfp.Attributes.Add("class", "newPic");
            }
            pfp.Src = picUrl;

            // המידע משמאל לתמונה, תיאור ==========================================
            string description = "";
            if (dt.Rows[0]["description"] != DBNull.Value)
                description = (string)dt.Rows[0]["description"];

            pfDescriptionText.InnerHtml = description;

            // הכפתורים של התיאור ==================================================
            editDes.Attributes["class"] = "hidden";
            doneBtn.Attributes["class"] = "hidden";
            editBtn.Attributes["class"] = "visible";

            // חישוב גיל ===========================================================
            string birthDate = (string)dt.Rows[0]["birthDate"];
            string[] date_as_arr = birthDate.Split('-');
            DateTime birthday = new DateTime(int.Parse(date_as_arr[0]), int.Parse(date_as_arr[1]), int.Parse(date_as_arr[2]));
            TimeSpan ts = DateTime.Today - birthday;
            int age = (int)ts.TotalDays / 365;

            // המידע מימין לתמונה ==================================================
            string location = (string)dt.Rows[0]["location"];
            string pronouns = (string)dt.Rows[0]["pronouns"];
            pfAge_Pronouns.InnerHtml = $"{age} year old, {pronouns}";
            pfLocation.InnerHtml = location;

            // מספר החיות שיש למשתמש ===============================================
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

            // של המשתמש הנוכחי id ה ================================================
            int userId = (int)dt.Rows[0]["Id"];


            int adopted = 0;
            int sheltering = 0;
            string color = "black";
            if (dt.Rows[0]["adopted"] != DBNull.Value)
                adopted = (int)dt.Rows[0]["adopted"];
            if (dt.Rows[0]["up4adoption"] != DBNull.Value)
                sheltering = (int)dt.Rows[0]["up4adoption"];
            if (dt.Rows[0]["color"] != DBNull.Value)
                color = (string)dt.Rows[0]["color"];
            pfUsername.Style.Add("color", color);

            pfOwned.InnerHtml = "" + owned;
            pfAdopted.InnerHtml = "" + adopted;
            pfSheltetring.InnerHtml = "" + sheltering;

            //הצגת הנתונים של החיות של המשתמש =====================================
            PresentShelteringAnimals();




            // מנגנון לאישור מאמץ  ==========================================================
            if (adopterId != null && adopterId != "")
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                //מצאית המספר המזהה של המאמץ והמאומץ
                int applicant = int.Parse(adopterId);
                int animalApplied4Int = int.Parse(animalApplied4);

                command = $"select * from animalData where Id='{animalApplied4}'";
                adapter = new SqlDataAdapter(command, connectionString);
                DataTable dtAdoptedAnimal = new DataTable();
                adapter.Fill(dtAdoptedAnimal);
                string animalApplied4_name = (string)dtAdoptedAnimal.Rows[0]["name"];

                if (applicant == 0)
                {
                    string commandStr = $"update animalData set applicant = '0' where Id = '{animalApplied4Int}'";
                    SqlCommand cmd = new SqlCommand(commandStr, connection);
                    cmd.ExecuteNonQuery();

                    connection.Close();
                    Response.Redirect("Profile.aspx");

                }
                else
                {
                    // מציאת החיות של המאמץ ושם החייה שהוא מאמץ ובדיקה אם כבר הוספנו לו את החיים
                    command = $"select * from userData where Id='{applicant}'";
                    adapter = new SqlDataAdapter(command, connectionString);
                    DataTable dtAdopter = new DataTable();
                    adapter.Fill(dtAdopter);
                    string animals = (string)dtAdopter.Rows[0]["animals"];

                    if (!animals.Contains(animalApplied4_name))
                    {
                        // עידכון פרטי המאמץ ================
                        string commandStr = $"update userData set animals += ', {animalApplied4_name}', adopted += '1' where Id = '{applicant}'";

                        if (animals == null || animals == "")
                            commandStr = $"update userData set animals = '{animalApplied4_name}', adopted += '1' where Id = '{applicant}'";
                        SqlCommand cmd = new SqlCommand(commandStr, connection);
                        cmd.ExecuteNonQuery();

                        // sheltererעידכון פרטי ה ==========
                        commandStr = $"update userData set up4adoption -= '1' where username = '{username}'";
                        cmd = new SqlCommand(commandStr, connection);
                        cmd.ExecuteNonQuery();

                        // עידכון פרטי החיה =================
                        commandStr = $"update animalData set applicant = '-1' where Id = '{animalApplied4Int}'";
                        cmd = new SqlCommand(commandStr, connection);
                        cmd.ExecuteNonQuery();
                        adopterId = "";
                        adopterId_Html.Value = "";
                        connection.Close();
                        Response.Redirect("Profile.aspx");
                    }
                }
                connection.Close();
            }
        }

        //==========================================================================



        // הצגת הנתונים של החיות של המשתמש =====================
        protected void PresentShelteringAnimals()
        {
            string username = (string)Session["user"];

            const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\Data.mdf;Integrated Security=True";

            // של המשתמש הנמצא כרגע בעמוד id מציאת ה ===========
            string commandStr = $"select * from userData where username='{username}'";
            SqlDataAdapter adapter = new SqlDataAdapter(commandStr, connectionString);
            DataTable dtUsers = new DataTable();
            adapter.Fill(dtUsers);

            int userId = (int)dtUsers.Rows[0]["Id"];

            // id מציאת כל החיות של המשתמש עם אותו וספירתן =====
            commandStr = $"select * from animalData where shelterer='{userId}'";

            SqlDataAdapter adapter1 = new SqlDataAdapter(commandStr, connectionString);
            DataTable dtAnimals = new DataTable();
            adapter1.Fill(dtAnimals);

            //===================================================


            // לכל חיה שמוצאים בטבלה div יצירת =================
            int n = dtAnimals.Rows.Count;

            ownedAnimals.InnerHtml = "";

            // הקופסא הסופית ===================================
            string output1 = "";

            if (n > 0)
            {
                output1 = "<h2 id = 'ownedText' runat='server'> Sheltered Animals </h2>";
                ownedAnimals.InnerHtml += output1;
            }

            for (int i = 0; i < n; i++)
            {
                output1 = "";

                // נתונים של החיה ==============================
                int animalId = (int)dtAnimals.Rows[i]["Id"];
                string animalPicUrl = (string)dtAnimals.Rows[i]["picurl"];
                string animalName = (string)dtAnimals.Rows[i]["name"];
                int applicant = (int)dtAnimals.Rows[i]["applicant"];
                bool isPending = false;
                string adopterInfo = "";

                // מציאת הטקסט והצבע של הסטטוס ================
                string status;
                string color;

                if (applicant > 0)
                {
                    color = "orange";
                    status = "Pending";
                    isPending = true;
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


                // applicant אם יש ==============================
                if (isPending)
                {
                    commandStr = $"select * from userData where id='{applicant}'";

                    SqlDataAdapter adapter2 = new SqlDataAdapter(commandStr, connectionString);
                    DataTable dtAdopter = new DataTable();
                    adapter2.Fill(dtAdopter);

                    string adopterEmail = (string)dtAdopter.Rows[0]["email"];
                    string adopterPhone = (string)dtAdopter.Rows[0]["phoneNum"];
                    string adopter = (string)dtAdopter.Rows[0]["fullName"];
                    string adopterPic = (string)dtAdopter.Rows[0]["picurl"];

                    adopterInfo = $"<h4 id='applicantTitle' style='margin-left:30px;'>Applicant</h4>" +
                                  $"<div class='adopterDiv'>" +
                                  $"<table>" +
                                  $"<tr>" +
                                  $"<td> " +
                                  $"<img src='{adopterPic}' onclick='sendAdopter({applicant})' class='adopterPic'/> " +
                                  $"</td>" +
                                  $"<td>" +
                                  $"<br /><br />" +
                                  $"<div style='margin-left:30px;'> " +
                                  $"<label id='adopterName'>- {adopter}</label>" +
                                  $"<br /> <label style='margin-left:30px;'>{adopterEmail}</label>" +
                                  $"<br /> <label style='margin-left:30px;'>{adopterPhone}</label>" +
                                  $"<br />" +
                                  $"<br /> <center>" +
                                  $"<button id='accept' class='coolBtn' onclick='sendAcception({animalId}, {applicant});'>Accept</button>" +
                                  $"<button id='deny' class='coolBtn' onclick='sendAcception({animalId}, 0);'>Deny</button>" +
                                  $"</center>" +
                                  $"</td>" +
                                  $"</tr>" +
                                  $"</table>" +
                                  $"</div>";
                }



                // הקופסא הסופית =============================
                output1 = $"" +
                       $"<div class='ownedDiv'>" +
                       $"<table class='ownedT'>" +
                       $"<tr>" +
                       $"<td><img class='newAnimalPic' src='{animalPicUrl}'</td>" +
                       $"<td class='leftText'> " +
                       $"   <div class='textLeft' style='font-size: 24px; margin-left:30px;'> " +
                       $"       <br /><label style='font-weight:600;font-size:26px;'>{animalName}</label> " +
                       $"       <br /><label style='font-weight:400;'>Adoption Status:</label> <label style='color:{color}'>{status}</label>" +
                       $"       {adopterInfo}" +
                       $"   </div>" +
                       $"</td>" +
                       $"</tr>" +
                       $"</table>" +
                       $"</div>";


                ownedAnimals.InnerHtml += output1;
            }
        }

        //====================================================================================


        // שהמשתמש שם לתמונה הוא תקין url בדיקה אם ה
        private bool RemoteFileExists(string url)
        {
            try
            {
                //Creating the HttpWebRequest
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "HEAD";

                //Getting the Web Response.
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                //Returns TRUE if the Status code == 200
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                //Any exception will returns false.
                return false;
            }
        }

        // כפתור שינוי התמונה בלחיצה עליה ======================================================
        protected void pfp_button_ServerClick(object sender, EventArgs e)
        {
            if (picUrl_html.Value != null && RemoteFileExists(picUrl_html.Value))
            {
                string username = (string)Session["User"];

                const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\Data.mdf;Integrated Security=True";

                SqlConnection conection = new SqlConnection(connectionString);
                string picUrl = (string)picUrl_html.Value;
                conection.Open();

                string commandStr = $"update userData set picurl = '{picUrl}' where username = '{username}'";
                SqlCommand cmd = new SqlCommand(commandStr, conection);
                cmd.ExecuteNonQuery();
                conection.Close();
                Response.Redirect("Profile.aspx");
            }
        }

        // כפתור העריכה של התיאור ==============================================================
        protected void editBtn_ServerClick(object sender, EventArgs e)
        {
            editDes.Value = pfDescriptionText.InnerHtml;

            pfDescriptionText.Attributes["class"] = "hidden";
            editBtn.Attributes["class"] = "hidden";
            editDes.Attributes["class"] = "visible";
            doneBtn.Attributes["class"] = "visible";


        }

        // כפתור סיום העריכה של התיאור =========================================================
        protected void DoneBtn_ServerClick(object sender, EventArgs e)
        {
            editDes.Value = editDes.Value.Replace("'", "`");
            editDes.Value = editDes.Value.Replace('"', '平'); //בחרתי אות מיפנית בתור תו זמני מהנחה שאין לנו משתמשים יפנים
            editDes.Value = editDes.Value.Replace("平", "``");
            pfDescriptionText.InnerHtml = editDes.Value;
            string description = editDes.Value;

            pfDescriptionText.Attributes["class"] = "visible";
            editBtn.Attributes["class"] = "visible";
            editDes.Attributes["class"] = "hidden";
            doneBtn.Attributes["class"] = "hidden";

            string username = (string)Session["User"];

            const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\Data.mdf;Integrated Security=True";

            SqlConnection conection = new SqlConnection(connectionString);
            string picUrl = (string)picUrl_html.Value;
            conection.Open();

            string commandStr = $"update userData set description = '{description}' where username = '{username}'";
            SqlCommand cmd = new SqlCommand(commandStr, conection);
            cmd.ExecuteNonQuery();
            conection.Close();


        }

        // Sheltering Application העברה לעמוד ה ==================================================
        protected void btAddAnimal_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("ShelteringApplication.aspx");
        }
    }
}