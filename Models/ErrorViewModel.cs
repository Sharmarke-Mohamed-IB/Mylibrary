namespace MyLibrary.Models
{
    public class ErrorViewModel
    {
        // This holds the unique request ID for the error, can be null
        public string? RequestId { get; set; }

        // This returns true if the RequestId has a value, otherwise false
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
