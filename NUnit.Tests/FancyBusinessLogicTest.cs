using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Mocks;
using RhinoMocksDemo;

namespace NUnit.Tests
{
  [TestFixture]
  public class FancyBusinessLogicTest
  {
    private IDataAccess _mockDAO;
    private FancyBusinessLogic _fancyBL;

    [SetUp]
    public void SetUp()
    {
      //reset all my objects under test and mocks
      _mockDAO = MockRepository.GenerateMock<IDataAccess>();
      _fancyBL = new FancyBusinessLogic { MyDataAccessObject = _mockDAO };
    }

    [Test]
    public void TestGetImportantDataAndUpdateTheName()
    {
      //Arrange
      int myRecordId = 100;
      var recordFromDatabase = new ImportantData
      {
        Name = "Orignal Name",
        RecordId = myRecordId
      };

      _mockDAO.Stub(dao => dao.GetRecordFromDatabase(myRecordId))
        .Return(recordFromDatabase);

      //Act
      var myRecord = _fancyBL.GetImportantDataAndUpdateTheName(myRecordId);

      //Assert
      Assert.AreEqual(myRecord.RecordId, myRecordId);
      Assert.AreEqual(myRecord.Name, "All Your Base Are Belong To Us");
    }

    [Test]
    public void TestExpectations()
    {
      //Arrange
      int myRecordId = 100;
      var recordFromDatabase = new ImportantData
      {
        Name = "Orignal Name",
        RecordId = myRecordId
      };

      _mockDAO.Expect(dao => dao.GetRecordFromDatabase(myRecordId))
        .Return(recordFromDatabase);

      _mockDAO.Expect(dao => dao.GetRecordFromDatabase(101))
        .Return(recordFromDatabase);

      //Act
      _fancyBL.GetImportantDataAndUpdateTheName(myRecordId);

      //Assert
      _mockDAO.VerifyAllExpectations();
    }
  }
}
