namespace KORM.Interfaces;

public interface IKustoConnectionOptions
{
    public string ClusterUri { get; }
    public string DefaultDatabase { get; }
}