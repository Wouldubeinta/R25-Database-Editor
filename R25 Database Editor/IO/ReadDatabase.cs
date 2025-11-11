using PackageIO;
using System.Data;

namespace R25_Database_Editor
{
    /// <summary>
    /// Read Database Class.
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
    internal class ReadDatabase
    {
        public static void Defaultdata_Clubs(string file, DataGridView Teams_dataGridView)
        {
            Reader? br = null;
            DataTable? dt = null;
            Bitmap[]? Imagelist = null;

            try
            {
                dt = new DataTable();
                Imagelist = BitmapImage.genderImages();

                dt.Columns.Add("Gender", typeof(Image));
                dt.Columns.Add("Team Index", typeof(int));
                dt.Columns.Add("Team ID", typeof(int));
                dt.Columns.Add("Full Name", typeof(string));
                dt.Columns.Add("Short Name", typeof(string));

                br = new Reader(file, FileMode.Open, Endian.Little);

                Global.TeamHeader = br.ReadBytes(3748, Endian.Little);
                Global.team_amount = br.ReadInt32(Endian.Little);

                for (int i = 0; i < Global.team_amount; i++)
                {
                    Global.team[i].identifier = br.ReadInt32(Endian.Little);

                    Global.team[i].teamEnabled = br.ReadBoolean();

                    Global.team[i].isId = br.ReadBoolean();
                    Global.team[i].id = br.ReadInt32(Endian.Little);

                    Global.team[i].isLicensed = br.ReadBoolean();
                    Global.team[i].licensed = br.ReadBoolean();

                    Global.team[i].isFullName = br.ReadBoolean();
                    Global.team[i].fullNameSize = br.ReadByte();
                    Global.team[i].fullName = br.ReadString(Global.team[i].fullNameSize);

                    Global.team[i].isShortName = br.ReadBoolean();
                    Global.team[i].shortNameSize = br.ReadByte();
                    Global.team[i].shortName = br.ReadString(Global.team[i].shortNameSize);

                    Global.team[i].isNickname = br.ReadBoolean();
                    Global.team[i].nicknameSize = br.ReadByte();
                    Global.team[i].nickname = br.ReadString(Global.team[i].nicknameSize);

                    Global.team[i].isHudName = br.ReadBoolean();
                    Global.team[i].hudNameSize = br.ReadByte();
                    Global.team[i].hudName = br.ReadString(Global.team[i].hudNameSize);

                    Global.team[i].isShirtName = br.ReadBoolean();

                    if (Global.team[i].isShirtName) 
                    {
                        Global.team[i].shirtNameSize = br.ReadByte();
                        Global.team[i].shirtName = br.ReadString(Global.team[i].shirtNameSize);
                    }

                    Global.team[i].isGender = br.ReadBoolean();
                    Global.team[i].gender = br.ReadInt32(Endian.Little);

                    Global.team[i].islogo = br.ReadBoolean();
                    Global.team[i].logoSize = br.ReadByte();
                    Global.team[i].logo = br.ReadString(Global.team[i].logoSize);

                    Global.team[i].isWcLogo = br.ReadBoolean();
                    Global.team[i].wcLogoSize = 0;
                    Global.team[i].wcLogo = string.Empty;

                    if (Global.team[i].isWcLogo)
                    {
                        Global.team[i].wcLogoSize = br.ReadByte();
                        Global.team[i].wcLogo = br.ReadString(Global.team[i].wcLogoSize);
                    }

                    Global.team[i].isSupporters = br.ReadBoolean();
                    Global.team[i].supporters = 0;

                    if (Global.team[i].isSupporters) 
                        Global.team[i].supporters = br.ReadInt32(Endian.Little);

                    Global.team[i].isCommentaryTeamHash = br.ReadBoolean();
                    Global.team[i].commentaryTeamHash = br.ReadUInt32(Endian.Little);

                    Global.team[i].primaryColour.isRgb = br.ReadBoolean();
                    Global.team[i].primaryColour.r = br.ReadByte();
                    Global.team[i].primaryColour.g = br.ReadByte();
                    Global.team[i].primaryColour.b = br.ReadByte();

                    Global.team[i].secondaryColour.isRgb = br.ReadBoolean();
                    Global.team[i].secondaryColour.r = br.ReadByte();
                    Global.team[i].secondaryColour.g = br.ReadByte();
                    Global.team[i].secondaryColour.b = br.ReadByte();

                    Global.team[i].hudTextColour.isRgb = br.ReadBoolean();
                    Global.team[i].hudTextColour.r = br.ReadByte();
                    Global.team[i].hudTextColour.g = br.ReadByte();
                    Global.team[i].hudTextColour.b = br.ReadByte();

                    Global.team[i].isClubType = br.ReadBoolean();
                    Global.team[i].clubType = 0;

                    if (Global.team[i].isClubType)
                        Global.team[i].clubType = br.ReadInt32(Endian.Little);

                    Global.team[i].isAffiliations = br.ReadBoolean();
                    Global.team[i].affiliations = 0;

                    if (Global.team[i].isAffiliations)
                        Global.team[i].affiliations = br.ReadInt32(Endian.Little);

                    Global.team[i].isWorldCupTeam = br.ReadBoolean();
                    Global.team[i].WorldCupTeam = false;

                    if (Global.team[i].isWorldCupTeam)
                        Global.team[i].WorldCupTeam = br.ReadBoolean();

                    Global.team[i].isStadiumAmount = br.ReadBoolean();
                    Global.team[i].stadiumAmount = br.ReadInt32(Endian.Little);

                    Global.team[i].stadium = new TeamData.Stadium[3];

                    for (int j = 0; j < 3; j++)
                    {
                        Global.team[i].stadium[j].isId = br.ReadBoolean();
                        Global.team[i].stadium[j].id = 5;

                        if (Global.team[i].stadium[j].isId)
                            Global.team[i].stadium[j].id = br.ReadInt32(Endian.Little);

                        Global.team[i].stadium[j].isWantCustomName = br.ReadBoolean();
                        Global.team[i].stadium[j].wantCustomName = false;

                        if (Global.team[i].stadium[j].isWantCustomName)
                            Global.team[i].stadium[j].wantCustomName = br.ReadBoolean();

                        Global.team[i].stadium[j].isCustomName = br.ReadBoolean();
                        Global.team[i].stadium[j].customNameSize = 0;
                        Global.team[i].stadium[j].customName = string.Empty;

                        if (Global.team[i].stadium[j].isCustomName)
                        {
                            Global.team[i].stadium[j].customNameSize = br.ReadByte();
                            Global.team[i].stadium[j].customName = br.ReadString(Global.team[i].stadium[j].customNameSize);
                        }

                        Global.team[i].stadium[j].isStadiumIsOnDisk = br.ReadBoolean();
                        Global.team[i].stadium[j].StadiumIsOnDisk = false;

                        if (Global.team[i].stadium[j].isStadiumIsOnDisk)
                            Global.team[i].stadium[j].StadiumIsOnDisk = br.ReadBoolean();
                    }

                    Global.team[i].finalStadium.isId = br.ReadBoolean();
                    Global.team[i].finalStadium.id = 5;

                    if (Global.team[i].finalStadium.isId)
                        Global.team[i].finalStadium.id = br.ReadInt32(Endian.Little);

                    Global.team[i].finalStadium.isWantCustomName = br.ReadBoolean();
                    Global.team[i].finalStadium.wantCustomName = false;

                    if (Global.team[i].finalStadium.isWantCustomName)
                        Global.team[i].finalStadium.wantCustomName = br.ReadBoolean();

                    Global.team[i].finalStadium.isCustomName = br.ReadBoolean();
                    Global.team[i].finalStadium.customNameSize = 0;
                    Global.team[i].finalStadium.customName = string.Empty;

                    if (Global.team[i].finalStadium.isCustomName)
                    {
                        Global.team[i].finalStadium.customNameSize = br.ReadByte();
                        Global.team[i].finalStadium.customName = br.ReadString(Global.team[i].finalStadium.customNameSize);
                    }

                    Global.team[i].feederClubs = new TeamData.FeederClubs[7];
                    byte feederClub_Amount = 0;

                    for (int j = 0; j < 7; j++)
                    {
                        Global.team[i].feederClubs[j].isFeederClubs = br.ReadBoolean();
                        Global.team[i].feederClubs[j].feederClubsId = 1;

                        if (Global.team[i].feederClubs[j].isFeederClubs)
                        {
                            feederClub_Amount++;
                            Global.team[i].feederClubs[j].feederClubsId = br.ReadInt32(Endian.Little);
                        }
                    }

                    Global.team[i].feederClubsAmount = feederClub_Amount;

                    Global.team[i].fedFromClubs = new TeamData.FedFromClubs[7];
                    byte fedFromClubs_Amount = 0;

                    for (int j = 0; j < 7; j++)
                    {
                        Global.team[i].fedFromClubs[j].isFedFromClubs = br.ReadBoolean();
                        Global.team[i].fedFromClubs[j].fedFromClubsId = 1;

                        if (Global.team[i].fedFromClubs[j].isFedFromClubs)
                        {
                            fedFromClubs_Amount++;
                            Global.team[i].fedFromClubs[j].fedFromClubsId = br.ReadInt32(Endian.Little);
                        }
                    }

                    Global.team[i].fedFromClubsAmount = fedFromClubs_Amount;

                    Global.team[i].isAlternateNumbering = br.ReadBoolean();
                    Global.team[i].alternateNumbering = false;

                    if (Global.team[i].isAlternateNumbering)
                        Global.team[i].alternateNumbering = br.ReadBoolean();

                    Global.team[i].isPlayerRoster = br.ReadBoolean();

                    Global.team[i].players = new TeamData.TeamPlayers[Global.MAX_PLAYERS_PER_TEAM]; // 64 players max.
                    byte team_players_amount = 0;

                    if (Global.team[i].isPlayerRoster) 
                    {
                        for (int j = 0; j < Global.MAX_PLAYERS_PER_TEAM; j++) // 64 players max.
                        {
                            Global.team[i].players[j].isPlayerId = br.ReadBoolean();
                            Global.team[i].players[j].playerId = 1;

                            if (Global.team[i].players[j].isPlayerId)
                            {
                                team_players_amount++;
                                Global.team[i].players[j].playerId = br.ReadInt32(Endian.Little);
                            }
                        }

                        Global.team[i].playerAmount = team_players_amount;
                    }

                    // LeagueMatch
                    Global.team[i].isLeagueMatch = br.ReadBoolean();
                    Global.team[i].leagueRoles = new TeamData.LeagueRoles[4];

                    if (Global.team[i].isLeagueMatch)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            Global.team[i].leagueRoles[j].isLeagueRoleId = br.ReadBoolean();
                            Global.team[i].leagueRoles[j].leagueRoleId = 0;

                            if (Global.team[i].leagueRoles[j].isLeagueRoleId)
                                Global.team[i].leagueRoles[j].leagueRoleId = br.ReadInt32(Endian.Little);
                        }

                        Global.team[i].leagueLineups = new TeamData.LeagueLineups[17]; // 17 players

                        for (int j = 0; j < 17; j++)
                        {
                            Global.team[i].leagueLineups[j].isLeagueLineupId = br.ReadBoolean();
                            Global.team[i].leagueLineups[j].leagueLineupId = 0;

                            if (Global.team[i].leagueLineups[j].isLeagueLineupId)
                                Global.team[i].leagueLineups[j].leagueLineupId = br.ReadInt32(Endian.Little);
                        }
                    }

                    // UnionMatch
                    Global.team[i].isUnionMatch = br.ReadBoolean();
                    Global.team[i].unionRoles = new TeamData.UnionRoles[4];

                    if (Global.team[i].isUnionMatch) 
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            Global.team[i].unionRoles[j].isUnionRoleId = br.ReadBoolean();
                            Global.team[i].unionRoles[j].unionRoleId = 1;

                            if (Global.team[i].unionRoles[j].isUnionRoleId)
                                Global.team[i].unionRoles[j].unionRoleId = br.ReadInt32(Endian.Little);
                        }

