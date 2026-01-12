# DevHelper

A small C#/.NET CLI tool that collects local developer productivity commands.

## Requirements

- .NET 8 SDK

Check your installation:

```bash
dotnet --version
```

## Project Structure

```text
DevHelper/
  DevHelper.sln
  README.md
  src/
    DevHelper.Cli/
      DevHelper.Cli.csproj
      Program.cs
      Commands/
      Services/
```

## Run locally (without installing)

Show general help:

```bash
dotnet run --project src/DevHelper.Cli -- --help
```

### hello

```bash
dotnet run --project src/DevHelper.Cli -- hello
dotnet run --project src/DevHelper.Cli -- hello --name Markus
```

### format-json

Create a valid JSON test file (Git Bash safe):

```bash
printf '{"a":1,"b":{"c":2}}' > test.json
```

Format in-place:

```bash
dotnet run --project src/DevHelper.Cli -- format-json --path test.json
cat test.json
```

Print prettified JSON to stdout (no overwrite):

```bash
dotnet run --project src/DevHelper.Cli -- format-json --path test.json --inplace false
```

## Install as a .NET tool (local build)

DevHelper can be packaged and installed as a .NET global tool so you can run it as `devhelper`.

### 1) Pack

From the repository root:

```bash
dotnet pack src/DevHelper.Cli -c Release -o ./nupkg
```

### 2) Install globally from the local package folder

```bash
dotnet tool install --global DevHelper --add-source ./nupkg
```

### 3) Run

```bash
devhelper --help
devhelper hello --name Markus
```

## Update after changes

1. Bump the version in `src/DevHelper.Cli/DevHelper.Cli.csproj` (e.g. `0.1.1`).
2. Pack and update:

```bash
dotnet pack src/DevHelper.Cli -c Release -o ./nupkg
dotnet tool update --global DevHelper --add-source ./nupkg
```

## Uninstall

```bash
dotnet tool uninstall --global DevHelper
```

## License

Add a license file if you plan to share/publish this tool publicly.