using System.Text;
using SpamassassinNet.CommandResults;

namespace SpamassassinNet;

public interface ICommand<T> where T : ResultBase
{
    string Name { get; }

    string Message { get; }

    public string ToMessagePack()
    {
        var commandBuilder = new StringBuilder();
        commandBuilder.Append($"{Name} SPAMC/1.5\r\n");
        commandBuilder.Append($"Content-length: {Message.Length}\r\n");
        commandBuilder.Append($"\r\n");
        commandBuilder.Append(Message);
        return commandBuilder.ToString();
    }
}