namespace TestLayer
{
    using Moq;
    using DBLayer;
    using Microsoft.Data.SqlClient;
    using NUnit.Framework;
    using System.Data;

    namespace TestLayer
    {
        [TestFixture]
        public class DatabaseHandlerTests
        {
            private Mock<IDbConnection> _mockConnection;
            private Mock<IDbCommand> _mockCommand;
            private Mock<IDataReader> _mockReader;
            private DatabaseHandler _dbHandler;

            [SetUp]
            public void Setup()
            {
                _mockConnection = new Mock<IDbConnection>();
                _mockCommand = new Mock<IDbCommand>();
                _mockReader = new Mock<IDataReader>();

                _mockConnection.Setup(m => m.Open()).Verifiable();

                _mockCommand.Setup(m => m.ExecuteReader()).Returns(_mockReader.Object).Verifiable();
                _mockCommand.Setup(m => m.ExecuteNonQuery()).Returns(1).Verifiable();

                _dbHandler = new DatabaseHandler();
            }

            [Test]
            public void ExecuteQuery_ShouldProcessResults()
            {
                // Arrange
                string expectedResult = "John Doe";
                string query = "SELECT FullName FROM Students";
                Action<IDataReader> processResults = reader =>
                {
                    while (reader.Read())
                    {
                        Assert.That(expectedResult == reader[0].ToString());
                    }
                };

                // Setup the mock to simulate reading a record from database
                _mockReader.SetupSequence(r => r.Read())
                           .Returns(true)
                           .Returns(false);
                _mockReader.Setup(r => r[0]).Returns(expectedResult);

                // Act
                _dbHandler.ExecuteQuery(query, processResults);

                // Assert
                _mockConnection.Verify(m => m.Open(), Times.Once);
                _mockCommand.Verify(m => m.ExecuteReader(), Times.Once);
            }

            [Test]
            public void ExecuteNonQuery_ShouldExecuteNonQuery()
            {
                // Arrange
                string query = "INSERT INTO Students (FullName) VALUES ('John Doe')";

                // Act
                _dbHandler.ExecuteNonQuery(query);

                // Assert
                _mockConnection.Verify(m => m.Open(), Times.Once);
                _mockCommand.Verify(m => m.ExecuteNonQuery(), Times.Once);
            }

            // Test for CreateDatabase method
            [Test]
            public void CreateDatabase_ShouldCreateDatabaseIfNotExist()
            {
                // Arrange
                string dbName = "NewSchoolDatabase";

                // Act
                _dbHandler.CreateDatabase(dbName);

                // Assert
                _mockCommand.Verify(m => m.ExecuteNonQuery(), Times.Once);
            }

            // Test for CreateTables method
            [Test]
            public void CreateTables_ShouldCreateTablesIfNotExist()
            {
                // Arrange
                string expectedQuery = "CREATE TABLE Parents (Id INT PRIMARY KEY IDENTITY(1,1), ParentCode NVARCHAR(50))";

                // Act
                _dbHandler.CreateTables();

                // Assert
                _mockCommand.Verify(m => m.ExecuteNonQuery(), Times.AtLeastOnce);  // At least one call for creating tables
            }

            [Test]
            public void InsertParent_ShouldInsertParentCorrectly()
            {
                // Arrange
                var parent = new Parent
                {
                    ParentCode = "P001",
                    FullName = "John Doe",
                    Email = "john.doe@example.com",
                    Phone = "123456789"
                };

                // Act
                _dbHandler.InsertParent(parent);

                // Assert
                _mockCommand.Verify(m => m.ExecuteNonQuery(), Times.Once);
                _mockCommand.Verify(m => m.Parameters.Add(parent.ParentCode), Times.Once);
            }
        }
    }

}
