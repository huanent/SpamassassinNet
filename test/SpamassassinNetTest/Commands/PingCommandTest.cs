using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpamassassinNet.CommandResults;
using SpamassassinNet.Commands;

namespace SpamassassinNetTest.Commands;

[TestClass]
public class PingCommandTest
{
    [TestMethod]
    public void SendTest()
    {
        var client = Helper.CreateClient();
        var result = client.SendAsync(new PingCommand()).Result;
        Assert.AreEqual(result.Code, 0);
        Assert.IsNotNull(result.Status, "PONG");
    }
}