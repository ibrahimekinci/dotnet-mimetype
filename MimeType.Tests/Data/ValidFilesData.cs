using System.Collections;
using System.Collections.Generic;

namespace MimeType.Tests.Data
{
    public class ValidFilesData : IEnumerable<object[]>
    {
        //filePath, expectedFileExtension, expectedMimeType
        public IEnumerator<object[]> GetEnumerator()
        {

            #region image
            yield return new object[] { "png", "image/png", "/Valid/sample (1).png", };
            yield return new object[] { "jpg", "image/jpeg", "/Valid/sample (1).jpg", };
            yield return new object[] { "jp2", "image/jp2", "/Valid/sample (1).jp2", };
            yield return new object[] { "jpf", "image/jpx", "/Valid/sample (1).jpf", };
            yield return new object[] { "jpm", "image/jpm", "/Valid/sample (1).jpm", };
            yield return new object[] { "gif", "image/gif", "/Valid/sample (1).gif", };
            yield return new object[] { "bmp", "image/bmp", "/Valid/sample (1).bmp", };
            yield return new object[] { "ps", "application/postscript", "/Valid/sample (1).ps", };
            yield return new object[] { "psd", "image/vnd.adobe.photoshop", "/Valid/sample (1).psd", };
            yield return new object[] { "ico", "image/x-icon", "/Valid/sample (1).ico", };
            yield return new object[] { "icns", "image/x-icns", "/Valid/sample (1).icns", };
            yield return new object[] { "tiff", "image/tiff", "/Valid/sample (1).tiff", };
            yield return new object[] { "bpg", "image/bpg", "/Valid/sample (1).bpg", };
            yield return new object[] { "xcf", "image/x-xcf", "/Valid/sample (1).xcf", };
            yield return new object[] { "pat", "image/x-gimp-pat", "/Valid/sample (1).pat", };
            yield return new object[] { "gbr", "image/x-gimp-gbr", "/Valid/sample (1).gbr", };
            yield return new object[] { "hdr", "image/vnd.radiance", "/Valid/sample (1).hdr", };
            yield return new object[] { "xpm", "image/x-xpixmap", "/Valid/sample (1).xpm", };
            yield return new object[] { "webp", "image/webp", "/Valid/sample (1).webp", };
            yield return new object[] { "dwg", "image/vnd.dwg", "/Valid/sample (1).dwg", };
            yield return new object[] { "jxl", "image/jxl", "/Valid/sample (1).jxl", };
            #endregion
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
