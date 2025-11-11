namespace R25_Database_Editor
{
    /// <summary>
    /// Globals Class.
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
    /// [Wouldubeinta]	   03/09/2025	Created
    /// </history>
    public class Global
    {
        public const int MAX_TOTAL_TEAMS = 600;

        public const int MIN_PLAYERS_PER_TEAM = 23;
        public const int MAX_PLAYERS_PER_TEAM = 64;
        public const int MAX_TOTAL_PLAYERS = MAX_TOTAL_TEAMS * MAX_PLAYERS_PER_TEAM;

        private static TeamData.Team[] _team = new TeamData.Team[MAX_TOTAL_TEAMS];
        private static PlayerData.Player[] _player = new PlayerData.Player[MAX_TOTAL_PLAYERS];

        private static byte[] _TeamHeader = new byte[3748];
        private static byte[] _PlayerHeader = new byte[3112];

        private static string _version = string.Empty;
        private static string _currentPath = string.Empty;

        private static int _teamRowIndex = 0;

        private static int _team_amount = 0;
        private static int _team_index = 0;

        private static int _playerRowIndex = 0;

        private static int _player_amount = 0;
        private static int _player_index = 0;

        public static TeamData.Team[] team
        {
            get { return _team; }
            set { _team = value; }
        }

        public static PlayerData.Player[] player
        {
            get { return _player; }
            set { _player = value; }
        }

        public static string version
        {
            get { return _version; }
            set { _version = value; }
        }

        public static string currentPath
        {
            get { return _currentPath; }
            set { _currentPath = value; }
        }

        public static byte[] TeamHeader
        {
            get { return _TeamHeader; }
            set { _TeamHeader = value; }
        }

        public static byte[] PlayerHeader
        {
            get { return _PlayerHeader; }
            set { _PlayerHeader = value; }
        }

        public static int teamRowIndex
        {
            get { return _teamRowIndex; }
            set { _teamRowIndex = value; }
        }

        public static int team_index
        {
            get { return _team_index; }
            set { _team_index = value; }
        }

        public static int team_amount
        {
            get { return _team_amount; }
            set { _team_amount = value; }
        }

        public static int playerRowIndex
        {
            get { return _playerRowIndex; }
            set { _playerRowIndex = value; }
        }

        public static int player_amount
        {
            get { return _player_amount; }
            set { _player_amount = value; }
        }

        public static int player_index
        {
            get { return _player_index; }
            set { _player_index = value; }
        }
    }
}
