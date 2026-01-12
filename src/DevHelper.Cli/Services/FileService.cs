namespace DevHelper.Cli.Services;

public sealed class FileService
{
    public string ReadAllText(string path) => File.ReadAllText(path);

    public void WriteAllText(string path, string content) => File.WriteAllText(path, content);

    public bool Exists(string path) => File.Exists(path);
}