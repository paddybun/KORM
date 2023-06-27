using KORM.Cli.Dtos;
using KORM.Cli.Interfaces;

namespace KORM.Cli.Services;

public class Generator
{
    private readonly IGeneratorOptions _generatorOptions;
    public string FILEPATH_OUT = Path.Combine(Directory.GetCurrentDirectory(), "Generated");

    public readonly string ClassTemplate;
    public readonly string FieldTemplate;

    public Generator(IGeneratorOptions generatorOptions)
    {
        _generatorOptions = generatorOptions;
        ClassTemplate = Properties.Resources.EntityTemplate.Replace("\\t", generatorOptions.TabSeparator).Replace("\\n",generatorOptions.NewlineSeparator);
        FieldTemplate = Properties.Resources.FieldTemplate.Replace("\\t", generatorOptions.TabSeparator).Replace("\\n",generatorOptions.NewlineSeparator);
    }

    public void GenerateEntity(string @namespace, TableSchema schema)
    {
        var fields = string.Join(_generatorOptions.NewlineSeparator, schema.ColumnSchemata.Select(GenerateField));
        var tmp = ClassTemplate
            .Replace("%namespace%", @namespace)
            .Replace("%tablename%", schema.TableName)
            .Replace("%fields%", fields);
        
        if (!Directory.Exists(FILEPATH_OUT)) Directory.CreateDirectory(FILEPATH_OUT);

        var outpath = Path.Combine(FILEPATH_OUT, $"{schema.TableName}.cs");
        File.WriteAllText(outpath, tmp);
    }

    private string GenerateField(ColumnSchema column)
    {

        var dt = column.DataType switch
        {
            "System.String" => "string",
            "System.DateTime" => "DateTime",
            "System.Double" => _generatorOptions.Strict ? "double" : "double?",
            "System.Int32" => _generatorOptions.Strict ? "int" : "int?",
            "System.Int64" => _generatorOptions.Strict ? "long" : "long?",
            _ => "object"
        };

        var tmp = FieldTemplate
            .Replace("%columnname%", column.ColumnName)
            .Replace("%datatype%", dt);
        return tmp;
    }
}