using FluentAssertions;
using MimeType.Services;
using System.Linq;
using Xunit;

namespace MimeType.Tests
{
    public class BuiltInMimeTypesTests
    {
        [Fact]
        public void MimeTypes_ShouldLoadLazilyAndContainExpectedItems()
        {
            // Act
            var mimeTypes = BuiltInMimeTypes.MimeTypes;

            // Assert
            mimeTypes.Should().HaveCountGreaterThan(300); // Approximate, as per code
            mimeTypes.Any(mt => mt.Mime == "application/json").Should().BeTrue();
        }
    }
}
