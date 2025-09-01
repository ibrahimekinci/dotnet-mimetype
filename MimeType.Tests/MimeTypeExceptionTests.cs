using FluentAssertions;
using MimeType.Core.Exceptions;
using Xunit;

namespace MimeType.Tests
{
    public class MimeTypeExceptionTests
    {
        [Fact]
        public void Constructor_ShouldSetMessage()
        {
            // Arrange
            string message = "Test error";

            // Act
            var ex = new MimeTypeException(message);

            // Assert
            ex.Message.Should().Be(message);
        }
    }
}
