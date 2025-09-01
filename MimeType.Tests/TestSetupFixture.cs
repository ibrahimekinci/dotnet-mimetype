using System.Threading.Tasks;
using Xunit;

namespace MimeType.Tests
{
    public class TestSetupFixture : IAsyncLifetime
    {
        public Task InitializeAsync()
        {
            return TestSetup.EnsureTestFilesAsync();
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
