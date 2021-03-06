﻿using System;
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
            foreach (DataGridViewColumn column in dataGrid.Columns)
                column.Width = 40;
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
            
            if (mCount == 6 && eCount == 6)
            {
                rows = new List<List<string>>
                {
                    new List<string> {"E1", "E5", "E4", "E3", "E2", "E6"},
                    new List<string> {"E2", "E4", "E3", "E5", "E6", "E1"},
                    new List<string> {"E4", "E3", "E5", "E6", "E1", "E2"},
                    new List<string> {"E3", "E2", "E6", "E1", "E5", "E4"},
                    new List<string> {"E5", "E6", "E1", "E2", "E4", "E3"},
                    new List<string> {"E6", "E1", "E2", "E4", "E3", "E5"}
                };
                
                return rows.GetRange(0, (int)kCount);
            }

            if (mCount == 7 && eCount == 7)
            {
                rows = new List<List<string>>
                {
                    new List<string> {"E4", "E5", "E2", "E6", "E3", "E1", "E7"},
                    new List<string> {"E1", "E2", "E3", "E7", "E5", "E6", "E4"},
                    new List<string> {"E6", "E1", "E4", "E3", "E5", "E7", "E2"},
                    new List<string> {"E2", "E7", "E1", "E6", "E4", "E3", "E5"},
                    new List<string> {"E4", "E7", "E5", "E3", "E6", "E1", "E2"},
                    new List<string> {"E7", "E4", "E3", "E5", "E6", "E2", "E1"},
                    new List<string> {"E5", "E3", "E1", "E2", "E7", "E4", "E6"},
                    new List<string> {"E7", "E3", "E6", "E2", "E1", "E4", "E5"},
                    new List<string> {"E5", "E1", "E2", "E4", "E3", "E7", "E6"},
                    new List<string> {"E3", "E2", "E7", "E5", "E1", "E6", "E4"},
                    new List<string> {"E6", "E4", "E7", "E1", "E2", "E5", "E3"},
                    new List<string> {"E1", "E6", "E5", "E4", "E7", "E2", "E3"},
                    new List<string> {"E3", "E6", "E4", "E7", "E2", "E5", "E1"},
                    new List<string> {"E2", "E5", "E6", "E1", "E4", "E3", "E7"}
                };

                return rows.GetRange(0, (int)kCount);
            }

            if (mCount == 4 && eCount == 5)
            {
                rows = new List<List<string>>
                {
                    new List<string> {"E2", "E5", "E1", "E4"},
                    new List<string> {"E4", "E1", "E3", "E2"},
                    new List<string> {"E3", "E5", "E4", "E1"},
                    new List<string> {"E1", "E2", "E3", "E5"},
                    new List<string> {"E3", "E4", "E2", "E5"},
                    new List<string> {"E5", "E3", "E1", "E2"},
                    new List<string> {"E5", "E2", "E1", "E4"},
                    new List<string> {"E3", "E5", "E2", "E1"},
                    new List<string> {"E5", "E3", "E4", "E1"},
                    new List<string> {"E2", "E4", "E5", "E3"}
                };

                return rows.GetRange(0, (int)kCount);
            }

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
                    row.Add(Math.Round(_messageTab.table[0][j]*PmE[j]/PE, 3));
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

        internal List<List<double>> GenerateMessageDiffTable(TableData<double> _messageAfterTab,
            TableData<double> _messageTab, string[] _cryptograms)
        {
            {
                var rows = new List<List<double>>();
                for (var i = 0; i < _cryptograms.Length; i++)
                {
                    var row = new List<double>();
                    for (var j = 0; j < _messageTab.table[0].Length; j++)
                    {
                        row.Add(Math.Round(_messageAfterTab.table[i][j] - _messageTab.table[0][j], 3));
                    }
                    rows.Add(row);
                }
                return rows;
            }
        }

        internal List<List<double>> GenerateAposteriorKeysToMessageTable(TableData<string> _encodingTab,
            TableData<double> _messageTab, TableData<double> _keysTab, string[] _cryptograms)
        {
            {
                var rows = new List<List<double>>();
                for (var i = 0; i < _keysTab.table[0].Length; i++)
                {
                    var row = new List<double>();
                    for (var j = 0; j < _cryptograms.Length; j++)
                    {
                        var PkE = GetPkE(_encodingTab, _messageTab, _keysTab, _cryptograms, j);
                        var PE = GetPE(_encodingTab, _messageTab, _keysTab, _cryptograms, j);

                        row.Add(
                            Math.Round(
                                _keysTab.table[0][i]*PkE[i]/
                                (PE*_messageTab.table[0][GetMessage(_encodingTab, i, _cryptograms[j])]), 3));
                    }
                    rows.Add(row);
                }
                return rows;
            }
        }

        private int GetMessage(TableData<string> _encodingTab, int kInd, string cryptogram)
        {
            for (var i = 0; i < _encodingTab.table[kInd].Length; i++)
            {
                if (_encodingTab.table[kInd][i] == cryptogram)
                {
                    return i;
                }
            }
            return 0;
        }

        private double[] GetPkE(TableData<string> _encodingTab, TableData<double> _messageTab,
            TableData<double> _keysTab, string[] _cryptograms, int eInd)
        {
            var res = new double[_keysTab.table[0].Length];
            for (var i = 0; i < _encodingTab.table.Length; i++)
            {
                for (var j = 0; j < _encodingTab.table[i].Length; j++)
                {
                    if (_encodingTab.table[i][j] == _cryptograms[eInd])
                    {
                        res[i] += _messageTab.table[0][j];
                    }
                }
            }
            return res;
        }
    }
}