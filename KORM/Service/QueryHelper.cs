using KORM.Interfaces;

namespace KORM.Service;

public class QueryHelper
{
    private readonly IKustoConnector _connector;

    public QueryHelper(IKustoConnector connector)
    {
        _connector = connector;
    }
}