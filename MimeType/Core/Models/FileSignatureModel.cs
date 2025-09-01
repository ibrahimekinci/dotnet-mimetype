using MimeType.Core.Interfaces;

namespace MimeType.Core.Models
{
    /// <summary>
    /// Represents a file signature with one or more checkers to validate file bytes.
    /// A signature matches if ANY of its checkers return true.
    /// </summary>
    public sealed record FileSignatureModel(params IFileSignatureChecker[] checkers)
    {
        public bool Is(byte[] fileBytes)
        {
            if (fileBytes == null || fileBytes.Length == 0)
                return false;

            foreach (var checker in checkers)
            {
                if (checker.Is(fileBytes))
                    return true;
            }

            return false;
        }
    }
}
