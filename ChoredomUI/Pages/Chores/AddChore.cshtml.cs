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
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
                {
                    string sql = "INSERT INTO Chore(ChoreName)" + "VALUES (@choreName)";

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
    }
}