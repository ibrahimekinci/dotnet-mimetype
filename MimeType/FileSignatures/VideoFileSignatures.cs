using MimeType.FileSignatureChecker;
using MimeType.FileSignatureChecker.Video;
using MimeType.Models;

namespace MimeType.FileSignatures
{
    internal class VideoFileSignatures
    {
        // Flv matches a Flash video file.
        public static FileSignature Flv = new FileSignature(new PrefixFileSignatureChecker("\x46\x4C\x56\x01"));

        // Asf matches an Advanced Systems Format file.
        public static FileSignature Asf = new FileSignature(new PrefixFileSignatureChecker(new byte[]
        {
            0x30, 0x26, 0xB2, 0x75, 0x8E, 0x66, 0xCF, 0x11,
            0xA6, 0xD9, 0x00, 0xAA, 0x00, 0x62, 0xCE, 0x6C,
        }));

        // Rmvb matches a RealMedia Variable Bitrate file.
        public static FileSignature Rmvb = new FileSignature(new PrefixFileSignatureChecker(new byte[] { 0x2E, 0x52, 0x4D, 0x46 }));

        // Mpeg matches a Moving Picture Experts Group file.
        public static FileSignature Mpeg = new FileSignature(new MpegFileSignatureChecker());

        // Avi matches an Audio Video Interleaved file.
        public static FileSignature Avi = new FileSignature(new AviFileSignatureChecker());

    }
}
