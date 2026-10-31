using eLibrary.Data;
using eLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Linq;

namespace eLibrary.Pages;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    // Konstruktor för databas
    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    // Sökresultat
    public List<Book> SearchResults { get; set; } = new();

    // Senast tillagda böcker
    public List<Book> LatestBooks { get; set; } = new();

    // Egenskaper för utskrift av ålder och genre till HTML
    public List<string> AvailableGenres { get; set; } = new();
    public List<string> AvailableAges { get; set; } = new();
    public bool HasSearched { get; set; } = false;

    public string CurrentSearchWord { get; set; } = "";


    public async Task OnGetAsync(string? query, string? age, string? genre)
    {
        // Hämta alla unika genrenamn sorterade i bokstavsordning
        AvailableGenres = await _context.Genres
            .Select(g => g.Name)
            .OrderBy(name => name)
            .ToListAsync();

        // Hämta alla unika åldersgrupper
        AvailableAges = await _context.Books
            .Where(b => !string.IsNullOrEmpty(b.Age))
            .Select(b => b.Age!)
            .Distinct()
            .OrderBy(a => a)
            .ToListAsync();
            
        //Sökfrågan ska slås mot tabellerna böcker, författare och genre
        var searchQuery = _context.Books
            .Include(b => b.Authors)
            .Include(b => b.Genres)
            .AsQueryable();
        
        // Kontrollera om sökfrasen innehåller titel, författare eller ISBN
        if (!string.IsNullOrWhiteSpace(query))
        {
            HasSearched = true;
            CurrentSearchWord = query;

            var sQuery = query.Trim();
            searchQuery = searchQuery.Where(b => 
                b.Title.ToLower().Contains(sQuery.ToLower()) || 
                b.Isbn.Contains(sQuery) ||
                b.Authors.Any(a => (a.FirstName + " " + a.LastName).ToLower().Contains(sQuery.ToLower()))
                );
        }

        // Filtrera på ålder
        if (!string.IsNullOrWhiteSpace(age))
        {
            searchQuery = searchQuery.Where( b => b.Age == age);
        }

        // Filtrera på genre
        if (!string.IsNullOrWhiteSpace(genre))
        {
            searchQuery = searchQuery.Where(b => b.Genres.Any(g => g.Name == genre));
        }

        // Kontrollera att användaren gjort en sökning
        HasSearched = !string.IsNullOrWhiteSpace(query) 
           || !string.IsNullOrWhiteSpace(age) 
           || !string.IsNullOrWhiteSpace(genre);
        
        // Visa sökresultat
        if (HasSearched)
        {
            SearchResults = await searchQuery.ToListAsync();
        }

        //Senaste 5 tillagda böckerna
        LatestBooks = await _context.Books
            .OrderByDescending(d => d.AddedDate)
            .Take(5)
            .ToListAsync();
    }
}
