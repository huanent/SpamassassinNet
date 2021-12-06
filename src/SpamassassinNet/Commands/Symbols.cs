using SpamassassinNet.CommandResults;

namespace SpamassassinNet.Commands;

public class Symbols : AbstractMessage<CheckResult>
{
    public Symbols(string message) : base(message)
    {
    }

    public override string Name => "SYMBOLS";
}