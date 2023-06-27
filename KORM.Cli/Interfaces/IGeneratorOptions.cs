namespace KORM.Cli.Interfaces;

public interface IGeneratorOptions
{
    bool Strict { get; set; }
    string NewlineSeparator { get; set; }
    string TabSeparator { get; set; }
}