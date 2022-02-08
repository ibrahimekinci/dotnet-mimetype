using System.Collections.Generic;
using System.IO;

namespace MimeType.Core
{
    public interface IMimeTypeHelper
    {
        #region Extension
        public string? GetDefaultFileExtensionByMimeType(string mimeType);
        public HashSet<string>? GetFileExtensionsByMimeType(string mimeType);

        public string? GetFileExtensionWithoutPointByFilePath(string filePath);
        public HashSet<string>? GetFileExtensionsWithoutPointByFilePath(string filePath);

        public string? GetDefaultFileExtensionWithoutPointFromFileSignature(string filePath);
        public HashSet<string>? GetFileExtensionsWithoutPointFromFileSignature(string filePath);

        public string? GetDefaultFileExtensionWithoutPointByFileSignature(Stream fileStream);
        public HashSet<string>? GetFileExtensionsWithoutPointByFileSignature(Stream fileStream);

        public string? GetDefaultFileExtensionWithoutPointByFileSignature(byte[] fileBytes);
        public HashSet<string>? GetFileExtensionsWithoutPointByFileSignature(byte[] fileBytes);
        #endregion

        #region MimeType
        public string? GetDefaultMimeTypeByFileExtension(string fileExtensionWithoutPoint);
        public HashSet<string>? GetMimeTypesByFileExtension(string fileExtensionWithoutPoint);

        public string? GetDefaultMimeTypeByFilePath(string filePath);
        public HashSet<string>? GetMimeTypesByFilePath(string filePath);

        public string? GetDefaultMimeTypeFromFileSignature(string filePath);
        public HashSet<string>? GetMimeTypesFromFileSignature(string filePath);

        public string? GetDefaultMimeTypeByFileSignature(Stream fileStream);
        public HashSet<string>? GetMimeTypesByFileSignature(Stream fileStream);

        public string? GetDefaultMimeTypeByFileSignature(byte[] fileBytes);
        public HashSet<string>? GetMimeTypesByFileSignature(byte[] fileBytes);
        #endregion
    }
}
