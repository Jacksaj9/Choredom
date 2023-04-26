using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Net;
using ChoredomUI.Models;

namespace ChoredomUI.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential LoginInfo { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // verify user credential
                if (LoginInfo.Email == "admin@chore.com" && LoginInfo.Password == "ChoredomRules")
                {

                    var claims = new List<Claim> {
                       new Claim(ClaimTypes.Email, LoginInfo.Email),
                       new Claim(ClaimTypes.Name, "Ariel"),
                       new Claim("Username", "Admin")
                    };

                    var identity = new ClaimsIdentity(claims, "ChoredomCookie");
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync("ChoredomCookie", principal);

                    return RedirectToPage("/Index");

                }
                return Page();
            }
            return Page();
        }

        private bool LoginVerified()
        {

            return true;

        }

        private string GetUserSalt(string email)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
            {
                string sql = "SELECT salt FROM [User] WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@email", LoginInfo.Email);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return reader["Salt"].ToString();
                }
                return "";
            }
        }
    }



    public class Credential
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}