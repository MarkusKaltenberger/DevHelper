using System.CommandLine;
using DevHelper.Cli.Commands;

var root = new RootCommand("DevHelper - small local developer productivity tools");

root.Subcommands.Add(HelloCommand.Build());
root.Subcommands.Add(FormatJsonCommand.Build());

var parseResult = root.Parse(args);
return await parseResult.InvokeAsync();