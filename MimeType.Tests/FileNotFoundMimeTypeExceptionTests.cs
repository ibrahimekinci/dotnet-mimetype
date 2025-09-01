using FluentAssertions;
using MimeType.Core.Exceptions;
using Xunit;

namespace MimeType.Tests
{
    public class FileNotFoundMimeTypeExceptionTests
    {
        [Fact]
        public void Constructor_ShouldSetDefaultMessage()
        {
            // Act
            var ex = new FileNotFoundMimeTypeException();

            // Assert
            ex.Message.Should().Be("Invalid or non-readable stream provided.");
        }

        [Fact]
        public void Constructor_ShouldSetCustomMessage()
        {
            // Arrange
            string message = "Custom error";

            // Act
            var ex = new FileNotFoundMimeTypeException(message);

            // Assert
            ex.Message.Should().Be(message);
        }
    }
}
