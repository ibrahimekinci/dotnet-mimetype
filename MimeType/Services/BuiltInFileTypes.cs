using MimeType.Core.Models;
using MimeType.Infrastructure.FileSignatures;
using System;
using System.Collections.Immutable;

namespace MimeType.Services
{
    /// <summary>
    /// Provides a lazy-initialized set of built-in file types with signatures and mappings.
    /// 
    /// Supported file types and extensions:
    /// - image/bmp: .bmp
    /// - image/gif: .gif
    /// - image/png: .png
    /// - image/tiff: .tiff, .tif
    /// - image/webp: .webp
    /// - image/jpeg: .jpg, .jpeg, .jpe, .jfif
    /// - image/jp2: .jp2, .jpx, .jpm
    /// - image/jxl: .jxl
    /// - image/vnd.dwg: .dwg
    /// - audio/mpeg: .mp3
    /// - video/mp4: .mp4
    /// - application/zip: .zip
    /// 
    /// Reference: https://www.iana.org/assignments/media-types/media-types.xhtml
    /// Reference: https://mimetype.io/all-types
    /// </summary>
    public static class BuiltInFileTypes
    {
        private static readonly Lazy<ImmutableHashSet<FileTypeModel>> _fileTypes =
            new(LoadFileTypes, isThreadSafe: true);

        public static ImmutableHashSet<FileTypeModel> FileTypes => _fileTypes.Value;

        private static ImmutableHashSet<FileTypeModel> LoadFileTypes()
        {
            return
            [
                // === IMAGE TYPES ===
                new FileTypeModel(ImageFileSignatures.Bmp,"image/bmp","bmp"),
                new FileTypeModel(ImageFileSignatures.Gif, "image/gif", "gif"),
                new FileTypeModel(ImageFileSignatures.Png,"image/png","png"),
                new FileTypeModel(ImageFileSignatures.Tiff,"image/tiff","tiff","tif"),
                new FileTypeModel(ImageFileSignatures.Webp, "image/webp","webp"),
                new FileTypeModel(ImageFileSignatures.Jpeg, "image/jpeg","jpg","jpeg", "jpe", "jfif"),
                new FileTypeModel(ImageFileSignatures.Jxl,  "image/jxl","jxl"),
                new FileTypeModel(ImageFileSignatures.Dwg, "image/vnd.dwg","dwg")
             ];
        }
    }
}
