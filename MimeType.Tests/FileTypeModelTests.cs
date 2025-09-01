
using FluentAssertions;
using MimeType.Core.Models;
using MimeType.Infrastructure.FileSignatureCheckers;
using System.Collections.Immutable;
using System.Text;
using Xunit;

namespace MimeType.Tests
{
    public class FileTypeModelTests
    {
        [Fact]
        public void Is_ShouldDelegateToSignature()
        {
            // Arrange
            var signature = new FileSignatureModel(new PrefixFileSignatureChecker("TEST"));
            var model = new FileTypeModel(signature, "test/mime", "test");
            byte[] bytes = Encoding.ASCII.GetBytes("TEST");

            // Act
            bool result = model.Is(bytes);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Properties_ShouldBeSetCorrectly()
        {
            // Arrange
            var signature = new FileSignatureModel();
            var model = new FileTypeModel(signature, "image/test", "ext1", "ext2");

            // Assert
            model.Mime.Should().Be("image/test");
            model.Extensions.Should().BeEquivalentTo(ImmutableHashSet.Create("ext1", "ext2"));
        }
    }
}
