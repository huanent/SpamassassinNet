namespace SpamassassinNet.CommandResults;

public class BasicResult
{
    private readonly List<string> _headers = new();
    public string Body { get; }
    public IEnumerable<string> Headers => _headers;

    public BasicResult(string content)
    {
        while (true)
        {
            var line = CutSpan(content, out content);

            if (!string.IsNullOrEmpty(line))
            {
                _headers.Add(line);
            }
            else if (line == string.Empty)
            {
                Body = content;
                break;
            }
            else
            {
                break;
            }
        }
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

    public int Code
    {
        get
        {
            var header = _headers.FirstOrDefault(f => f.StartsWith("SPAMD/"));
            CutSpan(header, out header, " ");
            var code = CutSpan(header, out header, " ");
            return int.Parse(code);
        }
    }

    public string Status
    {
        get
        {
            var header = _headers.FirstOrDefault(f => f.StartsWith("SPAMD/"));
            CutSpan(header, out header, " ");
            CutSpan(header, out header, " ");
            return header;
        }
    }

    public long ContentLength
    {
        get
        {
            var header = _headers.FirstOrDefault(f => f.StartsWith("Content-length:"));
            if (header == null) return 0;
            CutSpan(header, out header, " ");
            return long.Parse(header);
        }
    }
}