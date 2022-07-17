using MimeType.Core;
using System.Linq;

namespace MimeType.FileSignatureChecker.Audio
{
    internal class AiffFileSignatureChecker : BaseFileSignatureChecker, IFileSignatureChecker
    {
        private readonly static uint _minByteLength = 12;
        private readonly static byte[] _fileHeaderPart1Expected = new byte[] { 0x46, 0x4F, 0x52, 0x4D };
        private readonly static byte[] _fileHeaderPart2Expected = new byte[] { 0x41, 0x49, 0x46, 0x46 };
        public bool Is(byte[] raw)
        {
            if (raw != null && raw.Length > _minByteLength)
            {
                var fileHeaderPart1 = raw.Take(4).ToArray();
                var fileHeaderPart2 = raw.Skip(8).Take(4).ToArray();

                if (BytesEqual(fileHeaderPart1, _fileHeaderPart1Expected) && BytesEqual(fileHeaderPart2, _fileHeaderPart2Expected))
                    return true;
            }
            return false;
        }
    }
}
