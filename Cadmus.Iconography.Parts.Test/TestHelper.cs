using Cadmus.Core;
using Cadmus.Core.Layers;
using Cadmus.Refs.Bricks;
using Fusi.Antiquity.Chronology;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Cadmus.Iconography.Parts.Test;

internal static class TestHelper
{
    private static readonly JsonSerializerOptions _options =
        new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

    public static string SerializePart(IPart part)
    {
        ArgumentNullException.ThrowIfNull(part);

        return JsonSerializer.Serialize(part, part.GetType(), _options);
    }

    public static T? DeserializePart<T>(string json)
        where T : class, IPart, new()
    {
        ArgumentNullException.ThrowIfNull(json);

        return JsonSerializer.Deserialize<T>(json, _options);
    }

    public static string SerializeFragment(ITextLayerFragment fr)
    {
        ArgumentNullException.ThrowIfNull(fr);

        return JsonSerializer.Serialize(fr, fr.GetType(), _options);
    }

    public static T? DeserializeFragment<T>(string json)
        where T : class, ITextLayerFragment, new()
    {
        ArgumentNullException.ThrowIfNull(json);

        return JsonSerializer.Deserialize<T>(json, _options);
    }

    public static void AssertPinIds(IPart part, DataPin pin)
    {
        Assert.Equal(part.ItemId, pin.ItemId);
        Assert.Equal(part.Id, pin.PartId);
        Assert.Equal(part.RoleId, pin.RoleId);
    }

    public static List<DocReference> GetDocReferences(int count)
    {
        List<DocReference> citations = [];

        for (int n = 1; n <= count; n++)
        {
            citations.Add(new DocReference
            {
                Citation = "Hom. Il. 1,23",
                Note = $"Note {n}",
                Tag = n % 2 == 0 ? "even" : "odd"
            });
        }
        return citations;
    }

    public static List<Chronotope> GetChronotopes(int count)
    {
        List<Chronotope> chronotopes = [];

        for (int n = 1; n <= count; n++)
        {
            chronotopes.Add(new Chronotope
            {
                Place = $"place-{n}",
                Date = HistoricalDate.Parse(1300 + n + " AD"),
                Tag = "tag"
            });
        }

        return chronotopes;
    }

    public static List<AssertedChronotope> GetAssertedChronotopes(int count)
    {
        List<AssertedChronotope> chronotopes = [];

        for (int n = 1; n <= count; n++)
        {
            chronotopes.Add(new AssertedChronotope
            {
                Place = new AssertedPlace { Value = $"place-{n}" },
                Date = new AssertedHistoricalDate(
                    HistoricalDate.Parse(1300 + n + " AD")!)
            });
        }

        return chronotopes;
    }

    static public bool IsDataPinNameValid(string name) =>
        Regex.IsMatch(name, @"^[a-zA-Z0-9\-_\.]+$");

    static public void AssertValidDataPinNames(IList<DataPin> pins)
    {
        foreach (DataPin pin in pins)
        {
            Assert.True(IsDataPinNameValid(pin.Name!), pin.ToString());
        }
    }
}
