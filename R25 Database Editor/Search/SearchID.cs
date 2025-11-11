namespace R25_Database_Editor
{
    /// <summary>
    /// Search Id Class.
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
    /// [Wouldubeinta]	   02/09/2025	Created
    /// </history>
    public class SearchID
    {
        public static int TeamsIndex(int index)
        {
            int selectedIndex = 1;

            try
            {
                for (int i = 0; i < Global.team_amount; i++)
                {
                    if (Global.team[i].id.Equals(index))
                    {
                        selectedIndex = i;
                        break;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            return selectedIndex;
        }

        public static int PlayersIndex(int index)
        {
            int SelectedIndex = 1;

            try
            {
                for (int i = 0; i < Global.player_amount; i++)
                {
                    if (Global.player[i].id.Equals(index))
                    {
                        SelectedIndex = i;
                        break;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            return SelectedIndex;
        }

        public static int RolesIndex(string role)
        {
            int SelectedIndex = -1;

            try
            {
                for (int i = 0; i < StringArrays.Roles.Length; i++)
                {
                    if (StringArrays.Roles[i].Equals(role))
                    {
                        SelectedIndex = i;
                        break;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            return SelectedIndex;
        }
    }
}
