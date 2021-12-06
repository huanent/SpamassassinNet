using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpamassassinNet.CommandResults;
using SpamassassinNet.Commands;

namespace SpamassassinNetTest.Commands;

[TestClass]
public class ReportTest
{
    [TestMethod]
    public void SendTest()
    {
        var client = Helper.CreateClient();
        var mail = Helper.GetRes("spam.eml");
        var result = client.SendAsync(new Report(mail)).Result;
        Assert.AreEqual(result.Code, 0);
        Assert.IsFalse(result.Spam);
        Assert.IsNotNull(result.Score);
        Assert.IsNotNull(result.Body);
    }
    
    [TestMethod]
    public void SendErrorMailContentTest()
    {
        var client = Helper.CreateClient();
        var result = client.SendAsync(new Report("xxx")).Result;
        Assert.AreEqual(result.Code, 0);
        Assert.IsTrue(result.Spam);
        Assert.IsNotNull(result.Score);
        Assert.IsNotNull(result.Body);
    }
}