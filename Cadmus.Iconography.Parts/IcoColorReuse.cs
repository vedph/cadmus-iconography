namespace Cadmus.Iconography.Parts;

/// <summary>
/// The reuse of a color in an iconographic instruction.
/// </summary>
public class IcoColorReuse
{
    /// <summary>
    /// Gets or sets the reused color. This refers to
    /// <see cref="IcoInstruction.Colors"/>.
    /// </summary>
    public string Color { get; set; } = "";

    /// <summary>
    /// Gets or sets the location corresponding to the reuse.
    /// </summary>
    public string? Location { get; set; }

    /// <summary>
    /// Gets or sets a generic note about the reuse.
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
        return $"{Color}" + (string.IsNullOrEmpty(Note) ? "" : ": " + Note);
    }
}
