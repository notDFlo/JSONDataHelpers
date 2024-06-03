using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JSONTools.GenericParser.GenericParserModels;

namespace JSONTools.GenericParser
{
  public class JsonParser_Generic<T> where T : class, new()
  {
    // -Useful for parsing JSON files that use existing classes as templates
    // -The path to the actual *.json is determined by the name of the class
    // -HOWEVER: the root / data directory still need to be pass as a parameter
    //           if the directory the class resides in does not match the root
    //           ------
    //           this discrepancy is demonstrated with this example.
    //           see: specification of the "GenericParserModels" directory reference

    #region Properties
    private readonly string _jsonDirectory = Environment.CurrentDirectory;
    private readonly string _fullFilePath = string.Empty;
    private List<T> _entries = new List<T>();
    #endregion // Properties

    #region Constructors
    public JsonParser_Generic(string rootPath = "")
    {
      // this method assumes the class "m_TestClass"
      //   - this is simply to demonstrate the functionality
      //     of the generic parser itself.
      //
      // comment this out to use intended functionality
      if (!string.IsNullOrEmpty(rootPath))
      {
        this._jsonDirectory = rootPath;
      }

      this._fullFilePath = Path.Combine(this._jsonDirectory, $"{typeof(T).Name}.json");
      Console.WriteLine("---------------------------------------");
      Console.WriteLine($"Default/Specified Directory: {this._jsonDirectory}");
      Console.WriteLine($"            Type of generic: {typeof(T)}");
      Console.WriteLine($"            Name of generic: {nameof(T)}");
      Console.WriteLine($"       typeof(generic).Name: {typeof(T).Name}");
      Console.WriteLine($"         Full JSON FilePath: {this._fullFilePath}");
      Console.WriteLine("---------------------------------------");
    }
    #endregion // Constructors

    #region Methods
    public void ParseJson()
    {
      // read and deserialize the JSON file's text
      string rawJsonData = File.ReadAllText(this._fullFilePath);
      // use the generic (T) to deserialize the data into your class
      this._entries = JsonSerializer.Deserialize<List<T>>(rawJsonData) ?? new List<T>();
    }

    // again, this method is to demonstrate the functionality of the generic parser
    // ----------
    // the actual implementation can be done with your own classes, without using 
    // these Print methods
    public void PrintEntries()
    {
      
      foreach (var entry in this._entries)
      {
        Console.WriteLine($"Name          : {(entry as m_TestClass).Name}");
        Console.WriteLine($"Description   : {(entry as m_TestClass).Description}");
        Console.WriteLine($"Date of Birth : {(entry as m_TestClass).DateOfBirth.ToShortDateString()}");
        Console.WriteLine("     -----");

      }
      Console.WriteLine("---------------------------------------");
    }

    public void PrintEntries_By_ToString()
    {
      foreach (var entry in this._entries)
      {
        Console.WriteLine(entry.ToString());
        Console.WriteLine("     -----");
      }
      Console.WriteLine("---------------------------------------");
    }
    #endregion // Methods
  }
}
