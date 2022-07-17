using MimeType.FileSignatures;
using MimeType.Models;
using System.Collections.Generic;

namespace MimeType
{
    public class FileTypeHelper
    {
        #region Lists
        public readonly HashSet<FileType> RootFileTypes = new HashSet<FileType>()
        {
//Archive start
		   SevenZ,
           Gzip,
           Fits,
           Xar,
           Bz2,
           Ar,
           Deb,
           Warc,
           Cab,
           Xz,
           Lzip,
           RPM,
           Cpio,
           RAR,
//Archive end

//Audio start
		    Flac,
            Midi,
            Ape,
            MusePack,
            Au,
            Amr,
            Voc,
            M3u,
            AAC,
            Mp3,
            Wav,
            Aiff,
            Qcp,

//Audio end

//Binary start
		    Lnk,
            Wasm,
            Exe,
            //TODO
            //Elf,
            Nes,
            SWF,
            Torrent,

//Binary end

//Database start
            Sqlite,
            MsAccessAce,
            MsAccessMdb,

//Database end

//Document start
            Pdf,
            Fdf,
            Mobi,
            Lit,

//Document end

//Font start
            Woff,
            Woff2,
            Otf,

//Font end

//Ftyp start
            AVIF,
            Mp4,
            ThreeGP,
            ThreeG2,
            AMp4,
            QuickTime,
            Mqv,
            M4a,
            M4v,
            Heic,
            HeicSequence,
            Heif,
            HeifSequence,
//Ftyp end

//image start
		    Png,
            APng,
            Jpg,
            Jp2,
            Jpx,
            Jpm,
            Gif,
            Bmp,
            Ps,
            Psd,
            Ico,
            Icns,
            Tiff,
            Bpg,
            Xcf,
            Pat,
            Gbr,
            Hdr,
            Xpm,
            Webp,
            Dwg,
            Jxl, 
//image end

//Ogg start
            Ogg,
            OggAudio,
            OggVideo, 

//Ogg end

//Video start
            Flv,
            Asf,
            Rmvb,
            Avi,
            Mpeg, 
//Video end

//Zip start
            Odt,
            Ott,
            Ods,
            Ots,
            Odp,
            Otp,
            Odg,
            Otg,
            Odf,
            Odc,
            Epub,
            Sxc,
            Zip
//Zip end
        };

        public readonly HashSet<FileType> ArchiveFileTypes = new HashSet<FileType>()
        {
            SevenZ,
            Gzip,
            Fits,
            Xar,
            Bz2,
            Ar,
            Deb,
            Warc,
            Cab,
            Xz,
            Lzip,
            RPM,
            Cpio,
            RAR
        };

        public readonly HashSet<FileType> AudioFileTypes = new HashSet<FileType>()
        {
            Flac,
            Midi,
            Ape,
            MusePack,
            Au,
            Amr,
            Voc,
            M3u,
            AAC,
            Mp3,
            Wav,
            Aiff,
            Qcp,
        };

        public readonly HashSet<FileType> BinaryFileTypes = new HashSet<FileType>()
        {   Lnk,
            Wasm,
            Exe,
            Elf,
            Nes,
            SWF,
            Torrent,
        };

        public readonly HashSet<FileType> DatabaseFileTypes = new HashSet<FileType>()
          {
            Sqlite,
            MsAccessAce,
            MsAccessMdb,
          };

        public readonly HashSet<FileType> DocumentFileTypes = new HashSet<FileType>()
        {
            Pdf,
            Fdf,
            Mobi,
            Lit,
        };

        public readonly HashSet<FileType> FontFileTypes = new HashSet<FileType>()
        {
            Woff,
            Woff2,
            Otf,
        };

        public readonly HashSet<FileType> FtypFileTypes = new HashSet<FileType>()
        {
            AVIF,
            Mp4,
            ThreeGP,
            ThreeG2,
            AMp4,
            QuickTime,
            Mqv,
            M4a,
            M4v,
            Heic,
            HeicSequence,
            Heif,
            HeifSequence,
        };

