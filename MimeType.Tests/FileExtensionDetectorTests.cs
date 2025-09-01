using FluentAssertions;
using MimeType.Core.Interfaces;
using MimeType.Services;
using System.Collections.Immutable;
using Xunit;

namespace MimeType.Tests
{
    public class FileExtensionDetectorTests
    {
        private readonly IFileExtensionDetector _detector = new FileExtensionDetector();

        [Fact]
        public void Detect_ShouldReturnExtensions_ForValidMimeType()
        {
            // Arrange
            string mimeType = "image/jpeg";

            // Act
            var extensions = _detector.Detect(mimeType);

            // Assert
            extensions.Should().BeEquivalentTo(ImmutableHashSet.Create(".jpg", ".jfif-tbnl", ".jif", ".jfif", ".jpe", ".pjpg", ".jpeg"));
        }

        [Fact]
        public void Detect_ShouldReturnEmptySet_ForInvalidMimeType()
        {
            // Arrange
            string mimeType = "invalid/mime";

            // Act
            var extensions = _detector.Detect(mimeType);

            // Assert
            extensions.Should().BeEmpty();
        }

        [Fact]
        public void Detect_ShouldReturnEmptySet_ForNullOrEmptyMimeType()
        {
            // Act
            var extensionsNull = _detector.Detect(null!);
            var extensionsEmpty = _detector.Detect(string.Empty);

            // Assert
            extensionsNull.Should().BeEmpty();
            extensionsEmpty.Should().BeEmpty();
        }

        [Fact]
        public void Detect_ShouldBeCaseInsensitive()
        {
            // Arrange
            string mimeType = "IMAGE/JPEG";

            // Act
            var extensions = _detector.Detect(mimeType);

            // Assert
            extensions.Should().BeEquivalentTo(ImmutableHashSet.Create(".jpg", ".jfif-tbnl", ".jif", ".jfif", ".jpe", ".pjpg", ".jpeg"));
        }
    }

}
