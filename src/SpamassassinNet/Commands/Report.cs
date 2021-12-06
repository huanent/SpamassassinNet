namespace SpamassassinNet.Commands;

public class Report:AbstractMessage
{
    public Report(string message) : base(message)
    {
    }

    public override string Name => "REPORT";
}