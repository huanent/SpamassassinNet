using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpamassassinNet.Commands;

namespace SpamassassinNetTest;

[TestClass]
public class ClientTest
{
    private readonly ClientOptions _options = new()
    {
        Host = TestConfig.Host,
        Port = TestConfig.Port,
        EnableHeartbeat = true
    };

    [TestMethod]
    public void Send()
    {
        var client = new Client(_options);
        var result = client.SendAsync(new Ping()).Result;
        Assert.AreEqual(result.Code, 0);
        Assert.AreEqual(result.Status, "PONG");
    }
}