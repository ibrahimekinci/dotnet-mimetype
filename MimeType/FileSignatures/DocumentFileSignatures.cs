using MimeType.FileSignatureChecker;
using MimeType.Models;

namespace MimeType.FileSignatures
{
    internal class DocumentFileSignatures
    {
        // Pdf matches a Portable Document Format file.
        public static FileSignature Pdf = new FileSignature(new PrefixFileSignatureChecker("%PDF-"), new PrefixFileSignatureChecker("\012%PDF-"), new PrefixFileSignatureChecker("\xef\xbb\xbf%PDF-"));

        // Fdf matches a Forms Data Format file.
        public static FileSignature Fdf = new FileSignature(new PrefixFileSignatureChecker("%FDF"));

        // Mobi matches a Mobi file.
        public static FileSignature Mobi = new FileSignature(new OffsetFileSignatureChecker(60, "BOOKMOBI"));

        // Lit matches a Microsoft Lit file.
        public static FileSignature Lit = new FileSignature(new PrefixFileSignatureChecker("ITOLITLS"));

    }
}
