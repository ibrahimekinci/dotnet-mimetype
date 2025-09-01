
using FluentAssertions;
using MimeType.Infrastructure.FileSignatureCheckers.Image;
using System.Text;
using Xunit;

namespace MimeType.Tests
{
    public class DwgFileSignatureCheckerTests
    {
        [Fact]
        public void Is_ShouldReturnTrue_ForValidDwg()
        {
            // Arrange
            var checker = new DwgFileSignatureChecker();
            byte[] bytes = Encoding.ASCII.GetBytes("AC1015"); // AC + 1015

            // Act
            bool result = checker.Is(bytes);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Is_ShouldReturnFalse_ForInvalid()
        {
            // Arrange
            var checker = new DwgFileSignatureChecker();
            byte[] bytes = Encoding.ASCII.GetBytes("AC9999");

            // Act
            bool result = checker.Is(bytes);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Is_ShouldReturnFalse_ForShortBytes()
        {
            // Arrange
            var checker = new DwgFileSignatureChecker();
            byte[] bytes = new byte[5];

            // Act
            bool result = checker.Is(bytes);

            // Assert
            result.Should().BeFalse();
        }
    }
}
