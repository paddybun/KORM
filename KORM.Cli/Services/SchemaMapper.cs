using System.Data;
using KORM.Cli.Dtos;
using KORM.Interfaces;
using Kusto.Cloud.Platform.Data;

namespace KORM.Cli.Services;

public class SchemaMapper
{
    private readonly IKustoConnector _connector;

    public SchemaMapper(IKustoConnector connector)
    {
        _connector = connector;
    }

    public TableSchema CreateSchema(string tablename)
    {
        var queryProvider = _connector.GetQueryProvider();
        var result = queryProvider.ExecuteQuery($"{tablename} | getschema");
        var schemaDs = result.ToDataSet();
        var ts = new TableSchema(tablename);
        foreach (DataRow row in schemaDs.Tables[0].Rows)
        {
            ts.ColumnSchemata.Add(new ColumnSchema(
                (string) row["ColumnName"],
                (string) row["DataType"],
                (int) row["ColumnOrdinal"],
                (string) row["ColumnType"]));
        }
        ts.ColumnSchemata.Sort();
        return ts;
    }
}