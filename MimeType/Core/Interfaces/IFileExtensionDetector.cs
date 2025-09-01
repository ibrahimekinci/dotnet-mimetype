using System.Collections.Immutable;

namespace MimeType.Core.Interfaces
{
    public interface IFileExtensionDetector
    {
        /// <summary>
        /// Defines a contract for a service that detects file extensions.
        /// </summary>
        public ImmutableHashSet<string> Detect(string mimeType);
    }
}
