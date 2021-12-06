namespace SpamassassinNet;

public class ClientOptions
{
    public string? Host { get; set; }
    public int Port { get; set; }
    public bool EnableHeartbeat { get; set; } = true;
    public TimeSpan HeartbeatInterval { get; set; } = TimeSpan.FromSeconds(5);
}