using System;
using System.Data;
using System.Data.SqlClient;

namespace pet_shelter.pages
{
    public partial class Puppies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            const string fileName = "Puppies";
            Session["currentPage"] = fileName;
            bool isLogin = (bool)Session["isLogin"];
            string username = (string)Session["user"];
            string animalApplied4 = animalId_Html.Value;
            const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\Data.mdf;Integrated Security=True";


            SqlDataAdapter adapter;


            if (IsPostBack)
            {
                if (!isLogin)
                {
                    ClientScript.RegisterStartupScript(GetType(), "toLogin", "if (confirm('You must sign in to use this function. Would you like to be redirected to login ?')) window.location.href = 'Login.aspx';", true);
                }
                else if (animalApplied4 != null && animalApplied4 != "")
                {
                    // של המשתמש מטבלת המשתמשים id קבלת ה
                    string commandStr = $"select * from userData where username='{username}'";
                    DataTable dt = new DataTable();
                    adapter = new SqlDataAdapter(commandStr, connectionString);
                    adapter.Fill(dt);

                    // של המשתמש הנוכחי id ה
                    int userId = (int)dt.Rows[0]["Id"];
                    SqlConnection connection = new SqlConnection(connectionString);

                    // של החיה id בדיקה של ה
                    commandStr = $"select * from animalData where Id = '{animalApplied4}'";
                    DataTable animaldt = new DataTable();
                    adapter = new SqlDataAdapter(commandStr, connectionString);
                    adapter.Fill(animaldt);

                    if (animaldt.Rows.Count > 0)
                    {
                        int sheltererId = (int)animaldt.Rows[0]["shelterer"];

                        // בדיקה אם שם המשתמש מנסה לאמץ את החיה של עצמו
                        if (userId != sheltererId)
                        {
                            // applicant של המשתמש שרוצה לאמץ בטבלה במקום של ה id שם את ה
                            connection.Open();
                            commandStr = $"update animalData set applicant = '{userId}' where Id = '{animalApplied4}'";
                            SqlCommand cmd = new SqlCommand(commandStr, connection);
                            cmd.ExecuteNonQuery();
                            connection.Close();

                            // הודעה למשתמש שהפעולה בוצאה בהצלחה 
                            ClientScript.RegisterStartupScript(GetType(), "applicationAccepted", "alert('The shelterer has been notified of your interest')", true);
                        }
                        else
                            ClientScript.RegisterStartupScript(GetType(), "adoptYourOwnAnimal", "alert('You can`t adopt your own animal')", true);
                    }
                }
            }


            // databaseלקיחת מידע מתוך ה
            SqlConnection conection = new SqlConnection(connectionString);

            string command = $"select * from animalData where type='{fileName}'";
            adapter = new SqlDataAdapter(command, connectionString);
            DataTable dtAnimals = new DataTable();
            adapter.Fill(dtAnimals);

            int id;
            string name;
            string picUrl;
            string breed;
            string info;
            string color;
            string characteristics;
            string description;
            string str = "";
            string str2 = "";

            for (int i = 0; i < dtAnimals.Rows.Count; i++)
            {
                if ((int)dtAnimals.Rows[i]["applicant"] == 0)
                {
                    id = (int)dtAnimals.Rows[i]["Id"];
                    name = (string)dtAnimals.Rows[i]["name"];
                    string name_ = name.Replace(' ', '_');
                    name_ = name_.Replace("'", "_");
                    name_ = name_.Replace(".", ",");
                    picUrl = (string)dtAnimals.Rows[i]["picurl"];
                    breed = (string)dtAnimals.Rows[i]["breed"];
                    info = (string)dtAnimals.Rows[i]["info"];
                    color = (string)dtAnimals.Rows[i]["color"];
                    characteristics = (string)dtAnimals.Rows[i]["characteristics"];
                    description = (string)dtAnimals.Rows[i]["description"];

                    if (!tableContent.InnerHtml.Contains(name))
                    {
                        //של החייה div יצירת
                        str = $"<div class='left' id='{name_}'> " +
                        $"    <table class='leftT'>  " +
                        $"        <tr> " +
                        $"            <td> " +
                        $"                <img id='{name_}Pic' class='newAnimalPic' src='{picUrl}' /> " +
                        $"            </td> " +
                        $"            <td class='leftText'> " +
                        $"                <div class='textLeft'> " +
                        $"                    <br /><lable style = 'font-size:25px;' > {name} </lable > " +
                        $"                    <br /> " +
                        $"                    <br /> {breed} " +
                        $"                    <br /> {info} " +
                        $"                    <br /> " +
                        $"                    <br /> <label class='minyTitle'>Color</label> " +
                        $"                    <br /> {color} " +

                        $"                    <br /> " +
                        $"                    <br /><label class='minyTitle'>Characteristics</label> " +
                        $"                    <br /> {characteristics} " +


                        $"                    <br /> " +
                        $"                    <br /><label class='minyTitle'>Meet {name}:</label> " +
                        $"                    <br /> {description} " +

                        $"                    <br /><br /> " +
                        $"                    <button class='chosen' type='button' onclick='sendApplication({id})'>I Choose You!</button> " +
                        $"                </div> " +
                        $"            </td>  " +
                        $"        </tr> " +
                        $"    </table> " +
                        $"</div>";
                        //הוספת החייה לתוכן העניינים
                        str2 = $"<br /><label onclick='{name_}.scrollIntoView()'>- {name}</label>";

                        userAnimals.InnerHtml += str;
                        tableContent.InnerHtml += str2;
                    }
                }
            }
        }
    }
}