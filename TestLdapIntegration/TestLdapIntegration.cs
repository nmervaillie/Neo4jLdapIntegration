using System;
using System.Threading.Tasks;
using Neo4j.Driver;
using NUnit.Framework;

namespace TestLdapIntegration
{
    public class Tests
    {
        private IDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = GraphDatabase.Driver("neo4j://localhost:37687", AuthTokens.Basic("architect", "changeme"),
                config => config
                    .WithMaxConnectionPoolSize(3));
        }

        [Test]
        public async Task ShouldNotFailOnAuthorizationException()
        {
            for (var i = 0; i < 50; i++)
            {
                string ret;
                var session = _driver.AsyncSession();

                try
                {
                    await session.WriteTransactionAsync(async tx =>
                    {
                        await tx.RunAsync(@"CALL apoc.util.sleep(500)");
                    });
                }
                finally
                {
                    await session.CloseAsync();
                }

                Console.Write($"{i} ");
            }
        }
    }
}