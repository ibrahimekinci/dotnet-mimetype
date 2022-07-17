using MimeType.Core;
using System;
using System.Linq;
using System.Text;

namespace MimeType.FileSignatureChecker.Image
{
    internal class Jpeg2kFileSignatureChecker : BaseFileSignatureChecker, IFileSignatureChecker
    {
        private readonly static uint _minByteLength = 24;
        private readonly static byte[][] _fileHeadersPart1Expected = new byte[][] { new byte[] { 0x6A, 0x50, 0x20, 0x20 }, new byte[] { 0x6A, 0x50, 0x32, 0x20 } };
        private byte[][] _signatures { get; set; }
        public Jpeg2kFileSignatureChecker(params byte[][] signatures)
        {
            if (signatures == null || signatures.Length == 0)
                throw new Exception("signatures cannot is empty");

            _signatures = signatures;
        }
        public Jpeg2kFileSignatureChecker(params string[] signatures)
        {
            if (signatures == null || signatures.Length == 0)
                throw new Exception("signatures cannot is empty");

            _signatures = signatures.Select(x => ConvertToBytes(x)).Where(x => x != null && x.Length > 0).ToArray();
        }

        public bool Is(byte[] raw)
        {
            if (raw?.Length > _minByteLength)
            {
                var fileHeaderPart1 = raw.Skip(4).Take(4).ToArray();
                if (_fileHeadersPart1Expected.Any(fileHeaderPart1Expected => BytesEqual(fileHeaderPart1, fileHeaderPart1Expected)))
                {
                    foreach (var signature in _signatures)
                    {
                        if (signature?.Length > 0 && raw.Length > signature.Length)
                        {
                            var fileHeaderPart2 = raw.Skip(20).Take(4).ToArray();
                            if (BytesEqual(signature, fileHeaderPart2))
                                return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
