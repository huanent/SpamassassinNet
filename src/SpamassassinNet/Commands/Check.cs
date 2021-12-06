namespace SpamassassinNet.Commands;

public class Check : AbstractMessage
{
    public override string Name => "CHECK";

    public Check(string message) : base(message)
    {
    }
}