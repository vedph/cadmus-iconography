namespace Cadmus.Iconography.Parts;

/// <summary>
/// An implementation difference with reference to a <see cref="IcoInstruction"/>.
/// </summary>
public class IcoInstructionDiff
{
    /// <summary>
    /// Gets or sets the diff type.
    /// Usually from thesaurus <c>ico-instruction-diff-types</c>.
    /// </summary>
    public string Type { get; set; } = "";

    /// <summary>
    /// Gets or sets the target this diff refers to.
    /// </summary>
    public string? Target { get; set; }

    /// <summary>
    /// Gets or sets the note.
    /// </summary>
    public string? Note { get; set; }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        return $"[{Type}] {Target}";
    }
}
