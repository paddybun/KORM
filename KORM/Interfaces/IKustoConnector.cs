using Kusto.Data.Common;
using Kusto.Ingest;

namespace KORM.Interfaces;

public interface IKustoConnector
{
    public ICslQueryProvider GetQueryProvider();
    public ICslAdminProvider GetAdminProvider();
    public IKustoQueuedIngestClient GetQueuedIngestClient();
}