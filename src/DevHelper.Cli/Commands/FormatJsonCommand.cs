using System.CommandLine;
using System.Text.Json;
using DevHelper.Cli.Services;

namespace DevHelper.Cli.Commands;

public static class FormatJsonCommand
{
    public static Command Build()
    {
        var cmd = new Command("format-json", "Prettify a JSON file in-place");

        var pathOpt = new Option<string>("--path")
        {
            Description = "Path to a JSON file"
        };

        var inplaceOpt = new Option<bool>("--inplace")
        {
            Description = "Overwrite the input file",
            DefaultValueFactory = _ => true
        };

        cmd.Options.Add(pathOpt);
        cmd.Options.Add(inplaceOpt);

        cmd.SetAction(parseResult =>
        {
            var path = parseResult.GetValue(pathOpt);
            var inplace = parseResult.GetValue(inplaceOpt);

            if (string.IsNullOrWhiteSpace(path))
            {
                Console.Error.WriteLine("❌ Missing required option: --path");
                return 2;
            }

            var files = new FileService();

            if (!files.Exists(path))
            {
                Console.Error.WriteLine($"❌ File not found: {path}");
                return 2;
            }

            var raw = files.ReadAllText(path);

            try
            {
                using var doc = JsonDocument.Parse(raw);

                var pretty = JsonSerializer.Serialize(doc.RootElement, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                if (inplace)
                {
                    files.WriteAllText(path, pretty + Environment.NewLine);
                    Console.WriteLine($"✅ Formatted in-place: {path}");
                }
                else
                {
                    Console.WriteLine(pretty);
                }

                return 0;
            }
            catch (JsonException ex)
            {
                Console.Error.WriteLine($"❌ Invalid JSON: {ex.Message}");
                return 3;
            }
        });

        return cmd;
    }
}