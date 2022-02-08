using MimeType.Core;
using System.Linq;
using System.Text;

namespace MimeType.FileSignatureChecker.Image
{
    internal class WebpFileSignatureChecker : BaseFileSignatureChecker, IFileSignatureChecker
    {
        public bool Is(byte[] raw)
        {
            if (raw?.Length > 12)
            {
                var fileHeaderPart1 = raw.Take(4).ToArray();
                if (BytesEqual(fileHeaderPart1, ConvertToBytes("RIFF")))
                {
                    var fileHeaderPart2 = raw.Skip(8).Take(4).ToArray();
                    if (BytesEqual(fileHeaderPart2, new byte[] { 0x57, 0x45, 0x42, 0x50 }))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
