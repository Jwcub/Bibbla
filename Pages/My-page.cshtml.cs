using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
