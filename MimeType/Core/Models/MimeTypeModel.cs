using System.Collections.Immutable;

namespace MimeType.Core.Models
{
    /// <summary>
    /// Represents a MIME type with its associated file extensions.
    /// Used for extension-to-MIME mapping without signature detection.
    /// </summary>
    public record class MimeTypeModel(string mime, params string[] extensions)
    {
        public string Mime { get; set; } = mime;
        public ImmutableHashSet<string> Extensions { get; set; } = [.. extensions];
    }
}
