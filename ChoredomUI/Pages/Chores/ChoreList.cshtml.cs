using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using ChoredomUI.Models;

namespace ChoredomUI.Pages.Chores
{
    public class IndexModel : PageModel
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
                    while(reader.Read())
                    {
                        Chore chore = new Chore();
                        chore.ChoreName = reader["ChoreName"].ToString();
                        chore.ChoreId = int.Parse(reader["ChoreId"].ToString());
                        ChoreList.Add(chore);
                    }
                }
            }
        }
    }
}