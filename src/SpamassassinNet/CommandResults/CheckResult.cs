namespace SpamassassinNet.CommandResults;

public class CheckResult : BasicResult
{
    public CheckResult(string content) : base(content)
    {
    }

    public bool? Spam
    {
        get
        {
            var header = Headers.FirstOrDefault(f => f.StartsWith("Spam:"));
            if (header == null) return null;
            CutSpan(header, out header, ":");
            var spam = CutSpan(header, out header, ";");
            return bool.Parse(spam);
        }
    }

    public string? Score
    {
        get
        {
            var header = Headers.FirstOrDefault(f => f.StartsWith("Spam:"));
            if (header == null) return null;
            CutSpan(header, out header, ";");
            return header;
        }
    }
}