using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpamassassinNet.CommandResults;
using SpamassassinNet.Commands;

namespace SpamassassinNetTest.Commands;

[TestClass]
public class PingTest
{
    [TestMethod]
    public void Send()
    {
        var client = Helper.CreateClient();
        var result = client.SendAsync<BasicResult>(new Ping()).Result;
        Assert.AreEqual(result.Code, 0);
        Assert.IsNotNull(result.Status, "PONG");
    }
}