using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpamassassinNetTest;

[TestClass]
public class CommandResultTest
{
    [TestMethod]
    public void CutOneLineNotWrapTest()
    {
        var content = "SPAMD/1.5 0 PONG";
        var result = CommandResult.CutSpan(content, out var surplus);
        Assert.IsNull(result);
        Assert.AreEqual(surplus, content);
    }

    [TestMethod]
    public void CutOneLineTest()
    {
        var content = "SPAMD/1.5 0 PONG\r\n";
        var result = CommandResult.CutSpan(content, out var surplus);
        Assert.AreEqual(result, "SPAMD/1.5 0 PONG");
        Assert.AreEqual(surplus, string.Empty);
    }
}