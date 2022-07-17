using MimeType.FileSignatureChecker;
using MimeType.Models;

namespace MimeType.FileSignatures
{
    internal class DatabaseFileSignatures
    {
        // Sqlite matches an SQLite database file.
        public static FileSignature Sqlite = new FileSignature(new PrefixFileSignatureChecker(new byte[]
        {
            0x53, 0x51, 0x4c, 0x69, 0x74, 0x65, 0x20, 0x66,
            0x6f, 0x72, 0x6d, 0x61, 0x74, 0x20, 0x33, 0x00,
        }));

        // MsAccessAce matches Microsoft Access dababase file.
        public static FileSignature MsAccessAce = new FileSignature(new OffsetFileSignatureChecker(4, "Standard ACE DB"));

        // MsAccessMdb matches legacy Microsoft Access database file (JET, 2003 and earlier).
        public static FileSignature MsAccessMdb = new FileSignature(new OffsetFileSignatureChecker(4, "Standard Jet DB"));

    }
}
