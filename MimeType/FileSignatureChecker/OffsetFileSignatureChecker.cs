using MimeType.Core;
using System.Linq;
using System.Text;

namespace MimeType.FileSignatureChecker
{
    internal class OffsetFileSignatureChecker : BaseFileSignatureChecker, IFileSignatureChecker
    {
        private readonly uint _offset;
        private readonly uint _minByteLength;
        private byte[][] _signatures { get; set; }
        public OffsetFileSignatureChecker(uint offset, params byte[][] signatures)
        {
            _offset = offset;
            _signatures = signatures;
        }
        public OffsetFileSignatureChecker(uint offset, params string[] signatures)
        {
            _offset = offset;
            if (signatures != null && signatures.Length > 0)
                _signatures = signatures.Select(x => ConvertToBytes(x)).Where(x => x != null && x.Length > 0).ToArray();
        }
        public OffsetFileSignatureChecker(uint offset, uint minByteLength, params byte[][] signatures)
        {
            _offset = offset;
            _minByteLength = minByteLength;
            _signatures = signatures;
        }
        public OffsetFileSignatureChecker(uint offset, uint minByteLength, params string[] signatures)
        {
            _offset = offset;
            _minByteLength = minByteLength;
            if (signatures != null && signatures.Length > 0)
                _signatures = signatures.Select(x => ConvertToBytes(x)).Where(x => x != null && x.Length > 0).ToArray();
        }
        public bool Is(byte[] raw)
        {
            if (raw?.Length > 0 && raw?.Length > _minByteLength)
            {
                foreach (var signature in _signatures)
                {
                    if (signature?.Length > 0 && raw.Length > signature.Length + _offset)
                    {
                        var fileHeader = raw.Skip((int)_offset).Take(signature.Length).ToArray();
                        if (BytesEqual(signature, fileHeader))
                            return true;
                    }
                }
            }

            return false;
        }
    }
}

