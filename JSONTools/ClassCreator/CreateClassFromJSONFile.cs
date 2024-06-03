using System.Text.Json;

namespace JSONTools.ClassCreator
{
  public class CreateClassFromJSONFile
  {
    #region Properties
    private readonly string _jsonFilePath = string.Empty;
    private readonly string _outputCsFilePath = string.Empty;

    #endregion // Properties

    #region Constructors
    public CreateClassFromJSONFile(string jsonFilePath = "", string outputCsFilePath = "")
    {
      this._jsonFilePath = jsonFilePath;
      this._outputCsFilePath = outputCsFilePath;
    }
    #endregion // Constructors

    #region Methods
    public void GenerateClassFromJson()
    {
      var jsonContent = File.ReadAllText(_jsonFilePath);
      var jsonDocument = JsonDocument.Parse(jsonContent);

      var className = Path.GetFileNameWithoutExtension(_jsonFilePath);
      var properties = new Dictionary<string, string>();

      foreach (var property in jsonDocument.RootElement.EnumerateObject())
      {
        properties.Add(property.Name, GetCSharpType(property.Value.ValueKind));
      }

      var classDefinition = GenerateClassDefinition(className, properties);
      File.WriteAllText(_outputCsFilePath, classDefinition);
    }
    private string GetCSharpType(JsonValueKind jsonType)
    {
      return jsonType switch
      {
        JsonValueKind.Number => "double", // TODO: verify if this is potentially an integer vs a double
        JsonValueKind.String => "string",
        JsonValueKind.True => "bool",
        JsonValueKind.False => "bool",
        JsonValueKind.Array => "List<object>", // TODO: Validate this assumption of "Object" - it could be a more specific type
        JsonValueKind.Object => "object",
        _ => "string",
      };
    }
    private string GenerateClassDefinition(string className, Dictionary<string, string> properties)
    {
      var classDefinition = $"public class {className}\n{{\n";
      foreach (var property in properties)
      {
        classDefinition += $"    public {property.Value} {property.Key} {{ get; set; }}\n";
      }
      classDefinition += "}\n";
      return classDefinition;
    }
    #endregion // Methods
  }
}
