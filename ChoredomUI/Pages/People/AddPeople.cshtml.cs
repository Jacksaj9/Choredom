using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ChoredomUI.Models;
using Microsoft.Data.SqlClient;

namespace ChoredomUI.Pages.Chores
{
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
                    string sql = "INSERT INTO Person(FirstName, LastName)" + "VALUES (@FirstName, @LastName)";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@FirstName", NewPerson.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", NewPerson.LastName);

                    conn.Open();

                    cmd.ExecuteNonQuery();
                    string sqlPersonID = "SELECT @@Identity";
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
