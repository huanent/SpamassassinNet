using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpamassassinNetTest;

[TestClass]
public class ConnectionTest
{
    [TestMethod]
    public void SendTest()
    {
        var connection = new Connection(TestConfig.Host, TestConfig.Port);
        var rsp = connection.SendAsync("PING SPAMC/1.5\r\nContent-length: 0\r\n\r\n").Result;
        Assert.AreEqual(rsp, "SPAMD/1.5 0 PONG\r\n");
    }
}