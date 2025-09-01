using MimeType.Core.Exceptions;
using MimeType.Core.Interfaces;
using MimeType.Core.Models;
using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace MimeType.Services
{
    /// <summary>
    /// Detects file types based on file signatures (magic bytes) from files, streams, or byte arrays.
    /// </summary>
    public sealed class FileSignatureDetector() : IFileSignatureDetector
    {
        public ImmutableHashSet<FileTypeModel> Detect(byte[] fileBytes, string? fileExtension = null)
        {
            if (fileBytes == null || fileBytes.Length == 0)
                throw new FileNotFoundException("An empty byte array sent");

            var fileTypes = BuiltInFileTypes.FileTypes.Where(ft => ft.Is(fileBytes))?.ToImmutableHashSet();

            if (fileTypes != null && !fileTypes.IsEmpty && !string.IsNullOrEmpty(fileExtension))
                fileTypes = [.. fileTypes.Where(x => x.Extensions.Any(y => y.Equals(fileExtension.Trim(), StringComparison.OrdinalIgnoreCase)))];

            if (fileTypes == null || fileTypes.IsEmpty)
                return ImmutableHashSet<FileTypeModel>.Empty;

            return fileTypes;
        }

        public ImmutableHashSet<FileTypeModel> Detect(Stream fileStream, string? fileExtension = null)
        {
            return Detect(ReadStream(fileStream), fileExtension);
        }

        public ImmutableHashSet<FileTypeModel> Detect(string filePath, string? fileExtension = null)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundMimeTypeException($"File not found: {filePath}");

            return Detect(File.ReadAllBytes(filePath), fileExtension);
        }

        private static byte[] ReadStream(Stream stream)
        {
            if (stream == null || !stream.CanRead)
                throw new MimeTypeException("Invalid or non-readable stream provided.");

            if (stream.Position != 0 && stream.CanSeek)
                stream.Seek(0, SeekOrigin.Begin);

            using var ms = new MemoryStream();
            stream.CopyTo(ms);

            return ms.ToArray();
        }
    }
}
