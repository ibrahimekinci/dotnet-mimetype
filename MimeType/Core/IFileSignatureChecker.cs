namespace MimeType.Core
{
    internal interface IFileSignatureChecker
    {
        public bool Is(byte[] fileBytes);
    }
}
