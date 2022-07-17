using MimeType.FileSignatureChecker;
using MimeType.Models;

namespace MimeType.FileSignatures
{
    internal class ArchiveFileSignatures
    {
        // SevenZ matches a 7z archive.
        public static FileSignature SevenZ = new FileSignature(new PrefixFileSignatureChecker(new byte[] { 0x37, 0x7A, 0xBC, 0xAF, 0x27, 0x1C }));

        // Gzip matches gzip files based on http://www.zlib.org/rfc-gzip.html#header-trailer.
        public static FileSignature Gzip = new FileSignature(new PrefixFileSignatureChecker(new byte[] { 0x1f, 0x8b }));

        // Fits matches an Flexible Image Transport System file.
        public static FileSignature Fits = new FileSignature(new PrefixFileSignatureChecker(new byte[]
        {
          0x53, 0x49, 0x4D, 0x50, 0x4C, 0x45, 0x20, 0x20, 0x3D, 0x20,
          0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20,
          0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x54,
        }));

        // Xar matches an eXtensible ARchive format file.
        public static FileSignature Xar = new FileSignature(new PrefixFileSignatureChecker(new byte[] { 0x78, 0x61, 0x72, 0x21 }));

        // Bz2 matches a bzip2 file.
        public static FileSignature Bz2 = new FileSignature(new PrefixFileSignatureChecker(new byte[] { 0x42, 0x5A, 0x68 }));

        // Ar matches an ar (Unix) archive file.
        public static FileSignature Ar = new FileSignature(new PrefixFileSignatureChecker(new byte[] { 0x21, 0x3C, 0x61, 0x72, 0x63, 0x68, 0x3E }));

        // Deb matches a Debian package file.
        public static FileSignature Deb = new FileSignature(new OffsetFileSignatureChecker(8, new byte[]
        {
        0x64, 0x65, 0x62, 0x69, 0x61, 0x6E, 0x2D,
        0x62, 0x69, 0x6E, 0x61, 0x72, 0x79,
        }));

        // Warc matches a Web ARChive file.
        public static FileSignature Warc = new FileSignature(new PrefixFileSignatureChecker("WARC/1.0", "WARC/1.1"));

        // Cab matches a Cabinet archive file.
        public static FileSignature Cab = new FileSignature(new PrefixFileSignatureChecker("MSCF\x00\x00\x00\x00"));

        // Xz matches an xz compressed stream based on https://tukaani.org/xz/xz-file-format.txt.
        public static FileSignature Xz = new FileSignature(new PrefixFileSignatureChecker(new byte[] { 0xFD, 0x37, 0x7A, 0x58, 0x5A, 0x00 }));

        // Lzip matches an Lzip compressed file.
        public static FileSignature Lzip = new FileSignature(new PrefixFileSignatureChecker(new byte[] { 0x4c, 0x5a, 0x49, 0x50 }));

        // RPM matches an RPM or Delta RPM package file.
        public static FileSignature RPM = new FileSignature(new PrefixFileSignatureChecker("drpm"), new PrefixFileSignatureChecker(new byte[] { 0xed, 0xab, 0xee, 0xdb }));

        // Cpio matches a cpio archive file.
        public static FileSignature Cpio = new FileSignature(new PrefixFileSignatureChecker("070707", "070701", "070702"));

        // RAR matches a RAR archive file.
        public static FileSignature RAR = new FileSignature(new PrefixFileSignatureChecker("Rar!\x1A\x07\x00", "Rar!\x1A\x07\x01\x00"));
    }
}
