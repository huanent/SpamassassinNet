using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpamassassinNet.CommandResults;
using SpamassassinNet.Commands;

namespace SpamassassinNetTest.Commands;

[TestClass]
public class SkipCommandTest
{
    [TestMethod]
    public void SendTest()
    {
        var client = Helper.CreateClient();
        _ = client.SendAsync(new SkipCommand("xxx")).Result;
    }
}