using MimeType.Core.Interfaces;
using System;
using System.Linq;
using System.Text;

namespace MimeType.Infrastructure.FileSignatureCheckers
{
    /// <summary>
    /// Checks if the file starts with any of the specified signatures.
    /// Respects a minimum byte length for template-based safety.
    /// Uses ReadOnlySpan for efficiency.
    /// </summary>
    public class PrefixFileSignatureChecker : BaseFileSignatureChecker, IFileSignatureChecker
    {
        private readonly byte[][] _signatures;
        private readonly int _minByteLength;

        public PrefixFileSignatureChecker(params byte[][] signatures)
        {
            _signatures = signatures ?? Array.Empty<byte[]>();
            _minByteLength = 0; // default
        }

        public PrefixFileSignatureChecker(int minByteLength, params byte[][] signatures)
        {
            _signatures = signatures ?? Array.Empty<byte[]>();
            _minByteLength = minByteLength;
        }

        public PrefixFileSignatureChecker(params string[] signatures)
        {
            _signatures = signatures?
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(Encoding.ASCII.GetBytes)
                .ToArray()
                ?? Array.Empty<byte[]>();
            _minByteLength = 0;
        }

        public PrefixFileSignatureChecker(int minByteLength, params string[] signatures)
        {
            _signatures = signatures?
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(Encoding.ASCII.GetBytes)
                .ToArray()
                ?? Array.Empty<byte[]>();
            _minByteLength = minByteLength;
        }

        public bool Is(byte[] fileBytes)
        {
            if (fileBytes == null || fileBytes.Length < _minByteLength)
                return false;

            var span = fileBytes.AsSpan();
            foreach (var sig in _signatures)
            {
                if (sig.Length == 0 || span.Length < sig.Length) continue;
                if (span.Slice(0, sig.Length).SequenceEqual(sig)) return true;
            }

            return false;
        }
    }
}
