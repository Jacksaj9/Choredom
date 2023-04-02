using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ChoredomUI.Models;
using Microsoft.Data.SqlClient;

namespace ChoredomUI.Pages.Chores
{
    public class AddPersonModel : PageModel
    {
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
                    string sql = "INSERT INTO Person(PersonFirstName, PersonLastName)" + "VALUES (@personFirstName, @personLastName)";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@personFirstName", NewPerson.PersonFirstName);
                    cmd.Parameters.AddWithValue("@personFLastName", NewPerson.PersonLastName);

                    conn.Open();

                    cmd.ExecuteNonQuery();
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
