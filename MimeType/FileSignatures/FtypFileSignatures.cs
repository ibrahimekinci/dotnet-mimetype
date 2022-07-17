using MimeType.FileSignatureChecker;
using MimeType.FileSignatureChecker.Ftyp;
using MimeType.Models;

namespace MimeType.FileSignatures
{
    internal class FtypFileSignatures
    {
        // AVIF matches an AV1 Image File Format still or animated.
        // Wikipedia page seems outdated listing image/avif-sequence for animations.
        // https://github.com/AOMediaCodec/av1-avif/issues/59
        public static FileSignature AVIF = new FileSignature(new FtypFileSignatureChecker("avif", "avis"));

        // Mp4 matches an MP4 file.
        public static FileSignature Mp4 = new FileSignature(new FtypFileSignatureChecker(
                                                                                         "avc1", "dash", "iso2", "iso3",
                                                                                         "iso4", "iso5", "iso6", "isom",
                                                                                         "mmp4", "mp41", "mp42", "mp4v",
                                                                                         "mp71", "MSNV", "NDAS", "NDSC",
                                                                                         "NSDC", "NSDH", "NDSM", "NDSP",
                                                                                         "NDSS", "NDXC", "NDXH", "NDXM",
                                                                                         "NDXP", "NDXS", "F4V ", "F4P "
                                                                                         ));

        // ThreeGP matches a 3GPP file.
        public static FileSignature ThreeGP = new FileSignature(new FtypFileSignatureChecker(
                                                                                             "3gp1", "3gp2", "3gp3", "3gp4",
                                                                                             "3gp5", "3gp6", "3gp7", "3gs7",
                                                                                             "3ge6", "3ge7", "3gg6"
                                                                                            ));

        // ThreeG2 matches a 3GPP2 file.
        public static FileSignature ThreeG2 = new FileSignature(new FtypFileSignatureChecker(
                                                                                             "3g24", "3g25", "3g26", "3g2a",
                                                                                             "3g2b", "3g2c", "KDDI"
                                                                                            ));

        // AMp4 matches an audio MP4 file.
        public static FileSignature AMp4 = new FileSignature(new FtypFileSignatureChecker(
                                                                                          // audio for Adobe Flash Player 9+
                                                                                          "F4A ", "F4B ",
                                                                                          // Apple iTunes AAC-LC (.M4A) Audio
                                                                                          "M4B ", "M4P ",
                                                                                          // MPEG-4 (.MP4) for SonyPSP
                                                                                          "MSNV",
                                                                                          // Nero Digital AAC Audio
                                                                                          "NDAS"
                                                                                        ));

        // QuickTime matches a QuickTime File Format file.
        public static FileSignature QuickTime = new FileSignature(new OffsetFileSignatureChecker(8, 12, "\x00\x00\x00\x08wide"), new OffsetFileSignatureChecker(4, 12, "ftypqt  ", "ftypmoov", "moov\x00", "mdat\x00", "free\x00", "skip\x00", "pnot\x00"));

        // Mqv matches a Sony / Mobile QuickTime  file.
        public static FileSignature Mqv = new FileSignature(new FtypFileSignatureChecker("mqt "));

        // M4a matches an audio M4A file.
        public static FileSignature M4a = new FileSignature(new FtypFileSignatureChecker("M4A "));

        // M4v matches an Appl4 M4V video file.
        public static FileSignature M4v = new FileSignature(new FtypFileSignatureChecker("M4V ", "M4VH", "M4VP"));

        // Heic matches a High Efficiency Image Coding (HEIC) file.
        public static FileSignature Heic = new FileSignature(new FtypFileSignatureChecker("heic", "heix"));

        // HeicSequence matches a High Efficiency Image Coding (HEIC) file sequence.
        public static FileSignature HeicSequence = new FileSignature(new FtypFileSignatureChecker("hevc", "hevx"));

        // Heif matches a High Efficiency Image File Format (HEIF) file.
        public static FileSignature Heif = new FileSignature(new FtypFileSignatureChecker("mif1", "heim", "heis", "avic"));

        // HeifSequence matches a High Efficiency Image File Format (HEIF) file sequence.
        public static FileSignature HeifSequence = new FileSignature(new FtypFileSignatureChecker("msf1", "hevm", "hevs", "avcs"));
    }
}
