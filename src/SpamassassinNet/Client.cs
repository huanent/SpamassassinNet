using SpamassassinNet.CommandResults;
using SpamassassinNet.Commands;

namespace SpamassassinNet;

public class Client
{
    private readonly ClientOptions _options;

    public Client(ClientOptions options)
    {
        _options = options;

        if (_options.EnableHeartbeat)
        {
            _ = StartHeartbeatAsync();
        }
    }

    private async Task StartHeartbeatAsync(CancellationToken token = default)
    {
        var timer = new PeriodicTimer(_options.HeartbeatInterval);

        do
        {
            await SendAsync<BasicResult>(new Ping());
        } while (await timer.WaitForNextTickAsync(token));
    }

    public async Task<T?> SendAsync<T>(ICommand command) where T : BasicResult
    {
        var connection = new Connection(_options.Host, _options.Port);
        var messagePack = command.ToMessagePack();
        var result = await connection.SendAsync(messagePack);
        return (T?) Activator.CreateInstance(typeof(T), result);
    }
}