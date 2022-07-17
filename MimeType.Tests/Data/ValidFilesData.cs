using System.Collections;
using System.Collections.Generic;

namespace MimeType.Tests.Data
{
    public class ValidFilesData : IEnumerable<object[]>
    {
        //filePath, expectedFileExtension, expectedMimeType
        public IEnumerator<object[]> GetEnumerator()
        {
            #region Archive
            yield return new object[]
            {
                "7z",
                "application/x-7z-compressed",
                "/Valid/sample (1).7z"
            };
            yield return new object[]
            {
                "gz",
                "application/gzip,application/x-gzip,application/x-gunzip,application/gzipped,application/gzip-compressed,application/x-gzip-compressed,gzip/document",
                "/Valid/sample (1).gz"
            };
            yield return new object[]
            {
                "fits",
                "application/fits",
                "/Valid/sample (1).fits"
            };
            yield return new object[]
            {
                "xar",
                "application/x-xar",
                "/Valid/sample (1).xar"
            };
            yield return new object[]
            {
                "bz2",
                "application/x-bzip2",
                "/Valid/sample (1).bz2"
            };
            yield return new object[]
            {
                "a",
                "application/x-archive",
                "/Valid/sample (1).a"
            };
            yield return new object[]
            {
                "deb",
                "application/vnd.debian.binary-package",
                "/Valid/sample (1).deb"
            };
            yield return new object[]
            {
                "warc",
                "application/warc",
                "/Valid/sample (1).warc"
            };
            yield return new object[]
            {
                "cab",
                "application/vnd.ms-cab-compressed",
                "/Valid/sample (1).cab"
            };
            yield return new object[]
            {
                "xz",
                "application/x-xz",
                "/Valid/sample (1).xz"
            };
            yield return new object[]
            {
                "lz",
                "application/lzip",
                "/Valid/sample (1).lz"
            };
            yield return new object[]
            {
                "rpm",
                "application/x-rpm",
                "/Valid/sample (1).rpm"
            };
            yield return new object[]
            {
                "cpio",
                "application/x-cpio",
                "/Valid/sample (1).cpio"
            };
            yield return new object[]
            {
                "rar",
                "application/x-rar-compressed",
                "/Valid/sample (1).rar"
            };
            #endregion

            #region audio
            yield return new object[]
            {
              "flac",
              "audio/flac",
              "/Valid/sample (1).flac"
            };
            yield return new object[]
            {
              "midi",
              "audio/midi",
              "/Valid/sample (1).midi"
            };
            yield return new object[]
            {
              "ape",
              "audio/ape",
              "/Valid/sample (1).ape"
            };
            yield return new object[]
            {
              "mpc",
              "audio/musepack",
              "/Valid/sample (1).mpc"
            };
            yield return new object[]
            {
              "au",
              "audio/basic",
              "/Valid/sample (1).au"
            };
            yield return new object[]
            {
              "amr",
              "audio/amr,audio/amr-nb",
              "/Valid/sample (1).amr"
            };
            yield return new object[]
            {
              "voc",
              "audio/x-unknown",
              "/Valid/sample (1).voc"
            };
            yield return new object[]
            {
              "m3u",
              "application/vnd.apple.mpegurl",
              "/Valid/sample (1).m3u"
            };
            yield return new object[]
            {
              "aac",
              "audio/aac",
              "/Valid/sample (1).aac"
            };
            yield return new object[]
            {
              "mp3",
              "audio/mpeg,audio/x-mpeg,audio/mp3",
              "/Valid/sample (1).mp3"
            };
            yield return new object[]
            {
              "wav",
              "audio/wav,audio/x-wav,audio/vnd.wave,audio/wave",
              "/Valid/sample (1).wav"
            };
            yield return new object[]
            {
              "aiff",
              "audio/aiff",
              "/Valid/sample (1).aiff"
            };
            yield return new object[]
            {
              "qcp",
              "audio/qcelp",
              "/Valid/sample (1).qcp"
            };
            #endregion

            #region binary
            yield return new object[]
            {
              "lnk",
              "application/x-ms-shortcut",
              "/Valid/sample (1).lnk"
            };
            yield return new object[]
            {
              "wasm",
              "application/wasm",
              "/Valid/sample (1).wasm"
            };
            yield return new object[]
            {
              "exe",
              "application/vnd.microsoft.portable-executable",
              "/Valid/sample (1).exe"
            };
            //TODO
            //yield return new object[]
            //{
            //  "",
            //  "application/x-elf",
            //  "/Valid/sample (1)_elf"
            //};
            yield return new object[]
            {
              "nes",
              "application/vnd.nintendo.snes.rom",
              "/Valid/sample (1).nes"
            };
            yield return new object[]
            {
              "swf",
              "application/x-shockwave-flash",
              "/Valid/sample (1).swf"
            };
            yield return new object[]
            {
              "torrent",
              "application/x-bittorrent",
              "/Valid/sample (1).torrent"
            };
            #endregion

            #region database
            yield return new object[]
            {
              "sqlite",
              "application/vnd.sqlite3,application/x-sqlite3",
              "/Valid/sample (1).sqlite"
            };
            yield return new object[]
            {
              "accdb",
              "application/x-msaccess",
              "/Valid/sample (1).accdb"
            };
            yield return new object[]
            {
              "mdb",
              "application/x-msaccess",
              "/Valid/sample (1).mdb"
            };
            #endregion

            #region document
            yield return new object[]
            {
              "pdf",
              "application/pdf,application/x-pdf",
              "/Valid/sample (1).pdf"
            };
            yield return new object[]
            {
              "fdf",
              "application/vnd.fdf",
              "/Valid/sample (1).fdf"
            };
            yield return new object[]
            {
              "mobi",
              "application/x-mobipocket-ebook",
              "/Valid/sample (1).mobi"
            };
            yield return new object[]
            {
              "lit",
              "application/x-ms-reader",
              "/Valid/sample (1).lit"
            };
            #endregion

            #region font
            yield return new object[]
            {
              "woff",
              "font/woff",
              "/Valid/sample (1).woff"
            };
            yield return new object[]
            {
              "woff2",
              "font/woff2",
              "/Valid/sample (1).woff2"
            };
            yield return new object[]
            {
              "otf",
              "font/otf",
              "/Valid/sample (1).otf"
            };
            #endregion

            #region ftyp
            yield return new object[]
            {
              "avif",
              "image/avif",
              "/Valid/sample (1).avif"
            };
            yield return new object[]
            {
              "mp4",
              "video/mp4",
              "/Valid/sample (1)_video.mp4"
            };
            yield return new object[]
            {
              "3gp",
              "video/3gpp,video/3gp,audio/3gpp",
              "/Valid/sample (1).3gp"
            };
            yield return new object[]
            {
              "3g2",
              "video/3gpp2,video/3g2,audio/3gpp2",
              "/Valid/sample (1).3g2"
            };
            yield return new object[]
            {
              "mp4",
              "audio/mp4,audio/x-m4a,audio/x-mp4a",
              "/Valid/sample (1)_audio.mp4"
            };
            yield return new object[]
            {
              "mov",
              "video/quicktime",
              "/Valid/sample (1).mov"
            };
            yield return new object[]
            {
              "mqv",
              "video/quicktime",
              "/Valid/sample (1).mqv"
            };
            yield return new object[]
            {
              "m4a",
              "audio/x-m4a",
              "/Valid/sample (1).m4a"
            };
            yield return new object[]
            {
              "m4v",
              "video/x-m4v",
              "/Valid/sample (1).m4v"
            };
            yield return new object[]
            {
              "heic",
              "image/heic",
              "/Valid/sample (1).heic"
            };
            yield return new object[]
            {
              "heic",
              "image/heic-sequence",
              "/Valid/sample (1).heic"
            };
            yield return new object[]
            {
              "heif",
              "image/heif",
              "/Valid/sample (1).heif"
            };
            yield return new object[]
            {
              "heif",
              "image/heif-sequence",
              "/Valid/sample (1).heif"
            };
            #endregion

            #region image
            yield return new object[] {
                "png",
                "image/png",
                "/Valid/sample (1).png"
            };
            yield return new object[] {
                "png",
                "image/vnd.mozilla.apng",
                "/Valid/sample (1).png"
            };
            yield return new object[] {
                "jpg",
                "image/jpeg",
                "/Valid/sample (1).jpg"
            };
            yield return new object[] {
                "jp2",
                "image/jp2",
                "/Valid/sample (1).jp2"
            };
            yield return new object[] {
                "jpf",
                "image/jpx",
                "/Valid/sample (1).jpf"
            };
            yield return new object[] {
                "jpm",
                "image/jpm",
                "/Valid/sample (1).jpm"
            };
            yield return new object[] {
                "gif",
                "image/gif",
                "/Valid/sample (1).gif"
            };
            yield return new object[] {
                "bmp",
                "image/bmp,image/x-bmp,image/x-ms-bmp",
                "/Valid/sample (1).bmp"
            };
            yield return new object[] {
                "ps",
                "application/postscript",
                "/Valid/sample (1).ps"
            };
            yield return new object[] {
                "psd",
                "image/vnd.adobe.photoshop,image/x-psd,application/photoshop",
                "/Valid/sample (1).psd"
            };
            yield return new object[] {
                "ico",
                "image/x-icon",
                "/Valid/sample (1).ico"
            };
            yield return new object[] {
                "icns",
                "image/x-icns",
                "/Valid/sample (1).icns"
            };
            yield return new object[] {
                "tiff",
                "image/tiff",
                "/Valid/sample (1).tiff"
            };
            yield return new object[] {
                "bpg",
                "image/bpg",
                "/Valid/sample (1).bpg"
            };
            yield return new object[] {
                "xcf",
                "image/x-xcf",
                "/Valid/sample (1).xcf"
            };
            yield return new object[] {
                "pat",
                "image/x-gimp-pat",
                "/Valid/sample (1).pat"
            };
            yield return new object[] {
                "gbr",
                "image/x-gimp-gbr",
                "/Valid/sample (1).gbr"
            };
            yield return new object[] {
                "hdr",
                "image/vnd.radiance",
                "/Valid/sample (1).hdr"
            };
            yield return new object[] {
                "xpm",
                "image/x-xpixmap",
                "/Valid/sample (1).xpm"
            };
            yield return new object[] {
                "webp",
                "image/webp",
                "/Valid/sample (1).webp"
            };
            yield return new object[] {
                "dwg",
                "image/vnd.dwg,image/x-dwg,application/acad,application/x-acad,application/autocad_dwg,application/dwg,application/x-dwg,application/x-autocad,drawing/dwg",
                "/Valid/sample (1).dwg"
            };
            yield return new object[] {
                "jxl",
                "image/jxl",
                "/Valid/sample (1).jxl"
            };
            #endregion

            #region ogg
            yield return new object[]
            {
              "ogg",
              "application/ogg,application/x-ogg",
              "/Valid/sample (1).ogg"
            };
            yield return new object[]
            {
              "oga",
              "audio/ogg",
              "/Valid/sample (1).oga"
            };
            yield return new object[]
            {
              "ogv",
              "video/ogg",
              "/Valid/sample (1).ogv"
            };
            #endregion

            #region video
            yield return new object[]
            {
              "flv",
              "video/x-flv",
              "/Valid/sample (1).flv"
            };
            yield return new object[]
            {
              "asf",
              "video/x-ms-asf,video/asf,video/x-ms-wmv",
              "/Valid/sample (1).asf"
            };
            yield return new object[]
            {
              "rmvb",
              "application/vnd.rn-realmedia-vbr",
              "/Valid/sample (1).rmvb"
            };
            yield return new object[]
            {
              "avi",
              "video/x-msvideo,video/avi,video/msvideo",
              "/Valid/sample (1).avi"
            };
            yield return new object[]
            {
              "mpeg",
              "video/mpeg",
              "/Valid/sample (1).mpeg"
            };

            #endregion

            #region zip
            yield return new object[]
            {
              "odt",
              "application/vnd.oasis.opendocument.text,application/x-vnd.oasis.opendocument.text",
              "/Valid/sample (1).odt"
            };
            yield return new object[]
            {
              "ott",
              "application/vnd.oasis.opendocument.text-template,application/x-vnd.oasis.opendocument.text-template",
              "/Valid/sample (1).ott"
            };
            yield return new object[]
            {
              "ods",
              "application/vnd.oasis.opendocument.spreadsheet,application/x-vnd.oasis.opendocument.spreadsheet",
              "/Valid/sample (1).ods"
            };
            yield return new object[]
            {
              "ots",
              "application/vnd.oasis.opendocument.spreadsheet-template,application/x-vnd.oasis.opendocument.spreadsheet-template",
              "/Valid/sample (1).ots"
            };
            yield return new object[]
            {
              "odp",
              "application/vnd.oasis.opendocument.presentation,application/x-vnd.oasis.opendocument.presentation",
              "/Valid/sample (1).odp"
            };
            yield return new object[]
            {
              "otp",
              "application/vnd.oasis.opendocument.presentation-template,application/x-vnd.oasis.opendocument.presentation-template",
              "/Valid/sample (1).otp"
            };
            yield return new object[]
            {
              "odg",
              "application/vnd.oasis.opendocument.graphics,application/x-vnd.oasis.opendocument.graphics",
              "/Valid/sample (1).odg"
            };
            yield return new object[]
            {
              "otg",
              "application/vnd.oasis.opendocument.graphics-template,application/x-vnd.oasis.opendocument.graphics-template",
              "/Valid/sample (1).otg"
            };
            yield return new object[]
            {
              "odf",
              "application/vnd.oasis.opendocument.formula,application/x-vnd.oasis.opendocument.formula",
              "/Valid/sample (1).odf"
            };
            yield return new object[]
            {
              "odc",
              "application/vnd.oasis.opendocument.chart,application/x-vnd.oasis.opendocument.chart",
              "/Valid/sample (1).odc"
            };
            yield return new object[]
            {
              "epub",
              "application/epub+zip",
              "/Valid/sample (1).epub"
            };
            yield return new object[]
            {
              "sxc",
              "application/vnd.sun.xml.calc",
              "/Valid/sample (1).sxc"
            };
            yield return new object[]
            {
              "zip",
              "application/zip",
              "/Valid/sample (1).zip"
            };
            #endregion
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
