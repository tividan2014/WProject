using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WirtekProject;

namespace WirtekProjectTest
{
    [TestClass]
    public class CsvCarImporterTests
    {
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void GetCars_ThrowsFileNotFoundException_WhenInputFilePathIsInvalid()
        {
            // Arrange
            var invalidFilePath = "InvalidFile.csv";
            var carImporter = new CsvCarImporter();

            // Act
            var cars = carImporter.GetCars(invalidFilePath, 0).ToList();

            // Assert
        }

        [TestMethod]
        public void GetCars_ReturnsListOfCars_WhenInputFileIsValid()
        {
            // Arrange
            var invalidFilePath = "./../../../../WirtekProject/InputData/Cars1.csv";
            var carImporter = new CsvCarImporter();

            // Act
            var cars = carImporter.GetCars(invalidFilePath, 0);

            // Assert
            var carInfos = cars.ToList();
            Assert.AreEqual(5, carInfos.Count);

            Assert.AreEqual("WV", carInfos[0].Manufacturer);
            Assert.AreEqual("Tiguan", carInfos[0].Model);
            Assert.AreEqual("43000.56", carInfos[0].Price.ToString(CultureInfo.InvariantCulture));

            //... and others asserts
        }
    }
}
