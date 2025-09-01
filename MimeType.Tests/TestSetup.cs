using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace MimeType.Tests
{
    /// <summary>
    /// Ensures test files are available locally before tests run.
    /// 
    /// This class lists a wide range of valid_filefiles for potential testing.
    /// Currently, only image formats are actively tested in FileSignatureDetectorTests.
    /// Supported file extensions (potential, based on samples; not all have signature checkers yet):
    /// - Audio: .aac, .aiff, .amr, .ape, .au, .flac, .m4a, .midi, .mp3, .oga, .qcp, .voc, .wav
    /// - Video: .3g2, .3gp, .asf, .avi, .flv, .mkv, .mov, .mp4, .mpeg, .mqv, .ogv, .rmvb, .webm
    /// - Images: .avif, .bmp, .bpg, .dae, .djvu, .dwg, .gbr, .gif, .hdr, .heic, .heif, .icns, .ico, .jp2, .jpf, .jpg, .jpm, .jxl, .png, .psd, .svg, .tiff, .webp, .x3d, .xcf, .xpm
    /// - Documents: .accdb, .csv, .dbf, .doc, .docx, .epub, .fdf, .html, .ics, .js, .json, .kml, .lit, .mdb, .mobi, .msg, .ndjson, .odc, .odf, .odg, .odp, .ods, .odt, .otg, .otp, .ots, .ott, .owl, .pdf, .php, .pl, .ppt, .pptx, .ps, .pub, .py, .rtf, .srt, .sxc, .tcl, .tcx, .tsv, .txt, .vcf, .vtt, .xar, .xfdf, .xlf, .xls, .xlsx, .xml
    /// - Archives: .7z, .bz2, .cab, .cpio, .crx, .deb, .gz, .jar, .lz, .rar, .rpm, .tar, .warc, .xz, .zip, .zst
    /// - Others: .3mf, .a, .aaf, .amf, .atom, .class, .dcm, .eot, .exe, .fb, .fits, .geojson, .glb, .gml, .gpx, .har, .lnk, .lua, .m3u, .macho, .mpc, .mrc, .msi, .nes, .otf, .p7s, .pat, .shp, .shx, .so, .sqlite, .swf, .torrent, .ttf, .wasm, .woff, .woff2
    /// 
    /// Recommendation: Add more signature checkers and tests for these formats to expand library coverage.
    /// </summary>
    public static class TestSetup
    {
        private static readonly string TestFilesDir = Path.Combine(
            Path.GetDirectoryName(typeof(TestSetup).Assembly.Location) ?? throw new InvalidOperationException("Unable to determine assembly location"),
            "..", "..", "..", "TestFiles", "Valid");
        private static readonly string[] Files =
        {
            //"valid_file (1).3g2",
            //"valid_file (1).3gp",
            //"valid_file (1).3mf",
            //"valid_file (1).7z",
            //"valid_file (1).a",
            //"valid_file (1).aac",
            //"valid_file (1).aaf",
            //"valid_file (1).accdb",
            //"valid_file (1).aiff",
            //"valid_file (1).amf",
            //"valid_file (1).amr",
            //"valid_file (1).ape",
            //"valid_file (1).asf",
            //"valid_file (1).atom",
            //"valid_file (1).au",
            //"valid_file (1).avi",
            //"valid_file (1).avif",
            "valid_file (1).bmp",
            //"valid_file (1).bpg",
            //"valid_file (1).bz2",
            //"valid_file (1).cab",
            //"valid_file (1).class",
            //"valid_file (1).cpio",
            //"valid_file (1).crx",
            //"valid_file (1).csv",
            //"valid_file (1).dae",
            //"valid_file (1).dbf",
            //"valid_file (1).dcm",
            //"valid_file (1).deb",
            //"valid_file (1).djvu",
            //"valid_file (1).doc",
            //"valid_file (1).docx",
            "valid_file (1).dwg",
            //"valid_file (1).eot",
            //"valid_file (1).epub",
            //"valid_file (1).exe",
            //"valid_file (1).fb",
            //"valid_file (1).fdf",
            //"valid_file (1).fits",
            //"valid_file (1).flac",
            //"valid_file (1).flv",
            //"valid_file (1).gbr",
            //"valid_file (1).geojson",
            "valid_file (1).gif",
            //"valid_file (1).glb",
            //"valid_file (1).gml",
            //"valid_file (1).gpx",
            //"valid_file (1).gz",
            //"valid_file (1).har",
            //"valid_file (1).hdr",
            //"valid_file (1).heic",
            //"valid_file (1).heif",
            //"valid_file (1).html",
            //"valid_file (1).icns",
            //"valid_file (1).ico",
            //"valid_file (1).ics",
            //"valid_file (1).jar",
            "valid_file (1).jp2",
            //"valid_file (1).jpf",
            "valid_file (1).jpg",
            "valid_file (1).jpeg",
            "valid_file (1).jfif",
            "valid_file (1).jpe",
            "valid_file (1).jpm",
            //"valid_file (1).js",
            //"valid_file (1).json",
            "valid_file (1).jxl",
            //"valid_file (1).kml",
            //"valid_file (1).lit",
            //"valid_file (1).lnk",
            //"valid_file (1).lua",
            //"valid_file (1).lz",
            //"valid_file (1).m3u",
            //"valid_file (1).m4a",
            //"valid_file (1).macho",
            //"valid_file (1).mdb",
            //"valid_file (1).midi",
            //"valid_file (1).mkv",
            //"valid_file (1).mobi",
            //"valid_file (1).mov",
            //"valid_file (1).mp3",
            //"valid_file (1).mp4",
            //"valid_file (1).mpc",
            //"valid_file (1).mpeg",
            //"valid_file (1).mqv",
            //"valid_file (1).mrc",
            //"valid_file (1).msg",
            //"valid_file (1).msi",
            //"valid_file (1).ndjson",
            //"valid_file (1).nes",
            //"valid_file (1).odc",
            //"valid_file (1).odf",
            //"valid_file (1).odg",
            //"valid_file (1).odp",
            //"valid_file (1).ods",
            //"valid_file (1).odt",
            //"valid_file (1).oga",
            //"valid_file (1).ogv",
            //"valid_file (1).otf",
            //"valid_file (1).otg",
            //"valid_file (1).otp",
            //"valid_file (1).ots",
            //"valid_file (1).ott",
            //"valid_file (1).owl",
            //"valid_file (1).p7s",
            //"valid_file (1).pat",
            //"valid_file (1).pdf",
            //"valid_file (1).php",
            //"valid_file (1).pl",
            "valid_file (1).png",
            //"valid_file (1).ppt",
            //"valid_file (1).pptx",
            //"valid_file (1).ps",
            //"valid_file (1).psd",
            //"valid_file (1).pub",
            //"valid_file (1).py",
            //"valid_file (1).qcp",
            //"valid_file (1).rar",
            //"valid_file (1).rmvb",
            //"valid_file (1).rpm",
            //"valid_file (1).rss",
            //"valid_file (1).rtf",
            //"valid_file (1).shp",
            //"valid_file (1).shx",
            //"valid_file (1).so",
            //"valid_file (1).sqlite",
            //"valid_file (1).srt",
            //"valid_file (1).svg",
            //"valid_file (1).swf",
            //"valid_file (1).sxc",
            //"valid_file (1).tar",
            //"valid_file (1).tcl",
            //"valid_file (1).tcx",
            "valid_file (1).tiff",
            //"valid_file (1).torrent",
            //"valid_file (1).tsv",
            //"valid_file (1).ttf",
            //"valid_file (1).txt",
            //"valid_file (1).vcf",
            //"valid_file (1).voc",
            //"valid_file (1).vtt",
            //"valid_file (1).warc",
            //"valid_file (1).wasm",
            //"valid_file (1).wav",
            //"valid_file (1).webm",
            "valid_file (1).webp",
            //"valid_file (1).woff",
            //"valid_file (1).woff2",
            //"valid_file (1).x3d",
            //"valid_file (1).xar",
            //"valid_file (1).xcf",
            //"valid_file (1).xfdf",
            //"valid_file (1).xlf",
            //"valid_file (1).xls",
            //"valid_file (1).xlsx",
            //"valid_file (1).xml",
            //"valid_file (1).xpm",
            //"valid_file (1).xz",
            //"valid_file (1).zip",
            //"valid_file (1).zst"
        };

        [Fact]
        public static Task EnsureTestFilesAsync()
        {
            // Create the test files directory if it doesn't exist.
            if (!Directory.Exists(TestFilesDir))
                Directory.CreateDirectory(TestFilesDir);

            // Check for the existence of each valid_filefile.
            foreach (var fileName in Files)
            {
                string localPath = Path.Combine(TestFilesDir, fileName);
                if (!File.Exists(localPath))
                {
                    throw new FileNotFoundException($"Test file {fileName} is missing in {TestFilesDir}.");
                }
            }

            return Task.CompletedTask;
        }

        public static string GetFilePath(string fileName) =>
            Path.Combine(TestFilesDir, fileName);
    }
}