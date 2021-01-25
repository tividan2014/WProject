using System.Collections.Generic;
using System.IO;
using WirtekProject.Model;

namespace WirtekProject
{
    public class CsvCarImporter : ICarImporter
    {
        public IEnumerable<CarInfo> GetCars(string filePath, int startId)
        {
            if (!IsFileValid(filePath))
                throw new FileNotFoundException($"File path '{filePath}' is invalid");
            else
            {
                var lineCounter = 0;
                var line =  string.Empty;

                using (var file = new StreamReader(filePath))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        var param = line.Split(Constants.CommaSymbol);
                        decimal.TryParse(param[2], Constants.Style, Constants.Culture, out var price);

                        var car = new CarInfo
                        {
                            Id = startId + lineCounter,
                            Manufacturer = param[0],
                            Model = param[1],
                            Price = price
                        };

                        lineCounter++;

                        yield return car;
                    }
                }
            }
        }

        private bool IsFileValid(string carsFilePath)
        {
            if (!File.Exists(carsFilePath))
            {
                return false;
            }

            return true;
        }
    }
}
