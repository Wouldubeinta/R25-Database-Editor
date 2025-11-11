using PackageIO;

namespace R25_Database_Editor
{
    /// <summary>
    /// Commentary Hashes Class.
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
    /// [Wouldubeinta]	   10/11/2025	Created
    /// </history>
    public class CommentaryHashes
    {
        public static Dialogue_Wildcardhash.WildcardHash[] Read(string file)
        {
            Reader? br = null;
            Dialogue_Wildcardhash.WildcardHash[]? wildcardHashes = null;

            try
            {
                br = new Reader(file);

                uint count = br.ReadUInt32();
                wildcardHashes = new Dialogue_Wildcardhash.WildcardHash[count];

                for (int i = 0; i < count; i++)
                {
                    wildcardHashes[i] = new Dialogue_Wildcardhash.WildcardHash();
                    wildcardHashes[i].hash = br.ReadUInt32();
                    int nameSize = br.ReadInt32();
                    wildcardHashes[i].name = br.ReadString(nameSize);
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (br != null) { br.Close(); br = null; }
            }
            return wildcardHashes;
        }

        public static int GetHashes(uint hash, Dialogue_Wildcardhash.WildcardHash[] wildcardHashes)
        {
            int index = -1;

            for (int i = 0; i < wildcardHashes.Length; i++)
            {
                if (wildcardHashes[i].hash == hash)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public static uint SetHashes(string name, Dialogue_Wildcardhash.WildcardHash[] wildcardHashes)
        {
            uint hash = 2913447899; // none hash

            for (int i = 0; i < wildcardHashes.Length; i++)
            {
                if (wildcardHashes[i].name == name)
                {
                    hash = wildcardHashes[i].hash;
                    break;
                }
            }
            return hash;
        }
    }
}
