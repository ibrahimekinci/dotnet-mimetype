using MimeType.Core;
using System;
using System.Linq;

namespace MimeType.FileSignatureChecker.Ftyp
{
    internal class FtypFileSignatureChecker : BaseFileSignatureChecker, IFileSignatureChecker
    {
        private readonly uint _minByteLength = 12;
        private readonly byte[][] _fileHeadersPart2;
        private readonly static byte[]? _fileHeaderPart1Expected = ConvertToBytes("ftyp");
        public FtypFileSignatureChecker(params byte[][] signatures)
        {
            if (signatures == null || signatures.Length == 0)
                throw new Exception("signatures cannot is empty");

            _fileHeadersPart2 = signatures;
        }
        public FtypFileSignatureChecker(params string[] signatures)
        {
            if (signatures == null || signatures.Length == 0)
                throw new Exception("signatures cannot is empty");

            _fileHeadersPart2 = signatures.Select(x => ConvertToBytes(x)).Where(x => x != null && x.Length > 0).ToArray();
        }
        public bool Is(byte[] raw)
        {
            if (raw != null && raw.Length > _minByteLength)
            {
                var fileHeaderPart1 = raw.Skip(4).Take(4).ToArray();
                var fileHeaderPart2 = raw.Skip(8).Take(4).ToArray();

                if (BytesEqual(fileHeaderPart1, _fileHeaderPart1Expected) &&
                    _fileHeadersPart2.Any(fileHeaderPart2Expected => BytesEqual(fileHeaderPart2, fileHeaderPart2Expected)))
                    return true;
            }

            return false;
        }
    }
}
