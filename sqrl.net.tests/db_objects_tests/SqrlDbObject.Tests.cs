using sqrl.net.domain.db_objects;

namespace sqrl.net.tests.db_objects
{
    public class SqrlDbObjectTests
    {
        public class TestSqrlDbObject : SqrlDbObject
        {
            public TestSqrlDbObject(string name) : base(name)
            {
            }
        }

        [Fact]
        public void Constructor_ShouldInitializeName()
        {
            // Arrange
            var name = "TestObject";

            // Act
            var obj = new TestSqrlDbObject(name);

            // Assert
            Assert.Equal(name, obj.Name);
        }

        [Fact]
        public void ToString_ShouldReturnName()
        {
            // Arrange
            var name = "TestObject";
            var obj = new TestSqrlDbObject(name);

            // Act
            var result = obj.ToString();

            // Assert
            Assert.Equal(name, result);
        }
    }
}