        public readonly HashSet<FileType> ImageFileTypes = new HashSet<FileType>()
        {
            Png,
            APng,
            Jpg,
            Jp2,
            Jpx,
            Jpm,
            Gif,
            Bmp,
            Ps,
            Psd,
            Ico,
            Icns,
            Tiff,
            Bpg,
            Xcf,
            Pat,
            Gbr,
            Hdr,
            Xpm,
            Webp,
            Dwg,
            Jxl,
        };

        public readonly HashSet<FileType> OggFileTypes = new HashSet<FileType>()
        {
            Ogg,
            OggAudio,
            OggVideo,
        };

        public readonly HashSet<FileType> VideoFileTypes = new HashSet<FileType>()
        {
            Flv,
            Asf,
            Rmvb,
            Avi,
            Mpeg,
        };

        public readonly HashSet<FileType> ZipFileTypes = new HashSet<FileType>()
        {
            Odt,
            Ott,
            Ods,
            Ots,
            Odp,
            Otp,
            Odg,
            Otg,
            Odf,
            Odc,
            Epub,
            Sxc,
            Zip
        };

        #endregion

        #region Archive
        public static FileType SevenZ = new FileType(ArchiveFileSignatures.SevenZ)
        {
            Extension = "7z",
            Mime = "application/x-7z-compressed"
        };

        public static FileType Gzip = new FileType(ArchiveFileSignatures.Gzip)
        {
            Extension = "gz",
            Mime = "application/gzip",
            Aliases = new HashSet<string>
               {
                    "application/x-gzip",
                    "application/x-gunzip",
                    "application/gzipped",
                    "application/gzip-compressed",
                    "application/x-gzip-compressed",
                    "gzip/document"
               }
        };

        public static FileType Fits = new FileType(ArchiveFileSignatures.Fits)
        {
            Extension = "fits",
            Mime = "application/fits"
        };

        public static FileType Xar = new FileType(ArchiveFileSignatures.Xar)
        {
            Extension = "xar",
            Mime = "application/x-xar"
        };

        public static FileType Bz2 = new FileType(ArchiveFileSignatures.Bz2)
        {
            Extension = "bz2",
            Mime = "application/x-bzip2"
        };

        public static FileType Ar = new FileType(ArchiveFileSignatures.Ar)
        {
            Extension = "a",
            Mime = "application/x-archive",
        };

        public static FileType Deb = new FileType(ArchiveFileSignatures.Deb)
        {
            Extension = "deb",
            Mime = "application/vnd.debian.binary-package"
        };

        public static FileType Warc = new FileType(ArchiveFileSignatures.Warc)
        {
            Extension = "warc",
            Mime = "application/warc"
        };

        public static FileType Cab = new FileType(ArchiveFileSignatures.Cab)
        {
            Extension = "cab",
            Mime = "application/vnd.ms-cab-compressed"
        };

        public static FileType Xz = new FileType(ArchiveFileSignatures.Xz)
        {
            Extension = "xz",
            Mime = "application/x-xz"
        };

        public static FileType Lzip = new FileType(ArchiveFileSignatures.Lzip)
        {
            Extension = "lz",
            Mime = "application/lzip",
            Aliases = new HashSet<string> { "application/x-lzip" }
        };

        public static FileType RPM = new FileType(ArchiveFileSignatures.RPM)
        {
            Extension = "rpm",
            Mime = "application/x-rpm"
        };

        public static FileType Cpio = new FileType(ArchiveFileSignatures.Cpio)
        {
            Extension = "cpio",
            Mime = "application/x-cpio"
        };

        public static FileType RAR = new FileType(ArchiveFileSignatures.RAR)
        {
            Extension = "rar",
            Mime = "application/x-rar-compressed"
        };

        #endregion

        #region Audio
        public static FileType Flac = new FileType(AudioFileSignatures.Flac)
        {
            Extension = "flac",
            Mime = "audio/flac"
        };

        public static FileType Midi = new FileType(AudioFileSignatures.Midi)
        {
            Extension = "midi",
            Mime = "audio/midi",
            Aliases = new HashSet<string> { "audio/mid", "audio/sp-midi", "audio/x-mid", "audio/x-midi" }
        };

        public static FileType Ape = new FileType(AudioFileSignatures.Ape)
        {
            Extension = "ape",
            Mime = "audio/ape"
        };

