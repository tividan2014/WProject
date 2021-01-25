using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WirtekProject
{
    class ConsoleTableExport : IExporter
    {
        public void Export<T>(IEnumerable<T> rows)
        {
            var propertiesInfo = typeof(T).GetProperties();
            var columnsName = GetColumnsName(propertiesInfo);

            PrintLine();
            PrintRow(columnsName);
            PrintLine();

            foreach (var row in rows)
            {
                if (row == null)
                    continue;

                var cells = new string[propertiesInfo.Length];
                for (var i = 0; i < columnsName.Length; i++)
                {

                    cells[i] = GetPropValue(row, columnsName[i])?.ToString()?.Trim();
                }

                PrintRow(cells);
            }

            PrintLine();
        }

        private static string[] GetColumnsName(PropertyInfo[] propertiesInfo)
        {
            var columns = new string[propertiesInfo.Length];
            for (var i = 0; i < propertiesInfo.Length; i++)
            {
                columns[i] = propertiesInfo[i].Name;
            }

            return columns;
        }

        private object GetPropValue(object src, string propName)
        {
            return src?.GetType().GetProperty(propName)?.GetValue(src, null);
        }

        private void PrintLine()
        {
            Console.WriteLine(new string('-', Constants.TableWidth));
        }

        private void PrintRow(params string[] columns)
        {
            var width = (Constants.TableWidth - columns.Length) / columns.Length;
            var row = columns.Aggregate("|", (current, column) => current + (AlignCentre(column, width) + "|"));

            Console.WriteLine(row);
        }

        private string AlignCentre(string text, int width)
        {
            text = text?.Length > width ? text.Substring(0, width - 3) + "..." : text;

            return string.IsNullOrEmpty(text) ? new string(' ', width) : text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        }
    }
}
