using SpamassassinNet.CommandResults;

namespace SpamassassinNet.Commands;

public class ReportIfSpam : AbstractMessage<ReportIfSpamResult>
{
    public ReportIfSpam(string message) : base(message)
    {
    }

    public override string Name => "REPORT_IFSPAM";
}