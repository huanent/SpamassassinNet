using SpamassassinNet.CommandResults;

namespace SpamassassinNet.Commands;

public class Check : AbstractMessage<CheckResult>
{
    public override string Name => "CHECK";

    public Check(string message) : base(message)
    {
    }
}