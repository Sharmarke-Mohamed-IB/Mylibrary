namespace MyLibrary.Models
{
    public class Book
    {
        // Unique identifier for each book
        public int Id { get; set; }

        // Title of the book
        public string Title { get; set; } = null!;

        // Author name
        public string Author { get; set; } = null!;

        // Genre or category of the book
        public string Genre { get; set; } = null!;

        // URL to the cover image of the book
        public string CoverImageUrl { get; set; } = null!;

        // A brief description or summary of the book
        public string Description { get; set; } = null!;

        // Publisher of the book
        public string Publisher { get; set; } = null!;

        // The year the book was published
        public int YearPublished { get; set; }

        // Number of pages in the book
        public int Pages { get; set; }

        // Language the book is written in
        public string Language { get; set; } = null!;
    }
}
