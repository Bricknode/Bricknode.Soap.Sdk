namespace Bricknode.MigrationTestClient;

/// <summary>A demo runner drives a fixed set of read-only calls against one SDK flavour.</summary>
internal interface IDemoRunner
{
    /// <summary>Display name of the SDK being exercised ("SOAP" / "REST").</summary>
    string Name { get; }

    Task RunAsync(AppConfig config);
}

/// <summary>
/// Console formatting shared by both runners. It only deals in primitives/strings, so it does not
/// touch any SDK type and can live outside the extern-alias files.
/// </summary>
internal static class Output
{
    public static void Header(string sdk)
    {
        Console.WriteLine();
        Console.WriteLine(new string('=', 60));
        Console.WriteLine($"  Bricknode SDK demo  —  {sdk} client");
        Console.WriteLine(new string('=', 60));
    }

    /// <summary>Print one area's outcome: OK/FAIL by the API's response message, count, and a sample.</summary>
    public static void Area(string title, string? message, int count, IEnumerable<string>? sample = null)
    {
        var ok = string.Equals(message, "OK", StringComparison.OrdinalIgnoreCase);
        Console.WriteLine();
        Console.WriteLine($"[{(ok ? "OK  " : "FAIL")}] {title}");
        Console.WriteLine($"        message : {message ?? "(null)"}");
        Console.WriteLine($"        results : {count}");

        if (sample is not null)
        {
            var items = sample.Where(s => !string.IsNullOrWhiteSpace(s)).Take(5).ToList();
            if (items.Count > 0)
                Console.WriteLine($"        sample  : {string.Join(", ", items)}");
        }
    }

    public static void Error(string title, Exception ex)
    {
        Console.WriteLine();
        Console.WriteLine($"[ERR ] {title}");
        Console.WriteLine($"        {ex.GetType().Name}: {ex.Message}");
    }
}
