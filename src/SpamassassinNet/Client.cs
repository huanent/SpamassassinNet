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
            await SendAsync(new Ping());
        } while (await timer.WaitForNextTickAsync(token));
    }

    public async Task<CommandResult> SendAsync(ICommand command)
    {
        var connection = new Connection(_options.Host, _options.Port);
        var messagePack = command.ToMessagePack();
        var result = await connection.SendAsync(messagePack);
        return new CommandResult(result);
    }
}