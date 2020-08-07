using Microsoft.VisualStudio.TestTools.UnitTesting;
using CO453_ConsoleAppAnswer;

namespace ConsoleApp.UnitTest
{
    [TestClass]
    public class DistanceConverterTest
    {
        [TestMethod]
        public void TestMilesToFeet()
        {
            // Arrange

            DistanceConverter15 converter = new DistanceConverter15();

            converter.FromUnit = DistanceUnit.Miles;
            converter.ToUnit = DistanceUnit.Feet;

            converter.FromDistance = 2.0;
            double expectedDistance = 10560;

            // Act

            converter.PerformConversion();

            // Assert

            Assert.AreEqual(expectedDistance, converter.ToDistance);
        }
    }
}
