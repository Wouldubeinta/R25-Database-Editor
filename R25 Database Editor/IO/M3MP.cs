using PackageIO;
using ZstdSharp;

namespace R25_Database_Editor
{
    /// <summary>
    /// M3MP Creator Class.
    /// </summary>
    /// <remarks>
    ///   RL26 Database Editor. Written by Wouldubeinta
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
    /// [Wouldubeinta]	   23/09/2025	Created
    /// </history>
    public class M3MP
    {
        public static void CreateM3MP(ToolStripProgressBar PB, ToolStripLabel tslp, StatusStrip ss)
        {
            if (File.Exists(Global.currentPath + @"\database.xml"))
                File.Delete(Global.currentPath + @"\database.xml");

            if (File.Exists(Global.currentPath + @"\database.m3mp"))
                File.Delete(Global.currentPath + @"\database.m3mp");

            List<byte[]> RawData = new(3);
            List<int> RawFileOffsets = new(3);
            int[] RawFileSize = new int[3];
            string[] FileName = new string[3];

            Reader? br = null;
            MemoryStream? stream = null;

            try
            {
                FileName = FileNames();

                for (int i = 0; i < 3; i++)
                {
                    br = new Reader(Global.currentPath + @"\" + FileName[i], FileMode.Open, Endian.Little);

                    RawFileSize[i] = Convert.ToInt32(br.Length);
                    RawData.Add(br.ReadBytes(RawFileSize[i]));

                    PB.Maximum = 3;
                    PB.Value = (i);
                    PB.PerformStep();

                    int percent = (100 * i) / 3;
                    tslp.Text = percent + "%";
                    ss.Refresh();
                }

                int bufferSize = RawData.Sum(a => a.Length);
                byte[] buffer = new byte[bufferSize];
                stream = new MemoryStream(buffer);

                foreach (byte[] bytes in RawData)
                {
                    RawFileOffsets.Add((int)stream.Position);
                    stream.Write(bytes, 0, bytes.Length);
                }

                PB.Value = 0;
                tslp.Text = string.Empty;
                ss.Refresh();

                WriteM3MP(buffer, RawFileSize, RawFileOffsets, PB, tslp, ss);

                ModifyFileInfo m3mpXmlOut = new();

                int fileIndex = -1;

                if (File.Exists(Global.currentPath + @"\File Index.txt"))
                    fileIndex = Convert.ToInt32(File.ReadAllText(Global.currentPath + @"\File Index.txt"));
 
                m3mpXmlOut.Index = fileIndex;
                m3mpXmlOut.IsCompressed = false;

                int fileSize = (int)IO.FileInfo(Global.currentPath + @"\database.m3mp");

                m3mpXmlOut.MainCompressedSize = fileSize;
                m3mpXmlOut.MainUnCompressedSize = fileSize;
                m3mpXmlOut.VramCompressedSize = 0;
                m3mpXmlOut.VramUnCompressedSize = 0;
                IO.XmlSerialize(Global.currentPath + @"\database.xml", m3mpXmlOut);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (br != null)
                    br.Close();
                if (stream != null)
                    stream.Dispose();
            }
        }

        public static void WriteM3MP(byte[] dataBuffer, int[] RawFileSize, List<int> RawFileOffsets, ToolStripProgressBar PB, ToolStripLabel tslp, StatusStrip ss)
        {
            MemoryStream? stream = null;
            Reader? br = null;
            Writer? bw = null;

            List<byte[]>? UnCompressed_data = null;
            List<int>? UnCompressed_sizes = null;
            List<byte[]>? Compressed_data = null;
            List<int>? Compressed_sizes = null;
            List<int>? Data_offsets = null;

            int[] FileNameOffsets = new int[3];
            string[] FileName = new string[3];

            int FileSize = 0;
            int ChunkSize = 0;
            int Chunk = 1;
            int LastChunkSize = 0;

            try
            {
                stream = new MemoryStream(dataBuffer);
                br = new Reader(stream, Endian.Little);

                FileSize = dataBuffer.Length;
                ChunkSize = 32768;
                LastChunkSize = 0;
                decimal ChunkSizeDec = (decimal)FileSize / ChunkSize;
                byte Check = 0;

                if (FileSize < ChunkSize)
                {
                    LastChunkSize = FileSize;
                }
                else if (decimal.Round(ChunkSizeDec, 0) == ChunkSizeDec)
                {
                    Chunk = FileSize / ChunkSize;
                    Check = 1;
                }
                else if (decimal.Round(ChunkSizeDec, 0) != ChunkSizeDec)
                {
                    Chunk = (FileSize / ChunkSize) + 1;
                    LastChunkSize = ChunkSize * (Chunk - 1);
                    LastChunkSize = FileSize - LastChunkSize;
                    Check = 2;
                }

                UnCompressed_data = new List<byte[]>(Chunk);
                UnCompressed_sizes = new List<int>(Chunk);
                Compressed_data = new List<byte[]>(Chunk);
                Compressed_sizes = new List<int>(Chunk);
                Data_offsets = new List<int>(Chunk);

                if (Check == 0)
                {
                    UnCompressed_data.Add(br.ReadBytes(LastChunkSize));
                    UnCompressed_sizes.Add(LastChunkSize);
                }
                else if (Check == 1)
                {
                    for (int i = 0; i < Chunk; i++)
                    {
                        UnCompressed_data.Add(br.ReadBytes(ChunkSize));
                        UnCompressed_sizes.Add(ChunkSize);
                    }
                }
                else if (Check == 2)
                {
                    for (int i = 0; i < Chunk - 1; i++)
                    {
                        UnCompressed_data.Add(br.ReadBytes(ChunkSize));
                        UnCompressed_sizes.Add(ChunkSize);
                    }

                    UnCompressed_data.Add(br.ReadBytes(LastChunkSize));
                    UnCompressed_sizes.Add(LastChunkSize);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (br != null)
                    br.Close();
                if (stream != null)
                    stream.Close();
            }

            for (int i = 0; i < Chunk; i++)
            {
                Thread t1 = new(() =>
                {
                    Compressed_data.Add(ZstdHelper.Compress(UnCompressed_data[i]));
                    Compressed_sizes.Add(Compressed_data[i].Length);
                });
                t1.Start();
                t1.Join();

                PB.Maximum = Chunk;
                PB.Value = (i);
                PB.PerformStep();

                int percent = (100 * i) / Chunk;
                tslp.Text = percent + "%";
                ss.Refresh();
            }

            PB.Value = 0;
            tslp.Text = string.Empty;
            ss.Refresh();

            try
            {
                FileName = FileNames();

                bw = new Writer(Global.currentPath + @"\database.m3mp", FileMode.Create, Endian.Little);

                int DataOffset = 165;

                bw.WriteInt32(0x504D334D, Endian.Little); // Magic
                bw.WriteInt32(3, Endian.Little); // Amount of files
                bw.WriteInt32(Chunk, Endian.Little); // Chunks
                bw.WriteInt32(DataOffset, Endian.Little); // Data Offset

                for (int i = 0; i < 3; i++)
                {
                    bw.WriteInt32(0, Endian.Little); // File offsets
                    bw.WriteInt32(0, Endian.Little); // Uncompressed file sizes
                    bw.WriteInt32(0, Endian.Little); // File Name Offsets
                    bw.WriteInt32(0, Endian.Little); // Reserved
                }

                for (int i = 0; i < 3; i++)
                {
                    FileNameOffsets[i] = Convert.ToInt32(bw.Position);
                    bw.WriteString(FileName[i].Replace("\\", "/")); // DB Files
                    bw.WriteInt8(0); // Reserved
                }

                bw.Position = 16;

                for (int i = 0; i < 3; i++)
                {
                    bw.WriteInt32(RawFileOffsets[i], Endian.Little); // File offsets
                    bw.WriteInt32(RawFileSize[i], Endian.Little); // Uncompressed file sizes
                    bw.WriteInt32(FileNameOffsets[i], Endian.Little); // File Name Offsets
                    bw.WriteInt32(0, Endian.Little); // Reserved
                }

                bw.Position = DataOffset;

                byte[] buff = new byte[12 * Chunk];
                bw.Write(buff, Endian.Little);

                for (int i = 0; i < Chunk; i++)
                {
                    Data_offsets.Add((int)bw.Position);
                    bw.Write(Compressed_data[i], Endian.Little);

                    PB.Maximum = Chunk;
                    PB.Value = (i);
                    PB.PerformStep();

                    int percent = (100 * i) / Chunk;
                    tslp.Text = percent + "%";
                    ss.Refresh();
                }

                bw.Position = DataOffset;

                for (int i = 0; i < Chunk; i++)
                {
                    bw.WriteInt32(Data_offsets[i], Endian.Little);
                    bw.WriteInt32(Compressed_sizes[i], Endian.Little);
                    bw.WriteInt32(UnCompressed_sizes[i], Endian.Little);
                }

                PB.Value = 0;
                tslp.Text = string.Empty;
                ss.Refresh();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (bw != null)
                    bw.Close();
            }
        }

        private static string[] FileNames()
        {
            string[] names = [@"defaultdata\defaultdata_players", @"defaultdata\defaultdata_clubs", @"defaultdata\playerdatabase_version.bin"];
            return names;
        }
    }
}