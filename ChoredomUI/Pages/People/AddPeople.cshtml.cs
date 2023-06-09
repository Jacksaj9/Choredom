using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ChoredomUI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace ChoredomUI.Pages.Chores
{
    [Authorize]
    public class AddPersonModel : PageModel
    {
        [BindProperty]
        public Person NewPerson { get; set; } = new Person();
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
                {
                    string sql = "INSERT INTO Person(FirstName, LastName, PersonBio)" + "VALUES (@FirstName, @LastName, @PersonBio)";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@FirstName", NewPerson.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", NewPerson.LastName);
                    cmd.Parameters.AddWithValue("@PersonBio", NewPerson.PersonBio);
                    conn.Open();

                    cmd.ExecuteNonQuery();
                    //string sqlPersonID = "SELECT @@Identity";
                }
                return RedirectToPage("PeopleList");
            }
            else
            {
                return Page();
            }
        }
    }
}
