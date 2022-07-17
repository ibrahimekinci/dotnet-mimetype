using MimeType.Core;
using System.Linq;
using System.Text;

namespace MimeType.FileSignatureChecker.Image
{
    internal class WebpFileSignatureChecker : BaseFileSignatureChecker, IFileSignatureChecker
    {
        private readonly static uint _minByteLength = 12;
        private readonly static byte[]? _fileHeaderPart1Expected = ConvertToBytes("RIFF");
        private readonly static byte[] _fileHeaderPart2Expected = new byte[] { 0x57, 0x45, 0x42, 0x50 };
        public bool Is(byte[] raw)
        {
            if (raw?.Length > _minByteLength)
            {
                var fileHeaderPart1 = raw.Take(4).ToArray();
                if (BytesEqual(fileHeaderPart1, _fileHeaderPart1Expected))
                {
                    var fileHeaderPart2 = raw.Skip(8).Take(4).ToArray();
                    if (BytesEqual(fileHeaderPart2, _fileHeaderPart2Expected))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
