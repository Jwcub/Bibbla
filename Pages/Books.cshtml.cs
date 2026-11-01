using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using eLibrary.Data;
using eLibrary.Models;
using System.Security.Claims;

namespace eLibrary.Pages.Books;
public class DetailsModel : PageModel
{
    private readonly AppDbContext _context;

    // Konstruktor
    public DetailsModel(AppDbContext context)
    {
        _context = context;
    }

    // Property för book
    public Book Book { get; set; } = null!;

    // Hämta info om bok i databas
    public async Task<IActionResult> OnGetAsync(int bookId)
    {
        var fetchedBook = await _context.Books
            .Include(b => b.Authors)
            .Include(b => b.Genres)
            .FirstOrDefaultAsync(b => b.BookId == bookId);

        if (fetchedBook == null)
        {
            return NotFound(); 
        }

        Book = fetchedBook;

        return Page();
    }

    // Låna bok
    public async Task<IActionResult> OnPostBorrowAsync(int bookId)
    {
        //Hämta användarens Id
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(userIdString, out int userId))
        {
            return RedirectToPage("/Login"); //Om inget användarnamn, logga in
        }

        // Hitta bok
        var book = await _context.Books.FindAsync(bookId);

        // Kontrollera att boken existerar och är tillgänglig
        if (book == null || book.AvailableCopies <= 0)
        {
            ModelState.AddModelError(string.Empty, "Boken är tyvärr utlånad.");
            return Page();
        }

        // Skapa lån
        var loan = new Loan
        {
            UserId = userId,
            BookId = bookId,
            LoanDate = DateTime.UtcNow,
            DueDate = DateTime.UtcNow.AddDays(30),
            ReturnedDate = null
        };

        // Minska antalet tillgängliga kopior
        book.AvailableCopies -= 1;

        //Spara till databasen
        _context.Loans.Add(loan);
        await _context.SaveChangesAsync();

        // Skicka användaren till min sida
        return RedirectToPage("/My-page");
    }

    // Reservera bok
    public async Task<IActionResult> OnPostReserveAsync(int bookId)
    {
        //Hämta användarens Id
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(userIdString, out int userId))
        {
            return RedirectToPage("/Login"); //Om inget användarnamn, logga in
        }

        // Kontrollera att boken existerar och är tillgänglig
        var book = await _context.Books.FindAsync(bookId);
        if (book == null)
        {
            return NotFound();
        }

        // Kontrollera att användaren inte redan reserverat boken
        bool alreadyReserved = await _context.Reservations
            .AnyAsync(r => r.BookId == bookId && r.UserId == userId);
        if (alreadyReserved)
        {
            var fetchedBook = await _context.Books
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .FirstOrDefaultAsync(b => b.BookId == bookId);

            if (fetchedBook != null)
            {
                Book = fetchedBook;
            }
            
            ModelState.AddModelError(string.Empty, "Du har redan reserverat den här boken.");
            return Page();
        }

        // Skapa reservation
        var reservation = new Reservation
        {
            UserId = userId,
            BookId = bookId,
            ResDate = DateTime.UtcNow
        };

        // Spara i databasen
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();

        // Skicka användare till min sida
        return RedirectToPage("/My-page");
    }
}

