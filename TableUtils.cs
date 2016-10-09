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
        private DataGridView dataGrid;

        public TableUtils(DataGridView dgv)
        {
            dataGrid = dgv;
        }

        public void FillTable(TableData<double> table)
        {
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();
            dataGrid.Refresh();

            Array.ForEach(table.colNames, colname => dataGrid.Columns.Add(colname, colname));
            for (int i = 0; i < table.rowNames.Length; i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                for (int j = 0; j < table.colNames.Length; j++)
                {
                    newRow.Cells.Add(new DataGridViewTextBoxCell() { Value = table.table[i][j] });
                }
                newRow.HeaderCell.Value = table.rowNames[i];
                dataGrid.Rows.Add(newRow);
            }
        }

        public TableData<Double> SaveTable(TableData<Double> oldTab)
        {
            List<List<Double>> newValues = new List<List<double>>();

            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                List<double> row = new List<Double>();
                for (int j = 0; j < dataGrid.Rows[i].Cells.Count; j++)
                {
                    String val = dataGrid.Rows[i].Cells[j].Value.ToString();
                    row.Add(GetDouble(val, 0.0));
                }
                newValues.Add(row);
            }
            return new TableData<double>(oldTab.rowNames.ToList(), oldTab.colNames.ToList(), newValues);
        }

        private static double GetDouble(string value, double defaultValue)
        {
            double result;

            //Try parsing in the current culture
            if (!double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture, out result) &&
                //Then try in US english
                !double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out result) &&
                //Then in neutral language
                !double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                result = defaultValue;
            }

            return result;
        } 
    }
}