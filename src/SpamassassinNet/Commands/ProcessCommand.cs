using SpamassassinNet.CommandResults;

namespace SpamassassinNet.Commands;

public class ProcessCommand : CommandBase<ResultBase>
{
    public ProcessCommand(string body)
    {
        Body = body;
    }

    protected override string Name => "PROCESS";
    protected override string Body { get; }
}