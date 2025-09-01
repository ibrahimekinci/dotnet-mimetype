using FluentAssertions;
using MimeType.Core.Interfaces;
using MimeType.Services;
using System.IO;
using System.Linq;
using Xunit;

namespace MimeType.Tests
{
    public class FileSignatureDetectorIntegrationTests : IClassFixture<TestSetupFixture>
    {
        private readonly IFileSignatureDetector _detector = new FileSignatureDetector();

        [Theory]
        [InlineData("valid_file (1).bmp", "image/bmp")]
        [InlineData("valid_file (1).gif", "image/gif")]
        [InlineData("valid_file (1).png", "image/png")]
        [InlineData("valid_file (1).tiff", "image/tiff")]
        [InlineData("valid_file (1).webp", "image/webp")]
        [InlineData("valid_file (1).jpeg", "image/jpeg")]
        [InlineData("valid_file (1).jpg", "image/jpeg")]
        [InlineData("valid_file (1).jxl", "image/jxl")]
        [InlineData("valid_file (1).dwg", "image/vnd.dwg")]
        public void Detect_FilePath_ShouldDetectCorrectType(string fileName, string expectedMime)
        {
            // Arrange
            string filePath = TestSetup.GetFilePath(fileName);

            // Act
            var fileTypes = _detector.Detect(filePath);

            // Assert
            if(fileTypes.IsEmpty)
                throw new Xunit.Sdk.XunitException($"No file type detected for {fileName}");
            fileTypes.Should().HaveCount(1);
            if (expectedMime == "image/jp2")
            {
                // JPEG 2000 can be identified by two different MIME types
                fileTypes.First().Mime.Should().MatchRegex("image/(jp2|jpm)");
            }
            else
                fileTypes.First().Mime.Should().Be(expectedMime);
        }

        [Theory]
        [InlineData("valid_file (1).bmp", "bmp", "image/bmp")]
        [InlineData("valid_file (1).jpg", "jpeg", "image/jpeg")]
        public void Detect_FilePath_WithExtension_ShouldFilter(string fileName, string extension, string expectedMime)
        {
            // Arrange
            string filePath = TestSetup.GetFilePath(fileName);

            // Act
            var fileTypes = _detector.Detect(filePath, extension);

            // Assert
            fileTypes.Should().HaveCount(1);
            fileTypes.First().Mime.Should().Be(expectedMime);
        }

        [Fact]
        public void Detect_FilePath_WithMismatchExtension_ShouldReturnEmpty()
        {
            // Arrange
            string filePath = TestSetup.GetFilePath("valid_file (1).bmp");

            // Act
            var fileTypes = _detector.Detect(filePath, "invalid");

            // Assert
            fileTypes.Should().BeEmpty();
        }

        [Theory]
        [InlineData("valid_file (1).gif")]
        public void Detect_Stream_FromFile_ShouldDetect(string fileName)
        {
            // Arrange
            string filePath = TestSetup.GetFilePath(fileName);
            using var stream = File.OpenRead(filePath);

            // Act
            var fileTypes = _detector.Detect(stream);

            // Assert
            fileTypes.First().Mime.Should().Be("image/gif");
        }

        [Theory]
        [InlineData("valid_file (1).png")]
        public void Detect_ByteArray_FromFile_ShouldDetect(string fileName)
        {
            // Arrange
            string filePath = TestSetup.GetFilePath(fileName);
            byte[] bytes = File.ReadAllBytes(filePath);

            // Act
            var fileTypes = _detector.Detect(bytes);

            // Assert
            fileTypes.First().Mime.Should().Be("image/png");
        }
    }
}
