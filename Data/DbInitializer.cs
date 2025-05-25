using MyLibrary.Models;

namespace MyLibrary.Data
{
    public static class DbInitializer
    {
        public static void Seed(LibraryContext db)
        {
            if (db.Books.Any()) return;

            var books = new List<Book>
            {
                // English  Books
                new Book
                {
                    Title = "The 48 Laws of Power",
                    Author = "Robert Greene",
                    Genre = "Self-help",
                    CoverImageUrl = "/images/48laws.jpg",
                    Description = "A guide to power dynamics and strategies.",
                    Publisher = "Viking Press",
                    YearPublished = 1998,
                    Pages = 452,
                    Language = "English"
                },
                new Book
                {
                    Title = "Atomic Habits",
                    Author = "James Clear",
                    Genre = "Self-help",
                    CoverImageUrl = "/images/atomic_habits.jpg",
                    Description = "An easy & proven way to build good habits.",
                    Publisher = "Penguin",
                    YearPublished = 2018,
                    Pages = 320,
                    Language = "English"
                },
                new Book
                {
                    Title = "Rich Dad Poor Dad",
                    Author = "Robert Kiyosaki",
                    Genre = "Finance",
                    CoverImageUrl = "/images/richdad.jpg",
                    Description = "What the rich teach their kids about money.",
                    Publisher = "Warner Books",
                    YearPublished = 1997,
                    Pages = 336,
                    Language = "English"
                },
                new Book
                {
                    Title = "1984",
                    Author = "George Orwell",
                    Genre = "Dystopian",
                    CoverImageUrl = "/images/1984.jpg",
                    Description = "A dystopian tale of totalitarian control.",
                    Publisher = "Secker & Warburg",
                    YearPublished = 1949,
                    Pages = 328,
                    Language = "English"
                },
                new Book
                {
                    Title = "The Great Gatsby",
                    Author = "F. Scott Fitzgerald",
                    Genre = "Novel",
                    CoverImageUrl = "/images/gatsby.jpg",
                    Description = "A classic novel about the American Dream.",
                    Publisher = "Scribner",
                    YearPublished = 1925,
                    Pages = 180,
                    Language = "English"
                },

                // Turkish Books
                new Book
                {
                    Title = "Tutunamayanlar",
                    Author = "Oğuz Atay",
                    Genre = "Modern Literature",
                    CoverImageUrl = "/images/tutunamayanlar.jpg",
                    Description = "A masterpiece of Turkish literature.",
                    Publisher = "İletişim Yayınları",
                    YearPublished = 1971,
                    Pages = 724,
                    Language = "Turkish"
                },
                new Book
                {
                    Title = "İnce Memed",
                    Author = "Yaşar Kemal",
                    Genre = "Novel",
                    CoverImageUrl = "/images/incememed.jpg",
                    Description = "A legendary folk hero story.",
                    Publisher = "Yapı Kredi Yayınları",
                    YearPublished = 1955,
                    Pages = 430,
                    Language = "Turkish"
                },
                new Book
                {
                    Title = "Kürk Mantolu Madonna",
                    Author = "Sabahattin Ali",
                    Genre = "Romance",
                    CoverImageUrl = "/images/kurk.jpg",
                    Description = "A tragic love story.",
                    Publisher = "Yapı Kredi Yayınları",
                    YearPublished = 1943,
                    Pages = 160,
                    Language = "Turkish"
                },
                new Book
                {
                    Title = "Saatleri Ayarlama Enstitüsü",
                    Author = "Ahmet Hamdi Tanpınar",
                    Genre = "Satire",
                    CoverImageUrl = "/images/saat.jpg",
                    Description = "A satire on modernity and tradition.",
                    Publisher = "Dergah Yayınları",
                    YearPublished = 1961,
                    Pages = 390,
                    Language = "Turkish"
                },
                new Book
                {
                    Title = "Serenad",
                    Author = "Zülfü Livaneli",
                    Genre = "Historical Fiction",
                    CoverImageUrl = "/images/serenad.jpg",
                    Description = "A love story mixed with dark history.",
                    Publisher = "Doğan Kitap",
                    YearPublished = 2011,
                    Pages = 480,
                    Language = "Turkish"
                }
            };

            db.Books.AddRange(books);
            db.SaveChanges();
        }
    }
}
