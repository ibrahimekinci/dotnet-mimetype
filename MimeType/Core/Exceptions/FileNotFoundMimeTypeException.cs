namespace MimeType.Core.Exceptions
{
    /// <summary>
    /// Exception thrown when a file or stream is invalid or not found for MIME type detection.
    /// </summary>
    public class FileNotFoundMimeTypeException : MimeTypeException
    {
        public FileNotFoundMimeTypeException(string message) : base(message) { }
        public FileNotFoundMimeTypeException() : base("Invalid or non-readable stream provided.") { }
    }
}
