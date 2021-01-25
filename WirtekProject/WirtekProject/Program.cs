using System;
using System.IO;
using System.Linq;

namespace WirtekProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var importer = new CsvCarImporter();
                var exporter = new ConsoleTableExport();

                var cars1 = importer.GetCars(Constants.CarsFilePath1, Constants.FirstIndexFile1);
                var cars2 = importer.GetCars(Constants.CarsFilePath2, Constants.FirstIndexFile2);
                var cars = cars1.Concat(cars2);

                exporter.Export(cars);
                Console.ReadKey();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
