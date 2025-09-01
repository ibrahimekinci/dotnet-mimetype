using System;
using System.Text;

namespace MimeType.Infrastructure.FileSignatureCheckers
{
    /// <summary>
    /// Base utilities for file signature checkers, providing ASCII conversion.
    /// </summary>
    public abstract class BaseFileSignatureChecker
    {
        public static ReadOnlySpan<byte> AsciiBytes(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? ReadOnlySpan<byte>.Empty : Encoding.ASCII.GetBytes(value);
        }
    }
}
