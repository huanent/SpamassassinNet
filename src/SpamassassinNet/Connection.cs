using System.Net.Sockets;
using System.Text;

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
        var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        
        try
        {
            await socket.ConnectAsync(_host ?? throw new NullReferenceException(), _port);
            var messagePack = Encoding.ASCII.GetBytes(message);
            await socket.SendAsync(messagePack.AsMemory(), SocketFlags.None);
            socket.Shutdown(SocketShutdown.Send);
            var buffer = new Memory<byte>(new byte[1025 * 512]);
            var resultPack = new List<byte>();

            while (true)
            {
                var length = await socket.ReceiveAsync(buffer, SocketFlags.None);
                if (length == 0) break;
                resultPack.AddRange(buffer[..length].ToArray());
            }

            var result = Encoding.ASCII.GetString(resultPack.ToArray());
            return result;
        }
        finally
        {
            socket.Close();
        }
    }
}