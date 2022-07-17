using MimeType.Core;
using System.Linq;

namespace MimeType.FileSignatureChecker.Audio
{
    internal class QcpFileSignatureChecker : BaseFileSignatureChecker, IFileSignatureChecker
    {
        private readonly static uint _minByteLength = 12;
        private readonly static byte[]? _fileHeaderPart1Expected = ConvertToBytes("RIFF");
        private readonly static byte[]? _fileHeaderPart2Expected = ConvertToBytes("QLCM");
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
