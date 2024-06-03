namespace JSONTools
{
  internal class Program
  {
    static void Main(string[] args)
    {
      string rootPath = ".\\GenericParser";

      //JsonParser_Generic<m_TestClass> parser = new JsonParser_Generic<m_TestClass>(rootPath);
      //parser.ParseJson();
      //parser.PrintEntries();
      //parser.PrintEntries_By_ToString();

      Console.WriteLine();
      Console.WriteLine("[DEBUG] Parsing Complete...");
      Console.WriteLine("[DEBUG] Press ENTER to Exit...");
      Console.ReadLine();
    }
  }
}
