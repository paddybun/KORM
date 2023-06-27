using KORM.Cli.Interfaces;

namespace KORM.Cli.Dtos;

public class DefaultGeneratorOptions: IGeneratorOptions
{
    /// <summary>
    /// If set to true, directs the generator to create strict properties based on their DataType => e.g. System.Int32 to int
    /// If set to false, directs the generator to create nullable properties based on ther DataType => e.g. System.Int32 to int?
    /// Default: false
    /// </summary>
    public bool Strict { get; set; } = false;
    public string NewlineSeparator { get; set; } = Environment.NewLine;
    public string TabSeparator { get; set; } = "\t";
}