using PackageIO;

namespace R25_Database_Editor
{
    /// <summary>
    /// Write Database Class.
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
    internal class WriteDatabase
    {
        public static void WriteTeamData(string file)
        {
            Writer? bw = null;

            try
            {
                bw = new Writer(file, FileMode.Create, Endian.Little);

                bw.Write(Global.TeamHeader, Endian.Little);
                bw.WriteInt32(Global.team_amount, Endian.Little);

                for (int i = 0; i < Global.team_amount; i++)
                {
                    bw.WriteInt32(Global.team[i].identifier, Endian.Little);

                    bw.WriteBool(Global.team[i].teamEnabled); // ?

                    // Team ID
                    bw.WriteBool(Global.team[i].isId);
                    bw.WriteInt32(Global.team[i].id, Endian.Little);

                    // Team Licensed
                    bw.WriteBool(Global.team[i].isLicensed);
                    bw.WriteBool(Global.team[i].licensed);

                    // FullName
                    bw.WriteBool(Global.team[i].isFullName);
                    bw.WriteUInt8(Global.team[i].fullNameSize);
                    bw.WriteString(Global.team[i].fullName, Global.team[i].fullNameSize, Endian.Little);

                    // ShortName
                    bw.WriteBool(Global.team[i].isShortName);
                    bw.WriteUInt8(Global.team[i].shortNameSize);
                    bw.WriteString(Global.team[i].shortName, Global.team[i].shortNameSize, Endian.Little);

                    // Nickname
                    bw.WriteBool(Global.team[i].isNickname);
                    bw.WriteUInt8(Global.team[i].nicknameSize);
                    bw.WriteString(Global.team[i].nickname, Global.team[i].nicknameSize);

                    // HudName
                    bw.WriteBool(Global.team[i].isHudName);
                    bw.WriteUInt8(Global.team[i].hudNameSize);
                    bw.WriteString(Global.team[i].hudName, Global.team[i].hudNameSize, Endian.Little);

                    bw.WriteBool(Global.team[i].isShirtName);

                    if (Global.team[i].isShirtName)
                    {
                        bw.WriteUInt8(Global.team[i].shirtNameSize);
                        bw.WriteString(Global.team[i].shirtName, Global.team[i].shirtNameSize, Endian.Little);
                    }

                    // Gender
                    bw.WriteBool(Global.team[i].isGender);
                    bw.WriteInt32(Global.team[i].gender, Endian.Little);

                    // Logo
                    bw.WriteBool(Global.team[i].islogo);
                    bw.WriteUInt8(Global.team[i].logoSize);
                    bw.WriteString(Global.team[i].logo, Global.team[i].logoSize, Endian.Little);

                    // WC Logo
                    bw.WriteBool(Global.team[i].isWcLogo);

                    if (Global.team[i].isWcLogo)
                    {
                        bw.WriteUInt8(Global.team[i].wcLogoSize);
                        bw.WriteString(Global.team[i].wcLogo, Global.team[i].wcLogoSize, Endian.Little);
                    }

                    // Supporters
                    bw.WriteBool(Global.team[i].isSupporters);
                    bw.WriteInt32(Global.team[i].supporters, Endian.Little);

                    // Commentary
                    bw.WriteBool(Global.team[i].isCommentaryTeamHash);
                    bw.WriteUInt32(Global.team[i].commentaryTeamHash, Endian.Little);

                    // PrimaryColour
                    bw.WriteBool(Global.team[i].primaryColour.isRgb);
                    bw.WriteUInt8(Global.team[i].primaryColour.r);
                    bw.WriteUInt8(Global.team[i].primaryColour.g);
                    bw.WriteUInt8(Global.team[i].primaryColour.b);

                    // SecondaryColour
                    bw.WriteBool(Global.team[i].secondaryColour.isRgb);
                    bw.WriteUInt8(Global.team[i].secondaryColour.r);
                    bw.WriteUInt8(Global.team[i].secondaryColour.g);
                    bw.WriteUInt8(Global.team[i].secondaryColour.b);

                    // HudTextColour
                    bw.WriteBool(Global.team[i].hudTextColour.isRgb);
                    bw.WriteUInt8(Global.team[i].hudTextColour.r);
                    bw.WriteUInt8(Global.team[i].hudTextColour.g);
                    bw.WriteUInt8(Global.team[i].hudTextColour.b);

                    bw.WriteBool(Global.team[i].isClubType);

                    if (Global.team[i].isClubType)
                        bw.WriteInt32(Global.team[i].clubType, Endian.Little);

                    bw.WriteBool(Global.team[i].isAffiliations);

                    if (Global.team[i].isAffiliations)
                        bw.WriteInt32(Global.team[i].affiliations, Endian.Little);

                    bw.WriteBool(Global.team[i].isWorldCupTeam);

                    if (Global.team[i].isWorldCupTeam)
                        bw.WriteBool(Global.team[i].WorldCupTeam);

                    // Stadium Data
                    bw.WriteBool(Global.team[i].isStadiumAmount);
                    bw.WriteInt32(Global.team[i].stadiumAmount, Endian.Little);

                    for (int j = 0; j < 3; j++)
                    {
                        bw.WriteBool(Global.team[i].stadium[j].isId);

                        if (Global.team[i].stadium[j].isId)
                            bw.WriteInt32(Global.team[i].stadium[j].id, Endian.Little);

                        bw.WriteBool(Global.team[i].stadium[j].isWantCustomName);

                        if (Global.team[i].stadium[j].isWantCustomName)
                            bw.WriteBool(Global.team[i].stadium[j].wantCustomName);

                        bw.WriteBool(Global.team[i].stadium[j].isCustomName);

                        if (Global.team[i].stadium[j].isCustomName)
                        {
                            bw.WriteUInt8(Global.team[i].stadium[j].customNameSize);
                            bw.WriteString(Global.team[i].stadium[j].customName, Global.team[i].stadium[j].customNameSize, Endian.Little);
                        }

                        bw.WriteBool(Global.team[i].stadium[j].isStadiumIsOnDisk);

                        if (Global.team[i].stadium[j].isStadiumIsOnDisk)
                            bw.WriteBool(Global.team[i].stadium[j].StadiumIsOnDisk);
                    }

                    bw.WriteBool(Global.team[i].finalStadium.isId);

                    if (Global.team[i].finalStadium.isId)
                        bw.WriteInt32(Global.team[i].finalStadium.id, Endian.Little);

                    bw.WriteBool(Global.team[i].finalStadium.isWantCustomName);

                    if (Global.team[i].finalStadium.isWantCustomName)
                        bw.WriteBool(Global.team[i].finalStadium.wantCustomName);

                    bw.WriteBool(Global.team[i].finalStadium.isCustomName);

                    if (Global.team[i].finalStadium.isCustomName)
                    {
                        bw.WriteUInt8(Global.team[i].finalStadium.customNameSize);
                        bw.WriteString(Global.team[i].finalStadium.customName, Global.team[i].finalStadium.customNameSize, Endian.Little);
                    }

                    // FeederClub Data
                    for (int j = 0; j < 7; j++)
                    {
                        bw.WriteBool(Global.team[i].feederClubs[j].isFeederClubs);

                        if (Global.team[i].feederClubs[j].isFeederClubs)
                            bw.WriteInt32(Global.team[i].feederClubs[j].feederClubsId, Endian.Little);
                    }

                    // FedFromClubs Data
                    for (int j = 0; j < 7; j++)
                    {
                        bw.WriteBool(Global.team[i].fedFromClubs[j].isFedFromClubs);

                        if (Global.team[i].fedFromClubs[j].isFedFromClubs)
                            bw.WriteInt32(Global.team[i].fedFromClubs[j].fedFromClubsId, Endian.Little);
                    }

                    bw.WriteBool(Global.team[i].isAlternateNumbering);

                    if (Global.team[i].isAlternateNumbering)
                        bw.WriteBool(Global.team[i].alternateNumbering);

                    // Player Roster Data
                    bw.WriteBool(Global.team[i].isPlayerRoster);

                    if (Global.team[i].isPlayerRoster) 
                    {
                        for (int j = 0; j < Global.MAX_PLAYERS_PER_TEAM; j++)
                        {
                            bw.WriteBool(Global.team[i].players[j].isPlayerId);

                            if (Global.team[i].players[j].isPlayerId)
                                bw.WriteInt32(Global.team[i].players[j].playerId, Endian.Little);
                        }
                    }

                    // LeagueMatch Data
                    bw.WriteBool(Global.team[i].isLeagueMatch);

                    if (Global.team[i].isLeagueMatch) 
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            bw.WriteBool(Global.team[i].leagueRoles[j].isLeagueRoleId);

                            if (Global.team[i].leagueRoles[j].isLeagueRoleId)
                                bw.WriteInt32(Global.team[i].leagueRoles[j].leagueRoleId, Endian.Little);
                        }

                        for (int j = 0; j < 17; j++)
                        {
                            bw.WriteBool(Global.team[i].leagueLineups[j].isLeagueLineupId);

                            if (Global.team[i].leagueLineups[j].isLeagueLineupId)
                                bw.WriteInt32(Global.team[i].leagueLineups[j].leagueLineupId, Endian.Little);
                        }
                    }

                    // UnionMatch Data
                    bw.WriteBool(Global.team[i].isUnionMatch);

                    if (Global.team[i].isUnionMatch) 
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            bw.WriteBool(Global.team[i].unionRoles[j].isUnionRoleId);

                            if (Global.team[i].unionRoles[j].isUnionRoleId)
                                bw.WriteInt32(Global.team[i].unionRoles[j].unionRoleId, Endian.Little);
                        }

