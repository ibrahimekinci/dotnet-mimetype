using MimeType.Core.Interfaces;
using System;

namespace MimeType.Infrastructure.FileSignatureCheckers.Image
{
    /// <summary>
    /// Checks JPEG XL files: either raw codestream (0xFF 0x0A) or container (12-byte signature).
    /// </summary>
    public class JxlFileSignatureChecker : BaseFileSignatureChecker, IFileSignatureChecker
    {
        private static readonly byte[] ContainerMagic =
        {
         0x00,0x00,0x00,0x0C,0x4A,0x58,0x4C,0x20,0x0D,0x0A,0x87,0x0A
        };

        public bool Is(byte[] fileBytes)
        {
            if (fileBytes == null || fileBytes.Length < 2)
                return false;

            // Check raw codestream
            if (fileBytes[0] == 0xFF && fileBytes[1] == 0x0A)
                return true;

            // Check container magic using ReadOnlySpan
            if (fileBytes.Length >= ContainerMagic.Length)
            {
                var span = new ReadOnlySpan<byte>(fileBytes, 0, ContainerMagic.Length);
                return span.SequenceEqual(ContainerMagic);
            }

            return false;
        }
    }
}
