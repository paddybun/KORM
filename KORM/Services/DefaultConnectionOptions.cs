using KORM.Interfaces;

namespace KORM.Services;

public record DefaultConnectionOptions(string ClusterUri, string IngestUri, string DefaultDatabase) : IKustoConnectionOptions
{
}