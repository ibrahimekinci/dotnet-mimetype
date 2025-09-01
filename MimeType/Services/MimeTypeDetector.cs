using MimeType.Core.Interfaces;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace MimeType.Services
{
    public class MimeTypeDetector : IMimeTypeDetector
    {
        /// <summary>
        /// Detects MIME types based on file extensions.
        /// </summary>
        public ImmutableHashSet<string> Detect(string fileExtension)
        {
            if (!string.IsNullOrWhiteSpace(fileExtension))
            {
                fileExtension = fileExtension.Trim().ToLowerInvariant();
                var mimeTypes = BuiltInMimeTypes.MimeTypes.Where(ft => ft.Extensions.Any(x => x.Equals(fileExtension, StringComparison.OrdinalIgnoreCase)))?.Select(x => x.Mime)?.ToImmutableHashSet();
                if (mimeTypes != null && !mimeTypes.IsEmpty)
                    return mimeTypes;
            }
            return ImmutableHashSet<string>.Empty;
        }
    }
}
