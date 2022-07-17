using MimeType.Core;
using System.Linq;

namespace MimeType.FileSignatureChecker.Zip
{
    internal class ZipFileSignatureChecker : BaseFileSignatureChecker, IFileSignatureChecker
    {
        private readonly static uint _minByteLength = 3;
        public bool Is(byte[] raw)
        {
            if (raw != null && raw.Length > _minByteLength)
            {
                if (raw[0] == 0x50 && raw[1] == 0x4B &&
                    (raw[2] == 0x3 || raw[2] == 0x5 || raw[2] == 0x7) &&
                    (raw[3] == 0x4 || raw[3] == 0x6 || raw[3] == 0x8))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

