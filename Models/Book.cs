using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLibrary.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<Author> Authors { get; set; } = new();
        public List<Genre> Genres { get; set; } = new();
        public string? Age { get; set; } = string.Empty;
        public int PublishedYear { get; set; }
        public string? CoverImage { get; set; } = string.Empty;
        public string Isbn { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string? Shelf { get; set; } = string.Empty;
    }
}