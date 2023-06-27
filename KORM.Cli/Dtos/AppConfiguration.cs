namespace KORM.Cli.Dtos;

public class AppConfiguration
{
    public string KustoClusterUri { get; set; }
    public string KustoIngestClusterUri { get; set; }
    public string Database { get; set; }
}