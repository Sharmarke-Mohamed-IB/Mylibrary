using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Models
{
    public class User
    {
        // Unique ID for each user
        public int Id { get; set; }

        // Username is required and limited to max 50 characters
        [Required, StringLength(50)]
        public string Username { get; set; } = null!;

        // Store the hashed password; mark as password type for forms
        [Required, DataType(DataType.Password)]
        public string PasswordHash { get; set; } = null!;
    }
}
