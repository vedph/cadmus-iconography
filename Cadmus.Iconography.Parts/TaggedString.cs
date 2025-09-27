namespace Cadmus.Iconography.Parts;

/// <summary>
/// A string with an optional tag.
/// </summary>
public class TaggedString
{
    public string? Tag { get; set; }
    public string Value { get; set; } = "";

    public override string ToString()
    {
        return string.IsNullOrEmpty(Tag)? Value : $"{Value} ({Tag})";
    }
}
