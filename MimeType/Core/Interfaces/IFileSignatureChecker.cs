namespace MimeType.Core.Interfaces
{
    /// <summary>
    /// Strategy interface for file signature detection.
    /// Implementations define how to validate raw bytes against a specific signature.
    /// </summary>
    public interface IFileSignatureChecker
    {
        bool Is(byte[] fileBytes);
    }
}
