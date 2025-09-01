using MimeType.Core.Interfaces;
using System;
using System.Linq;

namespace MimeType.Infrastructure.FileSignatureCheckers.Image
{
    /// <summary>
    /// Checks WebP files: starts with "RIFF" followed by "WEBP" at offset 8.
    /// </summary>
    public class WebpFileSignatureChecker : BaseFileSignatureChecker, IFileSignatureChecker
    {
        private static readonly byte[] RiffMagic = { 0x52, 0x49, 0x46, 0x46 }; // "RIFF"
        private static readonly byte[] WebpMagic = { 0x57, 0x45, 0x42, 0x50 }; // "WEBP"

        public bool Is(byte[] fileBytes)
        {
            if (fileBytes == null || fileBytes.Length < 12)
                return false;

            var span = new ReadOnlySpan<byte>(fileBytes);

            if (!span.Slice(0, 4).SequenceEqual(RiffMagic))
                return false;

            return span.Slice(8, 4).SequenceEqual(WebpMagic);
        }
    }
}
