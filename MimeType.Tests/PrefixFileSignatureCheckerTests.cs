
using FluentAssertions;
using MimeType.Infrastructure.FileSignatureCheckers;
using System.Text;
using Xunit;

namespace MimeType.Tests
{
    public class PrefixFileSignatureCheckerTests
    {
        [Fact]
        public void Is_ShouldReturnTrue_ForMatchingPrefix()
        {
            // Arrange
            var checker = new PrefixFileSignatureChecker("GIF");
            byte[] bytes = Encoding.ASCII.GetBytes("GIF87a");

            // Act
            bool result = checker.Is(bytes);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Is_ShouldReturnFalse_ForNonMatching()
        {
            // Arrange
            var checker = new PrefixFileSignatureChecker("GIF");
            byte[] bytes = Encoding.ASCII.GetBytes("PNG");

            // Act
            bool result = checker.Is(bytes);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Is_ShouldReturnFalse_ForShortBytes()
        {
            // Arrange
            var checker = new PrefixFileSignatureChecker("GIF");
            byte[] bytes = Encoding.ASCII.GetBytes("GI");

            // Act
            bool result = checker.Is(bytes);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Is_ShouldHandleMultipleSignatures()
        {
            // Arrange
            var checker = new PrefixFileSignatureChecker("GIF87a", "GIF89a");

            // Act
            bool result87 = checker.Is(Encoding.ASCII.GetBytes("GIF87a"));
            bool result89 = checker.Is(Encoding.ASCII.GetBytes("GIF89a"));

            // Assert
            result87.Should().BeTrue();
            result89.Should().BeTrue();
        }
    }

}
