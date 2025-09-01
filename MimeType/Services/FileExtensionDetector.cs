using MimeType.Core.Interfaces;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace MimeType.Services
{
    /// <summary>
    /// Detects file extensions based on a given MIME type.
    /// </summary>
    public class FileExtensionDetector : IFileExtensionDetector
    {
        public ImmutableHashSet<string> Detect(string mimeType)
        {
            if (!string.IsNullOrWhiteSpace(mimeType))
            {
                var mimeTypeModel = BuiltInMimeTypes.MimeTypes.FirstOrDefault(ft => ft.Mime.Equals(mimeType, StringComparison.OrdinalIgnoreCase));
                if (mimeTypeModel != null)
                    return mimeTypeModel.Extensions;
            }
            return ImmutableHashSet<string>.Empty;
        }
    }
}
