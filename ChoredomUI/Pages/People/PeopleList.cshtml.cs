using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ChoredomUI.Models;
using System.Data.SqlClient;

namespace ChoredomUI.Pages.People
{
    public class PeopleListModel : PageModel
    {
        [BindProperty]
        public List<Person> PeopleList { get; set; } = new List<Person>();
        public void OnGet()
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
            {
                string sql = "SELECT * FROM Person Order By FirstName";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Person person = new Person();
                        person.PersonId = int.Parse(reader["PersonId"].ToString());
                        person.FirstName = reader["FirstName"].ToString();
                        person.LastName = reader["LastName"].ToString();
                        person.PersonBio = reader["PersonBio"].ToString();


                        PeopleList.Add(person);
                    }
                }
            }
        }

        public IActionResult OnPost(int id)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
            {
                string sql = "DELETE FROM Person WHERE PersonId = @personId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@personId", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                return RedirectToPage("PeopleList");

            }
        }

    }
}

