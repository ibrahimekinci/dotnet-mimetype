using MimeType.Core;
using System;
using System.Linq;

namespace MimeType.Models
{
    internal class FileSignature
    {
        protected readonly IFileSignatureChecker[] _checkers;
        public FileSignature(params IFileSignatureChecker[] checkers)
        {
            if (checkers == null || !checkers.Any())
                throw new Exception("MimeType -> checkers cannot is empty");

            _checkers = checkers;
        }
        public bool Is(byte[] fileBytes)
        {
            foreach (var checker in _checkers)
                return checker.Is(fileBytes);

            return false;
        }
    }
}
