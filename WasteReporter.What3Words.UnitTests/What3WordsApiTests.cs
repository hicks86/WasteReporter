using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WasteReporter.What3Words.UnitTests
{
    [TestClass()]
    public class What3WordsApiTests
    {
        [TestMethod]
        public void ConvertCoordinatesTo3WAShouldReturnString()
        {
            //Arrange
            var service = new What3WordsApi();
            //Act
            var words = service.ConvertCoordinatesTo3WA(51.222011, 0.152311).Result; //, 

            //Assert
            Assert.AreEqual("blame.deflection.hills", words.Words);
        }

        [TestMethod]
        public void Convert3WAToCoordinatesShouldReturnValue()
        {
            //Arrange
            var service = new What3WordsApi();

            //Act
            var coordinates = service.Convert3WAToCoordinates("blame.deflection.hills").Result;

            //Assert
            Assert.AreEqual((51.222011, 0.152311), coordinates.Coordinates);
        }
    }
}