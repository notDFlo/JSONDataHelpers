using JSONTools.GenericParser;
using JSONTools.GenericParser.GenericParserModels;

namespace NUnitTesting
{
  public class GenericParser
  {

    

    [SetUp]
    public void Setup()
    {
      
    }

    [Test]
    public void TestClass_ModelTest<T>() where T : class, new()
    {
      string rootPath = ".\\GenericParser";

      JsonParser_Generic<T> parser = new JsonParser_Generic<T>(rootPath);

      Assert.Contains("Diana", parser.ParseJson());

      Assert.IsTrue(parser != null);

      Assert.IsTrue(parser.PrintEntries().Count > 0);

      Assert.IsInstanceOf<JsonParser_Generic<T>>(parser);
    }
  }
}