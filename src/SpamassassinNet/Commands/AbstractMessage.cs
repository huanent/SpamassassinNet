namespace SpamassassinNet.Commands;

public abstract class AbstractMessage:ICommand
{
    protected AbstractMessage(string message)
    {
        Message = message;
    }

    public abstract string Name { get; }
    public string Message { get; }
}