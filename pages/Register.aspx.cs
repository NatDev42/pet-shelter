using System;
using System.Data.SqlClient;

namespace pet_shelter.pages
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // העמוד הנוכחי 
            Session["currentPage"] = "Register";
        }

        protected void rgsubmit_ServerClick(object sender, EventArgs e)
        {
            const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\Data.mdf;Integrated Security=True";

            SqlConnection conection = new SqlConnection(connectionString);

            rgUsername.Value = rgUsername.Value.Replace("'", "`");
            rgUsername.Value = rgUsername.Value.Replace('"', 'ة'); //בחרתי אות מיפנית בתור תו זמני מהנחה שאין לנו משתמשים יפנים
            rgUsername.Value = rgUsername.Value.Replace("ة", "``");
            string username = rgUsername.Value;
            string password = rgPassword.Value;
            string location = $"{rgCountry.Value}, {rgCity.Value}";
            string animals = rgAnimals.Value;
            string phoneNum = rgPhoneNum.Value;
            string email = rgEmail.Value;
            string birthDate = rgBirthDate.Value;
            string gender = "They/Them";
            string fullName = rgFirstName.Value + " " + rgLastName.Value;
            if (genderMale.Checked)
                gender = "He/Him";
            else if (genderFemale.Checked)
                gender = "She/Her";
            else
                gender = genderOtherText.Value;

            string commandStr = $"select count(*) from userData where username='{username}'";
            SqlCommand cmd = new SqlCommand(commandStr, conection);
            conection.Open();

            int n = (int)cmd.ExecuteScalar();
            if (n > 0)
            {
                UsernameTaken.Attributes.Add("class", "visibleWarning");
            }
            else
            {
                cmd.CommandText = $"insert into userData (username, password, pronouns, location, animals, email, birthDate, phoneNum, fullName, up4adoption, adopted) values('{username}', '{password}', '{gender}', '{location}', '{animals}', '{email}', '{birthDate}', '{phoneNum}', '{fullName}', '0', '0')";
                n = cmd.ExecuteNonQuery();
                Response.Redirect("Login.aspx");
            }
            conection.Close();

        }
    }
}