using System.ComponentModel.DataAnnotations;
using eLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore; 
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace eLibrary.Pages
{
    public class LoginModel : PageModel
    {
        // Privat variabel för databaskoppling
        private readonly AppDbContext _context;

        // Konstruktorn för login
        public LoginModel(AppDbContext context)
        {
            // Spara anslutning i privat variabel
            _context = context;
        }

        [BindProperty]
        public LoginCredentials Credentials { get; set; } = new();

        // Logga in
        public async Task<IActionResult> OnPostAsync()
        {
            // Vid fel, stanna kvar på sidan.
            if(!ModelState.IsValid)
            {
                return Page();
            }

            // Kontrollera om användare finns
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == Credentials.Username);

            // Kontrollera att lösenordet är korrekt
            if (user == null || !BCrypt.Net.BCrypt.Verify(Credentials.Password, user.PasswordHash))
            {
                ModelState.AddModelError(string.Empty, "Felaktig e-post eller lösenord.");
                return Page();
            }

            // Lagra information om användaren
            var claims = new List<Claim>
            {
                // Sparar användarnamn så du kan visa det på sidan senare
                new Claim(ClaimTypes.Name, user.UserName),

                // Spara förnamn
                new Claim(ClaimTypes.GivenName, user.FirstName),

                // Användarens roll
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            
                // Sparar ID:t, vilket är praktiskt när du behöver slå upp saker i databasen
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()) 
            };

            // ID för Cookie Authentication
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // Användarobjektet för ID-kortet
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            // Baka ihop och skicka inloggnings-cookien till webbläsaren
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, 
                claimsPrincipal);

            if (user.Role.ToString().ToLower() == "admin")
            {
                return RedirectToPage("/Admin");
            } else
            {
            return RedirectToPage("/My-page");
            }
        }

        // Hjälpklass för Credentials
        public class LoginCredentials
        {
            public string Username { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }
    }
}
