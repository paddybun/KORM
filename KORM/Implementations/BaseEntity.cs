using System.Collections.ObjectModel;
using System.Reflection;
using KORM.Attributes;
using KORM.Interfaces;

namespace KORM.Implementations;

public abstract class BaseEntity : IKustoEntity
{
    protected ReadOnlyDictionary<string, PropertyInfo> PropertyMapping { get; private set; }

    protected BaseEntity()
    {
        CreateMapping();
    }

    private void CreateMapping()
    {
        var t = GetType();
        var props = t.GetProperties();

        var mapped = props.ToDictionary(
            x => ((KustoColumnAttribute) Attribute.GetCustomAttribute(x, typeof(KustoColumnAttribute)))?.Name,
            y => y);

        var roDict = new ReadOnlyDictionary<string, PropertyInfo>(mapped);
        PropertyMapping = roDict;
    }

    public void SetValue(string name, object value)
    {
        var pi = PropertyMapping[name];
        var t = Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType;
        
        var isColumnEmpty = value is DBNull || (value as string) is "";

        var converted = (value == null || isColumnEmpty) ? null : Convert.ChangeType(value, t);
        pi.SetValue(this, converted);
    }
}