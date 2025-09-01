using FluentAssertions;
using MimeType.Infrastructure.FileSignatureCheckers.Image;
using Xunit;

namespace MimeType.Tests
{
    public class JxlFileSignatureCheckerTests
    {
        [Fact]
        public void Is_ShouldReturnTrue_ForCodestream()
        {
            // Arrange
            var checker = new JxlFileSignatureChecker();
            byte[] bytes = { 0xFF, 0x0A };

            // Act
            bool result = checker.Is(bytes);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Is_ShouldReturnTrue_ForContainer()
        {
            // Arrange
            var checker = new JxlFileSignatureChecker();
            byte[] bytes = { 0x00, 0x00, 0x00, 0x0C, 0x4A, 0x58, 0x4C, 0x20, 0x0D, 0x0A, 0x87, 0x0A };

            // Act
            bool result = checker.Is(bytes);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Is_ShouldReturnFalse_ForInvalid()
        {
            // Arrange
            var checker = new JxlFileSignatureChecker();
            byte[] bytes = { 0xFF, 0x0B };

            // Act
            bool result = checker.Is(bytes);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Is_ShouldReturnFalse_ForNull()
        {
            // Arrange
            var checker = new JxlFileSignatureChecker();

            // Act
            bool result = checker.Is(null!);

            // Assert
            result.Should().BeFalse();
        }
    }
}
