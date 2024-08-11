using Moq;
using System.Collections.Generic;
using Xunit;
using sqrl.net.domain.db_objects;
using sqrl.net.domain.db_interface;

namespace sqrl.net.tests
{
    public class SqlServerRepositoryTests
    {
        private readonly Mock<IServer> _mockServer;
        private readonly Mock<IDatabase> _mockDatabase;
        private readonly Mock<ITableCollection> _mockTables;
        private readonly Mock<ITable> _mockTable;
        private readonly Mock<IColumn> _mockColumn;
        private readonly SqlServerRepository _repository;

        public SqlServerRepositoryTests()
        {
            _mockServer = new Mock<IServer>();
            _mockDatabase = new Mock<IDatabase>();
            _mockTables = new Mock<ITableCollection>();
            _mockTable = new Mock<ITable>();
            _mockColumn = new Mock<IColumn>();

            _mockDatabase.Setup(d => d.Tables).Returns(_mockTables.Object);
            _mockTables.Setup(t => t.GetEnumerator()).Returns(new List<ITable> { _mockTable.Object }.GetEnumerator());
            _mockTable.Setup(t => t.Name).Returns("TestTable");
            _mockTable.Setup(t => t.Columns).Returns(new List<IColumn> { _mockColumn.Object });
            _mockColumn.Setup(c => c.Name).Returns("TestColumn");
            _mockColumn.Setup(c => c.DataType).Returns("nvarchar");

            _repository = new SqlServerRepository(_mockServer.Object, _mockDatabase.Object);
        }

        [Fact]
        void GetTables_ReturnsExpectedTables()
        {
            // Act
            var tables = _repository.GetTables();

            // Assert
            Assert.Single(tables);
            Assert.Equal("TestTable", tables[0].Name);
            Assert.Single(tables[0].Columns);
            Assert.Equal("TestColumn", tables[0].Columns[0].Name);
            Assert.Equal("nvarchar", tables[0].Columns[0].DataType);
        }
    }
}