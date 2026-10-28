using eLibrary.Data;
using eLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Pages
{
    [Authorize(Roles = "admin")]
    public class AdminModel : PageModel
    {

        // Lagra databaskoppling i privat variabel
        private readonly AppDbContext _context;

        // Konstruktor
        public AdminModel(AppDbContext context)
        {
            _context = context;
        }

        // Listor för att skicka datan till HTML-sidan
        public List<Loan> ActiveLoans { get; set; } = new();
        public List<Reservation> Reservations { get; set; } = new();

        public async Task OnGetAsync()
        {
            ActiveLoans = await _context.Loans
                .Include(l => l.Book)
                .Include(l => l.User) // <-- Lägg till denna!
                .Where(l => l.ReturnedDate == null)
                .OrderBy(l => l.LoanDate)
                .ToListAsync();
        }
    }
}
