using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Cadmus.Core;
using Fusi.Tools.Configuration;

namespace Cadmus.Iconography.Parts;

/// <summary>
/// Iconography instructions part.
/// <para>Tag: <c>it.vedph.iconography.instructions</c>.</para>
/// </summary>
[Tag("it.vedph.iconography.instructions")]
public sealed class IcoInstructionsPart : PartBase
{
    /// <summary>
    /// Gets or sets the entries.
    /// </summary>
    public List<IcoInstruction> Instructions { get; set; } = [];

    /// <summary>
    /// Get all the key=value pairs (pins) exposed by the implementor.
    /// </summary>
    /// <param name="item">The optional item. The item with its parts
    /// can optionally be passed to this method for those parts requiring
    /// to access further data.</param>
    /// <returns>The pins: <c>tot-count</c> and a collection of pins.</returns>
    public override IEnumerable<DataPin> GetDataPins(IItem? item = null)
    {
        DataPinBuilder builder = new(DataPinHelper.DefaultFilter);

        builder.Set("tot", Instructions?.Count ?? 0, false);

        if (Instructions?.Count > 0)
        {
            int diffCount = 0;
            HashSet<string> types = [];
            HashSet<string> positions = [];
            HashSet<string> scripts = [];
            HashSet<string> features = [];
            HashSet<string> languages = [];
            HashSet<double> dates = [];

            foreach (IcoInstruction entry in Instructions)
            {
                if (entry.Eid != null) builder.AddValue("eid", entry.Eid);

                foreach (string type in entry.Types) types.Add(type);
                positions.Add(entry.Position);
                if (entry.Script is not null) scripts.Add(entry.Script);

                if (entry.Differences?.Count > 0)
                    diffCount += entry.Differences.Count;

                if (entry.Features?.Count > 0)
                {
                    foreach (string feature in entry.Features)
                        features.Add(feature);
                }

                if (entry.Languages?.Count > 0)
                {
                    foreach (string lang in entry.Languages)
                        languages.Add(lang);
                }

                if (entry.Date is not null)
                    dates.Add(entry.Date.GetSortValue());
            }

            if (types.Count > 0) builder.AddValues("type", types);
            if (positions.Count > 0) builder.AddValues("position", positions);
            if (scripts.Count > 0) builder.AddValues("script", scripts);
            if (diffCount > 0) builder.AddValue("diff-count", diffCount);
            if (features.Count > 0) builder.AddValues("feature", features);
            if (languages.Count > 0) builder.AddValues("lang", languages);
            if (dates.Count > 0)
            {
                builder.AddValues("date-value", dates.Select(
                    n => n.ToString(CultureInfo.InvariantCulture)));
            }
        }

        return builder.Build(this);
    }

    /// <summary>
    /// Gets the definitions of data pins used by the implementor.
    /// </summary>
    /// <returns>Data pins definitions.</returns>
    public override IList<DataPinDefinition> GetDataPinDefinitions()
    {
        return
        [
            new DataPinDefinition(DataPinValueType.String,
                "eid",
                "The instruction EID.",
                "M"),
            new DataPinDefinition(DataPinValueType.String,
                "type",
                "The instruction type.",
                "M"),
            new DataPinDefinition(DataPinValueType.String,
                "position",
                "The position relative to the manuscript's page.",
                "M"),
            new DataPinDefinition(DataPinValueType.String,
                "script",
                "The script type.",
                "M"),
            new DataPinDefinition(DataPinValueType.Integer,
                "diff-count",
                "The total count of implementation differences."),
            new DataPinDefinition(DataPinValueType.String,
                "feature",
                "An instruction's feature.",
                "M"),
            new DataPinDefinition(DataPinValueType.String,
                "lang",
                "The language of the instruction.",
                "M"),
            new DataPinDefinition(DataPinValueType.Decimal,
                "date-value",
                "The date value.",
                "M"),
            new DataPinDefinition(DataPinValueType.Integer,
               "tot-count",
               "The total count of entries.")
        ];
    }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        StringBuilder sb = new();

        sb.Append("[CodIllumInstructions]");

        if (Instructions?.Count > 0)
        {
            sb.Append(' ');
            int n = 0;
            foreach (var entry in Instructions)
            {
                if (++n > 3) break;
                if (n > 1) sb.Append("; ");
                sb.Append(entry);
            }
            if (Instructions.Count > 3)
                sb.Append("...(").Append(Instructions.Count).Append(')');
        }

        return sb.ToString();
    }
}
