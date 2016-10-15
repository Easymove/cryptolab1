using System.Collections.Generic;
using System.Linq;

namespace cryptolab1.components
{
    public class TableData<T>
    {
        public TableData(List<string> rows, List<string> cols, List<List<T>> values)
        {
            rowNames = rows.ToArray();
            colNames = cols.ToArray();
            table = values.Select(x => x.ToArray()).ToArray();
        }

        public string[] rowNames { get; set; }
        public string[] colNames { get; set; }
        public T[][] table { get; set; }
    }
}