using SpamassassinNet.CommandResults;

namespace SpamassassinNet.Commands;

public class Skip : AbstractMessage<ResultBase>
{
    public Skip(string message) : base(message)
    {
    }

    public override string Name => "SKIP";
}