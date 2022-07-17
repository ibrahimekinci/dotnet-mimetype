using MimeType.Core;
using System.Linq;

namespace MimeType.FileSignatureChecker.Video
{
    internal class MpegFileSignatureChecker : BaseFileSignatureChecker, IFileSignatureChecker
    {
        private readonly static uint _minByteLength = 3;
        private readonly static byte[]? _fileHeaderPart1Expected = new byte[] { 0x00, 0x00, 0x01 };
        public bool Is(byte[] raw)
        {
            if (raw != null && raw.Length > _minByteLength)
            {
                var fileHeaderPart1 = raw.Take(4).ToArray();

                if (BytesEqual(fileHeaderPart1, _fileHeaderPart1Expected) && raw[3] >= 0xB0 && raw[3] <= 0xBF)
                    return true;
            }

            return false;
        }
    }
}

