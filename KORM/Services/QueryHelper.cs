using KORM.Extensions.EntityExtensions;
using KORM.Interfaces;

namespace KORM.Services;

public class QueryHelper
{
    private readonly IKustoConnector _connector;

    public QueryHelper(IKustoConnector connector)
    {
        _connector = connector;

        var date = DateTime.Now;
        var res = date.Between()
            .From(date.AddDays(-1))
            .To(date);
    }
}