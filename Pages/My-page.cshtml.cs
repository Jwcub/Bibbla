using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace eLibrary.Pages
{
    [Authorize]
    public class My_pageModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
