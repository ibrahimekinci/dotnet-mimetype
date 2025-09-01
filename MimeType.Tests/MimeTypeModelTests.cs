using FluentAssertions;
using MimeType.Core.Models;
using System.Collections.Immutable;
using Xunit;

namespace MimeType.Tests
{
    public class MimeTypeModelTests
    {
        [Fact]
        public void Properties_ShouldBeSetCorrectly()
        {
            // Arrange
            var model = new MimeTypeModel("application/test", "ext1", "ext2");

            // Assert
            model.Mime.Should().Be("application/test");
            model.Extensions.Should().BeEquivalentTo(ImmutableHashSet.Create("ext1", "ext2"));
        }
    }
}
