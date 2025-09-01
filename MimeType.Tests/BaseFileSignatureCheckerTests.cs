using FluentAssertions;
using MimeType.Infrastructure.FileSignatureCheckers;
using Xunit;

namespace MimeType.Tests
{
    public class BaseFileSignatureCheckerTests
    {
        [Fact]
        public void AsciiBytes_ShouldConvertStringToBytes()
        {
            // Act
            var bytes = BaseFileSignatureChecker.AsciiBytes("TEST");

            // Assert
            bytes.ToArray().Should().BeEquivalentTo(new byte[] { 84, 69, 83, 84 });
        }

        [Fact]
        public void AsciiBytes_ShouldReturnNull_ForEmptyString()
        {
            // Act
            var bytes = BaseFileSignatureChecker.AsciiBytes(string.Empty);

            // Assert
            bytes.ToArray().Should().BeNullOrEmpty();
        }
    }
}
