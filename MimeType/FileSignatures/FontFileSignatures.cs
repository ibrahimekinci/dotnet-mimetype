using MimeType.FileSignatureChecker;
using MimeType.Models;

namespace MimeType.FileSignatures
{
    internal class FontFileSignatures
    {
        // Woff matches a Web Open Font Format file.
        public static FileSignature Woff = new FileSignature(new PrefixFileSignatureChecker("wOFF"));

        // Woff2 matches a Web Open Font Format version 2 file.
        public static FileSignature Woff2 = new FileSignature(new PrefixFileSignatureChecker("wOF2"));

        // Otf matches an OpenType font file.
        public static FileSignature Otf = new FileSignature(new PrefixFileSignatureChecker(new byte[] { 0x4F, 0x54, 0x54, 0x4F, 0x00 }));
    }
}
