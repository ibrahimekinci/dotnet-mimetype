using FluentAssertions;
using MimeType.Infrastructure.FileSignatureCheckers;
using Xunit;

namespace MimeType.Tests
{
    public class OffsetFileSignatureCheckerTests
    {
        [Fact]
        public void Is_ShouldReturnTrue_ForMatchingSignatureAtOffset()
        {
            // Arrange
            var checker = new OffsetFileSignatureChecker(4, "TEST");
            byte[] bytes = { 0, 0, 0, 0, 84, 69, 83, 84 }; // 84=T,69=E,83=S,84=T

            // Act
            bool result = checker.Is(bytes);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Is_ShouldReturnFalse_ForNonMatchingSignature()
        {
            // Arrange
            var checker = new OffsetFileSignatureChecker(4, "TEST");
            byte[] bytes = { 0, 0, 0, 0, 84, 69, 83, 85 }; // Last byte differs

            // Act
            bool result = checker.Is(bytes);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Is_ShouldReturnFalse_WhenFileTooShort()
        {
            // Arrange
            var checker = new OffsetFileSignatureChecker(4, "TEST");
            byte[] bytes = { 0, 0, 0, 0 }; // shorter than offset + signature

            // Act
            bool result = checker.Is(bytes);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Is_ShouldRespectMinByteLength()
        {
            // Arrange
            var checker = new OffsetFileSignatureChecker(4, 8, "TEST"); // min length = 8
            byte[] bytes = { 0, 0, 0, 0, 84, 69, 83, 84 }; // length = 8

            // Act
            bool result = checker.Is(bytes);

            // Assert
            result.Should().BeTrue(); // length meets min

            // Arrange with minByteLength > actual length
            checker = new OffsetFileSignatureChecker(4, 9, "TEST"); // min length = 9
            result = checker.Is(bytes);
            result.Should().BeFalse(); // too short
        }

        [Fact]
        public void Is_ShouldHandleMultipleSignatures()
        {
            // Arrange
            var checker = new OffsetFileSignatureChecker(0, "AB", "CD");
            byte[] bytes1 = { 65, 66 }; // "AB"
            byte[] bytes2 = { 67, 68 }; // "CD"
            byte[] bytes3 = { 69, 70 }; // "EF"

            // Act & Assert
            checker.Is(bytes1).Should().BeTrue();
            checker.Is(bytes2).Should().BeTrue();
            checker.Is(bytes3).Should().BeFalse();
        }

        [Fact]
        public void Constructor_ShouldHandleByteArraysDirectly()
        {
            // Arrange
            var checker = new OffsetFileSignatureChecker(0, new byte[] { 1, 2 });

            // Act & Assert
            checker.Is(new byte[] { 1, 2 }).Should().BeTrue();
        }

        [Fact]
        public void Is_ShouldReturnFalse_ForEmptySignature()
        {
            // Arrange
            var checker = new OffsetFileSignatureChecker(0, new byte[0]);
            byte[] bytes = { 1, 2, 3 };

            // Act
            bool result = checker.Is(bytes);

            // Assert
            result.Should().BeFalse();
        }
    }
}
