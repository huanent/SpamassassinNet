using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpamassassinNet.Commands;

namespace SpamassassinNetTest.Commands;

[TestClass]
public class TellCommandTest
{
    [TestMethod]
    public void SendTest()
    {
        var client = Helper.CreateClient();
        var mail = Helper.GetRes("spam2.eml");
        var command = new TellCommand(mail)
        {
            MessageClass = MessageClass.Spam,
            Set = DatabaseKind.Local
        };

        var result = client.SendAsync(command).Result;
        Assert.AreEqual(result.Code, 0);
    }
}