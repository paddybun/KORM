using Azure.Identity;
using KORM.Interfaces;
using Kusto.Data;
using Kusto.Data.Common;
using Kusto.Data.Net.Client;
using Kusto.Ingest;

namespace KORM.Services;

public class KustoConnector: IKustoConnector, IDisposable
{
    private readonly IKustoConnectionOptions _connectionOptions;
    private bool _disposed = false;

    private ICslQueryProvider _queryProvider;
    private ICslAdminProvider _adminProvider;
    private IKustoQueuedIngestClient _queuedIngestClient;

    public KustoConnector(IKustoConnectionOptions connectionOptions)
    {
        _connectionOptions = connectionOptions;
    }

    public ICslQueryProvider GetQueryProvider()
    {
        if (_disposed) throw new ObjectDisposedException(nameof(ICslQueryProvider));
        if (_queryProvider != null) return _queryProvider;
        var kcsb =
            new KustoConnectionStringBuilder(_connectionOptions.ClusterUri, _connectionOptions.DefaultDatabase)
                .WithAadAzureTokenCredentialsAuthentication(new DefaultAzureCredential());
        _queryProvider = KustoClientFactory.CreateCslQueryProvider(kcsb);
        return _queryProvider;
    }
    public ICslAdminProvider GetAdminProvider()
    {
        if (_disposed) throw new ObjectDisposedException(nameof(ICslAdminProvider));
        if (_adminProvider != null) return _adminProvider;
        var kcsb =
            new KustoConnectionStringBuilder(_connectionOptions.ClusterUri, _connectionOptions.DefaultDatabase)
                .WithAadAzureTokenCredentialsAuthentication(new DefaultAzureCredential());
        _adminProvider = KustoClientFactory.CreateCslAdminProvider(kcsb);
        return _adminProvider;
    }

    public IKustoQueuedIngestClient GetQueuedIngestClient()
    {
        if (_disposed) throw new ObjectDisposedException(nameof(ICslAdminProvider));
        if (_queuedIngestClient != null) return _queuedIngestClient;
        var kcsb =
            new KustoConnectionStringBuilder(_connectionOptions.ClusterUri, _connectionOptions.DefaultDatabase)
                .WithAadAzureTokenCredentialsAuthentication(new DefaultAzureCredential());
        _queuedIngestClient = KustoIngestFactory.CreateQueuedIngestClient(kcsb);
        return _queuedIngestClient;
    }

    public void Dispose()
    {
        _queryProvider.Dispose();
        _adminProvider.Dispose();
        _queuedIngestClient.Dispose();
        _disposed = true;
    }
}