using System.Collections.Generic;

namespace WirtekProject
{
    internal interface IExporter
    {
        public void Export<T>(IEnumerable<T> cars);
    }
}
