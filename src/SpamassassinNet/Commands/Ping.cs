namespace SpamassassinNet.Commands;

public class Ping : ICommand
{
    public string Name => "PING";
    public string Message => string.Empty;
}