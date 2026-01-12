using System.CommandLine;

namespace DevHelper.Cli.Commands;

public static class HelloCommand
{
    public static Command Build()
    {
        var cmd = new Command("hello", "Sanity check command");

        var nameOpt = new Option<string>("--name")
        {
            Description = "Name to greet",
            DefaultValueFactory = _ => "developer"
        };

        cmd.Options.Add(nameOpt);

        cmd.SetAction(parseResult =>
        {
            var name = parseResult.GetValue(nameOpt) ?? "developer";
            Console.WriteLine($"Hello, {name}! ✅");
            return 0;
        });

        return cmd;
    }
}