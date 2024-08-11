using Xunit;
using sqrl.net.domain.db_objects;
using System.Collections.Generic;

namespace sqrl.net.tests.db_objects
{
    public class TableTests
    {
        [Fact]
        public void Table_ShouldInitializeProperties()
        {
            // Arrange
            string tableName = "Users";

            // Act
            SqrlTable table = new SqrlTable(tableName);

            // Assert
            Assert.Equal(tableName, table.Name);
            Assert.Empty(table.Columns);
        }

        [Fact]
        public void AddColumn_ShouldAddColumnToTable()
        {
            // Arrange
            SqrlTable table = new SqrlTable("Users");
            SqrlColumn column = new SqrlColumn("UserId", "INT");

            // Act
            table.AddColumn(column);

            // Assert
            Assert.Single(table.Columns);
            Assert.Contains(column, table.Columns);
        }

        [Fact]
        public void ToSql_ShouldReturnCorrectSqlScript()
        {
            // Arrange
            SqrlTable table = new SqrlTable("Users");
            table.AddColumn(new SqrlColumn("UserId", "INT"));
            table.AddColumn(new SqrlColumn("UserName", "VARCHAR(100)"));
            table.AddColumn(new SqrlColumn("Email", "VARCHAR(100)"));

            // Act
            string result = table.ToSql();

            // Assert
            string expectedSql =
@"CREATE TABLE [Users] (
    [UserId] INT,
    [UserName] VARCHAR(100),
    [Email] VARCHAR(100)
);";
            Assert.Equal(expectedSql, result);
        }
    }
}