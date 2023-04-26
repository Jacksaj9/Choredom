using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ChoredomUI.Models;
using Microsoft.Data.SqlClient;

namespace ChoredomUI.Pages.People
{
    public class EditPeopleModel : PageModel
    {
        [BindProperty]
        public Person ExistingPerson { get; set; } = new Person();
        public void OnGet(int id)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
            {
                string sql = "SELECT * FROM Person WHERE PersonId = @personId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@personId", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    ExistingPerson.FirstName = reader["FirstName"].ToString();
                    ExistingPerson.LastName = reader["LastName"].ToString();
                    ExistingPerson.PersonBio = reader["PersonBio"].ToString();
                }
            }
        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
                {
                    string sql = "UPDATE Person SET FirstName=@personFirstName, LastName=@personLastName, PersonBio=@personPersonBio WHERE PersonId=@personId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@personFirstName", ExistingPerson.FirstName);
                    cmd.Parameters.AddWithValue("@personLastName", ExistingPerson.LastName);
                    cmd.Parameters.AddWithValue("@personPersonBio", ExistingPerson.PersonBio);
                    cmd.Parameters.AddWithValue("@personId", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return RedirectToPage("PeopleList");
                }
            }
            else
            {
                return Page();
            }
        }
    }
}