
using FluentAssertions;
using MimeType.Core.Exceptions;
using MimeType.Core.Interfaces;
using MimeType.Services;
using System;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace MimeType.Tests
{
    public class FileSignatureDetectorTests
    {
        private readonly IFileSignatureDetector _detector = new FileSignatureDetector();

        [Fact]
        public void Detect_ByteArray_ShouldDetectJpeg()
        {
            // Arrange
            byte[] jpegBytes = { 0xFF, 0xD8, 0xFF };

            // Act
            var fileTypes = _detector.Detect(jpegBytes);

            // Assert
            fileTypes.Should().HaveCount(1);
            fileTypes.First().Mime.Should().Be("image/jpeg");
        }

        [Fact]
        public void Detect_ByteArray_ShouldReturnEmpty_ForInvalidBytes()
        {
            // Arrange
            byte[] invalidBytes = { 0x00, 0x00 };

            // Act
            var fileTypes = _detector.Detect(invalidBytes);

            // Assert
            fileTypes.Should().BeEmpty();
        }

        [Fact]
        public void Detect_ByteArray_ShouldThrow_ForNullOrEmptyBytes()
        {
            // Act & Assert
            Assert.Throws<FileNotFoundException>(() => _detector.Detect(Array.Empty<byte>()));
        }

        [Fact]
        public void Detect_ByteArray_WithExtensionFilter_ShouldFilterCorrectly()
        {
            // Arrange
            byte[] jpegBytes = { 0xFF, 0xD8, 0xFF };
            string extension = "jpg";

            // Act
            var fileTypes = _detector.Detect(jpegBytes, extension);

            // Assert
            fileTypes.Should().HaveCount(1);
            fileTypes.First().Mime.Should().Be("image/jpeg");
        }

        [Fact]
        public void Detect_ByteArray_WithMismatchExtension_ShouldReturnEmpty()
        {
            // Arrange
            byte[] jpegBytes = { 0xFF, 0xD8, 0xFF };
            string extension = "png";

            // Act
            var fileTypes = _detector.Detect(jpegBytes, extension);

            // Assert
            fileTypes.Should().BeEmpty();
        }

        [Fact]
        public void Detect_Stream_ShouldDetectPng()
        {
            // Arrange
            byte[] pngBytes = { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
            using var stream = new MemoryStream(pngBytes);

            // Act
            var fileTypes = _detector.Detect(stream);

            // Assert
            fileTypes.Should().HaveCount(1);
            fileTypes.First().Mime.Should().Be("image/png");
        }

        [Fact]
        public void Detect_Stream_ShouldThrow_ForInvalidStream()
        {
            // Arrange
            using var invalidStream = new MemoryStream();
            invalidStream.Close(); // Make it non-readable

            // Act & Assert
            Assert.Throws<MimeTypeException>(() => _detector.Detect(invalidStream));
        }

        [Fact]
        public void Detect_Stream_ShouldResetPositionIfNeeded()
        {
            // Arrange
            byte[] pngBytes = { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
            using var stream = new MemoryStream(pngBytes);
            stream.Seek(4, SeekOrigin.Begin);

            // Act
            var fileTypes = _detector.Detect(stream);

            // Assert
            fileTypes.Should().HaveCount(1);
            fileTypes.First().Mime.Should().Be("image/png");
        }

        [Fact]
        public void Detect_FilePath_ShouldDetectGif()
        {
            // Arrange
            string tempPath = Path.GetTempFileName();
            File.WriteAllBytes(tempPath, Encoding.ASCII.GetBytes("GIF87a"));

            // Act
            var fileTypes = _detector.Detect(tempPath);

            // Assert
            fileTypes.Should().HaveCount(1);
            fileTypes.First().Mime.Should().Be("image/gif");

            // Cleanup
            File.Delete(tempPath);
        }

        [Fact]
        public void Detect_FilePath_ShouldThrow_ForNonExistentFile()
        {
            // Act & Assert
            Assert.Throws<FileNotFoundMimeTypeException>(() => _detector.Detect("nonexistent.file"));
        }
    }
}
