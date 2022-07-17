using MimeType.FileSignatureChecker;
using MimeType.FileSignatureChecker.Zip;
using MimeType.Models;

namespace MimeType.FileSignatures
{
    internal class ZipFileSignatures
    {
        // Odt matches an OpenDocument Text file.
        public static FileSignature Odt = new FileSignature(new OffsetFileSignatureChecker(30, "mimetypeapplication/vnd.oasis.opendocument.text"));

        // Ott matches an OpenDocument Text Template file.
        public static FileSignature Ott = new FileSignature(new OffsetFileSignatureChecker(30, "mimetypeapplication/vnd.oasis.opendocument.text-template"));

        // Ods matches an OpenDocument Spreadsheet file.
        public static FileSignature Ods = new FileSignature(new OffsetFileSignatureChecker(30, "mimetypeapplication/vnd.oasis.opendocument.spreadsheet"));

        // Ots matches an OpenDocument Spreadsheet Template file.
        public static FileSignature Ots = new FileSignature(new OffsetFileSignatureChecker(30, "mimetypeapplication/vnd.oasis.opendocument.spreadsheet-template"));

        // Odp matches an OpenDocument Presentation file.
        public static FileSignature Odp = new FileSignature(new OffsetFileSignatureChecker(30, "mimetypeapplication/vnd.oasis.opendocument.presentation"));

        // Otp matches an OpenDocument Presentation Template file.
        public static FileSignature Otp = new FileSignature(new OffsetFileSignatureChecker(30, "mimetypeapplication/vnd.oasis.opendocument.presentation-template"));

        // Odg matches an OpenDocument Drawing file.
        public static FileSignature Odg = new FileSignature(new OffsetFileSignatureChecker(30, "mimetypeapplication/vnd.oasis.opendocument.graphics"));

        // Otg matches an OpenDocument Drawing Template file.
        public static FileSignature Otg = new FileSignature(new OffsetFileSignatureChecker(30, "mimetypeapplication/vnd.oasis.opendocument.graphics-template"));

        // Odf matches an OpenDocument Formula file.
        public static FileSignature Odf = new FileSignature(new OffsetFileSignatureChecker(30, "mimetypeapplication/vnd.oasis.opendocument.formula"));

        // Odc matches an OpenDocument Chart file.
        public static FileSignature Odc = new FileSignature(new OffsetFileSignatureChecker(30, "mimetypeapplication/vnd.oasis.opendocument.chart"));

        // Epub matches an EPUB file.
        public static FileSignature Epub = new FileSignature(new OffsetFileSignatureChecker(30, "mimetypeapplication/epub+zip"));

        // Sxc matches an OpenOffice Spreadsheet file.
        public static FileSignature Sxc = new FileSignature(new OffsetFileSignatureChecker(30, "mimetypeapplication/vnd.sun.xml.calc"));

        // Zip matches a zip archive.
        public static FileSignature Zip = new FileSignature(new ZipFileSignatureChecker());
    }
}
