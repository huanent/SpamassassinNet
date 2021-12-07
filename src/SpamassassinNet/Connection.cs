using System.Net.Sockets;

namespace SpamassassinNet;

internal class Connection
{
    private readonly string? _host;
    private readonly int _port;

    internal Connection(string? host, int port)
    {
        _host = host;
        _port = port;
    }

    internal async Task<string> SendAsync(string message)
    {
        using var client = new TcpClient(AddressFamily.InterNetwork);
        client.SendTimeout = 1000;
        client.ReceiveTimeout = 1000;
        await client.ConnectAsync(_host ?? throw new NullReferenceException(), _port);
        await using var stream = client.GetStream();
        await using var writer = new StreamWriter(stream);
        await writer.WriteAsync(message);
        await writer.FlushAsync();
        client.Client.Shutdown(SocketShutdown.Send);
        using var reader = new StreamReader(stream);
        var result= await reader.ReadToEndAsync();
        client.Client.Shutdown(SocketShutdown.Both);
        return result;
    }
}