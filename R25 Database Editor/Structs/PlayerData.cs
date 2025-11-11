namespace R25_Database_Editor
{
    /// <summary>
    /// Player Data Struct.
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
    public class PlayerData
    {
        public struct Player
        {
            public int identifier;
            public int dataSize; 
            public byte[] data; // Could be player appearance data ?
            public bool playerEnabled; // ?
            public bool isId;
            public int id;
            public bool isFirstName;
            public byte firstNameSize;
            public string firstName;
            public bool isLastName;
            public byte lastNameSize;
            public string lastName;
            public bool isLicensed;
            public bool licensed;
            public bool isGender;
            public int gender;
            public bool isJerseyName;
            public byte jerseyNameSize;
            public string jerseyName;
            public bool isJerseyNumber;
            public int jerseyNumber;
            public DOB dob;
            public bool isAge;
            public int age;
            public bool isCountryOfBirth;
            public int countryOfBirth;
            public bool isRepCountry;
            public int repCountry;
            public bool isStateOfOrigin;
            public int stateOfOrigin;
            public bool isCityVsCountry;
            public int cityVsCountry;
            public bool isAllStars;
            public int allStars;
            public bool isWorldCup;
            public bool WorldCup;
            public bool isContractExpiry;
            public int contractExpiry;
            public bool isPrimaryRole;
            public int primaryRole;
            public bool isSecondaryRole;
            public int secondaryRole;
            public bool isTertiaryRole;
            public int tertiaryRole;
            public bool isCommentaryNameHash;
            public uint commentaryNameHash;
            public bool isPreferredHand;
            public byte preferredHand;
            public bool isPreferredFoot;
            public byte preferredFoot;
            public Appearance appearance;
            public Attributes attributes;
            public Skills skills;
            public Statistics leagueMatchStats;
            public Statistics unionMatchStats;
            public Statistics ninesMatchStats;
        }

        public struct DOB
        {
            public bool isDay;
            public int day;
            public bool isMonth;
            public int month;
            public bool isYear;
            public int year;
        }

        public struct Appearance
        {
            public bool isHeight;
            public int height;
            public bool isWeight;
            public int weight;
            public bool isPhotogrammetryStatus;
            public int photogrammetryStatus;
        }

        public struct Attributes
        {
            public bool isMovementProfile;
            public int movementProfile;
            public bool isTemperament;
            public int temperament;
            public bool isFitness;
            public int fitness;
        }

        public struct Skills
        {
            public StrengthSkills strengthSkills;
            public SpeedSkills speedSkills;
            public KickingSkills kickingSkills;
            public HandsSkills handsSkills;
            public MentalitySkills mentalitySkills;
        }

        public struct StrengthSkills
        {
            public bool isStrength;
            public int strength;
            public bool isRucking;
            public int rucking;
            public bool isScrummaging;
            public int scrummaging;
            public bool isTackling;
            public int tackling;
            public bool isBreakTackle;
            public int breakTackling;
            public bool isFending;
            public int fending;
        }

        public struct SpeedSkills
        {
            public bool isAgility;
            public int agility;
            public bool isSprintSpeed;
            public int sprintSpeed;
            public bool isAcceleration;
            public int acceleration;
            public bool isBalance;
            public int balance;
            public bool isStamina;
            public int stamina;
            public bool isEvasion;
            public int evasion;
        }

        public struct KickingSkills
        {
            public bool isKickingAccuracy;
            public int kickingAccuracy;
            public bool isKickingPower;
            public int kickingPower;
            public bool isGoalKicking;
            public int goalKicking;
            public bool isToePoke;
            public int toePoke;
            public bool isConversionStyle;
            public int conversionStyle;
        }

        public struct HandsSkills
        {
            public bool isPassing;
            public int passing;
            public bool isAerialSkills;
            public int aerialSkills;
            public bool isOffload;
            public int offload;
            public bool isJackal;
            public int jackal;
            public bool isIntercepting;
            public int intercepting;
        }

        public struct MentalitySkills
        {
            public bool isFocus;
            public int focus;
            public bool isLeadership;
            public int leadership;
            public bool isDetermination;
            public int determination;
            public bool isDiscipline;
            public int discipline;
        }

        public struct Statistics
        {
            public bool isStatisticsStats;
            public bool isMatchesPlayed;
            public int matchesPlayed;
            public bool isMatchesWon;
            public int matchesWon;
            public bool isMatchesDrawn;
            public int matchesDrawn;
            public bool isBallStrips;
            public int ballStrips;
            public bool isConversions;
            public int conversions;
            public bool isConversionAttempts;
            public int conversionAttempts;
            public bool isFends;
            public int fends;
            public bool isFieldGoalAttempts;
            public int fieldGoalAttempts;
            public bool isFieldGoals;
            public int fieldGoals;
            public bool isFortyTwenties;
            public int fortyTwenties;
            public bool isHandlingErrors;
            public int handlingErrors;
            public bool isHitups;
            public int hitups;
            public bool isInterceptedPasses;
            public int interceptedPasses;
            public bool isInterceptions;
            public int interceptions;
            public bool isKickMetresGained;
            public int kickMetresGained;
            public bool isKicksInPlay;
            public int kicksInPlay;
            public bool isKnockOns;
            public int knockOns;
            public bool islineBreakAssists;
            public int lineBreakAssists;
            public bool isLineBreaks;
            public int lineBreaks;
            public bool isMetresRun;
            public int metresRun;
            public bool isMinutesPlayed;
            public int minutesPlayed;
            public bool isMissedTackles;
            public int missedTackles;
            public bool isOffloads;
            public int offloads;
            public bool isOneOnOneTackles;
            public int oneOnOneTackles;
            public bool isPasses;
            public int passes;
            public bool isPenaltiesConceded;
            public int penaltiesConceded;
            public bool isPenaltyGoals;
            public int penaltyGoals;
            public bool isPenaltyGoalAttempts;
            public int penaltyGoalAttempts;
            public bool isRuns;
            public int runs;
            public bool isTackleBreaks;
            public int tackleBreaks;
            public bool isTackles;
            public int tackles;
            public bool isTries;
            public int tries;
            public bool isTryAssists;
            public int tryAssists;
            public bool isBonusTries;
            public int bonusTries;
        }
    }
}
