using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using eLibrary.Data;
using eLibrary.Models;

namespace eLibrary.Pages.Books;
public class DetailsModel : PageModel
{
    private readonly AppDbContext _context;

    public DetailsModel(AppDbContext context)
    {
        _context = context;
    }

    public Book? Book { get; set; }

    public async Task<IActionResult> OnGetAsync(int BookId)
    {
        Book = await _context.Books
            .Include(b => b.Authors)
            .Include(b => b.Genres)
            .FirstOrDefaultAsync(b => b.BookId == BookId);

        if (Book == null)
        {
            return RedirectToPage("/404");
        }

        return Page();
    }
}

