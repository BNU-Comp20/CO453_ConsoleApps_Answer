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

            converter.fromUnit = DistanceConverter15.MILES;
            converter.toUnit = DistanceConverter15.FEET;

            converter.fromDistance = 2.0;
            double expectedDistance = 10560;

            // Act

            converter.PerformConversion();

            // Assert

            Assert.AreEqual(expectedDistance, converter.toDistance);
        }
    }
}
