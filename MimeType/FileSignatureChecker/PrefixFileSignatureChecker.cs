using MimeType.Core;
using System.Linq;
using System.Text;

namespace MimeType.FileSignatureChecker
{
    internal class PrefixFileSignatureChecker : BaseFileSignatureChecker, IFileSignatureChecker
    {
        private readonly byte[][] _signatures;
        private readonly uint _minByteLength;
        public PrefixFileSignatureChecker(params byte[][] signatures)
        {
            _signatures = signatures;
        }
        public PrefixFileSignatureChecker(params string[] signatures)
        {
            if (signatures != null && signatures.Length > 0)
                _signatures = signatures.Select(x => ConvertToBytes(x)).Where(x => x != null && x.Length > 0).ToArray();
        }
        public PrefixFileSignatureChecker(uint minByteLength, params byte[][] signatures)
        {
            _minByteLength = minByteLength;
            _signatures = signatures;
        }
        public PrefixFileSignatureChecker(uint minByteLength, params string[] signatures)
        {
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
                    if (signature?.Length > 0 && raw.Length > signature.Length)
                    {
                        var fileHeader = raw.Take(signature.Length).ToArray();
                        if (BytesEqual(signature, fileHeader))
                            return true;
                    }
                }
            }

            return false;
        }
    }
}
