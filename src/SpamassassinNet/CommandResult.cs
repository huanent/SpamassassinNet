namespace SpamassassinNet;

public class CommandResult
{
    public CommandResult(string content)
    {
        var statusLine = CutSpan(content, out content);
        ParseStatusLine(statusLine ?? throw new NullReferenceException());
        var contentLengthLine = CutSpan(content, out content);
        if (contentLengthLine == null) return;
        ParseContentLength(contentLengthLine);
        var otherHeader = CutSpan(content, out content, "\r\n\r\n");
        if (otherHeader == null) return;
        Message = content;
    }

    internal static string? CutSpan(string content, out string surplus, string separator = "\r\n")
    {
        var index = content.IndexOf(separator, StringComparison.Ordinal);

        if (index < 0)
        {
            surplus = content;
            return null;
        }

        surplus = content[(index + separator.Length)..];
        var line = content[..index];
        return line;
    }

    internal void ParseStatusLine(string content)
    {
        //content like: SPAMD/1.1 0 EX_OK
        CutSpan(content, out content, " ");
        var code = CutSpan(content, out content, " ");
        Code = int.Parse(code ?? throw new NullReferenceException());
        Status = content;
    }

    internal void ParseContentLength(string content)
    {
        //content like: Content-length: 123
        CutSpan(content, out content, " ");
        ContentLength = long.Parse(content ?? throw new NullReferenceException());
    }

    public int Code { get; internal set; }
    public string Status { get; internal set; }
    public long ContentLength { get; internal set; }
    public string Message { get; private set; }
}