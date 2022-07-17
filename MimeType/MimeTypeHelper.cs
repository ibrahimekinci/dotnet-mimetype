using MimeType.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MimeType
{
    public class MimeTypeHelper
    {
        internal static uint headerSizeLimitBytes = 1024;
        internal HashSet<FileType> FileTypes;
        public MimeTypeHelper()
        {
            var fileTypeHelper = new FileTypeHelper();
            FileTypes = fileTypeHelper.RootFileTypes;
        }

        public MimeTypeHelper(HashSet<FileType> fileTypes)
        {
            if (fileTypes == null)
                throw new Exception("FileTypes cannot is empty");

            FileTypes = fileTypes;
        }

        #region utils
        private byte[]? GetFileBytesByMaxSizeLimit(Stream? fileStream)
        {
            if (fileStream == null || fileStream.Length == 0)
                return null;

            var readSizeBytes = fileStream.Length > headerSizeLimitBytes ? headerSizeLimitBytes : fileStream.Length;
            byte[]? fileBytes = new byte[readSizeBytes];

            fileStream.Read(fileBytes, 0, fileBytes.Length);

            return fileBytes;
        }
        private byte[]? GetFileBytesByFilePath(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return null;

            var fileInfo = new FileInfo(filePath);
            if (fileInfo == null || !fileInfo.Exists || fileInfo.Length == 0)
                return null;

            var readSizeBytes = fileInfo.Length > headerSizeLimitBytes ? headerSizeLimitBytes : fileInfo.Length;
            byte[] fileBytes = new byte[readSizeBytes];

            using (var stream = fileInfo.OpenRead())
                stream.Read(fileBytes, 0, fileBytes.Length);

            return fileBytes;
        }
        #endregion

        #region map table
        public string GetFileExtensionWithoutPointByMimeType(string mimeType)
        {
            if (string.IsNullOrWhiteSpace(mimeType))
                return string.Empty;

            FileType? fileType = FileTypes.Where(x => string.Equals(x.Mime, mimeType, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if (fileType == null)
                fileType = FileTypes.Where(x => x.Aliases != null && x.Aliases.Any(y => string.Equals(y, mimeType, StringComparison.OrdinalIgnoreCase))).FirstOrDefault();

            var fileExtensionWithoutPoint = fileType?.Extension ?? string.Empty;
            return fileExtensionWithoutPoint;
        }
        public string GetMimeTypeByFileExtensionWithoutPoint(string fileExtensionWithoutPoint)
        {
            if (string.IsNullOrWhiteSpace(fileExtensionWithoutPoint))
                return string.Empty;

            fileExtensionWithoutPoint = fileExtensionWithoutPoint.ToLower();

            FileType? fileType = FileTypes.Where(x => string.Equals(x.Extension, fileExtensionWithoutPoint, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            var mimeType = fileType?.Mime ?? string.Empty;

            return mimeType;
        }
        public string GetFileExtensionWithoutPointByFilePath(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return string.Empty;

            var fileExtensionWithoutPoint = Path.GetExtension(filePath)?.TrimStart('.')?.ToLower();

            return fileExtensionWithoutPoint ?? string.Empty;
        }
        public string GetMimeTypeByFilePath(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return string.Empty;

            var fileExtensionWithoutPoint = GetFileExtensionWithoutPointByFilePath(filePath);
            return GetMimeTypeByFileExtensionWithoutPoint(fileExtensionWithoutPoint);
        }
        #endregion

        #region file signature fileStream
        public string GetFileExtensionWithoutPointByFileSignatureFromStream(Stream fileStream)
        {
            var fileBytes = GetFileBytesByMaxSizeLimit(fileStream);
            return GetFileExtensionWithoutPointByFileSignatureFromBytes(fileBytes);
        }
        public string GetMimeTypeByFileSignatureFromStream(Stream fileStream)
        {
            var fileBytes = GetFileBytesByMaxSizeLimit(fileStream);
            return GetMimeTypeByFileSignatureFromBytes(fileBytes);
        }
        #endregion

        #region file signature fileBytes
        public string GetFileExtensionWithoutPointByFileSignatureFromBytes(byte[]? fileBytes)
        {
            if (fileBytes == null || fileBytes.Length == 0)
                return string.Empty;

            if (fileBytes.Length > headerSizeLimitBytes)
                fileBytes = fileBytes.Take((int)headerSizeLimitBytes).ToArray();

            FileType fileType = FileTypes.Where(x => x.Is(fileBytes)).FirstOrDefault();

            var fileExtensionWithoutPoint = fileType?.Extension ?? string.Empty;

            return fileExtensionWithoutPoint;
        }
        public string GetMimeTypeByFileSignatureFromBytes(byte[]? fileBytes)
        {
            if (fileBytes == null || fileBytes.Length == 0)
                return string.Empty;

            if (fileBytes.Length > headerSizeLimitBytes)
                fileBytes = fileBytes.Take((int)headerSizeLimitBytes).ToArray();

            FileType fileType = FileTypes.Where(x => x.Is(fileBytes)).FirstOrDefault();

            var mimeType = fileType?.Mime ?? string.Empty;

            return mimeType;
        }
        #endregion

        #region file signature FileSystem(filePath)
        public string GetFileExtensionWithoutPointByFileSignatureFromFileSystem(string filePath)
        {
            var fileBytes = GetFileBytesByFilePath(filePath);
            return GetFileExtensionWithoutPointByFileSignatureFromBytes(fileBytes);
        }
        public string GetMimeTypeByFileSignatureFromFileSystem(string filePath)
        {
            var fileBytes = GetFileBytesByFilePath(filePath);
            return GetMimeTypeByFileSignatureFromBytes(fileBytes);
        }
        #endregion

        //TODO
        public bool ValidateFile(string fileExtension, string mimeType, byte[] fileBytes)
        {
            return true;
        }
        //TODO
        public bool ValidateFileFromFileSystem(string fileExtension, string mimeType, string filePath)
        {
            return true;
        }
    }
}
