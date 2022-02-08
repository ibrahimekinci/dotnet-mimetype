using MimeType.Core;
using System.Linq;
using System.Text;

namespace MimeType.FileSignatureChecker.Image
{
    internal class JxlFileSignatureChecker : BaseFileSignatureChecker, IFileSignatureChecker
    {
        public bool Is(byte[] raw)
        {
            if (raw?.Length > 2)
            {
                var fileHeaderPart1 = raw.Skip(0).Take(2).ToArray();
                if (BytesEqual(fileHeaderPart1, new byte[] { 0xFF, 0x0A }))
                {
                    return true;
                }
            }

            if (raw?.Length > 6)
            {
                var fileHeaderPart2 = raw.Skip(0).Take(2).ToArray();
                if (BytesEqual(fileHeaderPart2, ConvertToBytes("\x00\x00\x00\x0cJXL\x20\x0d\x0a\x87\x0a")))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