                        for (int j = 0; j < Global.MIN_PLAYERS_PER_TEAM; j++)
                        {
                            bw.WriteBool(Global.team[i].unionLineups[j].isUnionLineupId);

                            if (Global.team[i].unionLineups[j].isUnionLineupId)
                                bw.WriteInt32(Global.team[i].unionLineups[j].unionLineupId, Endian.Little);
                        }
                    }

                    // NinesMatch Data
                    bw.WriteBool(Global.team[i].isNinesMatch);

                    if (Global.team[i].isNinesMatch) 
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            bw.WriteBool(Global.team[i].nineRoles[j].isNinesRoleId);

                            if (Global.team[i].nineRoles[j].isNinesRoleId)
                                bw.WriteInt32(Global.team[i].nineRoles[j].nineRoleId, Endian.Little);
                        }

                        for (int j = 0; j < 14; j++)
                        {
                            bw.WriteBool(Global.team[i].nineLineups[j].isNineLineupId);

                            if (Global.team[i].nineLineups[j].isNineLineupId)
                                bw.WriteInt32(Global.team[i].nineLineups[j].nineLineupId, Endian.Little);
                        }
                    }

                    // Shirt Data
                    bw.WriteInt32(Global.team[i].dataSize, Endian.Little);
                    bw.Write(Global.team[i].data, Endian.Little);

                    /*
                    bw.WriteInt16(Global.team[i].jerseyAmount);

                    for (int j = 0; j < 8; j++)
                    {
                        bw.Write((Global.team[i].jerseys[j].name + new string(default(char), 24)).Take(24).Select(ch => (byte)ch).ToArray(), Endian.Little);
                        bw.WriteUInt8(0);

                        bw.WriteUInt16(Global.team[i].jerseys[j].padding1, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].nameColour.g);
                        bw.Write(Global.team[i].jerseys[j].padding2, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].nameColour.r);
                        bw.Write(Global.team[i].jerseys[j].padding3, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].nameColour.b);
                        bw.Write(Global.team[i].jerseys[j].padding4, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].keylineColour.b);
                        bw.Write(Global.team[i].jerseys[j].padding5, Endian.Little);
                        bw.WriteBool(Global.team[i].jerseys[j].showNumber);
                        bw.WriteUInt16(Global.team[i].jerseys[j].padding6, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].keylineColour.g);
                        bw.Write(Global.team[i].jerseys[j].padding7, Endian.Little);
                        bw.WriteBool(Global.team[i].jerseys[j].showInternalKeyline);
                        bw.Write(Global.team[i].jerseys[j].padding8, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].numberColour.g);
                        bw.Write(Global.team[i].jerseys[j].padding9, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].numberColour.b);
                        bw.Write(Global.team[i].jerseys[j].padding10, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].manufactureId);
                        bw.Write(Global.team[i].jerseys[j].padding11, Endian.Little);
                        bw.WriteInt16(Global.team[i].jerseys[j].licensedId, Endian.Little);
                        bw.Write(Global.team[i].jerseys[j].padding12, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].keylineSize);
                        bw.Write(Global.team[i].jerseys[j].padding13, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].numberFont);
                        bw.Write(Global.team[i].jerseys[j].padding14, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].nameFont);
                        bw.Write(Global.team[i].jerseys[j].padding15, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].keylineOffset);
                        bw.WriteBool(Global.team[i].jerseys[j].showingLeadingZero);
                        bw.Write(Global.team[i].jerseys[j].padding16, Endian.Little);
                        bw.WriteBool(Global.team[i].jerseys[j].showName);
                        bw.Write(Global.team[i].jerseys[j].padding17, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].keylineColour.r);
                        bw.Write(Global.team[i].jerseys[j].padding18, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].numberColour.r);
                        bw.Write(Global.team[i].jerseys[j].padding19, Endian.Little);
                    }

                    bw.Write(Global.team[i].padding2, Endian.Little);
                    */
                }
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

        public static void WritePlayerData(string file)
        {
            Writer? bw = null;

            try
            {
                bw = new Writer(file, FileMode.Create, Endian.Little);

                bw.Write(Global.PlayerHeader, Endian.Little);
                bw.WriteInt32(Global.player_amount); // Player Amount

                for (int i = 0; i < Global.player_amount; i++)
                {
                    bw.WriteInt32(Global.player[i].identifier, Endian.Little);

                    bw.WriteInt32(Global.player[i].dataSize, Endian.Little);
                    bw.Write(Global.player[i].data, Endian.Little); // Player Appearance Data ?

                    bw.WriteBool(Global.player[i].playerEnabled); // ?

                    // Player ID
                    bw.WriteBool(Global.player[i].isId);
                    bw.WriteInt32(Global.player[i].id, Endian.Little);

                    // First Name
                    bw.WriteBool(Global.player[i].isFirstName);

                    if (Global.player[i].isFirstName) 
                    {
                        bw.WriteUInt8(Global.player[i].firstNameSize);
                        bw.WriteString(Global.player[i].firstName, Global.player[i].firstNameSize, Endian.Little);
                    }

                    // Last Name
                    bw.WriteBool(Global.player[i].isLastName);

                    if (Global.player[i].isLastName) 
                    {
                        bw.WriteUInt8(Global.player[i].lastNameSize);
                        bw.WriteString(Global.player[i].lastName, Global.player[i].lastNameSize, Endian.Little);
                    }

                    // Player Licensed
                    bw.WriteBool(Global.player[i].isLicensed);

                    if (Global.player[i].isLicensed)
                        bw.WriteBool(Global.player[i].licensed);

                    // Player Sex
                    bw.WriteBool(Global.player[i].isGender);

                    if (Global.player[i].isGender)
                        bw.WriteInt32(Global.player[i].gender, Endian.Little);

                    bw.WriteBool(Global.player[i].isJerseyName);

                    if (Global.player[i].isJerseyName) 
                    {
                        bw.WriteUInt8(Global.player[i].jerseyNameSize);
                        bw.WriteString(Global.player[i].jerseyName, Global.player[i].jerseyNameSize, Endian.Little);
                    }

                    bw.WriteBool(Global.player[i].isJerseyNumber);

                    if (Global.player[i].isJerseyNumber)
                        bw.WriteInt32(Global.player[i].jerseyNumber, Endian.Little);

                    bw.WriteBool(Global.player[i].dob.isDay);
                    bw.WriteInt32(Global.player[i].dob.day, Endian.Little);
                    bw.WriteBool(Global.player[i].dob.isMonth);
                    bw.WriteInt32(Global.player[i].dob.month, Endian.Little);
                    bw.WriteBool(Global.player[i].dob.isYear);
                    bw.WriteInt32(Global.player[i].dob.year, Endian.Little);

                    bw.WriteBool(Global.player[i].isAge);

                    if (Global.player[i].isAge)
                        bw.WriteInt32(Global.player[i].age, Endian.Little);

                    bw.WriteBool(Global.player[i].isCountryOfBirth);

                    if (Global.player[i].isCountryOfBirth)
                        bw.WriteInt32(Global.player[i].countryOfBirth, Endian.Little);

                    bw.WriteBool(Global.player[i].isRepCountry);

                    if (Global.player[i].isRepCountry)
                        bw.WriteInt32(Global.player[i].repCountry, Endian.Little);

                    bw.WriteBool(Global.player[i].isStateOfOrigin);

                    if (Global.player[i].isStateOfOrigin)
                        bw.WriteInt32(Global.player[i].stateOfOrigin, Endian.Little);

                    bw.WriteBool(Global.player[i].isCityVsCountry);

                    if (Global.player[i].isCityVsCountry)
                        bw.WriteInt32(Global.player[i].cityVsCountry, Endian.Little);

                    bw.WriteBool(Global.player[i].isAllStars);

                    if (Global.player[i].isAllStars)
                        bw.WriteInt32(Global.player[i].allStars, Endian.Little);

                    bw.WriteBool(Global.player[i].isWorldCup);

                    if (Global.player[i].isWorldCup)
                        bw.WriteBool(Global.player[i].WorldCup);

                    bw.WriteBool(Global.player[i].isContractExpiry);

                    if (Global.player[i].isContractExpiry)
                        bw.WriteInt32(Global.player[i].contractExpiry, Endian.Little);

                    bw.WriteBool(Global.player[i].isPrimaryRole);

                    if (Global.player[i].isPrimaryRole)
                        bw.WriteInt32(Global.player[i].primaryRole, Endian.Little);

                    bw.WriteBool(Global.player[i].isSecondaryRole);

                    if (Global.player[i].isSecondaryRole)
                        bw.WriteInt32(Global.player[i].secondaryRole, Endian.Little);

                    bw.WriteBool(Global.player[i].isTertiaryRole);

                    if (Global.player[i].isTertiaryRole)
                        bw.WriteInt32(Global.player[i].tertiaryRole, Endian.Little);

                    bw.WriteBool(Global.player[i].isCommentaryNameHash);

                    if (Global.player[i].isCommentaryNameHash)
                        bw.WriteUInt32(Global.player[i].commentaryNameHash, Endian.Little);

                    bw.WriteBool(Global.player[i].isPreferredHand);

                    if (Global.player[i].isPreferredHand)
                        bw.WriteUInt8(Global.player[i].preferredHand);

                    bw.WriteBool(Global.player[i].isPreferredFoot);

                    if (Global.player[i].isPreferredFoot)
                        bw.WriteUInt8(Global.player[i].preferredFoot);

                    bw.WriteBool(Global.player[i].appearance.isHeight);
                    bw.WriteInt32(Global.player[i].appearance.height, Endian.Little);
                    bw.WriteBool(Global.player[i].appearance.isWeight);
                    bw.WriteInt32(Global.player[i].appearance.weight, Endian.Little);

                    // Player Attributes
                    bw.WriteBool(Global.player[i].attributes.isMovementProfile);

                    if (Global.player[i].attributes.isMovementProfile)
                        bw.WriteInt32(Global.player[i].attributes.movementProfile, Endian.Little);

                    bw.WriteBool(Global.player[i].attributes.isTemperament);

                    if (Global.player[i].attributes.isTemperament)
                        bw.WriteInt32(Global.player[i].attributes.temperament, Endian.Little);

                    bw.WriteBool(Global.player[i].attributes.isFitness);

                    if (Global.player[i].attributes.isFitness)
                        bw.WriteInt32(Global.player[i].attributes.fitness, Endian.Little);

                    // Strength Skills
                    bw.WriteBool(Global.player[i].skills.strengthSkills.isStrength);
                    bw.WriteInt32(Global.player[i].skills.strengthSkills.strength, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.strengthSkills.isRucking);
                    bw.WriteInt32(Global.player[i].skills.strengthSkills.rucking, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.strengthSkills.isScrummaging);
                    bw.WriteInt32(Global.player[i].skills.strengthSkills.scrummaging, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.strengthSkills.isTackling);
                    bw.WriteInt32(Global.player[i].skills.strengthSkills.tackling, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.strengthSkills.isBreakTackle);
                    bw.WriteInt32(Global.player[i].skills.strengthSkills.breakTackling, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.strengthSkills.isFending);
                    bw.WriteInt32(Global.player[i].skills.strengthSkills.fending, Endian.Little);

                    // Speed Skills
                    bw.WriteBool(Global.player[i].skills.speedSkills.isAgility);
                    bw.WriteInt32(Global.player[i].skills.speedSkills.agility, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.speedSkills.isAcceleration);
                    bw.WriteInt32(Global.player[i].skills.speedSkills.acceleration, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.speedSkills.isSprintSpeed);
                    bw.WriteInt32(Global.player[i].skills.speedSkills.sprintSpeed, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.speedSkills.isBalance);
                    bw.WriteInt32(Global.player[i].skills.speedSkills.balance, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.speedSkills.isStamina);
                    bw.WriteInt32(Global.player[i].skills.speedSkills.stamina, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.speedSkills.isEvasion);
                    bw.WriteInt32(Global.player[i].skills.speedSkills.evasion, Endian.Little);

                    // Kicking Skills
                    bw.WriteBool(Global.player[i].skills.kickingSkills.isKickingAccuracy);
                    bw.WriteInt32(Global.player[i].skills.kickingSkills.kickingAccuracy, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.kickingSkills.isKickingPower);
                    bw.WriteInt32(Global.player[i].skills.kickingSkills.kickingPower, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.kickingSkills.isGoalKicking);
                    bw.WriteInt32(Global.player[i].skills.kickingSkills.goalKicking, Endian.Little);

                    // Hands Skills
                    bw.WriteBool(Global.player[i].skills.handsSkills.isPassing);
                    bw.WriteInt32(Global.player[i].skills.handsSkills.passing, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.handsSkills.isAerialSkills);
                    bw.WriteInt32(Global.player[i].skills.handsSkills.aerialSkills, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.handsSkills.isOffload);
                    bw.WriteInt32(Global.player[i].skills.handsSkills.offload, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.handsSkills.isJackal);
                    bw.WriteInt32(Global.player[i].skills.handsSkills.jackal, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.handsSkills.isIntercepting);
                    bw.WriteInt32(Global.player[i].skills.handsSkills.intercepting, Endian.Little);

                    // Mentality Skills
                    bw.WriteBool(Global.player[i].skills.mentalitySkills.isFocus);
                    bw.WriteInt32(Global.player[i].skills.mentalitySkills.focus, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.mentalitySkills.isLeadership);
                    bw.WriteInt32(Global.player[i].skills.mentalitySkills.leadership, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.mentalitySkills.isDetermination);
                    bw.WriteInt32(Global.player[i].skills.mentalitySkills.determination, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.mentalitySkills.isDiscipline);
                    bw.WriteInt32(Global.player[i].skills.mentalitySkills.discipline, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.kickingSkills.isToePoke);

                    if (Global.player[i].skills.kickingSkills.isToePoke)
                        bw.WriteInt32(Global.player[i].skills.kickingSkills.toePoke, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.kickingSkills.isConversionStyle);

                    if (Global.player[i].skills.kickingSkills.isConversionStyle)
                        bw.WriteInt32(Global.player[i].skills.kickingSkills.conversionStyle, Endian.Little);

                    bw.WriteBool(Global.player[i].appearance.isPhotogrammetryStatus);

                    if (Global.player[i].appearance.isPhotogrammetryStatus)
                        bw.WriteInt32(Global.player[i].appearance.photogrammetryStatus, Endian.Little);

                    // LeagueMatch Stats
                    bw.WriteBool(Global.player[i].leagueMatchStats.isStatisticsStats);

                    if (Global.player[i].leagueMatchStats.isStatisticsStats)
                    {
                        bw.WriteBool(Global.player[i].leagueMatchStats.isMatchesPlayed);

                        if (Global.player[i].leagueMatchStats.isMatchesPlayed)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.matchesPlayed, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isMatchesWon);

                        if (Global.player[i].leagueMatchStats.isMatchesWon)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.matchesWon, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isMatchesDrawn);

                        if (Global.player[i].leagueMatchStats.isMatchesDrawn)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.matchesDrawn, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isBallStrips);

                        if (Global.player[i].leagueMatchStats.isBallStrips)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.ballStrips, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isConversions);

                        if (Global.player[i].leagueMatchStats.isConversions)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.conversions, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isConversionAttempts);

                        if (Global.player[i].leagueMatchStats.isConversionAttempts)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.conversionAttempts, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isFends);

                        if (Global.player[i].leagueMatchStats.isFends)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.fends, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isFieldGoalAttempts);

                        if (Global.player[i].leagueMatchStats.isFieldGoalAttempts)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.fieldGoalAttempts, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isFieldGoals);

                        if (Global.player[i].leagueMatchStats.isFieldGoals)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.fieldGoals, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isFortyTwenties);

                        if (Global.player[i].leagueMatchStats.isFortyTwenties)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.fortyTwenties, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isHandlingErrors);

                        if (Global.player[i].leagueMatchStats.isHandlingErrors)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.handlingErrors, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isHitups);

                        if (Global.player[i].leagueMatchStats.isHitups)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.hitups, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isInterceptedPasses);

                        if (Global.player[i].leagueMatchStats.isInterceptedPasses)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.interceptedPasses, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isInterceptions);

                        if (Global.player[i].leagueMatchStats.isInterceptions)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.interceptions, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isKickMetresGained);

                        if (Global.player[i].leagueMatchStats.isKickMetresGained)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.kickMetresGained, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isKicksInPlay);

                        if (Global.player[i].leagueMatchStats.isKicksInPlay)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.kicksInPlay, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isKnockOns);

                        if (Global.player[i].leagueMatchStats.isKnockOns)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.knockOns, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.islineBreakAssists);

                        if (Global.player[i].leagueMatchStats.islineBreakAssists)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.lineBreakAssists, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isLineBreaks);

                        if (Global.player[i].leagueMatchStats.isLineBreaks)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.lineBreaks, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isMetresRun);

                        if (Global.player[i].leagueMatchStats.isMetresRun)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.metresRun, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isMinutesPlayed);

                        if (Global.player[i].leagueMatchStats.isMinutesPlayed)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.minutesPlayed, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isMissedTackles);

                        if (Global.player[i].leagueMatchStats.isMissedTackles)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.missedTackles, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isOffloads);

                        if (Global.player[i].leagueMatchStats.isOffloads)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.offloads, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isOneOnOneTackles);

                        if (Global.player[i].leagueMatchStats.isOneOnOneTackles)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.oneOnOneTackles, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isPasses);

                        if (Global.player[i].leagueMatchStats.isPasses)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.passes, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isPenaltiesConceded);

                        if (Global.player[i].leagueMatchStats.isPenaltiesConceded)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.penaltiesConceded, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isPenaltyGoals);

                        if (Global.player[i].leagueMatchStats.isPenaltyGoals)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.penaltyGoals, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isPenaltyGoalAttempts);

                        if (Global.player[i].leagueMatchStats.isPenaltyGoalAttempts)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.penaltyGoalAttempts, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isRuns);

                        if (Global.player[i].leagueMatchStats.isRuns)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.runs, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isTackleBreaks);

                        if (Global.player[i].leagueMatchStats.isTackleBreaks)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.tackleBreaks, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isTackles);

                        if (Global.player[i].leagueMatchStats.isTackles)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.tackles, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isTries);

                        if (Global.player[i].leagueMatchStats.isTries)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.tries, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isTryAssists);

                        if (Global.player[i].leagueMatchStats.isTryAssists)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.tryAssists, Endian.Little);

                        bw.WriteBool(Global.player[i].leagueMatchStats.isBonusTries);

                        if (Global.player[i].leagueMatchStats.isBonusTries)
                            bw.WriteInt32(Global.player[i].leagueMatchStats.bonusTries, Endian.Little);
                    }

                    // UnionMatch Stats
                    bw.WriteBool(Global.player[i].unionMatchStats.isStatisticsStats);

                    if (Global.player[i].unionMatchStats.isStatisticsStats)
                    {
                        bw.WriteBool(Global.player[i].unionMatchStats.isMatchesPlayed);

                        if (Global.player[i].unionMatchStats.isMatchesPlayed)
                            bw.WriteInt32(Global.player[i].unionMatchStats.matchesPlayed, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isMatchesWon);

                        if (Global.player[i].unionMatchStats.isMatchesWon)
                            bw.WriteInt32(Global.player[i].unionMatchStats.matchesWon, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isMatchesDrawn);

                        if (Global.player[i].unionMatchStats.isMatchesDrawn)
                            bw.WriteInt32(Global.player[i].unionMatchStats.matchesDrawn, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isBallStrips);

                        if (Global.player[i].unionMatchStats.isBallStrips)
                            bw.WriteInt32(Global.player[i].unionMatchStats.ballStrips, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isConversions);

                        if (Global.player[i].unionMatchStats.isConversions)
                            bw.WriteInt32(Global.player[i].unionMatchStats.conversions, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isConversionAttempts);

                        if (Global.player[i].unionMatchStats.isConversionAttempts)
                            bw.WriteInt32(Global.player[i].unionMatchStats.conversionAttempts, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isFends);

                        if (Global.player[i].unionMatchStats.isFends)
                            bw.WriteInt32(Global.player[i].unionMatchStats.fends, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isFieldGoalAttempts);

                        if (Global.player[i].unionMatchStats.isFieldGoalAttempts)
                            bw.WriteInt32(Global.player[i].unionMatchStats.fieldGoalAttempts, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isFieldGoals);

                        if (Global.player[i].unionMatchStats.isFieldGoals)
                            bw.WriteInt32(Global.player[i].unionMatchStats.fieldGoals, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isFortyTwenties);

                        if (Global.player[i].unionMatchStats.isFortyTwenties)
                            bw.WriteInt32(Global.player[i].unionMatchStats.fortyTwenties, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isHandlingErrors);

                        if (Global.player[i].unionMatchStats.isHandlingErrors)
                            bw.WriteInt32(Global.player[i].unionMatchStats.handlingErrors, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isHitups);

                        if (Global.player[i].unionMatchStats.isHitups)
                            bw.WriteInt32(Global.player[i].unionMatchStats.hitups, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isInterceptedPasses);

                        if (Global.player[i].unionMatchStats.isInterceptedPasses)
                            bw.WriteInt32(Global.player[i].unionMatchStats.interceptedPasses, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isInterceptions);

                        if (Global.player[i].unionMatchStats.isInterceptions)
                            bw.WriteInt32(Global.player[i].unionMatchStats.interceptions, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isKickMetresGained);

                        if (Global.player[i].unionMatchStats.isKickMetresGained)
                            bw.WriteInt32(Global.player[i].unionMatchStats.kickMetresGained, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isKicksInPlay);

                        if (Global.player[i].unionMatchStats.isKicksInPlay)
                            bw.WriteInt32(Global.player[i].unionMatchStats.kicksInPlay, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isKnockOns);

                        if (Global.player[i].unionMatchStats.isKnockOns)
                            bw.WriteInt32(Global.player[i].unionMatchStats.knockOns, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.islineBreakAssists);

                        if (Global.player[i].unionMatchStats.islineBreakAssists)
                            bw.WriteInt32(Global.player[i].unionMatchStats.lineBreakAssists, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isLineBreaks);

                        if (Global.player[i].unionMatchStats.isLineBreaks)
                            bw.WriteInt32(Global.player[i].unionMatchStats.lineBreaks, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isMetresRun);

                        if (Global.player[i].unionMatchStats.isMetresRun)
                            bw.WriteInt32(Global.player[i].unionMatchStats.metresRun, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isMinutesPlayed);

                        if (Global.player[i].unionMatchStats.isMinutesPlayed)
                            bw.WriteInt32(Global.player[i].unionMatchStats.minutesPlayed, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isMissedTackles);

                        if (Global.player[i].unionMatchStats.isMissedTackles)
                            bw.WriteInt32(Global.player[i].unionMatchStats.missedTackles, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isOffloads);

                        if (Global.player[i].unionMatchStats.isOffloads)
                            bw.WriteInt32(Global.player[i].unionMatchStats.offloads, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isOneOnOneTackles);

                        if (Global.player[i].unionMatchStats.isOneOnOneTackles)
                            bw.WriteInt32(Global.player[i].unionMatchStats.oneOnOneTackles, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isPasses);

                        if (Global.player[i].unionMatchStats.isPasses)
                            bw.WriteInt32(Global.player[i].unionMatchStats.passes, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isPenaltiesConceded);

                        if (Global.player[i].unionMatchStats.isPenaltiesConceded)
                            bw.WriteInt32(Global.player[i].unionMatchStats.penaltiesConceded, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isPenaltyGoals);

                        if (Global.player[i].unionMatchStats.isPenaltyGoals)
                            bw.WriteInt32(Global.player[i].unionMatchStats.penaltyGoals, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isPenaltyGoalAttempts);

                        if (Global.player[i].unionMatchStats.isPenaltyGoalAttempts)
                            bw.WriteInt32(Global.player[i].unionMatchStats.penaltyGoalAttempts, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isRuns);

                        if (Global.player[i].unionMatchStats.isRuns)
                            bw.WriteInt32(Global.player[i].unionMatchStats.runs, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isTackleBreaks);

                        if (Global.player[i].unionMatchStats.isTackleBreaks)
                            bw.WriteInt32(Global.player[i].unionMatchStats.tackleBreaks, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isTackles);

                        if (Global.player[i].unionMatchStats.isTackles)
                            bw.WriteInt32(Global.player[i].unionMatchStats.tackles, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isTries);

                        if (Global.player[i].unionMatchStats.isTries)
                            bw.WriteInt32(Global.player[i].unionMatchStats.tries, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isTryAssists);

                        if (Global.player[i].unionMatchStats.isTryAssists)
                            bw.WriteInt32(Global.player[i].unionMatchStats.tryAssists, Endian.Little);

                        bw.WriteBool(Global.player[i].unionMatchStats.isBonusTries);

                        if (Global.player[i].unionMatchStats.isBonusTries)
                            bw.WriteInt32(Global.player[i].unionMatchStats.bonusTries, Endian.Little);
                    }

                    // NinesMatch Stats
                    bw.WriteBool(Global.player[i].ninesMatchStats.isStatisticsStats);

                    if (Global.player[i].ninesMatchStats.isStatisticsStats)
                    {
                        bw.WriteBool(Global.player[i].ninesMatchStats.isMatchesPlayed);

                        if (Global.player[i].ninesMatchStats.isMatchesPlayed)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.matchesPlayed, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isMatchesWon);

                        if (Global.player[i].ninesMatchStats.isMatchesWon)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.matchesWon, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isMatchesDrawn);

                        if (Global.player[i].ninesMatchStats.isMatchesDrawn)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.matchesDrawn, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isBallStrips);

                        if (Global.player[i].ninesMatchStats.isBallStrips)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.ballStrips, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isConversions);

                        if (Global.player[i].ninesMatchStats.isConversions)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.conversions, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isConversionAttempts);

                        if (Global.player[i].ninesMatchStats.isConversionAttempts)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.conversionAttempts, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isFends);

                        if (Global.player[i].ninesMatchStats.isFends)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.fends, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isFieldGoalAttempts);

                        if (Global.player[i].ninesMatchStats.isFieldGoalAttempts)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.fieldGoalAttempts, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isFieldGoals);

                        if (Global.player[i].ninesMatchStats.isFieldGoals)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.fieldGoals, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isFortyTwenties);

                        if (Global.player[i].ninesMatchStats.isFortyTwenties)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.fortyTwenties, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isHandlingErrors);

                        if (Global.player[i].ninesMatchStats.isHandlingErrors)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.handlingErrors, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isHitups);

                        if (Global.player[i].ninesMatchStats.isHitups)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.hitups, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isInterceptedPasses);

                        if (Global.player[i].ninesMatchStats.isInterceptedPasses)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.interceptedPasses, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isInterceptions);

                        if (Global.player[i].ninesMatchStats.isInterceptions)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.interceptions, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isKickMetresGained);

                        if (Global.player[i].ninesMatchStats.isKickMetresGained)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.kickMetresGained, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isKicksInPlay);

                        if (Global.player[i].ninesMatchStats.isKicksInPlay)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.kicksInPlay, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isKnockOns);

                        if (Global.player[i].ninesMatchStats.isKnockOns)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.knockOns, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.islineBreakAssists);

                        if (Global.player[i].ninesMatchStats.islineBreakAssists)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.lineBreakAssists, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isLineBreaks);

                        if (Global.player[i].ninesMatchStats.isLineBreaks)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.lineBreaks, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isMetresRun);

                        if (Global.player[i].ninesMatchStats.isMetresRun)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.metresRun, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isMinutesPlayed);

                        if (Global.player[i].ninesMatchStats.isMinutesPlayed)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.minutesPlayed, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isMissedTackles);

                        if (Global.player[i].ninesMatchStats.isMissedTackles)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.missedTackles, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isOffloads);

                        if (Global.player[i].ninesMatchStats.isOffloads)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.offloads, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isOneOnOneTackles);

                        if (Global.player[i].ninesMatchStats.isOneOnOneTackles)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.oneOnOneTackles, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isPasses);

                        if (Global.player[i].ninesMatchStats.isPasses)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.passes, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isPenaltiesConceded);

                        if (Global.player[i].ninesMatchStats.isPenaltiesConceded)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.penaltiesConceded, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isPenaltyGoals);

                        if (Global.player[i].ninesMatchStats.isPenaltyGoals)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.penaltyGoals, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isPenaltyGoalAttempts);

                        if (Global.player[i].ninesMatchStats.isPenaltyGoalAttempts)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.penaltyGoalAttempts, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isRuns);

                        if (Global.player[i].ninesMatchStats.isRuns)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.runs, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isTackleBreaks);

                        if (Global.player[i].ninesMatchStats.isTackleBreaks)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.tackleBreaks, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isTackles);

                        if (Global.player[i].ninesMatchStats.isTackles)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.tackles, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isTries);

                        if (Global.player[i].ninesMatchStats.isTries)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.tries, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isTryAssists);

                        if (Global.player[i].ninesMatchStats.isTryAssists)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.tryAssists, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesMatchStats.isBonusTries);

                        if (Global.player[i].ninesMatchStats.isBonusTries)
                            bw.WriteInt32(Global.player[i].ninesMatchStats.bonusTries, Endian.Little);
                    }
                }
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
    }
}
