using MimeType.Core.Models;
using MimeType.Infrastructure.FileSignatureCheckers;
using MimeType.Infrastructure.FileSignatureCheckers.Image;

namespace MimeType.Infrastructure.FileSignatures
{
    /// <summary>
    /// Provides predefined file signatures for common image formats.
    /// Used by BuiltInFileTypes to map extensions and MIME types.
    /// </summary>
    public static class ImageFileSignatures
    {
        public static readonly FileSignatureModel Bmp =
            new FileSignatureModel(new PrefixFileSignatureChecker("BM"));

        public static readonly FileSignatureModel Gif =
            new FileSignatureModel(new PrefixFileSignatureChecker("GIF87a", "GIF89a"));

        public static readonly FileSignatureModel Png =
            new FileSignatureModel(new PrefixFileSignatureChecker(
                new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A })); // .PNG....

        public static readonly FileSignatureModel Tiff =
            new FileSignatureModel(
                new PrefixFileSignatureChecker(new byte[] { 0x49, 0x49, 0x2A, 0x00 }), // II*
                new PrefixFileSignatureChecker(new byte[] { 0x4D, 0x4D, 0x00, 0x2A })  // MM*
            );

        public static readonly FileSignatureModel Webp =
            new FileSignatureModel(new WebpFileSignatureChecker());

        public static readonly FileSignatureModel Jpeg =
            new FileSignatureModel(new PrefixFileSignatureChecker(
                new byte[] { 0xFF, 0xD8, 0xFF })); // Start of Image

        public static readonly FileSignatureModel Jxl =
            new FileSignatureModel(new JxlFileSignatureChecker());

        public static readonly FileSignatureModel Dwg =
            new FileSignatureModel(new DwgFileSignatureChecker());
    }
}
