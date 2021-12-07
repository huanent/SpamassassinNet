namespace SpamassassinNet;

public class ClientOptions
{
    public string? Host { get; set; }
    public int Port { get; set; }
    public string ProtocolVersion { get; set; } = "1.5";
    public string? User { get; set; }
}