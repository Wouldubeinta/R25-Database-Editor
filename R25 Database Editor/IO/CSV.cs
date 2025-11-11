using System.Collections.Generic;
using System.Data;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace R25_Database_Editor
{
    /// <summary>
    /// CSV IO Class.
    /// </summary>
    /// <remarks>
    ///   R25 Database Editor. Written by Wouldubeinta
    ///   Copyright (C) 2025 Wouldy Mods.
    ///   
    ///   This program is free software; you can redistribute it and/or
    ///   modify it under the terms of the GNU General Public License
    ///   as published by the Free Software Foundation; either version 3
    ///   of the License, or (at your option) any later version.
    ///   
    ///   This program is distributed in the hope that it will be useful,
    ///   but WITHOUT ANY WARRANTY; without even the implied warranty of
    ///   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    ///   GNU General Public License for more details.
    ///   
    ///   You should have received a copy of the GNU General Public License
    ///   along with this program; if not, write to the Free Software
    ///   Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
    /// 
    ///   The author may be contacted at:
    ///   Discord: Wouldubeinta
    /// </remarks>
    /// <history>
    /// [Wouldubeinta]	   09/11/2025	Created
    /// </history>
    public static class CSV
    {
        public static void FromCSV(DataGridView dgv, string filePath, char delimiter = ',', bool hasHeader = true)
        {
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();

            try
            {
                using (StreamReader? sr = new StreamReader(filePath))
                {
                    string[]? headers = null;
                    if (hasHeader)
                    {
                        string headerLine = sr.ReadLine();
                        headers = headerLine.Split(delimiter);
                        foreach (string header in headers)
                        {
                            dataTable.Columns.Add(header.Trim());
                        }
                    }

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[]? fields = line.Split(delimiter);

                        // If no header, create columns based on the first row
                        if (!hasHeader && dataTable.Columns.Count == 0)
                        {
                            for (int i = 0; i < fields.Length; i++)
                            {
                                dataTable.Columns.Add($"Column{i + 1}");
                            }
                        }

                        DataRow row = dataTable.NewRow();
                        for (int i = 0; i < fields.Length; i++)
                        {
                            if (i < dataTable.Columns.Count) // Prevent index out of bounds if rows have fewer columns
                            {
                                row[i] = fields[i].Trim();
                            }
                        }
                        dataTable.Rows.Add(row);
                    }
                }

                dataSet.Tables.Add(dataTable);
                dgv.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + ex, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public static void ToCSV(DataGridView dGV, string filename)
        {
            ToolStripProgressBar PB = new();
            ToCSV(dGV, filename, PB);
            PB.Dispose();
        }

        public static void ToCSV(DataGridView dGV, string filename, ToolStripProgressBar PB)
        {
            try
            {
                int columnCount = dGV.ColumnCount;
                int rowCount = dGV.RowCount;
                string columnNames = string.Empty;
                string[] output = new string[rowCount + 1];
                string gender = string.Empty;

                for (int i = 0; i < columnCount; i++)
                {
                    columnNames += dGV.Columns[i].Name.ToString() + ",";
                }

                output[0] += columnNames;
                int lengthC = output[0].Length;
                output[0] = output[0].Remove(lengthC - 1, 1);

                for (int i = 1; (i - 1) < rowCount; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        if (dGV.Rows[i - 1].Cells[j].Value != null)
                        {
                            if (dGV.Rows[i - 1].Cells[j].Value.GetType() == typeof(Bitmap))
                            {
                                Bitmap bm = (Bitmap)dGV.Rows[i - 1].Cells[j].Value;
                                gender = "Male";
                                if (bm.Width == 13)
                                    gender = "Female";

                                output[i] += gender.TrimEnd([(char)0]) + ",";
                            }
                            else
                                output[i] += dGV.Rows[i - 1].Cells[j].Value.ToString().TrimEnd([(char)0]) + ",";

                            if (j == columnCount - 1)
                            {
                                int lengthR = output[i].Length;
                                output[i] = output[i].Remove(lengthR - 1, 1);
                            }
                        }
                        else
                            output[i] += string.Empty;
                    }

                    PB.Maximum = dGV.Rows.Count;
                    PB.Value = i - 1;
                    PB.PerformStep();
                }

                File.WriteAllLines(filename, output, Encoding.Default);
                PB.Value = 0;
                MessageBox.Show("Exporting to csv has finished", "Export CSV Is Complete :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
