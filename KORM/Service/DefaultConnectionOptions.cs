using KORM.Interfaces;

namespace KORM.Service;

public record DefaultConnectionOptions(string ClusterUri, string IngestUri, string DefaultDatabase) : IKustoConnectionOptions
{
}