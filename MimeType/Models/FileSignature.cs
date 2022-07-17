using MimeType.Core;
using System;
using System.Linq;

namespace MimeType.Models
{
    public class FileSignature
    {
        protected readonly IFileSignatureChecker[] _checkers;
        public FileSignature(params IFileSignatureChecker[] checkers)
        {
            if (checkers == null || checkers.Length == 0)
                throw new Exception("Checkers cannot is empty");

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
