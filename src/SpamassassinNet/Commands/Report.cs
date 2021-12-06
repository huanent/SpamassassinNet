using SpamassassinNet.CommandResults;

namespace SpamassassinNet.Commands;

public class Report : AbstractMessage<CheckResult>
{
    public Report(string message) : base(message)
    {
    }

    public override string Name => "REPORT";
}