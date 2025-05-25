using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Models;
using MyLibrary.Data;

namespace MyLibrary.Controllers
{
    public class HomeController : Controller
    {
        // Logger for debugging and logging info
        private readonly ILogger<HomeController> _logger;

        // Database context to access ContactMessages or other data
        private readonly LibraryContext _context;

        // Constructor to initialize logger and database context
        public HomeController(ILogger<HomeController> logger, LibraryContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Home page
        public IActionResult Index()
        {
            return View();
        }

        // About page
        public IActionResult About()
        {
            return View();
        }

        // GET: Contact page form
        public IActionResult Contact()
        {
            return View();
        }

        // POST: Handles submitted contact form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(ContactMessage model)
        {
            // Check if form data is valid
            if (ModelState.IsValid)
            {
                // Save contact message to the database
                _context.ContactMessages.Add(model);
                _context.SaveChanges();

                // Show a success message after saving
                ViewBag.Message = "Thank you for contacting us!";
                return View();
            }

            // If there are validation errors, return the form with entered data
            return View(model);
        }

        // Privacy policy page
        public IActionResult Privacy()
        {
            return View();
        }

        // Error page for unexpected exceptions
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel 
            { 
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
            });
        }
    }
}
