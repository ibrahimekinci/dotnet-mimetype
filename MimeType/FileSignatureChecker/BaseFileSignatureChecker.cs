using System.Text;

namespace MimeType.FileSignatureChecker
{
    internal abstract class BaseFileSignatureChecker
    {
        protected static byte[]? ConvertToBytes(string val)
        {
            if (string.IsNullOrWhiteSpace(val))
                return null;

            return Encoding.ASCII.GetBytes(val);
        }
        public bool BytesEqual(byte[] source, byte[] destination)
        {
            if (source.Length != destination.Length)
                return false;

            for (int i = 0; i < source.Length; i++)
                if (source[i] != destination[i])
                    return false;

            return true;
        }
    }
}
