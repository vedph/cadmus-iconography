using Bogus;
using Cadmus.Mat.Bricks;
using Cadmus.Refs.Bricks;
using Fusi.Antiquity.Chronology;
using System;
using System.Collections.Generic;

namespace Cadmus.Seed.Iconography.Parts;

internal static class SeedHelper
{
    /// <summary>
    /// Truncates the specified value to the specified number of decimals.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="decimals">The decimals.</param>
    /// <returns>Truncated value.</returns>
    private static float Truncate(float value, int decimals)
    {
        double factor = Math.Pow(10, decimals);
        return (float)((float)Math.Truncate(factor * value) / factor);
    }

    public static List<string> GetLocationRanges(int count, Faker faker)
    {
        List<string> locs = new(count);
        for (int n = 1; n <= count; n++)
        {
            int start = faker.Random.Number(1, 20);
            bool startVerso = faker.Random.Bool();
            int end = faker.Random.Number(21, 40);
            bool endVerso = faker.Random.Bool();

            locs.Add($"{start}{(startVerso ? "v" : "r")}-{end}{(endVerso ? "v" : "r")}");
        }
        return locs;
    }

    public static string GetLocationRange(Faker faker)
        => GetLocationRanges(1, faker)[0];

    public static string GetLocation(Faker faker)
    {
        int n = faker.Random.Number(1, 20);
        bool v = faker.Random.Bool();
        return $"{n}{(v ? "v" : "r")}";
    }

    /// <summary>
    /// Gets a random number of document references.
    /// </summary>
    /// <param name="count">The number of references to get.</param>
    /// <returns>References.</returns>
    public static List<DocReference> GetDocReferences(int count)
    {
        List<DocReference> refs = [];

        for (int n = 1; n <= count; n++)
        {
            refs.Add(new Faker<DocReference>()
                .RuleFor(r => r.Tag, f => f.PickRandom(null, "tag"))
                .RuleFor(r => r.Type, "biblio")
                .RuleFor(r => r.Citation,
                    f => f.Person.LastName + " " + f.Date.Past(10).Year)
                .RuleFor(r => r.Note, f => f.Lorem.Sentence())
                .Generate());
        }

        return refs;
    }

    public static List<ExternalId> GetExternalIds(int count)
    {
        List<ExternalId> ids = [];

        for (int n = 1; n <= count; n++)
        {
            ids.Add(new Faker<ExternalId>()
                .RuleFor(r => r.Tag, f => f.PickRandom(null, "tag"))
                .RuleFor(r => r.Scope, f => f.Lorem.Word())
                .RuleFor(r => r.Value, f => f.Internet.Url())
                .Generate());
        }

        return ids;
    }

    public static List<AssertedId> GetAssertedIds(int count)
    {
        List<AssertedId> ids = [];

        for (int n = 1; n <= count; n++)
        {
            ids.Add(new Faker<AssertedId>()
                .RuleFor(r => r.Tag, f => f.PickRandom(null, "tag"))
                .RuleFor(r => r.Scope, f => f.Lorem.Word())
                .RuleFor(r => r.Value, f => f.Internet.Url())
                .RuleFor(r => r.Assertion, GetAssertion())
                .Generate());
        }

        return ids;
    }

    public static List<AssertedCompositeId> GetAssertedCompositeIds(int count)
    {
        List<AssertedCompositeId> ids = [];

        for (int n = 1; n <= count; n++)
        {
            ids.Add(new Faker<AssertedCompositeId>()
                .RuleFor(r => r.Tag, f => f.PickRandom(null, "tag"))
                .RuleFor(r => r.Scope, f => f.Lorem.Word())
                .RuleFor(r => r.Target, f =>
                    new PinTarget
                    {
                        Gid = f.Internet.Url(),
                        Label = $"n{n}"
                    })
                .RuleFor(r => r.Assertion, GetAssertion())
                .Generate());
        }

        return ids;
    }

    public static Assertion GetAssertion()
    {
        return new Faker<Assertion>()
            .RuleFor(a => a.Tag, f => f.PickRandom("a", "b", null))
            .RuleFor(a => a.Rank, f => f.Random.Short(1, 3))
            .RuleFor(a => a.References, GetDocReferences(2))
            .RuleFor(a => a.Note, f => f.Lorem.Sentence().OrNull(f))
            .Generate();
    }

    public static List<AssertedChronotope> GetAssertedChronotopes(int count)
    {
        List<AssertedChronotope> chronotopes = [];
        for (int n = 1; n <= count; n++)
        {
            bool even = n % 2 == 0;
            chronotopes.Add(new AssertedChronotope
            {
                Place = new AssertedPlace
                {
                    Value = even ? "Even" : "Odd"
                },
                Date = new AssertedDate(HistoricalDate.Parse($"{1300 + n} AD")!)
            });
        }
        return chronotopes;
    }

    public static List<PhysicalDimension> GetDimensions(int count)
    {
        List<PhysicalDimension> dimensions = [];

        for (int n = 1; n <= count; n++)
        {
            dimensions.Add(new Faker<PhysicalDimension>()
                .RuleFor(d => d.Tag, f => f.Lorem.Word())
                .RuleFor(d => d.Value, f => Truncate(f.Random.Float(2, 10), 2))
                .RuleFor(d => d.Unit, "cm")
                .Generate());
        }

        return dimensions;
    }

    public static PhysicalSize GetPhysicalSize()
    {
        List<PhysicalDimension> dimensions = GetDimensions(2);

        Faker faker = new();
        return new PhysicalSize
        {
            Tag = "tag",
            W = dimensions[0],
            H = dimensions[1],
            Note = faker.Random.Bool(0.25f)? faker.Lorem.Sentence() : null
        };
    }
}
