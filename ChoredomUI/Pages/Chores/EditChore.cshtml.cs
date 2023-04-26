using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ChoredomUI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace ChoredomUI.Pages.Chores
{
    [Authorize]
    public class EditChoreModel : PageModel
    {
        [BindProperty]
        public Chore ExistingChore { get; set; } = new Chore();
        public void OnGet(int id)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
            {
                string sql = "SELECT * FROM Chore WHERE ChoreId = @choreId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@choreId", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    ExistingChore.ChoreName = reader["ChoreName"].ToString();
                }
            }
        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
                {
                    string sql = "UPDATE Chore SET ChoreName=@choreName WHERE ChoreId=@choreId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@choreName", ExistingChore.ChoreName);
                    cmd.Parameters.AddWithValue("@choreId", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return RedirectToPage("ChoreList");
                }
            }
            else
            {
                return Page();
            }
        }
    }
}
