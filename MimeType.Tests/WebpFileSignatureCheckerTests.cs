
using FluentAssertions;
using MimeType.Infrastructure.FileSignatureCheckers.Image;
using System.Text;
using Xunit;

namespace MimeType.Tests
{
    public class WebpFileSignatureCheckerTests
    {
        [Fact]
        public void Is_ShouldReturnTrue_ForValidWebp()
        {
            // Arrange
            var checker = new WebpFileSignatureChecker();
            byte[] bytes = Encoding.ASCII.GetBytes("RIFFxxxxWEBP"); // xxxx is size, ignored

            // Act
            bool result = checker.Is(bytes);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Is_ShouldReturnFalse_ForInvalid()
        {
            // Arrange
            var checker = new WebpFileSignatureChecker();
            byte[] bytes = Encoding.ASCII.GetBytes("RIFFxxxxINVALID");

            // Act
            bool result = checker.Is(bytes);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Is_ShouldReturnFalse_ForShortBytes()
        {
            // Arrange
            var checker = new WebpFileSignatureChecker();
            byte[] bytes = new byte[11];

            // Act
            bool result = checker.Is(bytes);

            // Assert
            result.Should().BeFalse();
        }
    }
}
