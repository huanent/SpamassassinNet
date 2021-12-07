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
        for (int i = 0; i < 20; i++)
        {
            var result = client.SendAsync(new PingCommand()).Result;
            Assert.AreEqual(result.Code, 0);
            Assert.AreEqual(result.Status, "PONG");
        }
    }
}