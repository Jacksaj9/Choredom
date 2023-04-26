using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using ChoredomUI.Models;

namespace ChoredomUI.Pages.Chores
{
    public class ChoreListModel : PageModel
    {
        [BindProperty]
        public List<Chore> ChoreList { get; set; } = new List<Chore>();
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
                        Chore chore = new Chore();
                        chore.ChoreId = int.Parse(reader["ChoreId"].ToString());
                        chore.ChoreName = reader["ChoreName"].ToString();

                        ChoreList.Add(chore);
                    }
                }
            }
        }

        public IActionResult OnPost(int id)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
            {
                string sql = "DELETE FROM Chore WHERE ChoreId = @choreId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@choreId", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                return RedirectToPage("ChoreList");

            }
        }

    }

}
