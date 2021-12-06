using SpamassassinNet.CommandResults;

namespace SpamassassinNet.Commands;

public class Ping : ICommand<BasicResult>
{
    public string Name => "PING";
    public string Message => string.Empty;
}