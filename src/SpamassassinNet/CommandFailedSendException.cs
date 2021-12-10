namespace SpamassassinNet;

public class CommandFailedSendException : Exception
{
    public CommandFailedSendException(Exception innerException)
        : base("Command sen to remote spam assassin server failed!", innerException)
    {
    }
}