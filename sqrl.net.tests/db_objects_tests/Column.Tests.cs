using Xunit;
using sqrl.net.domain.db_objects;

namespace sqrl.net.tests.db_objects
{
    public class ColumnTests
    {
        [Fact]
        public void Column_ShouldInitializeProperties()
        {
            // Arrange
            string expectedName = "UserId";
            string expectedDataType = "int";

            // Act
            SqrlColumn column = new SqrlColumn(expectedName, expectedDataType);

            // Assert
            Assert.Equal(expectedName, column.Name);
            Assert.Equal(expectedDataType, column.DataType);
        }

        [Fact]
        public void ToString_ShouldReturnName()
        {
            // Arrange
            string expectedName = "UserId";
            string expectedDataType = "int";
            string expectedResult = $"{expectedName}:{expectedDataType}";
            SqrlColumn column = new SqrlColumn(expectedName, expectedDataType);

            // Act
            string result = column.ToString();

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ToSql_ShouldReturnCorrectSqlScript()
        {
            // Arrange
            string columnName = "UserId";
            string columnDataType = "INT";
            SqrlColumn column = new SqrlColumn(columnName, columnDataType);

            // Act
            string result = column.ToSql();

            // Assert
            string expectedSql = "[UserId] INT";
            Assert.Equal(expectedSql, result);
        }
    }
}