                        Global.team[i].unionLineups = new TeamData.UnionLineups[Global.MIN_PLAYERS_PER_TEAM];

                        for (int j = 0; j < Global.MIN_PLAYERS_PER_TEAM; j++)
                        {
                            Global.team[i].unionLineups[j].isUnionLineupId = br.ReadBoolean();
                            Global.team[i].unionLineups[j].unionLineupId = 1;

                            if (Global.team[i].unionLineups[j].isUnionLineupId)
                                Global.team[i].unionLineups[j].unionLineupId = br.ReadInt32(Endian.Little);
                        }
                    }

                    // NinesMatch
                    Global.team[i].isNinesMatch = br.ReadBoolean();
                    Global.team[i].nineRoles = new TeamData.NineRoles[4];

                    if (Global.team[i].isNinesMatch) 
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            Global.team[i].nineRoles[j].isNinesRoleId = br.ReadBoolean();
                            Global.team[i].nineRoles[j].nineRoleId = 0;

                            if (Global.team[i].nineRoles[j].isNinesRoleId)
                                Global.team[i].nineRoles[j].nineRoleId = br.ReadInt32(Endian.Little);
                        }

                        Global.team[i].nineLineups = new TeamData.NineLineups[14];

                        for (int j = 0; j < 14; j++)
                        {
                            Global.team[i].nineLineups[j].isNineLineupId = br.ReadBoolean();
                            Global.team[i].nineLineups[j].nineLineupId = 0;

                            if (Global.team[i].nineLineups[j].isNineLineupId)
                                Global.team[i].nineLineups[j].nineLineupId = br.ReadInt32(Endian.Little);
                        }
                    }

                    // Shirt Data
                    Global.team[i].dataSize = br.ReadInt32(Endian.Little);
                    Global.team[i].data = br.ReadBytes(Global.team[i].dataSize, Endian.Little);

                    /*
                    //int dataSize = Global.team[i].dataSize - (2 + (518 * 8) + 9);
                    //Global.team[i].data = br.ReadBytes(dataSize, Endian.Little);

                    Global.team[i].jerseyAmount = br.ReadInt16();
                    Global.team[i].jerseys = new TeamData.Jerseys[8];
                    count += Global.team[i].jerseyAmount;

                    for (int j = 0; j < 8; j++)
                    {
                        Global.team[i].jerseys[j].name = br.ReadNullTerminatedString();
                        br.ReadBytes(24 - Global.team[i].jerseys[j].name.Length, Endian.Little);
                        Global.team[i].jerseys[j].padding1 = br.ReadBytes(83, Endian.Little);
                        Global.team[i].jerseys[j].numberColour.r = br.ReadByte();
                        Global.team[i].jerseys[j].padding2 = br.ReadByte();
                        Global.team[i].jerseys[j].numberColour.b = br.ReadByte();
                        Global.team[i].jerseys[j].padding3 = br.ReadBytes(54, Endian.Little);
                        Global.team[i].jerseys[j].licensedShortsId = br.ReadInt16();
                        Global.team[i].jerseys[j].padding4 = br.ReadBytes(98, Endian.Little);
                        Global.team[i].jerseys[j].licensedTopId = br.ReadInt16();
                        Global.team[i].jerseys[j].padding5 = br.ReadBytes(16, Endian.Little);
                        Global.team[i].jerseys[j].licensedSocksId = br.ReadInt16();
                        Global.team[i].jerseys[j].padding6 = br.ReadBytes(137, Endian.Little);
                        Global.team[i].jerseys[j].numberColour.g = br.ReadByte();
                        Global.team[i].jerseys[j].padding7 = br.ReadBytes(17, Endian.Little);
                        int t = 0;

                        /*
                        if (Global.team[i].jerseys[j].name != string.Empty) 
                        {
                            writer.WriteInt8(Convert.ToSByte(Global.team[i].fullName.Length));
                            writer.WriteString(Global.team[i].fullName);
                            writer.WriteInt8(Convert.ToSByte(Global.team[i].jerseys[j].name.Length));
                            writer.WriteString(Global.team[i].jerseys[j].name);
                            writer.WriteInt16(Global.team[i].jerseys[j].licensedTopId);
                            writer.WriteInt16(Global.team[i].jerseys[j].licensedShortsId);
                            writer.WriteInt16(Global.team[i].jerseys[j].licensedSocksId);
                        }
                        */

                        /*
                        Global.team[i].jerseys[j].nameColour.g = br.ReadByte();
                        Global.team[i].jerseys[j].padding2 = br.ReadBytes(14, Endian.Little);
                        Global.team[i].jerseys[j].nameColour.r = br.ReadByte();
                        Global.team[i].jerseys[j].padding3 = br.ReadBytes(35, Endian.Little);
                        Global.team[i].jerseys[j].nameColour.b = br.ReadByte();
                        Global.team[i].jerseys[j].padding4 = br.ReadBytes(8, Endian.Little);
                        Global.team[i].jerseys[j].keylineColour.b = br.ReadByte();
                        Global.team[i].jerseys[j].padding5 = br.ReadBytes(57, Endian.Little);
                        Global.team[i].jerseys[j].showNumber = br.ReadBoolean();
                        Global.team[i].jerseys[j].padding6 = br.ReadUInt16(Endian.Little);
                        Global.team[i].jerseys[j].keylineColour.g = br.ReadByte();
                        Global.team[i].jerseys[j].padding7 = br.ReadBytes(5, Endian.Little);
                        Global.team[i].jerseys[j].showInternalKeyline = br.ReadBoolean();
                        Global.team[i].jerseys[j].padding8 = br.ReadBytes(61, Endian.Little);
                        Global.team[i].jerseys[j].padding9 = br.ReadBytes(53, Endian.Little);
                        Global.team[i].jerseys[j].padding10 = br.ReadBytes(42, Endian.Little);
                        Global.team[i].jerseys[j].padding11 = br.ReadBytes(19, Endian.Little);
                        Global.team[i].jerseys[j].licensedId = br.ReadInt16(Endian.Little);
                        Global.team[i].jerseys[j].padding12 = br.ReadBytes(39, Endian.Little);
                        Global.team[i].jerseys[j].keylineSize = br.ReadByte();
                        Global.team[i].jerseys[j].padding13 = br.ReadBytes(48, Endian.Little);
                        Global.team[i].jerseys[j].numberFont = br.ReadByte();
                        Global.team[i].jerseys[j].padding14 = br.ReadBytes(79, Endian.Little);
                        Global.team[i].jerseys[j].nameFont = br.ReadByte();
                        Global.team[i].jerseys[j].padding15 = br.ReadBytes(15, Endian.Little);
                        Global.team[i].jerseys[j].keylineOffset = br.ReadByte();
                        Global.team[i].jerseys[j].showingLeadingZero = br.ReadBoolean();
                        Global.team[i].jerseys[j].padding16 = br.ReadBytes(7, Endian.Little);
                        Global.team[i].jerseys[j].showName = br.ReadBoolean();
                        Global.team[i].jerseys[j].padding17 = br.ReadBytes(39, Endian.Little);
                        Global.team[i].jerseys[j].keylineColour.r = br.ReadByte();
                        Global.team[i].jerseys[j].padding18 = br.ReadBytes(9, Endian.Little);
                    }

                    writer.Position = 0;

                    writer.WriteInt32(count);

                    Global.team[i].padding2 = br.ReadBytes(9, Endian.Little);
                    */
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["Gender"] = Imagelist[Global.team[i].gender];
                    dt.Rows[dt.Rows.Count - 1]["Team Index"] = i;
                    dt.Rows[dt.Rows.Count - 1]["Team ID"] = Global.team[i].id;
                    dt.Rows[dt.Rows.Count - 1]["Full Name"] = Global.team[i].shortName;
                    dt.Rows[dt.Rows.Count - 1]["Short Name"] = Global.team[i].nickname;
                }

                Teams_dataGridView.DataSource = dt;
                Teams_dataGridView.Columns[0].Width = 70;
                Teams_dataGridView.Columns[1].Width = 95;
                Teams_dataGridView.Columns[2].Width = 95;
                Teams_dataGridView.Columns[3].Width = 185;
                Teams_dataGridView.Columns[4].Width = 185;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (br != null)
                    br.Close();
            }
        }

        public static void Defaultdata_Players(string file, DataGridView Players_dataGridView)
        {
            Players_dataGridView.DataSource = null;

            Reader? br = null;
            DataTable? dt = null;
            Bitmap[]? Imagelist = null;

            try
            {
                dt = new DataTable();
                Imagelist = BitmapImage.genderImages();

                dt.Columns.Add("Gender", typeof(Image));
                dt.Columns.Add("Player Index", typeof(int));
                dt.Columns.Add("Player ID", typeof(int));
                dt.Columns.Add("First Name", typeof(string));
                dt.Columns.Add("Last Name", typeof(string));

                br = new Reader(file, FileMode.Open, Endian.Little);

                Global.PlayerHeader = br.ReadBytes(3112, Endian.Little);
                Global.player_amount = br.ReadInt32(Endian.Little);

                for (int i = 0; i < Global.player_amount; i++)
                {
                    Global.player[i].identifier = br.ReadInt32(Endian.Little);

                    Global.player[i].dataSize = br.ReadInt32(Endian.Little);
                    Global.player[i].data = br.ReadBytes(Global.player[i].dataSize, Endian.Little); // Player appearance data.

                    Global.player[i].playerEnabled = br.ReadBoolean(); // ?

                    // Player ID
                    Global.player[i].isId = br.ReadBoolean();
                    Global.player[i].id = br.ReadInt32(Endian.Little);

                    // First Name
                    Global.player[i].isFirstName = br.ReadBoolean();
                    Global.player[i].firstNameSize = 0;
                    Global.player[i].firstName = string.Empty;

                    if (Global.player[i].isFirstName) 
                    {
                        Global.player[i].firstNameSize = br.ReadByte();
                        Global.player[i].firstName = br.ReadString(Global.player[i].firstNameSize);
                    }

                    // Last Name
                    Global.player[i].isLastName = br.ReadBoolean();
                    Global.player[i].lastNameSize = 0;
                    Global.player[i].lastName = string.Empty;

                    if (Global.player[i].isLastName) 
                    {
                        Global.player[i].lastNameSize = br.ReadByte();
                        Global.player[i].lastName = br.ReadString(Global.player[i].lastNameSize);
                    }

                    Global.player[i].isLicensed = br.ReadBoolean();
                    Global.player[i].licensed = false;

                    if (Global.player[i].isLicensed)
                        Global.player[i].licensed = br.ReadBoolean();

                    Global.player[i].isGender = br.ReadBoolean();
                    Global.player[i].gender = 0;

                    if (Global.player[i].isGender)
                        Global.player[i].gender = br.ReadInt32(Endian.Little);

                    Global.player[i].isJerseyName = br.ReadBoolean();
                    Global.player[i].jerseyNameSize = 0;
                    Global.player[i].jerseyName = string.Empty;

                    if (Global.player[i].isJerseyName) 
                    {
                        Global.player[i].jerseyNameSize = br.ReadByte();
                        Global.player[i].jerseyName = br.ReadString(Global.player[i].jerseyNameSize);
                    }

                    Global.player[i].isJerseyNumber = br.ReadBoolean();
                    Global.player[i].jerseyNumber = 1;

                    if (Global.player[i].isJerseyNumber)
                        Global.player[i].jerseyNumber = br.ReadInt32(Endian.Little);

                    Global.player[i].dob.isDay = br.ReadBoolean();
                    Global.player[i].dob.day = br.ReadInt32(Endian.Little);
                    Global.player[i].dob.isMonth = br.ReadBoolean();
                    Global.player[i].dob.month = br.ReadInt32(Endian.Little);
                    Global.player[i].dob.isYear = br.ReadBoolean();
                    Global.player[i].dob.year = br.ReadInt32(Endian.Little);

                    Global.player[i].isAge = br.ReadBoolean();
                    Global.player[i].age = 0;

                    if (Global.player[i].isAge)
                        Global.player[i].age = br.ReadInt32(Endian.Little);

                    Global.player[i].isCountryOfBirth = br.ReadBoolean();
                    Global.player[i].countryOfBirth = 0;

                    if (Global.player[i].isCountryOfBirth)
                        Global.player[i].countryOfBirth = br.ReadInt32(Endian.Little);

                    Global.player[i].isRepCountry = br.ReadBoolean();
                    Global.player[i].repCountry = 0;

                    if (Global.player[i].isRepCountry)
                        Global.player[i].repCountry = br.ReadInt32(Endian.Little);

                    Global.player[i].isStateOfOrigin = br.ReadBoolean();
                    Global.player[i].stateOfOrigin = 0;

                    if (Global.player[i].isStateOfOrigin)
                        Global.player[i].stateOfOrigin = br.ReadInt32(Endian.Little);

                    Global.player[i].isCityVsCountry = br.ReadBoolean();
                    Global.player[i].cityVsCountry = 0;

                    if (Global.player[i].isCityVsCountry)
                        Global.player[i].cityVsCountry = br.ReadInt32(Endian.Little);

                    Global.player[i].isAllStars = br.ReadBoolean();
                    Global.player[i].allStars = 0;

                    if (Global.player[i].isAllStars)
                        Global.player[i].allStars = br.ReadInt32(Endian.Little);

                    Global.player[i].isWorldCup = br.ReadBoolean();
                    Global.player[i].WorldCup = false;

                    if (Global.player[i].isWorldCup)
                        Global.player[i].WorldCup = br.ReadBoolean();

                    Global.player[i].isContractExpiry = br.ReadBoolean();
                    Global.player[i].contractExpiry = 0;

                    if (Global.player[i].isContractExpiry)
                        Global.player[i].contractExpiry = br.ReadInt32(Endian.Little);

                    Global.player[i].isPrimaryRole = br.ReadBoolean();
                    Global.player[i].primaryRole = 0;

                    if (Global.player[i].isPrimaryRole)
                        Global.player[i].primaryRole = br.ReadInt32(Endian.Little);

                    Global.player[i].isSecondaryRole = br.ReadBoolean();
                    Global.player[i].secondaryRole = 0;

                    if (Global.player[i].isSecondaryRole)
                        Global.player[i].secondaryRole = br.ReadInt32(Endian.Little);

                    Global.player[i].isTertiaryRole = br.ReadBoolean();
                    Global.player[i].tertiaryRole = 0;

                    if (Global.player[i].isTertiaryRole)
                        Global.player[i].tertiaryRole = br.ReadInt32(Endian.Little);

                    Global.player[i].isCommentaryNameHash = br.ReadBoolean();
                    Global.player[i].commentaryNameHash = 0;

                    if (Global.player[i].isCommentaryNameHash)
                        Global.player[i].commentaryNameHash = br.ReadUInt32(Endian.Little);

                    Global.player[i].isPreferredHand = br.ReadBoolean();
                    Global.player[i].preferredHand = 0;

                    if (Global.player[i].isPreferredHand)
                        Global.player[i].preferredHand = br.ReadByte();

                    Global.player[i].isPreferredFoot = br.ReadBoolean();
                    Global.player[i].preferredFoot = 0;

                    if (Global.player[i].isPreferredFoot)
                        Global.player[i].preferredFoot = br.ReadByte();

                    Global.player[i].appearance.isHeight = br.ReadBoolean();
                    Global.player[i].appearance.height = 0;

                    if (Global.player[i].appearance.isHeight)
                        Global.player[i].appearance.height = br.ReadInt32(Endian.Little);

                    Global.player[i].appearance.isWeight = br.ReadBoolean();

                    if (Global.player[i].appearance.isWeight)
                        Global.player[i].appearance.weight = br.ReadInt32(Endian.Little);

                    Global.player[i].attributes.isMovementProfile = br.ReadBoolean();
                    Global.player[i].attributes.movementProfile = 0;

                    if (Global.player[i].attributes.isMovementProfile)
                        Global.player[i].attributes.movementProfile = br.ReadInt32(Endian.Little);

                    Global.player[i].attributes.isTemperament = br.ReadBoolean();
                    Global.player[i].attributes.temperament = 0;

                    if (Global.player[i].attributes.isTemperament)
                        Global.player[i].attributes.temperament = br.ReadInt32(Endian.Little);

                    Global.player[i].attributes.isFitness = br.ReadBoolean();
                    Global.player[i].attributes.fitness = 0;

                    if (Global.player[i].attributes.isFitness)
                        Global.player[i].attributes.fitness = br.ReadInt32(Endian.Little);

                    // Strength Skills
                    Global.player[i].skills.strengthSkills.isStrength = br.ReadBoolean();
                    Global.player[i].skills.strengthSkills.strength = 50;

                    if (Global.player[i].skills.strengthSkills.isStrength)
                        Global.player[i].skills.strengthSkills.strength = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.strengthSkills.isRucking = br.ReadBoolean();
                    Global.player[i].skills.strengthSkills.rucking = 50;

                    if (Global.player[i].skills.strengthSkills.isRucking)
                        Global.player[i].skills.strengthSkills.rucking = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.strengthSkills.isScrummaging = br.ReadBoolean();
                    Global.player[i].skills.strengthSkills.scrummaging = 50;

                    if (Global.player[i].skills.strengthSkills.isScrummaging)
                        Global.player[i].skills.strengthSkills.scrummaging = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.strengthSkills.isTackling = br.ReadBoolean();
                    Global.player[i].skills.strengthSkills.tackling = 0;

                    if (Global.player[i].skills.strengthSkills.isTackling)
                        Global.player[i].skills.strengthSkills.tackling = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.strengthSkills.isBreakTackle = br.ReadBoolean();
                    Global.player[i].skills.strengthSkills.breakTackling = 50;

                    if (Global.player[i].skills.strengthSkills.isBreakTackle)
                        Global.player[i].skills.strengthSkills.breakTackling = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.strengthSkills.isFending = br.ReadBoolean();
                    Global.player[i].skills.strengthSkills.fending = 50;

                    if (Global.player[i].skills.strengthSkills.isFending)
                        Global.player[i].skills.strengthSkills.fending = br.ReadInt32(Endian.Little);

                    // Speed Skills
                    Global.player[i].skills.speedSkills.isAgility = br.ReadBoolean();

                    if (Global.player[i].skills.speedSkills.isAgility)
                        Global.player[i].skills.speedSkills.agility = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.speedSkills.isAcceleration = br.ReadBoolean();

                    if (Global.player[i].skills.speedSkills.isAcceleration)
                        Global.player[i].skills.speedSkills.acceleration = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.speedSkills.isSprintSpeed = br.ReadBoolean();

                    if (Global.player[i].skills.speedSkills.isSprintSpeed)
                        Global.player[i].skills.speedSkills.sprintSpeed = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.speedSkills.isBalance = br.ReadBoolean();
                    Global.player[i].skills.speedSkills.balance = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.speedSkills.isStamina = br.ReadBoolean();
                    Global.player[i].skills.speedSkills.stamina = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.speedSkills.isEvasion = br.ReadBoolean();
                    Global.player[i].skills.speedSkills.evasion = br.ReadInt32(Endian.Little);

                    // Kicking Skills
                    Global.player[i].skills.kickingSkills.isKickingAccuracy = br.ReadBoolean();
                    Global.player[i].skills.kickingSkills.kickingAccuracy = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.kickingSkills.isKickingPower = br.ReadBoolean();
                    Global.player[i].skills.kickingSkills.kickingPower = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.kickingSkills.isGoalKicking = br.ReadBoolean();
                    Global.player[i].skills.kickingSkills.goalKicking = br.ReadInt32(Endian.Little);

                    // Hands Skills
                    Global.player[i].skills.handsSkills.isPassing = br.ReadBoolean();
                    Global.player[i].skills.handsSkills.passing = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.handsSkills.isAerialSkills = br.ReadBoolean();
                    Global.player[i].skills.handsSkills.aerialSkills = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.handsSkills.isOffload = br.ReadBoolean();
                    Global.player[i].skills.handsSkills.offload = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.handsSkills.isJackal = br.ReadBoolean();
                    Global.player[i].skills.handsSkills.jackal = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.handsSkills.isIntercepting = br.ReadBoolean();
                    Global.player[i].skills.handsSkills.intercepting = br.ReadInt32(Endian.Little);

                    // Mentality Skills
                    Global.player[i].skills.mentalitySkills.isFocus = br.ReadBoolean();
                    Global.player[i].skills.mentalitySkills.focus = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.mentalitySkills.isLeadership = br.ReadBoolean();
                    Global.player[i].skills.mentalitySkills.leadership = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.mentalitySkills.isDetermination = br.ReadBoolean();
                    Global.player[i].skills.mentalitySkills.determination = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.mentalitySkills.isDiscipline = br.ReadBoolean();
                    Global.player[i].skills.mentalitySkills.discipline = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.kickingSkills.isToePoke = br.ReadBoolean();
                    Global.player[i].skills.kickingSkills.toePoke = 0;

                    if (Global.player[i].skills.kickingSkills.isToePoke)
                        Global.player[i].skills.kickingSkills.toePoke = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.kickingSkills.isConversionStyle = br.ReadBoolean();
                    Global.player[i].skills.kickingSkills.conversionStyle = 0;

                    if (Global.player[i].skills.kickingSkills.isConversionStyle)
                        Global.player[i].skills.kickingSkills.conversionStyle = br.ReadInt32(Endian.Little);

                    Global.player[i].appearance.isPhotogrammetryStatus = br.ReadBoolean();
                    Global.player[i].appearance.photogrammetryStatus = 0;

                    if (Global.player[i].appearance.isPhotogrammetryStatus)
                        Global.player[i].appearance.photogrammetryStatus = br.ReadInt32(Endian.Little);

                    // LeagueMatch Stats
                    Global.player[i].leagueMatchStats.isStatisticsStats = br.ReadBoolean();

                    if (Global.player[i].leagueMatchStats.isStatisticsStats)
                    {
                        Global.player[i].leagueMatchStats.isMatchesPlayed = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.matchesPlayed = 0;

                        if (Global.player[i].leagueMatchStats.isMatchesPlayed)
                            Global.player[i].leagueMatchStats.matchesPlayed = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isMatchesWon = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.matchesWon = 0;

                        if (Global.player[i].leagueMatchStats.isMatchesWon)
                            Global.player[i].leagueMatchStats.matchesWon = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isMatchesDrawn = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.matchesDrawn = 0;

                        if (Global.player[i].leagueMatchStats.isMatchesDrawn)
                            Global.player[i].leagueMatchStats.matchesDrawn = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isBallStrips = br.ReadBoolean();

                        if (Global.player[i].leagueMatchStats.isBallStrips)
                            Global.player[i].leagueMatchStats.ballStrips = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isConversions = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.conversions = 0;

                        if (Global.player[i].leagueMatchStats.isConversions)
                            Global.player[i].leagueMatchStats.conversions = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isConversionAttempts = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.conversionAttempts = 0;

                        if (Global.player[i].leagueMatchStats.isConversionAttempts)
                            Global.player[i].leagueMatchStats.conversionAttempts = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isFends = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.fends = 0;

                        if (Global.player[i].leagueMatchStats.isFends)
                            Global.player[i].leagueMatchStats.fends = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isFieldGoalAttempts = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.fieldGoalAttempts = 0;

                        if (Global.player[i].leagueMatchStats.isFieldGoalAttempts)
                            Global.player[i].leagueMatchStats.fieldGoalAttempts = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isFieldGoals = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.fieldGoals = 0;

                        if (Global.player[i].leagueMatchStats.isFieldGoals)
                            Global.player[i].leagueMatchStats.fieldGoals = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isFortyTwenties = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.fortyTwenties = 0;

                        if (Global.player[i].leagueMatchStats.isFortyTwenties)
                            Global.player[i].leagueMatchStats.fortyTwenties = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isHandlingErrors = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.handlingErrors = 0;

                        if (Global.player[i].leagueMatchStats.isHandlingErrors)
                            Global.player[i].leagueMatchStats.handlingErrors = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isHitups = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.hitups = 0;

                        if (Global.player[i].leagueMatchStats.isHitups)
                            Global.player[i].leagueMatchStats.hitups = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isInterceptedPasses = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.interceptedPasses = 0;

                        if (Global.player[i].leagueMatchStats.isInterceptedPasses)
                            Global.player[i].leagueMatchStats.interceptedPasses = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isInterceptions = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.interceptions = 0;

                        if (Global.player[i].leagueMatchStats.isInterceptions)
                            Global.player[i].leagueMatchStats.interceptions = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isKickMetresGained = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.kickMetresGained = 0;

                        if (Global.player[i].leagueMatchStats.isKickMetresGained)
                            Global.player[i].leagueMatchStats.kickMetresGained = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isKicksInPlay = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.kicksInPlay = 0;

                        if (Global.player[i].leagueMatchStats.isKicksInPlay)
                            Global.player[i].leagueMatchStats.kicksInPlay = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isKnockOns = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.knockOns = 0;

                        if (Global.player[i].leagueMatchStats.isKnockOns)
                            Global.player[i].leagueMatchStats.knockOns = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.islineBreakAssists = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.lineBreakAssists = 0;

                        if (Global.player[i].leagueMatchStats.islineBreakAssists)
                            Global.player[i].leagueMatchStats.lineBreakAssists = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isLineBreaks = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.lineBreaks = 0;

                        if (Global.player[i].leagueMatchStats.isLineBreaks)
                            Global.player[i].leagueMatchStats.lineBreaks = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isMetresRun = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.metresRun = 0;

                        if (Global.player[i].leagueMatchStats.isMetresRun)
                            Global.player[i].leagueMatchStats.metresRun = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isMinutesPlayed = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.minutesPlayed = 0;

                        if (Global.player[i].leagueMatchStats.isMinutesPlayed)
                            Global.player[i].leagueMatchStats.minutesPlayed = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isMissedTackles = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.missedTackles = 0;

                        if (Global.player[i].leagueMatchStats.isMissedTackles)
                            Global.player[i].leagueMatchStats.missedTackles = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isOffloads = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.offloads = 0;

                        if (Global.player[i].leagueMatchStats.isOffloads)
                            Global.player[i].leagueMatchStats.offloads = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isOneOnOneTackles = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.oneOnOneTackles = 0;

                        if (Global.player[i].leagueMatchStats.isOneOnOneTackles)
                            Global.player[i].leagueMatchStats.oneOnOneTackles = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isPasses = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.passes = 0;

                        if (Global.player[i].leagueMatchStats.isPasses)
                            Global.player[i].leagueMatchStats.passes = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isPenaltiesConceded = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.penaltiesConceded = 0;

                        if (Global.player[i].leagueMatchStats.isPenaltiesConceded)
                            Global.player[i].leagueMatchStats.penaltiesConceded = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isPenaltyGoals = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.penaltyGoals = 0;

                        if (Global.player[i].leagueMatchStats.isPenaltyGoals)
                            Global.player[i].leagueMatchStats.penaltyGoals = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isPenaltyGoalAttempts = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.penaltyGoalAttempts = 0;

                        if (Global.player[i].leagueMatchStats.isPenaltyGoalAttempts)
                            Global.player[i].leagueMatchStats.penaltyGoalAttempts = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isRuns = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.runs = 0;

                        if (Global.player[i].leagueMatchStats.isRuns)
                            Global.player[i].leagueMatchStats.runs = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isTackleBreaks = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.tackleBreaks = 0;

                        if (Global.player[i].leagueMatchStats.isTackleBreaks)
                            Global.player[i].leagueMatchStats.tackleBreaks = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isTackles = br.ReadBoolean();

                        if (Global.player[i].leagueMatchStats.isTackles)
                            Global.player[i].leagueMatchStats.tackles = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isTries = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.tries = 0;

                        if (Global.player[i].leagueMatchStats.isTries)
                            Global.player[i].leagueMatchStats.tries = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isTryAssists = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.tryAssists = 0;

                        if (Global.player[i].leagueMatchStats.isTryAssists)
                            Global.player[i].leagueMatchStats.tryAssists = br.ReadInt32(Endian.Little);

                        Global.player[i].leagueMatchStats.isBonusTries = br.ReadBoolean();
                        Global.player[i].leagueMatchStats.bonusTries = 0;

                        if (Global.player[i].leagueMatchStats.isBonusTries)
                            Global.player[i].leagueMatchStats.bonusTries = br.ReadInt32(Endian.Little);
                    }

                    // UnionMatch Stats
                    Global.player[i].unionMatchStats.isStatisticsStats = br.ReadBoolean();

                    if (Global.player[i].unionMatchStats.isStatisticsStats)
                    {
                        Global.player[i].unionMatchStats.isMatchesPlayed = br.ReadBoolean();
                        Global.player[i].unionMatchStats.matchesPlayed = 0;

                        if (Global.player[i].unionMatchStats.isMatchesPlayed)
                            Global.player[i].unionMatchStats.matchesPlayed = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isMatchesWon = br.ReadBoolean();
                        Global.player[i].unionMatchStats.matchesWon = 0;

                        if (Global.player[i].unionMatchStats.isMatchesWon)
                            Global.player[i].unionMatchStats.matchesWon = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isMatchesDrawn = br.ReadBoolean();
                        Global.player[i].unionMatchStats.matchesDrawn = 0;

                        if (Global.player[i].unionMatchStats.isMatchesDrawn)
                            Global.player[i].unionMatchStats.matchesDrawn = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isBallStrips = br.ReadBoolean();

                        if (Global.player[i].unionMatchStats.isBallStrips)
                            Global.player[i].unionMatchStats.ballStrips = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isConversions = br.ReadBoolean();
                        Global.player[i].unionMatchStats.conversions = 0;

                        if (Global.player[i].unionMatchStats.isConversions)
                            Global.player[i].unionMatchStats.conversions = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isConversionAttempts = br.ReadBoolean();
                        Global.player[i].unionMatchStats.conversionAttempts = 0;

                        if (Global.player[i].unionMatchStats.isConversionAttempts)
                            Global.player[i].unionMatchStats.conversionAttempts = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isFends = br.ReadBoolean();
                        Global.player[i].unionMatchStats.fends = 0;

                        if (Global.player[i].unionMatchStats.isFends)
                            Global.player[i].unionMatchStats.fends = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isFieldGoalAttempts = br.ReadBoolean();
                        Global.player[i].unionMatchStats.fieldGoalAttempts = 0;

                        if (Global.player[i].unionMatchStats.isFieldGoalAttempts)
                            Global.player[i].unionMatchStats.fieldGoalAttempts = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isFieldGoals = br.ReadBoolean();
                        Global.player[i].unionMatchStats.fieldGoals = 0;

                        if (Global.player[i].unionMatchStats.isFieldGoals)
                            Global.player[i].unionMatchStats.fieldGoals = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isFortyTwenties = br.ReadBoolean();
                        Global.player[i].unionMatchStats.fortyTwenties = 0;

                        if (Global.player[i].unionMatchStats.isFortyTwenties)
                            Global.player[i].unionMatchStats.fortyTwenties = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isHandlingErrors = br.ReadBoolean();
                        Global.player[i].unionMatchStats.handlingErrors = 0;

                        if (Global.player[i].unionMatchStats.isHandlingErrors)
                            Global.player[i].unionMatchStats.handlingErrors = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isHitups = br.ReadBoolean();
                        Global.player[i].unionMatchStats.hitups = 0;

                        if (Global.player[i].unionMatchStats.isHitups)
                            Global.player[i].unionMatchStats.hitups = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isInterceptedPasses = br.ReadBoolean();
                        Global.player[i].unionMatchStats.interceptedPasses = 0;

                        if (Global.player[i].unionMatchStats.isInterceptedPasses)
                            Global.player[i].unionMatchStats.interceptedPasses = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isInterceptions = br.ReadBoolean();
                        Global.player[i].unionMatchStats.interceptions = 0;

                        if (Global.player[i].unionMatchStats.isInterceptions)
                            Global.player[i].unionMatchStats.interceptions = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isKickMetresGained = br.ReadBoolean();
                        Global.player[i].unionMatchStats.kickMetresGained = 0;

                        if (Global.player[i].unionMatchStats.isKickMetresGained)
                            Global.player[i].unionMatchStats.kickMetresGained = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isKicksInPlay = br.ReadBoolean();
                        Global.player[i].unionMatchStats.kicksInPlay = 0;

                        if (Global.player[i].unionMatchStats.isKicksInPlay)
                            Global.player[i].unionMatchStats.kicksInPlay = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isKnockOns = br.ReadBoolean();
                        Global.player[i].unionMatchStats.knockOns = 0;

                        if (Global.player[i].unionMatchStats.isKnockOns)
                            Global.player[i].unionMatchStats.knockOns = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.islineBreakAssists = br.ReadBoolean();
                        Global.player[i].unionMatchStats.lineBreakAssists = 0;

                        if (Global.player[i].unionMatchStats.islineBreakAssists)
                            Global.player[i].unionMatchStats.lineBreakAssists = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isLineBreaks = br.ReadBoolean();
                        Global.player[i].unionMatchStats.lineBreaks = 0;

                        if (Global.player[i].unionMatchStats.isLineBreaks)
                            Global.player[i].unionMatchStats.lineBreaks = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isMetresRun = br.ReadBoolean();
                        Global.player[i].unionMatchStats.metresRun = 0;

                        if (Global.player[i].unionMatchStats.isMetresRun)
                            Global.player[i].unionMatchStats.metresRun = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isMinutesPlayed = br.ReadBoolean();
                        Global.player[i].unionMatchStats.minutesPlayed = 0;

                        if (Global.player[i].unionMatchStats.isMinutesPlayed)
                            Global.player[i].unionMatchStats.minutesPlayed = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isMissedTackles = br.ReadBoolean();
                        Global.player[i].unionMatchStats.missedTackles = 0;

                        if (Global.player[i].unionMatchStats.isMissedTackles)
                            Global.player[i].unionMatchStats.missedTackles = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isOffloads = br.ReadBoolean();
                        Global.player[i].unionMatchStats.offloads = 0;

                        if (Global.player[i].unionMatchStats.isOffloads)
                            Global.player[i].unionMatchStats.offloads = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isOneOnOneTackles = br.ReadBoolean();
                        Global.player[i].unionMatchStats.oneOnOneTackles = 0;

                        if (Global.player[i].unionMatchStats.isOneOnOneTackles)
                            Global.player[i].unionMatchStats.oneOnOneTackles = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isPasses = br.ReadBoolean();
                        Global.player[i].unionMatchStats.passes = 0;

                        if (Global.player[i].unionMatchStats.isPasses)
                            Global.player[i].unionMatchStats.passes = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isPenaltiesConceded = br.ReadBoolean();
                        Global.player[i].unionMatchStats.penaltiesConceded = 0;

                        if (Global.player[i].unionMatchStats.isPenaltiesConceded)
                            Global.player[i].unionMatchStats.penaltiesConceded = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isPenaltyGoals = br.ReadBoolean();
                        Global.player[i].unionMatchStats.penaltyGoals = 0;

                        if (Global.player[i].unionMatchStats.isPenaltyGoals)
                            Global.player[i].unionMatchStats.penaltyGoals = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isPenaltyGoalAttempts = br.ReadBoolean();
                        Global.player[i].unionMatchStats.penaltyGoalAttempts = 0;

                        if (Global.player[i].unionMatchStats.isPenaltyGoalAttempts)
                            Global.player[i].unionMatchStats.penaltyGoalAttempts = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isRuns = br.ReadBoolean();
                        Global.player[i].unionMatchStats.runs = 0;

                        if (Global.player[i].unionMatchStats.isRuns)
                            Global.player[i].unionMatchStats.runs = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isTackleBreaks = br.ReadBoolean();
                        Global.player[i].unionMatchStats.tackleBreaks = 0;

                        if (Global.player[i].unionMatchStats.isTackleBreaks)
                            Global.player[i].unionMatchStats.tackleBreaks = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isTackles = br.ReadBoolean();

                        if (Global.player[i].unionMatchStats.isTackles)
                            Global.player[i].unionMatchStats.tackles = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isTries = br.ReadBoolean();
                        Global.player[i].unionMatchStats.tries = 0;

                        if (Global.player[i].unionMatchStats.isTries)
                            Global.player[i].unionMatchStats.tries = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isTryAssists = br.ReadBoolean();
                        Global.player[i].unionMatchStats.tryAssists = 0;

                        if (Global.player[i].unionMatchStats.isTryAssists)
                            Global.player[i].unionMatchStats.tryAssists = br.ReadInt32(Endian.Little);

                        Global.player[i].unionMatchStats.isBonusTries = br.ReadBoolean();
                        Global.player[i].unionMatchStats.bonusTries = 0;

                        if (Global.player[i].unionMatchStats.isBonusTries)
                            Global.player[i].unionMatchStats.bonusTries = br.ReadInt32(Endian.Little);
                    }

                    // NinesMatch Stats
                    Global.player[i].ninesMatchStats.isStatisticsStats = br.ReadBoolean();

                    if (Global.player[i].ninesMatchStats.isStatisticsStats)
                    {
                        Global.player[i].ninesMatchStats.isMatchesPlayed = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.matchesPlayed = 0;

                        if (Global.player[i].ninesMatchStats.isMatchesPlayed)
                            Global.player[i].ninesMatchStats.matchesPlayed = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isMatchesWon = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.matchesWon = 0;

                        if (Global.player[i].ninesMatchStats.isMatchesWon)
                            Global.player[i].ninesMatchStats.matchesWon = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isMatchesDrawn = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.matchesDrawn = 0;

                        if (Global.player[i].ninesMatchStats.isMatchesDrawn)
                            Global.player[i].ninesMatchStats.matchesDrawn = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isBallStrips = br.ReadBoolean();

                        if (Global.player[i].ninesMatchStats.isBallStrips)
                            Global.player[i].ninesMatchStats.ballStrips = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isConversions = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.conversions = 0;

                        if (Global.player[i].ninesMatchStats.isConversions)
                            Global.player[i].ninesMatchStats.conversions = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isConversionAttempts = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.conversionAttempts = 0;

                        if (Global.player[i].ninesMatchStats.isConversionAttempts)
                            Global.player[i].ninesMatchStats.conversionAttempts = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isFends = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.fends = 0;

                        if (Global.player[i].ninesMatchStats.isFends)
                            Global.player[i].ninesMatchStats.fends = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isFieldGoalAttempts = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.fieldGoalAttempts = 0;

                        if (Global.player[i].ninesMatchStats.isFieldGoalAttempts)
                            Global.player[i].ninesMatchStats.fieldGoalAttempts = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isFieldGoals = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.fieldGoals = 0;

                        if (Global.player[i].ninesMatchStats.isFieldGoals)
                            Global.player[i].ninesMatchStats.fieldGoals = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isFortyTwenties = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.fortyTwenties = 0;

                        if (Global.player[i].ninesMatchStats.isFortyTwenties)
                            Global.player[i].ninesMatchStats.fortyTwenties = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isHandlingErrors = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.handlingErrors = 0;

                        if (Global.player[i].ninesMatchStats.isHandlingErrors)
                            Global.player[i].ninesMatchStats.handlingErrors = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isHitups = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.hitups = 0;

                        if (Global.player[i].ninesMatchStats.isHitups)
                            Global.player[i].ninesMatchStats.hitups = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isInterceptedPasses = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.interceptedPasses = 0;

                        if (Global.player[i].ninesMatchStats.isInterceptedPasses)
                            Global.player[i].ninesMatchStats.interceptedPasses = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isInterceptions = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.interceptions = 0;

                        if (Global.player[i].ninesMatchStats.isInterceptions)
                            Global.player[i].ninesMatchStats.interceptions = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isKickMetresGained = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.kickMetresGained = 0;

                        if (Global.player[i].ninesMatchStats.isKickMetresGained)
                            Global.player[i].ninesMatchStats.kickMetresGained = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isKicksInPlay = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.kicksInPlay = 0;

                        if (Global.player[i].ninesMatchStats.isKicksInPlay)
                            Global.player[i].ninesMatchStats.kicksInPlay = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isKnockOns = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.knockOns = 0;

                        if (Global.player[i].ninesMatchStats.isKnockOns)
                            Global.player[i].ninesMatchStats.knockOns = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.islineBreakAssists = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.lineBreakAssists = 0;

                        if (Global.player[i].ninesMatchStats.islineBreakAssists)
                            Global.player[i].ninesMatchStats.lineBreakAssists = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isLineBreaks = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.lineBreaks = 0;

                        if (Global.player[i].ninesMatchStats.isLineBreaks)
                            Global.player[i].ninesMatchStats.lineBreaks = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isMetresRun = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.metresRun = 0;

                        if (Global.player[i].ninesMatchStats.isMetresRun)
                            Global.player[i].ninesMatchStats.metresRun = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isMinutesPlayed = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.minutesPlayed = 0;

                        if (Global.player[i].ninesMatchStats.isMinutesPlayed)
                            Global.player[i].ninesMatchStats.minutesPlayed = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isMissedTackles = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.missedTackles = 0;

                        if (Global.player[i].ninesMatchStats.isMissedTackles)
                            Global.player[i].ninesMatchStats.missedTackles = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isOffloads = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.offloads = 0;

                        if (Global.player[i].ninesMatchStats.isOffloads)
                            Global.player[i].ninesMatchStats.offloads = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isOneOnOneTackles = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.oneOnOneTackles = 0;

                        if (Global.player[i].ninesMatchStats.isOneOnOneTackles)
                            Global.player[i].ninesMatchStats.oneOnOneTackles = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isPasses = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.passes = 0;

                        if (Global.player[i].ninesMatchStats.isPasses)
                            Global.player[i].ninesMatchStats.passes = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isPenaltiesConceded = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.penaltiesConceded = 0;

                        if (Global.player[i].ninesMatchStats.isPenaltiesConceded)
                            Global.player[i].ninesMatchStats.penaltiesConceded = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isPenaltyGoals = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.penaltyGoals = 0;

                        if (Global.player[i].ninesMatchStats.isPenaltyGoals)
                            Global.player[i].ninesMatchStats.penaltyGoals = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isPenaltyGoalAttempts = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.penaltyGoalAttempts = 0;

                        if (Global.player[i].ninesMatchStats.isPenaltyGoalAttempts)
                            Global.player[i].ninesMatchStats.penaltyGoalAttempts = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isRuns = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.runs = 0;

                        if (Global.player[i].ninesMatchStats.isRuns)
                            Global.player[i].ninesMatchStats.runs = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isTackleBreaks = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.tackleBreaks = 0;

                        if (Global.player[i].ninesMatchStats.isTackleBreaks)
                            Global.player[i].ninesMatchStats.tackleBreaks = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isTackles = br.ReadBoolean();

                        if (Global.player[i].ninesMatchStats.isTackles)
                            Global.player[i].ninesMatchStats.tackles = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isTries = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.tries = 0;

                        if (Global.player[i].ninesMatchStats.isTries)
                            Global.player[i].ninesMatchStats.tries = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isTryAssists = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.tryAssists = 0;

                        if (Global.player[i].ninesMatchStats.isTryAssists)
                            Global.player[i].ninesMatchStats.tryAssists = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesMatchStats.isBonusTries = br.ReadBoolean();
                        Global.player[i].ninesMatchStats.bonusTries = 0;

                        if (Global.player[i].ninesMatchStats.isBonusTries)
                            Global.player[i].ninesMatchStats.bonusTries = br.ReadInt32(Endian.Little);
                    }

                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["Gender"] = Imagelist[Global.player[i].gender];
                    dt.Rows[dt.Rows.Count - 1]["Player Index"] = i;
                    dt.Rows[dt.Rows.Count - 1]["Player ID"] = Global.player[i].id;
                    dt.Rows[dt.Rows.Count - 1]["First Name"] = Global.player[i].firstName;
                    dt.Rows[dt.Rows.Count - 1]["Last Name"] = Global.player[i].lastName;
                }

                Players_dataGridView.DataSource = dt;
                Players_dataGridView.Columns[0].Width = 70;
                Players_dataGridView.Columns[1].Width = 95;
                Players_dataGridView.Columns[2].Width = 95;
                Players_dataGridView.Columns[3].Width = 155;
                Players_dataGridView.Columns[4].Width = 155;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (br != null)
                    br.Close();
            }
        }
    }
}
