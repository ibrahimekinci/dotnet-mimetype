using MimeType.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MimeType.Helpers
{
    public class MimeTypeHelper
    {
        internal static uint headerSizeLimitBytes = 1024;
        #region fileTypes
        internal static HashSet<FileType> RootFileTypes = new HashSet<FileType>
        {
//image start
		    FileTypes.Png,
            FileTypes.Jpg,
            FileTypes.Jp2,
            FileTypes.Jpx,
            FileTypes.Jpm,
            FileTypes.Gif,
            FileTypes.Bmp,
            FileTypes.Ps,
            FileTypes.Psd,
            FileTypes.Ico,
            FileTypes.Icns,
            FileTypes.Tiff,
            FileTypes.Bpg,
            FileTypes.Xcf,
            FileTypes.Pat,
            FileTypes.Gbr,
            FileTypes.Hdr,
            FileTypes.Xpm,
            FileTypes.Webp,
            FileTypes.Dwg,
            FileTypes.Jxl, 
//image end
        };
        #endregion

        #region func
        private byte[]? GetFileBytesByMaxSizeLimit(Stream? fileStream)
        {
            byte[]? fileBytes = null;

            if (fileStream?.Length > 0)
            {
                var readSizeBytes = fileStream.Length > headerSizeLimitBytes ? headerSizeLimitBytes : fileStream.Length;
                fileBytes = new byte[readSizeBytes];

                fileStream.Read(fileBytes, 0, fileBytes.Length);
            }

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
            {
                stream.Read(fileBytes, 0, fileBytes.Length);
            }

            return fileBytes;
        }
        #endregion

        #region map table
        public string GetFileExtensionWithoutPointByMimeType(string mimeType)
        {
            var fileExtensionWithoutPoint = string.Empty;

            if (!string.IsNullOrWhiteSpace(mimeType))
            {
                mimeType = mimeType.ToLower();

                FileType fileType = RootFileTypes.Where(x => string.Equals(x.Mime, mimeType, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                if (fileType == null)
                    fileType = RootFileTypes.Where(x => x.Aliases.Any(y => string.Equals(y, mimeType, StringComparison.OrdinalIgnoreCase))).FirstOrDefault();

                fileExtensionWithoutPoint = fileType?.Extension ?? string.Empty;
            }

            return fileExtensionWithoutPoint;
        }
        public string GetMimeTypeByFileExtensionWithoutPoint(string fileExtensionWithoutPoint)
        {
            var mimeType = string.Empty;

            if (!string.IsNullOrWhiteSpace(fileExtensionWithoutPoint))
            {
                fileExtensionWithoutPoint = fileExtensionWithoutPoint.ToLower();

                FileType fileType = RootFileTypes.Where(x => string.Equals(x.Extension, fileExtensionWithoutPoint, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                mimeType = fileType?.Mime ?? string.Empty;
            }

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
            var fileExtensionWithoutPoint = string.Empty;

            if (fileBytes?.Length > 0)
            {
                if (fileBytes.Length > headerSizeLimitBytes)
                    fileBytes = fileBytes.Take((int)headerSizeLimitBytes).ToArray();

                FileType fileType = RootFileTypes.Where(x => x.Is(fileBytes)).FirstOrDefault();

                fileExtensionWithoutPoint = fileType?.Extension ?? string.Empty;
            }

            return fileExtensionWithoutPoint;
        }
        public string GetMimeTypeByFileSignatureFromBytes(byte[]? fileBytes)
        {
            var mimeType = string.Empty;

            if (fileBytes?.Length > 0)
            {
                if (fileBytes.Length > headerSizeLimitBytes)
                    fileBytes = fileBytes.Take((int)headerSizeLimitBytes).ToArray();

                FileType fileType = RootFileTypes.Where(x => x.Is(fileBytes)).FirstOrDefault();

                mimeType = fileType?.Mime ?? string.Empty;
            }

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
    }
}
