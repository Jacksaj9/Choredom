using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChoredomUI.Pages.Chores
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Chore> ChoreList { get; set; } = new List<Chore>();
        public void OnGet()
        {

        }
    }
}
