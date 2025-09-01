using System;

namespace MimeType.Core.Exceptions
{
    /// <summary>
    /// Custom exception type for the MimeType library.
    /// Used instead of generic Exception to provide clearer error context.
    /// </summary>
    public  class MimeTypeException(string message) : Exception(message)
    {
    }
}
