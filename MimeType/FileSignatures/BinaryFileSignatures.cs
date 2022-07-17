using MimeType.FileSignatureChecker;
using MimeType.Models;

namespace MimeType.FileSignatures
{
    internal class BinaryFileSignatures
    {
        // Lnk matches Microsoft lnk binary format.
        public static FileSignature Lnk = new FileSignature(new PrefixFileSignatureChecker(new byte[] { 0x4C, 0x00, 0x00, 0x00, 0x01, 0x14, 0x02, 0x00 }));

        // Wasm matches a web assembly File Format file.
        public static FileSignature Wasm = new FileSignature(new PrefixFileSignatureChecker(new byte[] { 0x00, 0x61, 0x73, 0x6D }));

        // Exe matches a Windows/DOS executable file.
        public static FileSignature Exe = new FileSignature(new PrefixFileSignatureChecker(new byte[] { 0x4D, 0x5A }));

        // Elf matches an Executable and Linkable Format file.
        public static FileSignature Elf = new FileSignature(new PrefixFileSignatureChecker(new byte[] { 0x7F, 0x45, 0x4C, 0x46 }));

        // Nes matches a Nintendo Entertainment system ROM file.
        public static FileSignature Nes = new FileSignature(new PrefixFileSignatureChecker(new byte[] { 0x4E, 0x45, 0x53, 0x1A }));

        // SWF matches an Adobe Flash swf file.
        public static FileSignature SWF = new FileSignature(new PrefixFileSignatureChecker("CWS", "FWS", "ZWS"));

        // Torrent has bencoded text in the beginning.
        public static FileSignature Torrent = new FileSignature(new PrefixFileSignatureChecker("d8:announce"));
    }
}
