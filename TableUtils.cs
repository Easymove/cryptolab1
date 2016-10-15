using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using cryptolab1.components;

namespace cryptolab1
{
    public class TableUtils
    {
        private readonly DataGridView dataGrid;

        public TableUtils(DataGridView dgv)
        {
            dataGrid = dgv;
        }

        public void FillTable<T>(TableData<T> table)
        {
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();
            dataGrid.Refresh();

            Array.ForEach(table.colNames, colname => dataGrid.Columns.Add(colname, colname));
            for (var i = 0; i < table.rowNames.Length; i++)
            {
                var newRow = new DataGridViewRow();
                for (var j = 0; j < table.colNames.Length; j++)
                {
                    newRow.Cells.Add(new DataGridViewTextBoxCell {Value = table.table[i][j]});
                }
                newRow.HeaderCell.Value = table.rowNames[i];
                dataGrid.Rows.Add(newRow);
            }
        }

        public TableData<T> SaveTable<T>(TableData<T> oldTab)
        {
            var newValues = new List<List<T>>();

            for (var i = 0; i < dataGrid.Rows.Count; i++)
            {
                var row = new List<T>();
                for (var j = 0; j < dataGrid.Rows[i].Cells.Count; j++)
                {
                    var val = dataGrid.Rows[i].Cells[j].Value.ToString();
                    dynamic resVal = val;
                    if (typeof (T) == typeof (double))
                    {
                        resVal = GetDouble(val, 0.0);
                    }
                    row.Add(resVal);
                }
                newValues.Add(row);
            }
            return new TableData<T>(oldTab.rowNames.ToList(), oldTab.colNames.ToList(), newValues);
        }

        private static double GetDouble(string value, double defaultValue)
        {
            double result;

            //Try parsing in the current culture
            if (!double.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out result) &&
                //Then try in US english
                !double.TryParse(value, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out result) &&
                //Then in neutral language
                !double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                result = defaultValue;
            }

            return result;
        }

        public List<List<string>> GenerateEncodingTable(decimal kCount, decimal mCount, decimal eCount)
        {
            var rows = new List<List<string>>();
            for (var i = 0; i < kCount; i++)
            {
                var eNames = new NameGenerator().GenerateNames("E", (int) eCount).ToArray();
                var row = new List<string>();
                for (var j = 0; j < mCount; j++)
                {
                    row.Add(eNames[(i*(int) kCount + j + i)%(int) eCount]);
                }
                rows.Add(row);
            }
            return rows;
        }

        internal List<List<double>> GenerateAposteriorMessageTable(TableData<string> _encodingTab,
            TableData<double> _messageTab, TableData<double> _keysTab, string[] _cryptograms)
        {
            var rows = new List<List<double>>();
            for (var i = 0; i < _cryptograms.Length; i++)
            {
                var row = new List<double>();
                var PmE = GetPmE(_encodingTab, _messageTab, _keysTab, _cryptograms, i);
                var PE = GetPE(_encodingTab, _messageTab, _keysTab, _cryptograms, i);
                for (var j = 0; j < _messageTab.table[0].Length; j++)
                {
                    row.Add(_messageTab.table[0][j]*PmE[j]/PE);
                }
                rows.Add(row);
            }
            return rows;
        }

        private double[] GetPmE(TableData<string> _encodingTab, TableData<double> _messageTab,
            TableData<double> _keysTab, string[] _cryptograms, int eInd)
        {
            var res = new double[_messageTab.table[0].Length];
            for (var i = 0; i < _encodingTab.table.Length; i++)
            {
                for (var j = 0; j < _encodingTab.table[i].Length; j++)
                {
                    if (_encodingTab.table[i][j] == _cryptograms[eInd])
                    {
                        res[j] += _keysTab.table[0][i];
                    }
                }
            }
            return res;
        }

        private double GetPE(TableData<string> _encodingTab, TableData<double> _messageTab, TableData<double> _keysTab,
            string[] _cryptograms, int eInd)
        {
            var res = 0.0;
            for (var i = 0; i < _encodingTab.table.Length; i++)
            {
                for (var j = 0; j < _encodingTab.table[i].Length; j++)
                {
                    if (_encodingTab.table[i][j] == _cryptograms[eInd])
                    {
                        res += _keysTab.table[0][i]*_messageTab.table[0][j];
                    }
                }
            }
            return res;
        }
    }
}