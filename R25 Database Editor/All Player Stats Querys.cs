namespace R25_Database_Editor
{
    public partial class All_Player_Stats_Querys : Form
    {
        public All_Player_Stats_Querys()
        {
            InitializeComponent();
        }

        private void All_Player_Stats_Querys_Load(object sender, EventArgs e)
        {
            PlayerRole_comboBox.Items.AddRange(StringArrays.UnionRoles);
            PlayerRole_comboBox.SelectedIndex = 0;
        }

        private void ChangeStats_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Global.player_amount; i++)
            {
                int Role = Global.player[i].primaryRole;

                if (Role == SearchID.RolesIndex(PlayerRole_comboBox.Text))
                    SkillChange(i);
                else if (PlayerRole_comboBox.SelectedIndex == 0)
                    SkillChange(i);
            }

            MessageBox.Show("All player stats have been changed", "All Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SkillChange(int i)
        {
            // Strength Skills
            Global.player[i].skills.strengthSkills.strength = Results(Global.player[i].skills.strengthSkills.strength, Strength_numericUpDown.Value);
            Global.player[i].skills.strengthSkills.rucking = Results(Global.player[i].skills.strengthSkills.rucking, Rucking_numericUpDown.Value);
            Global.player[i].skills.strengthSkills.scrummaging = Results(Global.player[i].skills.strengthSkills.scrummaging, Scrummaging_numericUpDown.Value);
            Global.player[i].skills.strengthSkills.tackling = Results(Global.player[i].skills.strengthSkills.tackling, Tackling_numericUpDown.Value);
            Global.player[i].skills.strengthSkills.breakTackling = Results(Global.player[i].skills.strengthSkills.breakTackling, BreakTackle_numericUpDown.Value);
            Global.player[i].skills.strengthSkills.fending = Results(Global.player[i].skills.strengthSkills.fending, Fending_numericUpDown.Value);

            // Speed Skills
            Global.player[i].skills.speedSkills.agility = Results(Global.player[i].skills.speedSkills.agility, Agility_numericUpDown.Value);
            Global.player[i].skills.speedSkills.acceleration = Results(Global.player[i].skills.speedSkills.acceleration, Acceleration_numericUpDown.Value);
            Global.player[i].skills.speedSkills.sprintSpeed = Results(Global.player[i].skills.speedSkills.sprintSpeed, SprintSpeed_numericUpDown.Value);
            Global.player[i].skills.speedSkills.balance = Results(Global.player[i].skills.speedSkills.balance, Balance_numericUpDown.Value);
            Global.player[i].skills.speedSkills.stamina = Results(Global.player[i].skills.speedSkills.stamina, Stamina_numericUpDown.Value);
            Global.player[i].skills.speedSkills.evasion = Results(Global.player[i].skills.speedSkills.evasion, Evasion_numericUpDown.Value);

            // Kicking Skills
            Global.player[i].skills.kickingSkills.kickingAccuracy = Results(Global.player[i].skills.kickingSkills.kickingAccuracy, KickingAccuracy_numericUpDown.Value);
            Global.player[i].skills.kickingSkills.kickingPower = Results(Global.player[i].skills.kickingSkills.kickingPower, KickingPower_numericUpDown.Value);
            Global.player[i].skills.kickingSkills.goalKicking = Results(Global.player[i].skills.kickingSkills.goalKicking, GoalKicking_numericUpDown.Value);

            // Hands Skills
            Global.player[i].skills.handsSkills.passing = Results(Global.player[i].skills.handsSkills.passing, Passing_numericUpDown.Value);
            Global.player[i].skills.handsSkills.aerialSkills = Results(Global.player[i].skills.handsSkills.aerialSkills, AerialSkill_numericUpDown.Value);
            Global.player[i].skills.handsSkills.offload = Results(Global.player[i].skills.handsSkills.offload, Offload_numericUpDown.Value);
            Global.player[i].skills.handsSkills.jackal = Results(Global.player[i].skills.handsSkills.jackal, Jackal_numericUpDown.Value);
            Global.player[i].skills.handsSkills.intercepting = Results(Global.player[i].skills.handsSkills.intercepting, Intercepting_numericUpDown.Value);

            // Mentality Skills
            Global.player[i].skills.mentalitySkills.focus = Results(Global.player[i].skills.mentalitySkills.focus, Focus_numericUpDown.Value);
            Global.player[i].skills.mentalitySkills.leadership = Results(Global.player[i].skills.mentalitySkills.leadership, Leadership_numericUpDown.Value);
            Global.player[i].skills.mentalitySkills.determination = Results(Global.player[i].skills.mentalitySkills.determination, Determination_numericUpDown.Value);
            Global.player[i].skills.mentalitySkills.discipline = Results(Global.player[i].skills.mentalitySkills.discipline, Discipline_numericUpDown.Value);
        }

        private int Results(int Skill, decimal control)
        {
            int temp = 0;
            int Results = Skill + Convert.ToInt32(control);
            temp = Results;

            if (Results < 0)
                temp = 0;
            else if (Results > 99)
                temp = 99;
            return temp;
        }

        private void IncrementsValue_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Strength Skills
            Strength_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            Strength_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            Rucking_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            Rucking_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            Scrummaging_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            Scrummaging_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            Tackling_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            Tackling_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            BreakTackle_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            BreakTackle_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            Fending_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            Fending_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            // Speed Skills
            Agility_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            Agility_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            Acceleration_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            Acceleration_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            SprintSpeed_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            SprintSpeed_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            Balance_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            Balance_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            Stamina_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            Stamina_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            Evasion_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            Evasion_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            // Kicking Skills
            KickingAccuracy_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            KickingAccuracy_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            KickingPower_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            KickingPower_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            GoalKicking_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            GoalKicking_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            // Hands Skills
            Passing_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            Passing_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            AerialSkill_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            AerialSkill_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            Offload_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            Offload_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            Jackal_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            Jackal_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            Intercepting_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            Intercepting_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            // Mentality Skills
            Focus_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            Focus_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            Leadership_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            Leadership_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            Determination_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            Determination_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            Discipline_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            Discipline_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;
        }
    }
}
