namespace MimeType.Core.Interfaces
{
    using System.Collections.Immutable;

    /// <summary>
    /// Defines a contract for a service that detects MIME types.
    /// </summary>
    public interface IMimeTypeDetector
    {
        ImmutableHashSet<string> Detect(string fileExtension);
    }
}