using MimeType.Tests.Data;
using System.IO;
using System.Linq;
using Xunit;

namespace MimeType.Tests
{

    [Collection("MimeTypeTests")]
    public class MimeTypeHelperTest
    {
        const string _dataFileBasePath = $"C:/Users/Traveler/source/repos/MimeType/src/MimeType.Tests/Data/SampleFiles";

        #region utils
        private static FileStream? GetFileStreamByPath(string filePath)
        {
            if (!File.Exists(filePath))
                return null;

            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
            return fileStream;
        }
        private static byte[]? GetFileBytesByPath(string filePath)
        {
            if (!File.Exists(filePath))
                return null;

            var fileBytes = File.ReadAllBytes(filePath);
            return fileBytes;
        }
        private static string GetFullPath(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return string.Empty;

            var fullPath = $"{_dataFileBasePath}/{filePath}";
            return fullPath;
        }
        #endregion

        [Theory]
        [ClassData(typeof(ValidFilesData))]
        public void GetFileExtensionWithoutPointByMimeTypeTest(string fileExtension, string mimeTypes, string filePath)
        {
            Assert.NotEmpty(fileExtension);
            Assert.NotEmpty(mimeTypes);
            Assert.NotEmpty(filePath);

            var mimeTypeList = mimeTypes.Split(',');
            Assert.NotNull(mimeTypeList);
            Assert.True(mimeTypes.Length > 0);

            var mimeTypeHelper = new MimeTypeHelper();
            foreach (string mimeType in mimeTypeList)
            {
                Assert.NotEmpty(mimeType);

                var result = mimeTypeHelper.GetFileExtensionWithoutPointByMimeType(mimeType);

                if (string.Equals("application/x-msaccess", mimeType))
                    Assert.Contains(new string[2] { "accdb", "mdb" }, x => string.Equals(x, result));
                else if (string.Equals("audio/x-m4a", mimeType))
                    Assert.Contains(new string[2] { "mp4", "m4a" }, x => string.Equals(x, result));
                else if (string.Equals("video/quicktime", mimeType))
                    Assert.Contains(new string[2] { "mov", "mqv" }, x => string.Equals(x, result));
                else
                    Assert.Equal(fileExtension, result);
            }
        }

        [Theory]
        [ClassData(typeof(ValidFilesData))]
        public void GetMimeTypeByFileExtensionWithoutPointTest(string fileExtension, string mimeTypes, string filePath)
        {
            Assert.NotEmpty(fileExtension);
            Assert.NotEmpty(mimeTypes);
            Assert.NotEmpty(filePath);

            var mimeTypeList = mimeTypes.Split(',');
            Assert.NotNull(mimeTypeList);
            Assert.True(mimeTypes.Length > 0);

            var mimeType = mimeTypeList[0];
            Assert.NotEmpty(mimeType);

            var mimeTypeHelper = new MimeTypeHelper();
            var result = mimeTypeHelper.GetMimeTypeByFileExtensionWithoutPoint(fileExtension);

            if (string.Equals("png", fileExtension))
                Assert.Contains(new string[2] { "image/png", "image/vnd.mozilla.apng" }, x => string.Equals(x, result));
            else if (string.Equals("mp4", fileExtension))
                Assert.Contains(new string[2] { "audio/mp4", "video/mp4" }, x => string.Equals(x, result));
            else if (string.Equals("heif", fileExtension))
                Assert.Contains(new string[2] { "image/heif", "image/heif-sequence" }, x => string.Equals(x, result));
            else if (string.Equals("heic", fileExtension))
                Assert.Contains(new string[2] { "image/heic", "image/heic-sequence" }, x => string.Equals(x, result));
            else
                Assert.Equal(mimeType, result);
        }

        [Theory]
        [ClassData(typeof(ValidFilesData))]
        public void GetFileExtensionWithoutPointByFilePathTest(string fileExtension, string mimeTypes, string filePath)
        {
            Assert.NotEmpty(fileExtension);
            Assert.NotEmpty(mimeTypes);
            Assert.NotEmpty(filePath);

            var fullFilePath = GetFullPath(filePath);
            Assert.NotEmpty(fullFilePath);

            var mimeTypeHelper = new MimeTypeHelper();
            var result = mimeTypeHelper.GetFileExtensionWithoutPointByFilePath(fullFilePath);
            Assert.Equal(fileExtension, result);
        }

        [Theory]
        [ClassData(typeof(ValidFilesData))]
        public void GetMimeTypeByFilePathTest(string fileExtension, string mimeTypes, string filePath)
        {
            Assert.NotEmpty(fileExtension);
            Assert.NotEmpty(mimeTypes);
            Assert.NotEmpty(filePath);

            var mimeTypeList = mimeTypes.Split(',');
            Assert.NotNull(mimeTypeList);
            Assert.True(mimeTypes.Length > 0);

            var mimeType = mimeTypeList[0];
            Assert.NotEmpty(mimeType);

            var fullFilePath = GetFullPath(filePath);
            Assert.NotEmpty(fullFilePath);

            var mimeTypeHelper = new MimeTypeHelper();
            var result = mimeTypeHelper.GetMimeTypeByFilePath(fullFilePath);

            if (string.Equals("png", fileExtension))
                Assert.Contains(new string[2] { "image/png", "image/vnd.mozilla.apng" }, x => string.Equals(x, result));
            else if (string.Equals("mp4", fileExtension))
                Assert.Contains(new string[2] { "audio/mp4", "video/mp4" }, x => string.Equals(x, result));
            else if (string.Equals("heif", fileExtension))
                Assert.Contains(new string[2] { "image/heif", "image/heif-sequence" }, x => string.Equals(x, result));
            else if (string.Equals("heic", fileExtension))
                Assert.Contains(new string[2] { "image/heic", "image/heic-sequence" }, x => string.Equals(x, result));
            else
                Assert.Equal(mimeType, result);
        }

