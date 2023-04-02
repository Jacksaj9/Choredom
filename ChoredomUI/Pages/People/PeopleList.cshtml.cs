using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using ChoredomUI.Models;

namespace ChoredomUI.Pages.People
{
    public class PeopleModel : PageModel
    {
        [BindProperty]
        public List<Person> PeopleList { get; set; } = new List<Person>();
        public void OnGet()
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
            {
                string sql = "SELECT * FROM Chore Order By ChoreName";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Person person = new Person();
                        person.PersonId = int.Parse(reader["PersonId"].ToString());
                        person.PersonFirstName = reader["PersonFirstName"].ToString();
                        person.PersonLastName = reader["PersonLastName"].ToString();


                        PeopleList.Add(person);
                    }
                }
            }
        }
    }
}