        public static FileType MusePack = new FileType(AudioFileSignatures.MusePack)
        {
            Extension = "mpc",
            Mime = "audio/musepack"
        };

        public static FileType Au = new FileType(AudioFileSignatures.Au)
        {
            Extension = "au",
            Mime = "audio/basic"
        };

        public static FileType Amr = new FileType(AudioFileSignatures.Amr)
        {
            Extension = "amr",
            Mime = "audio/amr",
            Aliases = new HashSet<string> { "audio/amr-nb" }
        };

        public static FileType Voc = new FileType(AudioFileSignatures.Voc)
        {
            Extension = "voc",
            Mime = "audio/x-unknown"
        };

        public static FileType M3u = new FileType(AudioFileSignatures.M3u)
        {
            Extension = "m3u",
            Mime = "application/vnd.apple.mpegurl"
        };

        public static FileType AAC = new FileType(AudioFileSignatures.AAC)
        {
            Extension = "aac",
            Mime = "audio/aac"
        };

        public static FileType Mp3 = new FileType(AudioFileSignatures.Mp3)
        {
            Extension = "mp3",
            Mime = "audio/mpeg",
            Aliases = new HashSet<string> { "audio/x-mpeg", "audio/mp3" }
        };

        public static FileType Wav = new FileType(AudioFileSignatures.Wav)
        {
            Extension = "wav",
            Mime = "audio/wav",
            Aliases = new HashSet<string> { "audio/x-wav", "audio/vnd.wave", "audio/wave" }
        };

        public static FileType Aiff = new FileType(AudioFileSignatures.Aiff)
        {
            Extension = "aiff",
            Mime = "audio/aiff",
            Aliases = new HashSet<string> { "audio/x-aiff" }
        };

        public static FileType Qcp = new FileType(AudioFileSignatures.Qcp)
        {
            Extension = "qcp",
            Mime = "audio/qcelp"
        };
        #endregion

        #region Binary
        public static FileType Lnk = new FileType(BinaryFileSignatures.Lnk)
        {
            Extension = "lnk",
            Mime = "application/x-ms-shortcut"
        };

        public static FileType Wasm = new FileType(BinaryFileSignatures.Wasm)
        {
            Extension = "wasm",
            Mime = "application/wasm"
        };

        public static FileType Exe = new FileType(BinaryFileSignatures.Exe)
        {
            Extension = "exe",
            Mime = "application/vnd.microsoft.portable-executable"
        };

        public static FileType Elf = new FileType(BinaryFileSignatures.Elf)
        {
            Extension = "",
            Mime = "application/x-elf"
        };

        public static FileType Nes = new FileType(BinaryFileSignatures.Nes)
        {
            Extension = "nes",
            Mime = "application/vnd.nintendo.snes.rom"
        };

        public static FileType SWF = new FileType(BinaryFileSignatures.SWF)
        {
            Extension = "swf",
            Mime = "application/x-shockwave-flash"
        };

        public static FileType Torrent = new FileType(BinaryFileSignatures.Torrent)
        {
            Extension = "torrent",
            Mime = "application/x-bittorrent"
        };
        #endregion

        #region Database
        public static FileType Sqlite = new FileType(DatabaseFileSignatures.Sqlite)
        {
            Extension = "sqlite",
            Mime = "application/vnd.sqlite3",
            Aliases = new HashSet<string> { "application/x-sqlite3" }
        };

        public static FileType MsAccessAce = new FileType(DatabaseFileSignatures.MsAccessAce)
        {
            Extension = "accdb",
            Mime = "application/x-msaccess"
        };

        public static FileType MsAccessMdb = new FileType(DatabaseFileSignatures.MsAccessMdb)
        {
            Extension = "mdb",
            Mime = "application/x-msaccess"
        };
        #endregion

        #region Document
        public static FileType Pdf = new FileType(DocumentFileSignatures.Pdf)
        {
            Extension = "pdf",
            Mime = "application/pdf",
            Aliases = new HashSet<string> { "application/x-pdf" }
        };

        public static FileType Fdf = new FileType(DocumentFileSignatures.Fdf)
        {
            Extension = "fdf",
            Mime = "application/vnd.fdf"
        };

