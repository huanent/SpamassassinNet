namespace SpamassassinNet.Commands;

public class Symbols : AbstractMessage
{
    public Symbols(string message) : base(message)
    {
    }

    public override string Name => "SYMBOLS";
}