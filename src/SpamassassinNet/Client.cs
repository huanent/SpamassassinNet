using SpamassassinNet.CommandResults;
using SpamassassinNet.Commands;

namespace SpamassassinNet;

public class Client
{
    private readonly ClientOptions _options;

    public Client(ClientOptions options)
    {
        _options = options;
    }

    public async Task<T?> SendAsync<T>(ICommand<T> command) where T : ResultBase
    {
        var connection = new Connection(_options.Host, _options.Port);
        var messagePack = command.ToMessagePack();
        var result = await connection.SendAsync(messagePack);
        return (T?) Activator.CreateInstance(typeof(T), result);
    }
}