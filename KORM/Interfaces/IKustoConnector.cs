using Kusto.Data.Common;

namespace KORM.Interfaces;

public interface IKustoConnector
{
    public ICslQueryProvider GetQueryProvider();
    public ICslAdminProvider GetAdminProvider();
}