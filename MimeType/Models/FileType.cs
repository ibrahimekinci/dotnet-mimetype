using System;
using System.Collections.Generic;

namespace MimeType.Models
{
    internal class FileType
    {
        protected readonly FileSignature _fileSignature;
        public FileType(FileSignature fileSignature)
        {
            _fileSignature = fileSignature ?? throw new Exception("MimeType -> FileSignature cannot is empty");
        }

        public string Mime { get; set; }
        public string Extension { get; set; }
        public HashSet<string>? Aliases { get; set; }
        public HashSet<FileType>? Children { get; set; }
        public FileType? Parent { get; set; }
        public static bool Equals(byte[]? b1, byte[]? b2)
        {
            if (b1 == b2)
                return true;
            else if (b1?.Length != b2?.Length)
                return false;

            for (int i = 0; i < b1.Length; i++)
                if (b1[i] != b2[i])
                    return false;

            return true;
        }
        public bool Is(byte[] fileBytes) => _fileSignature.Is(fileBytes);
    }
}
