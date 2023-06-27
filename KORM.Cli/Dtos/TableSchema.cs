namespace KORM.Cli.Dtos;

public record TableSchema(string TableName)
{
    public List<ColumnSchema> ColumnSchemata { get; } = new();
}

public record ColumnSchema(string ColumnName, string DataType, int ColumnOrdinal, string ColumnType) : IComparable<ColumnSchema>
{
    public int CompareTo(ColumnSchema? other)
    {
        if (other == null) return 0;
        if (ColumnOrdinal > other.ColumnOrdinal) return 1;
        if (ColumnOrdinal < other.ColumnOrdinal) return -1;
        return 0;
    }
}