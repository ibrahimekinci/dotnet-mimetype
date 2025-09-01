using FluentAssertions;
using MimeType.Services;
using System.Linq;
using Xunit;

namespace MimeType.Tests
{
    public class BuiltInFileTypesTests
    {
        [Fact]
        public void FileTypes_ShouldLoadLazilyAndContainExpectedItems()
        {
            // Act
            var fileTypes = BuiltInFileTypes.FileTypes;

            // Assert
            fileTypes.Any(ft => ft.Mime == "image/png").Should().BeTrue();
        }
    }
}
