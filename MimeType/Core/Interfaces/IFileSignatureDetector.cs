using MimeType.Core.Models;
using System.Collections.Immutable;
using System.IO;

namespace MimeType.Core.Interfaces
{
    /// <summary>
    /// Defines a contract for detecting file types based on file signatures.
    /// Supports detection from file paths, streams, or byte arrays, optionally filtered by extension.
    /// </summary>
    public interface IFileSignatureDetector
    {
        ImmutableHashSet<FileTypeModel> Detect(byte[] fileBytes, string? fileExtension = null);
        ImmutableHashSet<FileTypeModel> Detect(Stream fileStream, string? fileExtension = null);
        ImmutableHashSet<FileTypeModel> Detect(string filePath, string? fileExtension = null);
    }
}