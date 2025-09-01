using FluentAssertions;
using MimeType.Core.Interfaces;
using MimeType.Services;
using Xunit;

namespace MimeType.Tests
{
    public class MimeTypeDetectorTests
    {
        private readonly IMimeTypeDetector _detector = new MimeTypeDetector();

        [Fact]
        public void Detect_ShouldReturnMimeTypes_ForValidExtension()
        {
            // Arrange
            string extension = ".jpg";

            // Act
            var mimeTypes = _detector.Detect(extension);

            // Assert
            mimeTypes.Should().Contain("image/jpeg");
            mimeTypes.Should().Contain("image/pjpeg");
        }

        [Fact]
        public void Detect_ShouldReturnEmptySet_ForInvalidExtension()
        {
            // Arrange
            string extension = ".invalid";

            // Act
            var mimeTypes = _detector.Detect(extension);

            // Assert
            mimeTypes.Should().BeEmpty();
        }

        [Fact]
        public void Detect_ShouldReturnEmptySet_ForNullOrEmptyExtension()
        {
            // Act
            var mimeTypesNull = _detector.Detect(null!);
            var mimeTypesEmpty = _detector.Detect(string.Empty);

            // Assert
            mimeTypesNull.Should().BeEmpty();
            mimeTypesEmpty.Should().BeEmpty();
        }

        [Fact]
        public void Detect_ShouldBeCaseInsensitive()
        {
            // Arrange
            string extension = ".JPG";

            // Act
            var mimeTypes = _detector.Detect(extension);

            // Assert
            mimeTypes.Should().Contain("image/jpeg");
        }

        [Fact]
        public void Detect_ShouldHandleExtensionsWithoutDot()
        {
            // Arrange
            string extension = ".jpg";

            // Act
            var mimeTypes = _detector.Detect(extension);

            // Assert
            mimeTypes.Should().Contain("image/jpeg");
        }
    }
}
