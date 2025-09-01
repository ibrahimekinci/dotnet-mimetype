using MimeType.Core.Interfaces;
using System;
using System.Linq;
using System.Text;

namespace MimeType.Infrastructure.FileSignatureCheckers
{
    /// <summary>
    /// Checks for a signature at a specific offset in the file bytes.
    /// Respects minimum byte length for template-based safety.
    /// Uses ReadOnlySpan for efficiency.
    /// </summary>
    public sealed class OffsetFileSignatureChecker : BaseFileSignatureChecker, IFileSignatureChecker
    {
        private readonly int _offset;
        private readonly int _minByteLength;
        private readonly byte[][] _signatures;

        public OffsetFileSignatureChecker(int offset, params byte[][] signatures)
        {
            _offset = offset;
            _signatures = signatures ?? Array.Empty<byte[]>();
            _minByteLength = 0;
        }

        public OffsetFileSignatureChecker(int offset, int minByteLength, params byte[][] signatures)
        {
            _offset = offset;
            _signatures = signatures ?? Array.Empty<byte[]>();
            _minByteLength = minByteLength;
        }

        public OffsetFileSignatureChecker(int offset, params string[] signatures)
        {
            _offset = offset;
            _signatures = signatures?
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(Encoding.ASCII.GetBytes)
                .ToArray()
                ?? Array.Empty<byte[]>();
            _minByteLength = 0;
        }

        public OffsetFileSignatureChecker(int offset, int minByteLength, params string[] signatures)
        {
            _offset = offset;
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
                if (sig.Length == 0 || span.Length < sig.Length + _offset) continue;

                if (span.Slice(_offset, sig.Length).SequenceEqual(sig))
                    return true;
            }

            return false;
        }
    }
}