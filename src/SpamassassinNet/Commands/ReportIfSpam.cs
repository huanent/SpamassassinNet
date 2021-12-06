namespace SpamassassinNet.Commands;

public class ReportIfSpam:AbstractMessage
{
    public ReportIfSpam(string message) : base(message)
    {
    }

    public override string Name => "REPORT_IFSPAM";
}