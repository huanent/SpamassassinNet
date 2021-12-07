using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpamassassinNet.CommandResults;
using SpamassassinNet.Commands;

namespace SpamassassinNetTest;

[TestClass]
public class ClientTest
{
    [TestMethod]
    public void SendTest()
    {
        var client = Helper.CreateClient();
        var result = client.SendAsync(new PingCommand()).Result;
        Assert.AreEqual(result.Code, 0);
        Assert.AreEqual(result.Status, "PONG");
        
        var result2 = client.SendAsync(new PingCommand()).Result;
        Assert.AreEqual(result2.Code, 0);
        Assert.AreEqual(result2.Status, "PONG");
    }
}