        public static FileType Mobi = new FileType(DocumentFileSignatures.Mobi)
        {
            Extension = "mobi",
            Mime = "application/x-mobipocket-ebook"
        };

        public static FileType Lit = new FileType(DocumentFileSignatures.Lit)
        {
            Extension = "lit",
            Mime = "application/x-ms-reader"
        };
        #endregion

        #region Font
        public static FileType Woff = new FileType(FontFileSignatures.Woff)
        {
            Extension = "woff",
            Mime = "font/woff"
        };

        public static FileType Woff2 = new FileType(FontFileSignatures.Woff2)
        {
            Extension = "woff2",
            Mime = "font/woff2"
        };

        public static FileType Otf = new FileType(FontFileSignatures.Otf)
        {
            Extension = "otf",
            Mime = "font/otf"
        };
        #endregion

        #region Ftyp
        public static FileType AVIF = new FileType(FtypFileSignatures.AVIF)
        {
            Extension = "avif",
            Mime = "image/avif"
        };

        public static FileType Mp4 = new FileType(FtypFileSignatures.Mp4)
        {
            Extension = "mp4",
            Mime = "video/mp4"
        };

        public static FileType ThreeGP = new FileType(FtypFileSignatures.ThreeGP)
        {
            Extension = "3gp",
            Mime = "video/3gpp",
            Aliases = new HashSet<string> { "video/3gp", "audio/3gpp" }
        };

        public static FileType ThreeG2 = new FileType(FtypFileSignatures.ThreeG2)
        {
            Extension = "3g2",
            Mime = "video/3gpp2",
            Aliases = new HashSet<string> { "video/3g2", "audio/3gpp2" }
        };

        public static FileType AMp4 = new FileType(FtypFileSignatures.AMp4)
        {
            Extension = "mp4",
            Mime = "audio/mp4",
            Aliases = new HashSet<string> { "audio/x-m4a", "audio/x-mp4a" }
        };

        public static FileType QuickTime = new FileType(FtypFileSignatures.QuickTime)
        {
            Extension = "mov",
            Mime = "video/quicktime"
        };

        public static FileType Mqv = new FileType(FtypFileSignatures.Mqv)
        {
            Extension = "mqv",
            Mime = "video/quicktime"
        };

        public static FileType M4a = new FileType(FtypFileSignatures.M4a)
        {
            Extension = "m4a",
            Mime = "audio/x-m4a"
        };

        public static FileType M4v = new FileType(FtypFileSignatures.M4v)
        {
            Extension = "m4v",
            Mime = "video/x-m4v"
        };

        public static FileType Heic = new FileType(FtypFileSignatures.Heic)
        {
            Extension = "heic",
            Mime = "image/heic"
        };

        public static FileType HeicSequence = new FileType(FtypFileSignatures.HeicSequence)
        {
            Extension = "heic",
            Mime = "image/heic-sequence"
        };

        public static FileType Heif = new FileType(FtypFileSignatures.Heif)
        {
            Extension = "heif",
            Mime = "image/heif"
        };

        public static FileType HeifSequence = new FileType(FtypFileSignatures.HeifSequence)
        {
            Extension = "heif",
            Mime = "image/heif-sequence"
        };
        #endregion

        #region Image
        public static FileType Png = new FileType(ImageFileSignatures.Png)
        {
            Extension = "png",
            Mime = "image/png"
        };

