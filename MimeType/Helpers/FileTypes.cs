using MimeType.FileSignatures;
using MimeType.Models;
using System.Collections.Generic;

namespace MimeType.Helpers
{
    internal class FileTypes
    {
        #region Image
        public static FileType Png = new FileType(ImageFileSignatures.Png)
        {
            Extension = "png",
            Mime = "image/png"
        };

        public static FileType Jpg = new FileType(ImageFileSignatures.Jpg)
        {
            Extension = "jpg",
            Mime = "image/jpeg"
        };

        public static FileType Jp2 = new FileType(ImageFileSignatures.Jp2)
        {
            Extension = "jp2",
            Mime = "image/jp2"
        };

        public static FileType Jpx = new FileType(ImageFileSignatures.Jpx)
        {
            Extension = "jpf",
            Mime = "image/jpx"
        };

        public static FileType Jpm = new FileType(ImageFileSignatures.Jpm)
        {
            Extension = "jpm",
            Mime = "image/jpm",
            Aliases = new HashSet<string>
            {
                "video/jpm"
            },
        };

        public static FileType Gif = new FileType(ImageFileSignatures.Gif)
        {
            Extension = "gif",
            Mime = "image/gif"
        };
        public static FileType Bmp = new FileType(ImageFileSignatures.Bmp)
        {
            Extension = "bmp",
            Mime = "image/bmp",
            Aliases = new HashSet<string>
            {
                "image/x-bmp","image/x-ms-bmp"
            },
        };

        public static FileType Ps = new FileType(ImageFileSignatures.Ps)
        {
            Extension = "ps",
            Mime = "application/postscript"
        };

        public static FileType Psd = new FileType(ImageFileSignatures.Psd)
        {
            Extension = "psd",
            Mime = "image/vnd.adobe.photoshop",
            Aliases = new HashSet<string>
            {
                "image/x-psd","application/photoshop"
            },
        };

        public static FileType Ico = new FileType(ImageFileSignatures.Ico)
        {
            Extension = "ico",
            Mime = "image/x-icon"
        };

        public static FileType Icns = new FileType(ImageFileSignatures.Icns)
        {
            Extension = "icns",
            Mime = "image/x-icns"
        };

        public static FileType Tiff = new FileType(ImageFileSignatures.Tiff)
        {
            Extension = "tiff",
            Mime = "image/tiff"
        };

        public static FileType Bpg = new FileType(ImageFileSignatures.Bpg)
        {
            Extension = "bpg",
            Mime = "image/bpg"
        };


        public static FileType Xcf = new FileType(ImageFileSignatures.Xcf)
        {
            Extension = "xcf",
            Mime = "image/x-xcf"
        };

        public static FileType Pat = new FileType(ImageFileSignatures.Pat)
        {
            Extension = "pat",
            Mime = "image/x-gimp-pat"
        };
        public static FileType Gbr = new FileType(ImageFileSignatures.Gbr)
        {
            Extension = "gbr",
            Mime = "image/x-gimp-gbr"
        };

        public static FileType Hdr = new FileType(ImageFileSignatures.Hdr)
        {
            Extension = "hdr",
            Mime = "image/vnd.radiance"
        };

        public static FileType Xpm = new FileType(ImageFileSignatures.Xpm)
        {
            Extension = "xpm",
            Mime = "image/x-xpixmap"
        };

        public static FileType Webp = new FileType(ImageFileSignatures.Webp)
        {
            Extension = "webp",
            Mime = "image/webp"
        };

        public static FileType Dwg = new FileType(ImageFileSignatures.Dwg)
        {
            Extension = "dwg",
            Mime = "image/vnd.dwg",
            Aliases = new HashSet<string>
            {
            "image/x-dwg", "application/acad", "application/x-acad",
            "application/autocad_dwg", "application/dwg", "application/x-dwg",
            "application/x-autocad", "drawing/dwg"
            },
        };

        public static FileType Jxl = new FileType(ImageFileSignatures.Jxl)
        {
            Extension = "jxl",
            Mime = "image/jxl"
        }; 
        #endregion
    }
}
