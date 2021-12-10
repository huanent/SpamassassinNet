## The [SpamAssassin Network Protocol](https://svn.apache.org/repos/asf/spamassassin/trunk/spamd/PROTOCOL) dotnet implementation
![Nuget](https://img.shields.io/nuget/v/SpamassassinNet?style=for-the-badge)
### Usage

```
ClientOptions options = new()
{
    Host = 127.0.0.1,
    Port = 783,
    User = "spamd"
};

var client= new Client(options);
var result = await client.SendAsync(new PingCommand());
```

### Support commands
- CheckCommand
- PingCommand
- ProcessCommand
- ReportCommand
- ReportIfSpamCommand
- SkipCommand
- SymbolsCommand
- TellCommand