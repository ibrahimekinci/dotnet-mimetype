using System;
using System.Collections.Generic;

namespace MimeType.Models
{
    public class FileType
    {
        protected readonly FileSignature _fileSignature;
        public FileType(FileSignature fileSignature)
        {
            if (fileSignature == null)
                throw new Exception("FileSignature cannot is empty");

            _fileSignature = fileSignature;
        }

        public string Mime { get; set; }
        public string Extension { get; set; }
        public HashSet<string>? Aliases { get; set; }
        public bool Is(byte[] fileBytes) => _fileSignature.Is(fileBytes);
        //public static bool Equals(byte[]? b1, byte[]? b2)
        //{
        //    if (b1 == b2)
        //        return true;
        //    else if (b1?.Length != b2?.Length)
        //        return false;

        //    for (int i = 0; i < b1?.Length; i++)
        //        if (b1?[i] != b2?[i])
        //            return false;

        //    return true;
        //}
    }
}
