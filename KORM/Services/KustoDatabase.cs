using System.Data;
using KORM.Implementations;
using KORM.Interfaces;
using Kusto.Cloud.Platform.Data;
using Kusto.Data.Common;

namespace KORM.Services;

public class KustoDatabase : IKustoDatabase
{
    private readonly IKustoConnector _connector;

    public KustoDatabase(IKustoConnector connector)
    {
        _connector = connector;
    }

    public List<T> Fetch<T>(string query) where T : IKustoEntity, new()
    {
        var queryProvider = _connector.GetQueryProvider();
        var kustoResult = queryProvider.ExecuteQuery(query, new ClientRequestProperties());
        var kustoDs = kustoResult.ToDataSet();
        var mappedEntites = new List<T>();
        
        foreach (DataRow dataRow in kustoDs.Tables[0].Rows)
        {
            var mappedEntity = new T();
            MapToEntity(dataRow, mappedEntity);
            mappedEntites.Add(mappedEntity);
        }

        return mappedEntites;
    }

    private void MapToEntity(DataRow row, IKustoEntity entityToMap)
    {
        var @base = (BaseEntity) entityToMap;
        foreach (DataColumn tableColumn in row.Table.Columns)
        {
            var value = row[tableColumn.ColumnName];
            @base.SetValue(tableColumn.ColumnName, value);
        }
    }
}