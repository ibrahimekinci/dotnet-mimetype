using System.Collections.Immutable;

namespace MimeType.Core.Models
{
    /// <summary>
    /// Describes a file type with its signature, MIME type, and associated extensions.
    /// </summary>
    public record FileTypeModel(FileSignatureModel signature, string mime, params string[] extensions)
    {
        public string Mime { get; set; } = mime;
        public ImmutableHashSet<string> Extensions { get; set; } = [.. extensions];
        public bool Is(byte[] fileBytes) => signature.Is(fileBytes);
    }
}
