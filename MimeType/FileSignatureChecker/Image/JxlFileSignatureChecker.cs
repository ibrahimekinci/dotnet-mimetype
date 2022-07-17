using MimeType.Core;
using System.Linq;
using System.Text;

namespace MimeType.FileSignatureChecker.Image
{
    internal class JxlFileSignatureChecker : BaseFileSignatureChecker, IFileSignatureChecker
    {
        private readonly static byte[] _fileHeaderPart1Expected = new byte[] { 0xFF, 0x0A };
        private readonly static byte[]? _fileHeaderPart2Expected = ConvertToBytes("\x00\x00\x00\x0cJXL\x20\x0d\x0a\x87\x0a");
        public bool Is(byte[] raw)
        {
            if (raw?.Length > 2)
            {
                var fileHeaderPart1 = raw.Skip(0).Take(2).ToArray();
                if (BytesEqual(fileHeaderPart1, _fileHeaderPart1Expected))
                {
                    return true;
                }
            }

            if (raw?.Length > 6)
            {
                var fileHeaderPart2 = raw.Skip(0).Take(2).ToArray();
                if (BytesEqual(fileHeaderPart2, _fileHeaderPart2Expected))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
