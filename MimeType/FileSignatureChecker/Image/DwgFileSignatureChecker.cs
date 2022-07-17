using MimeType.Core;
using System.Linq;

namespace MimeType.FileSignatureChecker.Image
{
    internal class DwgFileSignatureChecker : BaseFileSignatureChecker, IFileSignatureChecker
    {
        private readonly static uint _minByteLength = 5;
        private readonly static byte[] _fileHeaderPart1Expected = new byte[] { 0x41, 0x43 };
        private readonly static byte[][] _dwgVersions = new byte[][]
        {
          new byte[] {0x31, 0x2E, 0x34, 0x30},
          new byte[]  {0x31, 0x2E, 0x35, 0x30},
          new byte[]  {0x32, 0x2E, 0x31, 0x30},
          new byte[]  {0x31, 0x30, 0x30, 0x32},
          new byte[]  {0x31, 0x30, 0x30, 0x33},
          new byte[]  {0x31, 0x30, 0x30, 0x34},
          new byte[]  {0x31, 0x30, 0x30, 0x36},
          new byte[]  {0x31, 0x30, 0x30, 0x39},
          new byte[]  {0x31, 0x30, 0x31, 0x32},
          new byte[]  {0x31, 0x30, 0x31, 0x34},
          new byte[]  {0x31, 0x30, 0x31, 0x35},
          new byte[]  {0x31, 0x30, 0x31, 0x38},
          new byte[]  {0x31, 0x30, 0x32, 0x31},
          new byte[]  {0x31, 0x30, 0x32, 0x34},
          new byte[]  {0x31, 0x30, 0x33, 0x32},
        };
        public bool Is(byte[] raw)
        {
            if (raw?.Length > _minByteLength)
            {
                var fileHeaderPart1 = raw.Skip(0).Take(2).ToArray();
                if (BytesEqual(fileHeaderPart1, _fileHeaderPart1Expected))
                {
                    var fileHeaderPart2 = raw.Skip(2).Take(4).ToArray();
                    for (int i = 0; i < _dwgVersions.Length; i++)
                    {
                        if (BytesEqual(fileHeaderPart2, _dwgVersions[i]))
                            return true;
                    }
                }
            }

            return false;
        }
    }
}
