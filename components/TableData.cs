using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace cryptolab1.components
{
    public class TableData<T>
    {
        public String[] rowNames { get; set; }
        public String[] colNames { get; set; }
        public T[][] table { get; set; }

        public TableData(List<String> rows, List<String> cols, List<List<T>> values)
        {
            rowNames = rows.ToArray();
            colNames = cols.ToArray();
            table = values.Select(x => x.ToArray()).ToArray();
        }
    }
}