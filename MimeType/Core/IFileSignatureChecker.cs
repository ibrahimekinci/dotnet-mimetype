namespace MimeType.Core
{
    public interface IFileSignatureChecker
    {
        public bool Is(byte[] raw);
    }
}
