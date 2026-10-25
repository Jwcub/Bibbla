using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace eLibrary.Pages
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnPostAsync()
        {
           // Radera inloggningscookie
           await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

           // Skicka användaren till inloggningssidan
           return RedirectToPage("/Login"); 
        }
    }
}
