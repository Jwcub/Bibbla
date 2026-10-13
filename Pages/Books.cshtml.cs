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

    public async Task<IActionResult> OnGetAsync(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return NotFound();
        }

        Book = await _context.Books
            .Include(b => b.Authors)
            .Include(b => b.Genres)
            .FirstOrDefaultAsync(b => b.Title.ToLower() == title.ToLower());

        if (Book == null)
        {
            return NotFound();
        }

        return Page();
    }
}

