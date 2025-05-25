using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Data;
using MyLibrary.Models;
using System.Threading.Tasks;

namespace MyLibrary.Controllers
{
    public class BooksController : Controller
    {
        // This is the database context to interact with the Books table
        private readonly LibraryContext _context;

        // Constructor to initialize the context via dependency injection
        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: /Books/
        // This method returns the list of all books to the view
        public async Task<IActionResult> Index()
        {
            var books = await _context.Books.ToListAsync(); // Fetch all books from the database
            return View(books); // Pass the list to the view
        }

        // GET: /Books/Details/5
        // This method shows detailed information for a specific book
        public async Task<IActionResult> Details(int id)
        {
            // Try to find the book with the given ID
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);

            // If book is not found, return a 404 page
            if (book == null)
                return NotFound();

            // If found, display the details view for the book
            return View(book);
        }
    }
}
