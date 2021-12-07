using System;
using System.IO;

namespace SpamassassinNetTest;

public static class Helper
{
    public static Client CreateClient()
    {
        ClientOptions options = new()
        {
            Host = TestConfig.Host,
            Port = TestConfig.Port,
            User = "spamd"
        };

        return new Client(options);
    }

    public static string GetRes(string path)
    {
        return File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "res", path));
    }
}