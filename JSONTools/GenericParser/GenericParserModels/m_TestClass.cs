namespace JSONTools.GenericParser.GenericParserModels
{
  public class m_TestClass
  {
    #region Properties
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; } = DateTime.Now;
    #endregion // Properties

    #region Constructors
    public m_TestClass(string name, string description, DateTime dateOfBirth)
    {
      this.Name = name;
      this.Description = description;
      this.DateOfBirth = dateOfBirth;
    }
    #endregion // Constructors

    #region Methods
    public override string ToString()
    {
      return $"Name: {this.Name} || Description: {this.Description} || Date: {this.DateOfBirth.ToShortDateString()}";
    }
    #endregion // Methods
  }
}


