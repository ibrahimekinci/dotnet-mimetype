using MimeType.Helpers;
using MimeType.Tests.Data;
using System.IO;
using Xunit;

namespace MimeType.Tests
{

    [Collection("MimeTypeTests")]
    public class MimeTypeTests
    {
        public static string dataFileBasePath = $"C:/Users/Traveler/source/repos/MimeType/src/MimeType.Tests/Data/SampleFiles";
        public MimeTypeHelper mimeTypeHelper = new();

        #region func
        private FileStream? GetFileStreamByPath(string filePath)
        {
            FileStream? fileStream = null;
            if (File.Exists(filePath))
            {
                fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
            }
            return fileStream;
        }
        private byte[]? GetFileBytesByPath(string filePath)
        {
            byte[]? fileBytes = null;
            if (File.Exists(filePath))
            {
                fileBytes = File.ReadAllBytes(filePath);
            }
            return fileBytes;
        }
        private string GetFullPath(string filePath)
        {
            var fullPath = string.Empty;

            if (!string.IsNullOrWhiteSpace(filePath))
                fullPath = $"{dataFileBasePath}/{filePath}";

            return fullPath;
        }
        #endregion

        [Theory]
        [ClassData(typeof(ValidFilesData))]
        public void GetFileExtensionWithoutPointByMimeTypeTest(string expectedFileExtension, string expectedMimeType, string filePath)
        {
            var result = mimeTypeHelper.GetFileExtensionWithoutPointByMimeType(expectedMimeType);
            Assert.Equal(expectedFileExtension, result);
        }


        [Theory]
        [ClassData(typeof(ValidFilesData))]
        public void GetMimeTypeByFileExtensionWithoutPointTest(string expectedFileExtension, string expectedMimeType, string filePath)
        {
            var result = mimeTypeHelper.GetMimeTypeByFileExtensionWithoutPoint(expectedFileExtension);
            Assert.Equal(expectedMimeType, result);
        }


        [Theory]
        [ClassData(typeof(ValidFilesData))]
        public void GetFileExtensionWithoutPointByFilePathTest(string expectedFileExtension, string expectedMimeType, string filePath)
        {
            var fullFilePath = GetFullPath(filePath);
            var result = mimeTypeHelper.GetFileExtensionWithoutPointByFilePath(fullFilePath);
            Assert.Equal(expectedFileExtension, result);
        }

        [Theory]
        [ClassData(typeof(ValidFilesData))]
        public void GetMimeTypeByFilePathTest(string expectedFileExtension, string expectedMimeType, string filePath)
        {
            var fullFilePath = GetFullPath(filePath);
            var result = mimeTypeHelper.GetMimeTypeByFilePath(fullFilePath);
            Assert.Equal(expectedMimeType, result);
        }

        [Theory]
        [ClassData(typeof(ValidFilesData))]
        public void GetFileExtensionWithoutPointByFileSignatureFromStreamTest(string expectedFileExtension, string expectedMimeType, string filePath)
        {
            var fullFilePath = GetFullPath(filePath);
            var fileStream = GetFileStreamByPath(fullFilePath);

            var result = mimeTypeHelper.GetFileExtensionWithoutPointByFileSignatureFromStream(fileStream);
            Assert.Equal(expectedFileExtension, result);
        }

        [Theory]
        [ClassData(typeof(ValidFilesData))]
        public void GetMimeTypeByFileSignatureFromStreamTest(string expectedFileExtension, string expectedMimeType, string filePath)
        {
            var fullFilePath = GetFullPath(filePath);
            var fileStream = GetFileStreamByPath(fullFilePath);

            var result = mimeTypeHelper.GetMimeTypeByFileSignatureFromStream(fileStream);
            Assert.Equal(expectedMimeType, result);
        }

        [Theory]
        [ClassData(typeof(ValidFilesData))]
        public void GetFileExtensionWithoutPointByFileSignatureFromBytesTest(string expectedFileExtension, string expectedMimeType, string filePath)
        {
            var fullFilePath = GetFullPath(filePath);
            var fileBytes = GetFileBytesByPath(fullFilePath);

            var result = mimeTypeHelper.GetFileExtensionWithoutPointByFileSignatureFromBytes(fileBytes);
            Assert.Equal(expectedFileExtension, result);
        }

        [Theory]
        [ClassData(typeof(ValidFilesData))]
        public void GetMimeTypeByFileSignatureFromBytesTest(string expectedFileExtension, string expectedMimeType, string filePath)
        {
            var fullFilePath = GetFullPath(filePath);
            var fileBytes = GetFileBytesByPath(fullFilePath);

            var result = mimeTypeHelper.GetMimeTypeByFileSignatureFromBytes(fileBytes);
            Assert.Equal(expectedMimeType, result);
        }

        [Theory]
        [ClassData(typeof(ValidFilesData))]
        public void GetFileExtensionWithoutPointByFileSignatureFromFileSystemTest(string expectedFileExtension, string expectedMimeType, string filePath)
        {
            var fullFilePath = GetFullPath(filePath);
            var result = mimeTypeHelper.GetFileExtensionWithoutPointByFileSignatureFromFileSystem(fullFilePath);
            Assert.Equal(expectedFileExtension, result);
        }

        [Theory]
        [ClassData(typeof(ValidFilesData))]
        public void GetMimeTypeByFileSignatureFromFileSystemTest(string expectedFileExtension, string expectedMimeType, string filePath)
        {
            var fullFilePath = GetFullPath(filePath);
            var result = mimeTypeHelper.GetMimeTypeByFileSignatureFromFileSystem(fullFilePath);
            Assert.Equal(expectedMimeType, result);
        }
    }
}