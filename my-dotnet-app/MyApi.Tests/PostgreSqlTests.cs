using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using Xunit;

public class PostgreSqlTests
{
    [Fact]
    public async Task CanStartPostgres()
    {
        var postgres = new TestcontainersBuilder<PostgreSqlTestcontainer>()
            .WithDatabase(new PostgreSqlTestcontainerConfiguration
            {
                Database = "testdb",
                Username = "testuser",
                Password = "testpass"
            })
            .WithImage("postgres:15-alpine")
            .WithCleanUp(true)
            .Build();

        await postgres.StartAsync();

        Assert.True(postgres.IsRunning);

        await postgres.StopAsync();
    }
}