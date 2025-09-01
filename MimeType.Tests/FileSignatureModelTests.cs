
using FluentAssertions;
using MimeType.Core.Models;
using MimeType.Infrastructure.FileSignatureCheckers;
using System;
using System.Text;
using Xunit;

namespace MimeType.Tests
{
    public class FileSignatureModelTests
    {
        [Fact]
        public void Is_ShouldReturnTrue_IfAnyCheckerMatches()
        {
            // Arrange
            var checker1 = new PrefixFileSignatureChecker("NO");
            var checker2 = new PrefixFileSignatureChecker("YES");
            var model = new FileSignatureModel(checker1, checker2);
            byte[] bytes = Encoding.ASCII.GetBytes("YES");

            // Act
            bool result = model.Is(bytes);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Is_ShouldReturnFalse_IfNoCheckerMatches()
        {
            // Arrange
            var checker = new PrefixFileSignatureChecker("NO");
            var model = new FileSignatureModel(checker);
            byte[] bytes = Encoding.ASCII.GetBytes("YES");

            // Act
            bool result = model.Is(bytes);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Is_ShouldReturnFalse_ForNullOrEmptyBytes()
        {
            // Arrange
            var model = new FileSignatureModel(new PrefixFileSignatureChecker("TEST"));

            // Act
            bool nullResult = model.Is(null!);
            bool emptyResult = model.Is(Array.Empty<byte>());

            // Assert
            nullResult.Should().BeFalse();
            emptyResult.Should().BeFalse();
        }
    }
}
