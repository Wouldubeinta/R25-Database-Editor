namespace R25_Database_Editor
{
    /// <summary>
    /// Player Ratings Class.
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
    internal class Rating
    {
        public static int PlayerRating(int index)
        {
            int PlayerRole = 0;
            int Role = Global.player[index].primaryRole;

            if (Role == 0)
                PlayerRole = PlayerRatingFB(index);
            else if (Role == 2 || Role == 3)
                PlayerRole = PlayerRatingW(index);
            else if (Role == 5 || Role == 6)
                PlayerRole = PlayerRatingC(index);
            else if (Role == 9)
                PlayerRole = PlayerRatingFH(index);
            else if (Role == 10)
                PlayerRole = PlayerRatingSH(index);
            else if (Role == 12 || Role == 13)
                PlayerRole = PlayerRatingPR(index);
            else if (Role == 14)
                PlayerRole = PlayerRatingHK(index);
            else if (Role == 17 || Role == 18)
                PlayerRole = PlayerRatingL(index);
            else if (Role == 20)
                PlayerRole = PlayerRatingOF(index);
            else if (Role == 21)
                PlayerRole = PlayerRatingBF(index);
            else if (Role == 22)
                PlayerRole = PlayerRatingN8(index);
            return PlayerRole;
        }

        private static int PlayerRatingFB(int index)
        {
            decimal playerRating = (((Global.player[index].skills.strengthSkills.strength * 99) / 94) + ((Global.player[index].skills.speedSkills.agility * 99) / 96) + ((Global.player[index].skills.speedSkills.stamina * 99) / 97) + ((Global.player[index].skills.speedSkills.acceleration * 99) / 94)
            + ((Global.player[index].skills.mentalitySkills.discipline * 99) / 94) + ((Global.player[index].skills.speedSkills.balance * 99) / 92) + ((Global.player[index].skills.speedSkills.sprintSpeed * 99) / 95) + ((Global.player[index].skills.handsSkills.passing * 99) / 94)
            + ((Global.player[index].skills.speedSkills.evasion * 99) / 96) + ((Global.player[index].skills.handsSkills.aerialSkills * 99) / 98)) / 10;
            return (int)playerRating;
        }

        private static int PlayerRatingW(int index)
        {
            decimal playerRating = (((Global.player[index].skills.strengthSkills.strength * 99) / 94) + ((Global.player[index].skills.speedSkills.agility * 99) / 96) + ((Global.player[index].skills.speedSkills.stamina * 99) / 95) + ((Global.player[index].skills.speedSkills.acceleration * 99) / 98)
            + ((Global.player[index].skills.mentalitySkills.discipline * 99) / 94) + ((Global.player[index].skills.speedSkills.balance * 99) / 94) + ((Global.player[index].skills.speedSkills.sprintSpeed * 99) / 97) + ((Global.player[index].skills.handsSkills.offload * 99) / 93) + ((Global.player[index].skills.handsSkills.passing * 99) / 90)
            + ((Global.player[index].skills.strengthSkills.fending * 99) / 94) + ((Global.player[index].skills.speedSkills.evasion * 99) / 99) + ((Global.player[index].skills.strengthSkills.breakTackling * 99) / 95) + ((Global.player[index].skills.strengthSkills.tackling * 99) / 94)
            + ((Global.player[index].skills.handsSkills.aerialSkills * 99) / 94) + ((Global.player[index].skills.handsSkills.jackal * 99) / 96)) / 15;
            return (int)playerRating;
        }

        private static int PlayerRatingC(int index)
        {
            decimal playerRating = (((Global.player[index].skills.strengthSkills.strength * 99) / 99) + ((Global.player[index].skills.speedSkills.agility * 99) / 94) + ((Global.player[index].skills.speedSkills.stamina * 99) / 95) + ((Global.player[index].skills.speedSkills.acceleration * 99) / 96)
            + ((Global.player[index].skills.mentalitySkills.discipline * 99) / 94) + ((Global.player[index].skills.speedSkills.balance * 99) / 94) + ((Global.player[index].skills.speedSkills.sprintSpeed * 99) / 95) + ((Global.player[index].skills.handsSkills.passing * 99) / 94) + ((Global.player[index].skills.handsSkills.offload * 99) / 94)
            + ((Global.player[index].skills.handsSkills.jackal * 99) / 90) + ((Global.player[index].skills.speedSkills.evasion * 99) / 98) + ((Global.player[index].skills.strengthSkills.tackling * 99) / 94) + ((Global.player[index].skills.handsSkills.aerialSkills * 99) / 94)) / 13;
            return (int)playerRating;
        }

        private static int PlayerRatingFH(int index)
        {
            decimal playerRating = (((Global.player[index].skills.strengthSkills.strength * 99) / 92) + ((Global.player[index].skills.speedSkills.agility * 99) / 90) + ((Global.player[index].skills.speedSkills.stamina * 99) / 94) + ((Global.player[index].skills.speedSkills.acceleration * 99) / 92)
            + ((Global.player[index].skills.mentalitySkills.discipline * 99) / 94) + ((Global.player[index].skills.handsSkills.jackal * 99) / 94) + ((Global.player[index].skills.speedSkills.sprintSpeed * 99) / 93) + ((Global.player[index].skills.handsSkills.passing * 99) / 96) + ((Global.player[index].skills.kickingSkills.kickingAccuracy * 99) / 94)
            + ((Global.player[index].skills.kickingSkills.kickingPower * 99) / 99) + ((Global.player[index].skills.kickingSkills.toePoke * 99) / 96) + ((Global.player[index].skills.kickingSkills.goalKicking * 99) / 95) + ((Global.player[index].skills.mentalitySkills.determination * 99) / 98) + ((Global.player[index].skills.mentalitySkills.focus * 99) / 97)) / 14;
            return (int)playerRating;
        }

        private static int PlayerRatingSH(int index)
        {
            decimal playerRating = (((Global.player[index].skills.strengthSkills.strength * 99) / 90) + ((Global.player[index].skills.speedSkills.agility * 99) / 89) + ((Global.player[index].skills.speedSkills.stamina * 99) / 91) + ((Global.player[index].skills.speedSkills.acceleration * 99) / 94)
            + ((Global.player[index].skills.mentalitySkills.discipline * 99) / 94) + ((Global.player[index].skills.handsSkills.jackal * 99) / 94) + ((Global.player[index].skills.speedSkills.sprintSpeed * 99) / 93) + ((Global.player[index].skills.kickingSkills.kickingAccuracy * 99) / 94) + ((Global.player[index].skills.kickingSkills.kickingPower * 97) / 94)
            + ((Global.player[index].skills.kickingSkills.toePoke * 99) / 99) + ((Global.player[index].skills.kickingSkills.goalKicking * 99) / 95) + ((Global.player[index].skills.handsSkills.passing * 99) / 96) + ((Global.player[index].skills.mentalitySkills.focus * 99) / 98)) / 13;
            return (int)playerRating;
        }

        private static int PlayerRatingPR(int index)
        {
            decimal playerRating = (((Global.player[index].skills.strengthSkills.strength * 99) / 94) + ((Global.player[index].skills.speedSkills.agility * 99) / 94) + ((Global.player[index].skills.speedSkills.stamina * 99) / 94) + ((Global.player[index].skills.speedSkills.acceleration * 99) / 94)
            + ((Global.player[index].skills.mentalitySkills.discipline * 99) / 94) + ((Global.player[index].skills.mentalitySkills.determination * 99) / 94) + ((Global.player[index].skills.speedSkills.sprintSpeed * 99) / 93) + ((Global.player[index].skills.strengthSkills.fending * 99) / 94) + ((Global.player[index].skills.strengthSkills.breakTackling * 99) / 94)
            + ((Global.player[index].skills.strengthSkills.rucking * 99) / 98) + ((Global.player[index].skills.strengthSkills.scrummaging * 99) / 96) + ((Global.player[index].skills.strengthSkills.tackling * 99) / 99) + ((Global.player[index].skills.handsSkills.offload * 99) / 97)) / 13;
            return (int)(playerRating);
        }

        private static int PlayerRatingHK(int index)
        {
            decimal playerRating = (((Global.player[index].skills.strengthSkills.strength * 99) / 92) + ((Global.player[index].skills.speedSkills.agility * 99) / 95) + ((Global.player[index].skills.speedSkills.stamina * 99) / 97) + ((Global.player[index].skills.speedSkills.acceleration * 99) / 90)
            + ((Global.player[index].skills.mentalitySkills.discipline * 99) / 94) + ((Global.player[index].skills.mentalitySkills.leadership * 99) / 94) + ((Global.player[index].skills.speedSkills.sprintSpeed * 99) / 94) + ((Global.player[index].skills.strengthSkills.scrummaging * 99) / 94) + ((Global.player[index].skills.speedSkills.evasion * 99) / 94)
            + ((Global.player[index].skills.strengthSkills.tackling * 99) / 95) + ((Global.player[index].skills.kickingSkills.toePoke * 99) / 94) + ((Global.player[index].skills.kickingSkills.kickingPower * 99) / 94) + ((Global.player[index].skills.handsSkills.passing * 99) / 99) + ((Global.player[index].skills.handsSkills.offload * 99) / 98)
            + ((Global.player[index].skills.handsSkills.offload * 99) / 93)) / 15;
            return (int)playerRating;
        }

        private static int PlayerRatingL(int index)
        {
            decimal playerRating = (((Global.player[index].skills.strengthSkills.strength * 99) / 95) + ((Global.player[index].skills.speedSkills.agility * 99) / 93) + ((Global.player[index].skills.speedSkills.stamina * 99) / 94) + ((Global.player[index].skills.speedSkills.acceleration * 99) / 94)
            + ((Global.player[index].skills.mentalitySkills.discipline * 99) / 94) + ((Global.player[index].skills.strengthSkills.rucking * 99) / 94) + ((Global.player[index].skills.speedSkills.sprintSpeed * 99) / 94) + ((Global.player[index].skills.handsSkills.passing * 99) / 94) + ((Global.player[index].skills.handsSkills.offload * 99) / 97)
            + ((Global.player[index].skills.strengthSkills.fending * 99) / 94) + ((Global.player[index].skills.strengthSkills.breakTackling * 99) / 94) + ((Global.player[index].skills.strengthSkills.tackling * 99) / 99) + ((Global.player[index].skills.strengthSkills.scrummaging * 99) / 96)) / 13;
            return (int)playerRating;
        }

        private static int PlayerRatingOF(int index)
        {
            decimal playerRating = (((Global.player[index].skills.strengthSkills.strength * 99) / 96) + ((Global.player[index].skills.speedSkills.agility * 99) / 93) + ((Global.player[index].skills.speedSkills.stamina * 99) / 94) + ((Global.player[index].skills.speedSkills.acceleration * 99) / 94)
            + ((Global.player[index].skills.mentalitySkills.discipline * 99) / 94) + ((Global.player[index].skills.mentalitySkills.determination * 99) / 94) + ((Global.player[index].skills.speedSkills.sprintSpeed * 99) / 94) + ((Global.player[index].skills.handsSkills.passing * 99) / 94) + ((Global.player[index].skills.handsSkills.offload * 99) / 99)
            + ((Global.player[index].skills.strengthSkills.fending * 99) / 94) + ((Global.player[index].skills.speedSkills.evasion * 99) / 94) + ((Global.player[index].skills.strengthSkills.breakTackling * 99) / 95) + ((Global.player[index].skills.strengthSkills.tackling * 99) / 97) + ((Global.player[index].skills.strengthSkills.rucking * 99) / 96)
            + ((Global.player[index].skills.strengthSkills.scrummaging * 99) / 94)) / 15;
            return (int)playerRating;
        }

        private static int PlayerRatingBF(int index)
        {
            decimal playerRating = (((Global.player[index].skills.strengthSkills.strength * 99) / 96) + ((Global.player[index].skills.speedSkills.agility * 99) / 93) + ((Global.player[index].skills.speedSkills.stamina * 99) / 94) + ((Global.player[index].skills.speedSkills.acceleration * 99) / 94)
            + ((Global.player[index].skills.mentalitySkills.discipline * 99) / 94) + ((Global.player[index].skills.mentalitySkills.determination * 99) / 94) + ((Global.player[index].skills.speedSkills.sprintSpeed * 99) / 94) + ((Global.player[index].skills.handsSkills.passing * 99) / 94) + ((Global.player[index].skills.handsSkills.offload * 99) / 99)
            + ((Global.player[index].skills.strengthSkills.fending * 99) / 94) + ((Global.player[index].skills.speedSkills.evasion * 99) / 94) + ((Global.player[index].skills.strengthSkills.breakTackling * 99) / 95) + ((Global.player[index].skills.strengthSkills.tackling * 99) / 97) + ((Global.player[index].skills.strengthSkills.rucking * 99) / 96)
            + ((Global.player[index].skills.strengthSkills.scrummaging * 99) / 94)) / 15;
            return (int)playerRating;
        }

        private static int PlayerRatingN8(int index)
        {
            decimal playerRating = (((Global.player[index].skills.strengthSkills.strength * 99) / 96) + ((Global.player[index].skills.speedSkills.agility * 99) / 93) + ((Global.player[index].skills.speedSkills.stamina * 99) / 94) + ((Global.player[index].skills.speedSkills.acceleration * 99) / 94)
            + ((Global.player[index].skills.mentalitySkills.discipline * 99) / 94) + ((Global.player[index].skills.mentalitySkills.determination * 99) / 94) + ((Global.player[index].skills.speedSkills.sprintSpeed * 99) / 94) + ((Global.player[index].skills.handsSkills.passing * 99) / 94) + ((Global.player[index].skills.handsSkills.offload * 99) / 99)
            + ((Global.player[index].skills.strengthSkills.fending * 99) / 94) + ((Global.player[index].skills.speedSkills.evasion * 99) / 94) + ((Global.player[index].skills.strengthSkills.breakTackling * 99) / 95) + ((Global.player[index].skills.strengthSkills.tackling * 99) / 97) + ((Global.player[index].skills.strengthSkills.rucking * 99) / 96)
            + ((Global.player[index].skills.strengthSkills.scrummaging * 99) / 94)) / 15;
            return (int)playerRating;
        }
    }
}