        public static FileType APng = new FileType(ImageFileSignatures.Apng)
        {
            Extension = "png",
            Mime = "image/vnd.mozilla.apng"
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

        #region Ogg
        public static FileType Ogg = new FileType(OggFileSignatures.Ogg)
        {
            Extension = "ogg",
            Mime = "application/ogg",
            Aliases = new HashSet<string> { "application/x-ogg" }
        };

        public static FileType OggAudio = new FileType(OggFileSignatures.OggAudio)
        {
            Extension = "oga",
            Mime = "audio/ogg"
        };

        public static FileType OggVideo = new FileType(OggFileSignatures.OggVideo)
        {
            Extension = "ogv",
            Mime = "video/ogg"
        };

        #endregion

        #region Video
        public static FileType Flv = new FileType(VideoFileSignatures.Flv)
        {
            Extension = "flv",
            Mime = "video/x-flv"
        };

        public static FileType Asf = new FileType(VideoFileSignatures.Asf)
        {
            Extension = "asf",
            Mime = "video/x-ms-asf",
            Aliases = new HashSet<string> { "video/asf", "video/x-ms-wmv" }
        };

        public static FileType Rmvb = new FileType(VideoFileSignatures.Rmvb)
        {
            Extension = "rmvb",
            Mime = "application/vnd.rn-realmedia-vbr"
        };

        public static FileType Avi = new FileType(VideoFileSignatures.Avi)
        {
            Extension = "avi",
            Mime = "video/x-msvideo",
            Aliases = new HashSet<string> { "video/avi", "video/msvideo" }
        };

        public static FileType Mpeg = new FileType(VideoFileSignatures.Mpeg)
        {
            Extension = "mpeg",
            Mime = "video/mpeg"
        };
        #endregion

        #region Zip
        public static FileType Odt = new FileType(ZipFileSignatures.Odt)
        {
            Extension = "odt",
            Mime = "application/vnd.oasis.opendocument.text",
            Aliases = new HashSet<string> { "application/x-vnd.oasis.opendocument.text" },
        };

        public static FileType Ott = new FileType(ZipFileSignatures.Ott)
        {
            Extension = "ott",
            Mime = "application/vnd.oasis.opendocument.text-template",
            Aliases = new HashSet<string> { "application/x-vnd.oasis.opendocument.text-template" },
        };

        public static FileType Ods = new FileType(ZipFileSignatures.Ods)
        {
            Extension = "ods",
            Mime = "application/vnd.oasis.opendocument.spreadsheet",
            Aliases = new HashSet<string> { "application/x-vnd.oasis.opendocument.spreadsheet" },
        };

        public static FileType Ots = new FileType(ZipFileSignatures.Ots)
        {
            Extension = "ots",
            Mime = "application/vnd.oasis.opendocument.spreadsheet-template",
            Aliases = new HashSet<string> { "application/x-vnd.oasis.opendocument.spreadsheet-template" },
        };

        public static FileType Odp = new FileType(ZipFileSignatures.Odp)
        {
            Extension = "odp",
            Mime = "application/vnd.oasis.opendocument.presentation",
            Aliases = new HashSet<string> { "application/x-vnd.oasis.opendocument.presentation" },
        };

        public static FileType Otp = new FileType(ZipFileSignatures.Otp)
        {
            Extension = "otp",
            Mime = "application/vnd.oasis.opendocument.presentation-template",
            Aliases = new HashSet<string> { "application/x-vnd.oasis.opendocument.presentation-template" },
        };

        public static FileType Odg = new FileType(ZipFileSignatures.Odg)
        {
            Extension = "odg",
            Mime = "application/vnd.oasis.opendocument.graphics",
            Aliases = new HashSet<string> { "application/x-vnd.oasis.opendocument.graphics" },
        };

        public static FileType Otg = new FileType(ZipFileSignatures.Otg)
        {
            Extension = "otg",
            Mime = "application/vnd.oasis.opendocument.graphics-template",
            Aliases = new HashSet<string> { "application/x-vnd.oasis.opendocument.graphics-template" },
        };

        public static FileType Odf = new FileType(ZipFileSignatures.Odf)
        {
            Extension = "odf",
            Mime = "application/vnd.oasis.opendocument.formula",
            Aliases = new HashSet<string> { "application/x-vnd.oasis.opendocument.formula" },
        };

        public static FileType Odc = new FileType(ZipFileSignatures.Odc)
        {
            Extension = "odc",
            Mime = "application/vnd.oasis.opendocument.chart",
            Aliases = new HashSet<string> { "application/x-vnd.oasis.opendocument.chart" },
        };

        public static FileType Epub = new FileType(ZipFileSignatures.Epub)
        {
            Extension = "epub",
            Mime = "application/epub+zip"
        };

        public static FileType Sxc = new FileType(ZipFileSignatures.Sxc)
        {
            Extension = "sxc",
            Mime = "application/vnd.sun.xml.calc"
        };

        public static FileType Zip = new FileType(ZipFileSignatures.Zip)
        {
            Extension = "zip",
            Mime = "application/zip",
        };
        #endregion
    }
}
