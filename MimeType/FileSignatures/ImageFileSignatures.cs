using MimeType.FileSignatureChecker;
using MimeType.FileSignatureChecker.Image;
using MimeType.Models;

namespace MimeType.FileSignatures
{
    internal class ImageFileSignatures
    {
        // Png matches a Portable Network Graphics file.
        public static FileSignature Png = new FileSignature(new PrefixFileSignatureChecker(new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }));

        // Apng matches an Animated Portable Network Graphics file.
        // https://wiki.mozilla.org/APNG_Specification
        public static FileSignature Apng = new FileSignature(new OffsetFileSignatureChecker(37,"acTL"));

        // Jpg matches a Joint Photographic Experts Group file.
        public static FileSignature Jpg = new FileSignature(new PrefixFileSignatureChecker(new byte[] { 0xFF, 0xD8, 0xFF }));

        // Jp2 matches a JPEG 2000 Image file (ISO 15444-1).
        public static FileSignature Jp2 = new FileSignature(new Jpeg2kFileSignatureChecker(new byte[] { 0x6a, 0x70, 0x32, 0x20 }));

        // Jpx matches a JPEG 2000 Image file (ISO 15444-2).
        public static FileSignature Jpx = new FileSignature(new Jpeg2kFileSignatureChecker(new byte[] { 0x6a, 0x70, 0x78, 0x20 }));

        // Jpm matches a JPEG 2000 Image file (ISO 15444-6).
        public static FileSignature Jpm = new FileSignature(new Jpeg2kFileSignatureChecker(new byte[] { 0x6a, 0x70, 0x6D, 0x20 }));

        // Gif matches a Graphics Interchange Format file.
        public static FileSignature Gif = new FileSignature(new PrefixFileSignatureChecker("GIF87a", "GIF89a"));

        // Bmp matches a bitmap image file.
        public static FileSignature Bmp = new FileSignature(new PrefixFileSignatureChecker(new byte[] { 0x42, 0x4D }));

        // Ps matches a PostScript file.
        public static FileSignature Ps = new FileSignature(new PrefixFileSignatureChecker("%!PS-Adobe-"));

        // Psd matches a Photoshop Document file.
        public static FileSignature Psd = new FileSignature(new PrefixFileSignatureChecker("8BPS"));

        // Ico matches an ICO file.
        public static FileSignature Ico = new FileSignature(new PrefixFileSignatureChecker(new byte[] { 0x00, 0x00, 0x01, 0x00 }, new byte[] { 0x00, 0x00, 0x02, 0x00 }));

        // Icns matches an ICNS (Apple Icon Image format) file.
        public static FileSignature Icns = new FileSignature(new PrefixFileSignatureChecker("icns"));

        // Tiff matches a Tagged Image File Format file.
        public static FileSignature Tiff = new FileSignature(new PrefixFileSignatureChecker(new byte[] { 0x49, 0x49, 0x2A, 0x00 }, new byte[] { 0x4D, 0x4D, 0x00, 0x2A }));

        // Bpg matches a Better Portable Graphics file.
        public static FileSignature Bpg = new FileSignature(new PrefixFileSignatureChecker(new byte[] { 0x42, 0x50, 0x47, 0xFB }));

        // Xcf matches GIMP image data.
        public static FileSignature Xcf = new FileSignature(new PrefixFileSignatureChecker("gimp xcf"));

        // Pat matches GIMP pattern data.
        public static FileSignature Pat = new FileSignature(new OffsetFileSignatureChecker(20, "GPAT"));

        // Gbr matches GIMP brush data.
        public static FileSignature Gbr = new FileSignature(new OffsetFileSignatureChecker(20, "GIMP"));

        // Hdr matches Radiance HDR image.
        // https://web.archive.org/web/20060913152809/http://local.wasp.uwa.edu.au/~pbourke/dataformats/pic/
        public static FileSignature Hdr = new FileSignature(new PrefixFileSignatureChecker("#?RADIANCE\n"));

        // Xpm matches X PixMap image data.
        public static FileSignature Xpm = new FileSignature(new PrefixFileSignatureChecker(new byte[] { 0x2F, 0x2A, 0x20, 0x58, 0x50, 0x4D, 0x20, 0x2A, 0x2F }));

        // Webp matches a WebP file.
        public static FileSignature Webp = new FileSignature(new WebpFileSignatureChecker());

        // Dwg matches a CAD drawing file.
        public static FileSignature Dwg = new FileSignature(new DwgFileSignatureChecker());

        // Jxl matches JPEG XL image file.
        public static FileSignature Jxl = new FileSignature(new JxlFileSignatureChecker());

    }
}
