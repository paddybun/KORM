using System.Security.AccessControl;

namespace KORM.Attributes;

public class KustoColumnAttribute: Attribute
{
    public string Name { get; }

    public KustoColumnAttribute(string name)
    {
        Name = name;
    }
}