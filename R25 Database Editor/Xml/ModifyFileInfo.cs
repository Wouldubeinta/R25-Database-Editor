using System.Xml.Serialization;

namespace R25_Database_Editor
{
    /// <summary>
    /// Modify File Info Class.
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
    /// [Wouldubeinta]	   23/09/2025	Created
    /// </history>
    [Serializable()]
    public partial class ModifyFileInfo
    {
        #region Fields
        private int index = 0;
        private bool isCompressed = true;
        private int mainCompressedSize = 0;
        private int mainUnCompressedSize = 0;
        private int vramCompressedSize = 0;
        private int vramUnCompressedSize = 0;
        #endregion

        #region Properties
        [XmlAttribute()]
        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        [XmlAttribute()]
        public bool IsCompressed
        {
            get { return isCompressed; }
            set { isCompressed = value; }
        }

        [XmlAttribute()]
        public int MainCompressedSize
        {
            get { return mainCompressedSize; }
            set { mainCompressedSize = value; }
        }

        [XmlAttribute()]
        public int MainUnCompressedSize
        {
            get { return mainUnCompressedSize; }
            set { mainUnCompressedSize = value; }
        }

        [XmlAttribute()]
        public int VramCompressedSize
        {
            get { return vramCompressedSize; }
            set { vramCompressedSize = value; }
        }

        [XmlAttribute()]
        public int VramUnCompressedSize
        {
            get { return vramUnCompressedSize; }
            set { vramUnCompressedSize = value; }
        }
        #endregion
    }
}
