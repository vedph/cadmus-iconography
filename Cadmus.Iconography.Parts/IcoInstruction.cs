using Cadmus.Refs.Bricks;
using Fusi.Antiquity.Chronology;
using System.Collections.Generic;
using System.Text;

namespace Cadmus.Iconography.Parts;

/// <summary>
/// Instruction to the artist.
/// </summary>
public class IcoInstruction : IHasAssertion
{
    /// <summary>
    /// Gets or sets the optional entity ID to assign to this instruction.
    /// </summary>
    public string? Eid { get; set; }

    /// <summary>
    /// Gets or sets the instruction type(s).
    /// Usually from thesaurus <c>ico-instruction-types</c>.
    /// </summary>
    public List<TaggedString> Types { get; set; } = [];

    /// <summary>
    /// Gets or sets the subject specific to this instruction (e.g. a character
    /// inside an illumination).
    /// </summary>
    public string? Subject { get; set; }

    /// <summary>
    /// Gets or sets the script type.
    /// Usually from thesaurus <c>ico-instruction-scripts</c>.
    /// </summary>
    public string Script { get; set; } = "";

    /// <summary>
    /// Gets or sets the transcribed text of this instruction.
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    /// Gets or sets the sequences of symbols used in marking spots in the
    /// illumination area and referred to by this instruction (e.g. A, B, C...
    /// or any other symbols).
    /// </summary>
    public List<string>? Sequences { get; set; }

    /// <summary>
    /// Gets or sets the reference repertoire.
    /// </summary>
    public string? Repertoire { get; set; }

    /// <summary>
    /// Gets or sets the location.
    /// </summary>
    public string Location { get; set; } = "";

    /// <summary>
    /// Gets or sets the position relative to the manuscript's page (e.g.
    /// left margin, bottom, etc.).
    /// Usually from thesaurus <c>ico-instruction-positions</c>.
    /// </summary>
    public string Position { get; set; } = "";

    /// <summary>
    /// Gets or sets a note about <see cref="Position"/>.
    /// </summary>
    public string? PositionNote { get; set; }

    /// <summary>
    /// Gets or sets the target location of the instruction. This is used
    /// when the instructions are not where they should be with reference to
    /// the target (e.g. in a ms. the instruction is at "12r" but the
    /// image it targets is at "12v").
    /// </summary>
    public string? TargetLocation { get; set; }

    /// <summary>
    /// Gets or sets the description of the implementation of this instruction.
    /// </summary>
    public string? Implementation { get; set; }

    /// <summary>
    /// Gets or sets the implementation differences with reference to this
    /// instruction.
    /// </summary>
    public List<IcoInstructionDiff>? Differences { get; set; }

    /// <summary>
    /// Gets or sets the note.
    /// </summary>
    public string? Note { get; set; }

    /// <summary>
    /// Gets or sets a generic narrative description of this instruction.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets a set of binary features attached to this instruction.
    /// Usually from thesaurus <c>ico-instruction-feats</c>.
    /// </summary>
    public List<string>? Features { get; set; }

    /// <summary>
    /// Gets or sets the language(s) used in this instruction.
    /// Usually from thesaurus <c>ico-instruction-languages</c>.
    /// </summary>
    public List<string> Languages { get; set; } = [];

    /// <summary>
    /// Gets or sets the tool(s) used to create this instruction.
    /// Usually from thesaurus <c>ico-instruction-tools</c>.
    /// </summary>
    public List<string>? Tools { get; set; }

    /// <summary>
    /// Gets or sets the color(s) used in this instruction.
    /// Usually from thesaurus <c>ico-instruction-colors</c>.
    /// </summary>
    public List<string>? Colors { get; set; }

    /// <summary>
    /// Gets or sets the reuses of the colors of this instruction in other
    /// sheets of the same or other manuscript.
    /// </summary>
    public List<IcoColorReuse>? ColorReuses { get; set; }

    /// <summary>
    /// Gets or sets the links to various entities related to this instruction,
    /// like e.g. figurative subjects.
    /// </summary>
    public List<AssertedCompositeId>? Links { get; set; }

    /// <summary>
    /// Gets or sets the date of this instruction.
    /// </summary>
    public HistoricalDate? Date { get; set; }

    /// <summary>
    /// Gets or sets the confidence level assertion for the description of
    /// this instruction.
    /// </summary>
    public Assertion? Assertion { get; set; }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>String.</returns>
    public override string ToString()
    {
        StringBuilder sb = new();

        sb.Append('[');
        sb.AppendJoin(", ", Types);
        sb.Append("] ");

        sb.Append(Location).Append(" (").Append(Position).Append(')');

        return sb.ToString();
    }
}
