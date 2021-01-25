using System.Globalization;

namespace WirtekProject
{
    class Constants
    {
        public static string CarsFilePath1 = "./InputData/Cars1.csv";
        public static string CarsFilePath2 = "./InputData/Cars2.csv";

        public static int FirstIndexFile1 = 100;
        public static int FirstIndexFile2 = 100;

        public static NumberStyles Style = NumberStyles.AllowDecimalPoint;
        public static CultureInfo Culture = CultureInfo.CreateSpecificCulture("en-US");
        public static char CommaSymbol = ',';

        public static int TableWidth = 81;
    }
}
