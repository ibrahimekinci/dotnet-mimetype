using MimeType.Core.Interfaces;
using System;
using System.Linq;

namespace MimeType.Infrastructure.FileSignatureCheckers.Image
{
    /// <summary>
    /// Checks AutoCAD DWG files: starts with "AC" followed by a version string (e.g., "1.40", "1002").
    /// </summary>
    public class DwgFileSignatureChecker : BaseFileSignatureChecker, IFileSignatureChecker
    {
        private static readonly byte[][] Versions = new byte[][]
        {
            new byte[] {0x31,0x2E,0x34,0x30}, // 1.40
            new byte[] {0x31,0x2E,0x35,0x30}, // 1.50
            new byte[] {0x32,0x2E,0x31,0x30}, // 2.10
            new byte[] {0x31,0x30,0x30,0x32}, // 1002
            new byte[] {0x31,0x30,0x30,0x33}, // 1003
            new byte[] {0x31,0x30,0x30,0x34}, // 1004
            new byte[] {0x31,0x30,0x30,0x36}, // 1006
            new byte[] {0x31,0x30,0x30,0x39}, // 1009
            new byte[] {0x31,0x30,0x31,0x32}, // 1012
            new byte[] {0x31,0x30,0x31,0x34}, // 1014
            new byte[] {0x31,0x30,0x31,0x35}, // 1015
            new byte[] {0x31,0x30,0x31,0x38}, // 1018
            new byte[] {0x31,0x30,0x32,0x31}, // 1021
            new byte[] {0x31,0x30,0x32,0x34}, // 1024
            new byte[] {0x31,0x30,0x33,0x32}, // 1032
        };

        public bool Is(byte[] fileBytes)
        {
            if (fileBytes == null || fileBytes.Length < 6) return false;

            var header = fileBytes.AsSpan(0, 6);

            if (!header.Slice(0, 2).SequenceEqual(new byte[] { 0x41, 0x43 })) return false;

            var versionBytes = header.Slice(2, 4);
            foreach (var v in Versions)
            {
                if (versionBytes.SequenceEqual(v))
                    return true;
            }

            return false;
        }
    }
}
