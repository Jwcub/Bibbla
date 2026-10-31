using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using eLibrary.Data;
using eLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace eLibrary.Pages
{
    [Authorize]
    public class My_pageModel : PageModel
    {
        // Lagra databaskoppling i privat variabel
        private readonly AppDbContext _context;

        // Konstruktor
        public My_pageModel(AppDbContext context)
        {
            _context = context;
        }

        // Listor för att skicka datan till HTML-sidan
        public List<Loan> ActiveLoans { get; set; } = new();
        public List<Reservation> MyReservations { get; set; } = new();


        public async Task OnGetAsync()
        {
            // Kontrollera vem som är inloggad
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            if (int.TryParse(userIdString, out int userId))
            {
                // Hämta lån som inte är återlämnade
                ActiveLoans = await _context.Loans
                    .Include(l => l.Book)
                    .Where(l => l.UserId == userId && l.ReturnedDate == null)
                    .ToListAsync();

                // Hämta reservationer
                MyReservations = await _context.Reservations
                    .Include(r => r.Book)
                    .Where(r => r.UserId == userId)
                    .ToListAsync();
            }
        }

        // Förlänga lånetid på bok
        public async Task<IActionResult> OnPostProlongAsync(int bookId)
        {
            //Hämta användarens Id
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdString, out int userId))
            {
                ModelState.AddModelError(string.Empty, "Det gick inte att förlänga lånetiden.");
                return Page();
            }

            // Hitta det aktiva lånet
            var activeLoan = await _context.Loans
                .FirstOrDefaultAsync(
                    l => l.BookId == bookId && 
                    l.UserId == userId && 
                    l.ReturnedDate == null);

            // Lån saknas
            if (activeLoan == null)
            {
                ModelState.AddModelError(string.Empty, "Kunde inte hitta ett aktivt lån för den här boken.");
                return Page();
            }

            // Kontrollera om boken är reserverad
            var reservation = await _context.Reservations
            .FirstOrDefaultAsync(r => r.BookId == bookId && r.ResStatus == ReservationStatus.Pågående);

            if (reservation != null)
            {
                ModelState.AddModelError(string.Empty, "Boken kan inte förlängas eftersom den är reserverad.");
                return Page();
            }

            // Uppdatera lånetiden till 30 dagar från dagens datum 
            activeLoan.DueDate = DateTime.Today.AddDays(30);

            // Uppdatera i databasen
            await _context.SaveChangesAsync();

            // Ladda om sidan
            return RedirectToPage();
                
        }

    }
}
