using System;
using System.Data;
using System.Data.SqlClient;

namespace pet_shelter.pages
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // העמוד הנוכחי 
            Session["currentPage"] = "Sheltering_Application";

            if (!(bool)Session["isLogin"])
                Response.Redirect("error/pug.html");
        }

        protected void shSubmit_ServerClick(object sender, EventArgs e)
        {
            // הצבת המשתנים שהמשתמש שם בתוך משתנים
            string username = (string)Session["user"];
            string name = shName.Value.TrimEnd(' ');
            string type;
            if (shTypeDogs.Checked)
                type = "Puppies";
            else if (shTypeCats.Checked)
                type = "Kittens";
            else if (shTypeRodents.Checked)
                type = "Rodents";
            else if (shTypeTurtles.Checked)
                type = "Turtles";
            else
                type = "Horses";

            string breed = shBreed.Value;
            string age = shAge.Value;
            string gender = shGender.Value;
            string size = shSize.Value;
            string color = shColor.Value;
            string picUrl = shPicUrl.Value;
            string info = $"{age} - {gender} - {size}";
            string characteristics = shCharacteristics.Value;
            shDescription.Value = shDescription.Value.Replace("'", "`");
            shDescription.Value = shDescription.Value.Replace('"', 'ة'); //בחרתי אות מיפנית בתור תו זמני מהנחה שאין לנו משתמשים יפנים
            shDescription.Value = shDescription.Value.Replace("ة", "``");

            name = name.Replace("'", "`");
            name = name.Replace('"', 'ة'); //בחרתי אות מיפנית בתור תו זמני מהנחה שאין לנו משתמשים יפנים
            name = name.Replace("ة", "``");
            string description = shDescription.Value;
            //=============================================

            // הצבת המשתנים בתוך הטבלה
            const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\Data.mdf;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            

            // של המשתמש מטבלת המשתמשים id קבלת ה
            string commandStr = $"select * from userData where username='{username}'";
            SqlDataAdapter adapter = new SqlDataAdapter(commandStr, connectionString);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            int userId = (int)dt.Rows[0]["id"];

            connection.Open();

            // השמת הערכים בטבלה
            commandStr = $"insert into animalData (name, type, breed, info, color, characteristics, description, shelterer, picurl, applicant) values('{name}', '{type}', '{breed}', '{info}', '{color}', '{characteristics}', '{description}', '{userId}', '{picUrl}', '0')";
            SqlCommand cmd = new SqlCommand(commandStr, connection);
            cmd.ExecuteNonQuery();

            // עדכון מספר החיות השנמצאות אצל המשתמש במידה והחייה הוחנסה למערך הנתונים בהצלחה
            commandStr = $"update userData set up4adoption += '1' where username = '{username}'";
            cmd = new SqlCommand(commandStr, connection);
            cmd.ExecuteNonQuery();            

            connection.Close();
            Response.Redirect("Profile.aspx");
        }
    }
}