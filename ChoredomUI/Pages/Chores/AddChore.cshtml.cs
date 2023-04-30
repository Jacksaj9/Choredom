using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ChoredomUI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace ChoredomUI.Pages.Chores
{
    [Authorize]
    public class AddModel : PageModel
    {
        [BindProperty]
        public Chore NewChore { get; set; } = new Chore();
        
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
                {
                    string sql = "INSERT INTO Chore(ChoreName, ChoreRooms)" + "VALUES (@choreName, @choreRooms)";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@choreName", NewChore.ChoreName);

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                return RedirectToPage("ChoreList");
            }
            else
            {
                return Page();
            }
        }

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

    }
}