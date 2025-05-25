using Microsoft.AspNetCore.Mvc;
using MyLibrary.Data;
using MyLibrary.Models;
using System.Security.Cryptography;
using System.Text;

namespace MyLibrary.Controllers
{
    public class AccountController : Controller
    {
        // Bring in the database context so we can access user data
        private readonly LibraryContext _context;

        // Constructor to initialize the context
        public AccountController(LibraryContext context)
        {
            _context = context;
        }

        // Display the Register page
        public IActionResult Register()
        {
            return View();
        }

        // Handle user registration form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(string username, string password)
        {
            // Check if username or password is missing
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Please enter username and password.";
                return View();
            }

            // Check if the username already exists
            if (_context.Users.Any(u => u.Username == username))
            {
                ViewBag.Error = "Username already exists.";
                return View();
            }

            // Create a new user and hash their password
            var user = new User
            {
                Username = username,
                PasswordHash = ComputeSha256Hash(password)
            };

            // Save the user to the database
            _context.Users.Add(user);
            _context.SaveChanges();

            // Notify success and redirect to login page
            TempData["Success"] = "Registration successful. Please login.";
            return RedirectToAction("Login");
        }

        // Show the Login page
        public IActionResult Login()
        {
            return View();
        }

        // Handle login form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string username, string password)
        {
            // Hash the input password to compare with database
            var hash = ComputeSha256Hash(password);

            // Try to find the user with matching username and hashed password
            var user = _context.Users.SingleOrDefault(u => u.Username == username && u.PasswordHash == hash);

            // If no user found, show error
            if (user == null)
            {
                ViewBag.Error = "Invalid username or password.";
                return View();
            }

            // If login is successful, store user info in session
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("Username", user.Username);

            // Redirect to homepage after successful login
            return RedirectToAction("Index", "Home");
        }

        // Log out the user by clearing session
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        // Helper method to hash passwords using SHA256
        private string ComputeSha256Hash(string rawData)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                var builder = new StringBuilder();

                // Convert hash byte array to hexadecimal string
                foreach (var b in bytes)
                    builder.Append(b.ToString("x2"));

                return builder.ToString();
            }
        }
    }
}
