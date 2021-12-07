using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpamassassinNet.CommandResults;
using SpamassassinNet.Commands;

namespace SpamassassinNetTest.Commands;

[TestClass]
public class ReportCommandTest
{
    [TestMethod]
    public void SendTest()
    {
        var client = Helper.CreateClient();
        var mail = Helper.GetRes("spam1.eml");
        var result = client.SendAsync(new ReportCommand(mail)).Result;
        Assert.AreEqual(result.Code, 0);
        Assert.IsFalse(result.Spam);
        Assert.IsNotNull(result.Score);
        Assert.IsNotNull(result.Body);
    }
    
    [TestMethod]
    public void SendErrorMailContentTest()
    {
        var client = Helper.CreateClient();
        var result = client.SendAsync(new ReportCommand("xxx")).Result;
        Assert.AreEqual(result.Code, 0);
        Assert.IsTrue(result.Spam);
        Assert.IsNotNull(result.Score);
        Assert.IsNotNull(result.Body);
    }
}