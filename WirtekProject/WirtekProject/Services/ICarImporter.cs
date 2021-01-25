using System.Collections.Generic;
using WirtekProject.Model;

namespace WirtekProject
{
    interface ICarImporter
    {
        public IEnumerable<CarInfo> GetCars(string filePath, int startId);
    }
}
