using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhinoMocksDemo
{
  class Program
  {
    static void Main(string[] args)
    {
    }

  }

  public class ImportantData
  {
    public string Name { get; set; }
    public int RecordId { get; set; }
  }

  public interface IDataAccess
  {
    ImportantData GetRecordFromDatabase(int recordId);
    void NeverCallThisMethod();
  }

  public class DataAccessObject : IDataAccess
  {
    public ImportantData GetRecordFromDatabase(int recordId)
    { throw new NotImplementedException(); }
    public void NeverCallThisMethod() { throw new NotImplementedException(); }
  }
}
