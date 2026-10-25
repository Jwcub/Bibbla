using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace eLibrary.Pages
{
    [Authorize]
    public class My_booksModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
