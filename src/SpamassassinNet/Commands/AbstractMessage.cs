using SpamassassinNet.CommandResults;

namespace SpamassassinNet.Commands;

public abstract class AbstractMessage<T> : ICommand<T> where T : ResultBase
{
    protected AbstractMessage(string message)
    {
        Message = message;
    }

    public abstract string Name { get; }
    public string Message { get; }
}