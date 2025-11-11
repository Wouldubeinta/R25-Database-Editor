using PackageIO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace R25_Database_Editor
{
    /// <summary>
    /// IO Operations Class
    /// </summary>
    /// <remarks>
    ///   R25 Database Editor Written by Wouldubeinta
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
    ///   The author may be contacted at:
    ///   Discord: Wouldubeinta
    /// </remarks>
    /// <history>
    /// [Wouldubeinta]	   10/11/2025	Created
    /// </history>
    public class IO
    {
		public static long FileInfo(string file)
        {
            return new FileInfo(file).Length;
        }

        public static void ExtractTeamList(string file, DataGridView dgv) 
        {
            Writer? bw = null;

            try
            {
                FileStream? fs = new(file, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                bw = new(fs, Endian.Little);

                bw.WriteInt32(dgv.Rows.Count);

                // Write data rows
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    int teamId = Convert.ToInt32(row.Cells[2].Value);
                    string teamName = row.Cells[3].Value.ToString();
                    bw.WriteInt32(teamId, Endian.Little);
                    bw.WriteUInt8(Convert.ToByte(teamName.Length));
                    bw.WriteString(teamName, teamName.Length, Endian.Little);
                    bw.Flush();
                }

                MessageBox.Show("Exporting to dat for league editor has finished", "Export DAT Is Complete :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + ex, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (bw != null) { bw.Close(); bw = null; }
            }
        }
		
        /// <summary>
        /// Deserialize XML data.
        /// </summary>
        /// <param name="fileIn">Xml file in.</param>
        /// <returns>Returns generic type class data.</returns>
        /// <history>
        /// [Wouldubeinta]		14/07/2025	Created
        /// </history>
        public static T XmlDeserialize<T>(string fileIn)
        {
            StreamReader? reader = null;
            T? xmlData = default;

            try
            {
                XmlSerializer serializer = new(typeof(T));
                reader = new(fileIn);
                xmlData = (T)serializer.Deserialize(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + ex, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null) { reader.Dispose(); reader = null; }
            }
            return xmlData;
        }

        /// <summary>
        /// Serialize XML data.
        /// </summary>
        /// <param name="fileout">Xml file out.</param>
        /// <param name="data">Generic Type data.</param>
        /// <history>
        /// [Wouldubeinta]		14/07/2025	Created
        /// </history>
        public static void XmlSerialize<T>(string fileout, T data)
        {
            StringWriter? stringWriter = null;

            try
            {
                XmlWriterSettings settings = new();
                settings.Indent = true;
                settings.OmitXmlDeclaration = true;
                settings.NewLineHandling = NewLineHandling.None;
                stringWriter = new();
                XmlWriter writer = XmlWriter.Create(stringWriter, settings);
                XmlSerializer serializer = new(typeof(T));
                XmlSerializerNamespaces ns = new();
                ns.Add(string.Empty, string.Empty);
                serializer.Serialize(writer, data, ns);
                string startDocuments = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>";
                File.WriteAllText(fileout, startDocuments + "\n" + stringWriter.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + ex, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (stringWriter != null) { stringWriter.Dispose(); stringWriter = null; }
            }
        }
    }
}
