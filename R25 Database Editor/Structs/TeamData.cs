namespace R25_Database_Editor
{
    /// <summary>
    /// Team Data Struct.
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
    /// [Wouldubeinta]	   02/11/2025	Created
    /// </history>
    public class TeamData
    {
        public struct Team
        {
            public int identifier;
            public bool teamEnabled;
            public bool isId;
            public int id;
            public bool isLicensed;
            public bool licensed;
            public bool isFullName;
            public byte fullNameSize;
            public string fullName;
            public bool isShortName;
            public byte shortNameSize;
            public string shortName;
            public bool isNickname;
            public byte nicknameSize;
            public string nickname;
            public bool isHudName;
            public byte hudNameSize;
            public string hudName;
            public bool isShirtName;
            public byte shirtNameSize;
            public string shirtName;
            public bool isGender;
            public int gender;
            public bool islogo;
            public byte logoSize;
            public string logo;
            public bool isWcLogo;
            public byte wcLogoSize;
            public string wcLogo;
            public bool isSupporters;
            public int supporters;
            public bool isCommentaryTeamHash;
            public uint commentaryTeamHash;
            public RGB primaryColour;
            public RGB secondaryColour;
            public RGB hudTextColour;
            public bool isClubType;
            public int clubType;
            public bool isAffiliations;
            public int affiliations;
            public bool isWorldCupTeam;
            public bool WorldCupTeam;
            public bool isStadiumAmount;
            public int stadiumAmount;
            public Stadium[] stadium;
            public Stadium finalStadium;
            public byte feederClubsAmount;
            public FeederClubs[] feederClubs;
            public byte fedFromClubsAmount;
            public FedFromClubs[] fedFromClubs;
            public bool isAlternateNumbering;
            public bool alternateNumbering;
            public bool isPlayerRoster;
            public byte playerAmount;
            public TeamPlayers[] players;
            public bool isLeagueMatch;
            public LeagueRoles[] leagueRoles;
            public LeagueLineups[] leagueLineups;
            public bool isUnionMatch;
            public UnionRoles[] unionRoles;
            public UnionLineups[] unionLineups;
            public bool isNinesMatch;
            public NineRoles[] nineRoles;
            public NineLineups[] nineLineups;
            public int dataSize;
            public byte[] data;
            public short jerseyAmount;
            public Jerseys[] jerseys;
            public byte[] padding2;
        }

        public struct RGB
        {
            public bool isRgb;
            public byte r;
            public byte g;
            public byte b;
        }

        public struct Stadium
        {
            public bool isId;
            public int id;
            public bool isWantCustomName;
            public bool wantCustomName;
            public bool isCustomName;
            public byte customNameSize;
            public string customName;
            public bool isStadiumIsOnDisk;
            public bool StadiumIsOnDisk;
        }

        public struct FeederClubs
        {
            public bool isFeederClubs;
            public int feederClubsId;
        }

        public struct FedFromClubs
        {
            public bool isFedFromClubs;
            public int fedFromClubsId;
        }

        public struct TeamPlayers
        {
            public bool isPlayerId;
            public int playerId;
        }

        public struct LeagueRoles
        {
            public bool isLeagueRoleId;
            public int leagueRoleId;
        }

        public struct LeagueLineups
        {
            public bool isLeagueLineupId;
            public int leagueLineupId;
        }

        public struct UnionRoles
        {
            public bool isUnionRoleId;
            public int unionRoleId;
        }

        public struct UnionLineups
        {
            public bool isUnionLineupId;
            public int unionLineupId;
        }

        public struct NineRoles
        {
            public bool isNinesRoleId;
            public int nineRoleId;
        }

        public struct NineLineups
        {
            public bool isNineLineupId;
            public int nineLineupId;
        }

        public struct Jerseys
        {
            public string name;
            public RGB primaryKeylineColour;
            public RGB secondaryKeylineColour;
            public RGB numberColour;
            public short licensedTopId;
            public short licensedShortsId;
            public short licensedSocksId;
            public byte primaryKeylineWeight;
            public byte secondaryKeylineWeight;
            public byte numberFont;
            public bool showingLeadingZero;
            public bool showNumber;
            public byte[] padding1;
            public byte padding2;
            public byte[] padding3;
            public byte[] padding4;
            public byte[] padding5;
            public byte[] padding6;
            public byte[] padding7;
            public byte[] padding8;
            public byte[] padding9;
            public byte[] padding10;
            public byte[] padding11;
            public byte[] padding12;
            public byte[] padding13;
            public byte[] padding14;
            public byte[] padding15;
            public byte[] padding16;
            public byte[] padding17;
            public byte[] padding18;
            public byte[] padding19;
        }
    }
}