        [Theory]
        [ClassData(typeof(ValidFilesData))]
        public void GetFileExtensionWithoutPointByFileSignatureFromStreamTest(string fileExtension, string mimeTypes, string filePath)
        {
            Assert.NotEmpty(fileExtension);
            Assert.NotEmpty(mimeTypes);
            Assert.NotEmpty(filePath);

            var fullFilePath = GetFullPath(filePath);
            Assert.NotEmpty(fullFilePath);

            var fileStream = GetFileStreamByPath(fullFilePath);
            Assert.NotNull(fileStream);
            Assert.True(fileStream?.Length > 0);

            var mimeTypeHelper = new MimeTypeHelper();
            var result = mimeTypeHelper.GetFileExtensionWithoutPointByFileSignatureFromStream(fileStream);

            Assert.Equal(fileExtension, result);
        }

        [Theory]
        [ClassData(typeof(ValidFilesData))]
        public void GetMimeTypeByFileSignatureFromStreamTest(string fileExtension, string mimeTypes, string filePath)
        {
            Assert.NotEmpty(fileExtension);
            Assert.NotEmpty(mimeTypes);
            Assert.NotEmpty(filePath);

            var mimeTypeList = mimeTypes.Split(',');
            Assert.NotNull(mimeTypeList);
            Assert.True(mimeTypes.Length > 0);

            var mimeType = mimeTypeList[0];
            Assert.NotEmpty(mimeType);

            var fullFilePath = GetFullPath(filePath);
            Assert.NotEmpty(fullFilePath);

            var fileStream = GetFileStreamByPath(fullFilePath);
            Assert.NotNull(fileStream);
            Assert.True(fileStream?.Length > 0);

            var mimeTypeHelper = new MimeTypeHelper();
            var result = mimeTypeHelper.GetMimeTypeByFileSignatureFromStream(fileStream);

            Assert.Equal(mimeType, result);
        }

        [Theory]
        [ClassData(typeof(ValidFilesData))]
        public void GetFileExtensionWithoutPointByFileSignatureFromBytesTest(string fileExtension, string mimeTypes, string filePath)
        {
            Assert.NotEmpty(fileExtension);
            Assert.NotEmpty(mimeTypes);
            Assert.NotEmpty(filePath);

            var fullFilePath = GetFullPath(filePath);
            Assert.NotEmpty(fullFilePath);

            var fileBytes = GetFileBytesByPath(fullFilePath);
            Assert.NotNull(fileBytes);
            Assert.True(fileBytes?.Length > 0);

            var mimeTypeHelper = new MimeTypeHelper();
            var result = mimeTypeHelper.GetFileExtensionWithoutPointByFileSignatureFromBytes(fileBytes);
            Assert.Equal(fileExtension, result);
        }

        [Theory]
        [ClassData(typeof(ValidFilesData))]
        public void GetMimeTypeByFileSignatureFromBytesTest(string fileExtension, string mimeTypes, string filePath)
        {
            Assert.NotEmpty(fileExtension);
            Assert.NotEmpty(mimeTypes);
            Assert.NotEmpty(filePath);

            var mimeTypeList = mimeTypes.Split(',');
            Assert.NotNull(mimeTypeList);
            Assert.True(mimeTypes.Length > 0);

            var mimeType = mimeTypeList[0];
            Assert.NotEmpty(mimeType);

            var fullFilePath = GetFullPath(filePath);
            Assert.NotEmpty(fullFilePath);

            var fileBytes = GetFileBytesByPath(fullFilePath);
            Assert.NotNull(fileBytes);
            Assert.True(fileBytes?.Length > 0);

            var mimeTypeHelper = new MimeTypeHelper();
            var result = mimeTypeHelper.GetMimeTypeByFileSignatureFromBytes(fileBytes);
            Assert.Equal(mimeType, result);
        }

        [Theory]
        [ClassData(typeof(ValidFilesData))]
        public void GetFileExtensionWithoutPointByFileSignatureFromFileSystemTest(string fileExtension, string mimeTypes, string filePath)
        {
            Assert.NotEmpty(fileExtension);
            Assert.NotEmpty(mimeTypes);
            Assert.NotEmpty(filePath);

            var fullFilePath = GetFullPath(filePath);
            Assert.NotEmpty(fullFilePath);

            var mimeTypeHelper = new MimeTypeHelper();
            var result = mimeTypeHelper.GetFileExtensionWithoutPointByFileSignatureFromFileSystem(fullFilePath);
            Assert.Equal(fileExtension, result);
        }

        [Theory]
        [ClassData(typeof(ValidFilesData))]
        public void GetMimeTypeByFileSignatureFromFileSystemTest(string fileExtension, string mimeTypes, string filePath)
        {
            Assert.NotEmpty(fileExtension);
            Assert.NotEmpty(mimeTypes);
            Assert.NotEmpty(filePath);

            var mimeTypeList = mimeTypes.Split(',');
            Assert.NotNull(mimeTypeList);
            Assert.True(mimeTypes.Length > 0);

            var mimeType = mimeTypeList[0];
            Assert.NotEmpty(mimeType);

            var fullFilePath = GetFullPath(filePath);
            Assert.NotEmpty(fullFilePath);

            var mimeTypeHelper = new MimeTypeHelper();
            var result = mimeTypeHelper.GetMimeTypeByFileSignatureFromFileSystem(fullFilePath);
            Assert.Equal(mimeType, result);
        }
    }
}