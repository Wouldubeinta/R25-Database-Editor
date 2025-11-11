using PackageIO;
using System.Data;
using System.Reflection;

namespace R25_Database_Editor
{
    public partial class Team_Editor : Form
    {
        private readonly DataGridView Teams_dgv;
        private readonly DataGridView Players_dgv;
        private Dialogue_Wildcardhash.WildcardHash[]? commentaryTeamHash = null;

        public Team_Editor(DataGridView Teams_dgv, DataGridView Players_dgv)
        {
            InitializeComponent();
            this.Teams_dgv = Teams_dgv;
            this.Players_dgv = Players_dgv;
        }

        private DataTable? PlayersRoster_dt = null;
        private string[]? stadiumType = null;
        private int Team_Index = 0;

        private void Team_Editor_Load(object sender, EventArgs e)
        {
            TeamIndex_textBox.Text = Global.team_index.ToString();
            Team_Index = Global.team_index;
            TeamID_textBox.Text = Global.team[Team_Index].id.ToString();

            Fullname_textBox.Text = Global.team[Team_Index].fullName;
            shortName_textBox.Text = Global.team[Team_Index].shortName;
            nickname_textBox.Text = Global.team[Team_Index].nickname;
            hudName_textBox.Text = Global.team[Team_Index].hudName;
            shirtName_textBox.Text = Global.team[Team_Index].shortName;

            TeamType_comboBox.SelectedIndex = Global.team[Team_Index].clubType;

            Affiliations_comboBox.Items.AddRange(StringArrays.Affiliations);
            Affiliations_comboBox.SelectedIndex = Global.team[Team_Index].affiliations;

            isWorldCup_checkBox.Checked = Global.team[Team_Index].WorldCupTeam;

            TeamGender_textBox.Text = "Male";
            TeamGenderImage_label.Image = Properties.Resources.Male;

            if (Global.team[Team_Index].gender == 1)
            {
                TeamGender_textBox.Text = "Female";
                TeamGenderImage_label.Image = Properties.Resources.Female;
            }

            PrimaryColour_button.BackColor = Color.FromArgb(Global.team[Team_Index].primaryColour.r, Global.team[Team_Index].primaryColour.g, Global.team[Team_Index].primaryColour.b);
            SecondaryColour_button.BackColor = Color.FromArgb(Global.team[Team_Index].secondaryColour.r, Global.team[Team_Index].secondaryColour.g, Global.team[Team_Index].secondaryColour.b);
            HudTextColour_button.BackColor = Color.FromArgb(Global.team[Team_Index].hudTextColour.r, Global.team[Team_Index].hudTextColour.g, Global.team[Team_Index].hudTextColour.b);

            Logo_comboBox.Text = Global.team[Team_Index].logo;

            string Logo = Global.currentPath + @"\Logos\" + Global.team[Team_Index].logo + ".pc.png";

            if (File.Exists(Logo))
            {
                largeLogo_pictureBox.ImageLocation = Logo;
                smallLogo_pictureBox.ImageLocation = Logo;
            }

            isTeamEnabled_checkBox.Checked = Global.team[Team_Index].teamEnabled;

            string commentaryDataPath = Global.currentPath + @"\commentary_data\";

            commentaryTeamHash = CommentaryHashes.Read(commentaryDataPath + "dialogue_wildcardhash_teams");

            string[] commHashNames = new string[commentaryTeamHash.Length];

            for (int i = 0; i < commentaryTeamHash.Length; i++)
            {
                commHashNames[i] = commentaryTeamHash[i].name.ToTitleCase();
            }

            CommentaryTeamHash_comboBox.Items.AddRange(commHashNames);
            int commentaryHashIndex = CommentaryHashes.GetHashes(Global.team[Team_Index].commentaryTeamHash, commentaryTeamHash);

            if (commentaryHashIndex != -1)
                CommentaryTeamHash_comboBox.SelectedIndex = commentaryHashIndex;
            else
                CommentaryTeamHash_comboBox.SelectedIndex = 0;

            Stadium_comboBox.Items.AddRange(StringArrays.Stadiums);
            stadiumType = ["Primary Ground", "Secondary Ground", "Tertiary Ground"];
            StadiumAmount_numericUpDown.Value = Global.team[Team_Index].stadiumAmount;
            StadiumAmount_numericUpDown.Minimum = 1;

            JerseySelection_comboBox.Items.Add("Jersey 1");
            JerseyAmount_numericUpDown.Value = Global.team[Team_Index].jerseyAmount;
            JerseyAmount_numericUpDown.Minimum = 1;

            TeamPlayerAmount_textBox.Text = Global.team[Team_Index].playerAmount.ToString();

            playersRoster_dataGridView.CellValueChanged -= new DataGridViewCellEventHandler(PlayersRoster_dataGridView_CellValueChanged);
            lineup_dataGridView.CellValueChanged -= new DataGridViewCellEventHandler(Lineup_dataGridView_CellValueChanged);
            AssignRoles_dataGridView.CellValueChanged -= new DataGridViewCellEventHandler(AssignRoles_dataGridView_CellValueChanged);

            PlayersRoster();
            Lineup();
            Roles();

            playersRoster_dataGridView.CellValueChanged += new DataGridViewCellEventHandler(PlayersRoster_dataGridView_CellValueChanged);
            lineup_dataGridView.CellValueChanged += new DataGridViewCellEventHandler(Lineup_dataGridView_CellValueChanged);
            AssignRoles_dataGridView.CellValueChanged += new DataGridViewCellEventHandler(AssignRoles_dataGridView_CellValueChanged);

            int TeamRating = 0;

            for (int i = 0; i < Global.MIN_PLAYERS_PER_TEAM; i++)
            {
                if (Global.team[Team_Index].unionLineups != null)
                    TeamRating = TeamRating + Rating.PlayerRating(SearchID.PlayersIndex(Global.team[Team_Index].unionLineups[i].unionLineupId));
            }

            TeamRating = TeamRating / Global.MIN_PLAYERS_PER_TEAM;

            team_name_label.Text = Fullname_textBox.Text + " - " + TeamRating.ToString();
        }

        private void StadiumAmount_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            StadiumType_comboBox.Items.Clear();

            Global.team[Team_Index].stadiumAmount = Convert.ToInt32(StadiumAmount_numericUpDown.Value);

            for (int i = 0; i < Global.team[Team_Index].stadiumAmount; i++)
            {
                StadiumType_comboBox.Items.Add(stadiumType[i]);
            }

            StadiumType_comboBox.Items.Add("Final Ground");
            StadiumType_comboBox.SelectedIndex = 0;

            if (StadiumType_comboBox.SelectedIndex < Global.team[Team_Index].stadiumAmount)
            {
                Stadium_comboBox.SelectedIndex = Global.team[Team_Index].stadium[StadiumType_comboBox.SelectedIndex].id - 5;
                CustomName_checkBox.Checked = Global.team[Team_Index].stadium[StadiumType_comboBox.SelectedIndex].isCustomName;
                CustomName_textBox.Text = Global.team[Team_Index].stadium[StadiumType_comboBox.SelectedIndex].customName;
            }
            else
            {
                Stadium_comboBox.SelectedIndex = Global.team[Team_Index].finalStadium.id - 5;
                CustomName_checkBox.Checked = Global.team[Team_Index].finalStadium.isCustomName;
                CustomName_textBox.Text = Global.team[Team_Index].finalStadium.customName;
            }
        }

        private void StadiumType_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StadiumType_comboBox.SelectedIndex < Global.team[Team_Index].stadiumAmount)
            {
                Stadium_comboBox.SelectedIndex = Global.team[Team_Index].stadium[StadiumType_comboBox.SelectedIndex].id - 5;

                if (Global.team[Team_Index].stadium[StadiumType_comboBox.SelectedIndex].isWantCustomName)
                    CustomName_checkBox.Checked = Global.team[Team_Index].stadium[StadiumType_comboBox.SelectedIndex].wantCustomName;

                if (Global.team[Team_Index].stadium[StadiumType_comboBox.SelectedIndex].isCustomName)
                    CustomName_textBox.Text = Global.team[Team_Index].stadium[StadiumType_comboBox.SelectedIndex].customName;
            }
            else
            {
                Stadium_comboBox.SelectedIndex = Global.team[Team_Index].finalStadium.id - 5;

                if (Global.team[Team_Index].finalStadium.isWantCustomName)
                    CustomName_checkBox.Checked = Global.team[Team_Index].finalStadium.wantCustomName;

                if (Global.team[Team_Index].finalStadium.isCustomName)
                    CustomName_textBox.Text = Global.team[Team_Index].finalStadium.customName;
            }
        }

        private void CustomName_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CustomName_checkBox.Checked)
                CustomName_textBox.Text = Stadium_comboBox.Text;
            else
                CustomName_textBox.Text = string.Empty;
        }

        private void JerseySelection_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            LicensedJersey_comboBox.Items.Clear();
            LicensedJersey_comboBox.Items.Add("Custom Jersey");
            JerseyName_textBox.Text = Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].name;

            int Manufacture = Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].manufactureId;
            short LicJersey = Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].licensedId;

            JerseyManufacture_comboBox.SelectedIndexChanged -= new EventHandler(JerseyManufacture_comboBox_SelectedIndexChanged);

            if (Manufacture == 0)
            {
                JerseyManufacture_comboBox.SelectedIndex = 0;
                LicensedJersey_comboBox.Items.AddRange(Jerseys.ISC_List);
                LicensedJersey_comboBox.Text = Jerseys.Get_ISC_Jerseys(LicJersey);
            }
            else if (Manufacture == 2)
            {
                JerseyManufacture_comboBox.SelectedIndex = 1;
                LicensedJersey_comboBox.Items.AddRange(Jerseys.Asics_List);
                LicensedJersey_comboBox.Text = Jerseys.Get_Asics_Jerseys(LicJersey);
            }
            else if (Manufacture == 3)
            {
                JerseyManufacture_comboBox.SelectedIndex = 2;
                LicensedJersey_comboBox.Items.AddRange(Jerseys.Xblades_List);
                LicensedJersey_comboBox.Text = Jerseys.Get_Xblades_Jerseys(LicJersey);
            }
            else if (Manufacture == 4)
            {
                JerseyManufacture_comboBox.SelectedIndex = 3;
                LicensedJersey_comboBox.Items.AddRange(Jerseys.Canterbury_List);
                LicensedJersey_comboBox.Text = Jerseys.Get_Canterbury_Jerseys(LicJersey);
            }
            else if (Manufacture == 6)
            {
                JerseyManufacture_comboBox.SelectedIndex = 4;
                LicensedJersey_comboBox.Items.AddRange(Jerseys.ClassicSports_List);
                LicensedJersey_comboBox.Text = Jerseys.Get_ClassicSports_Jerseys(LicJersey);
            }
            else if (Manufacture == 7)
            {
                JerseyManufacture_comboBox.SelectedIndex = 5;
                LicensedJersey_comboBox.Items.AddRange(Jerseys.ClassicCollar_List);
                LicensedJersey_comboBox.Text = Jerseys.Get_ClassicCollar_Jerseys(LicJersey);
            }
            else if (Manufacture == 8)
            {
                JerseyManufacture_comboBox.SelectedIndex = 6;
                LicensedJersey_comboBox.Items.AddRange(Jerseys.Errea_List);
                LicensedJersey_comboBox.Text = Jerseys.Get_Errea_Jerseys(LicJersey);
            }
            else if (Manufacture == 14)
            {
                JerseyManufacture_comboBox.SelectedIndex = 7;
                LicensedJersey_comboBox.Items.AddRange(Jerseys.FemaleWC_List);
                LicensedJersey_comboBox.Text = Jerseys.Get_FemaleWC_Jerseys(LicJersey);
            }

            JerseyManufacture_comboBox.SelectedIndexChanged += new EventHandler(JerseyManufacture_comboBox_SelectedIndexChanged);

            if (LicJersey == 0)
                LicensedJersey_comboBox.SelectedIndex = 0;

            JerseyNameEnabled_checkBox.Checked = Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].showName;
            JerseyNameFont_numericUpDown.Value = Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].nameFont + 1;
            JerseyNameColour_button.BackColor = Color.FromArgb(Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].nameColour.r, Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].nameColour.g, Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].nameColour.b);
            JerseyNumberEnabled_checkBox.Checked = Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].showNumber;
            JerseyNumberFont_numericUpDown.Value = Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].numberFont + 1;
            ShowLeadingZero_Enabled_checkBox.Checked = Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].showingLeadingZero;
            JerseyNumberColour_button.BackColor = Color.FromArgb(Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].numberColour.r, Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].numberColour.g, Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].numberColour.b);
            KeylineSize_numericUpDown.Value = Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].keylineSize;
            KeylineOffset_numericUpDown.Value = Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].keylineOffset;
            KeylineColour_button.BackColor = Color.FromArgb(Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].keylineColour.r, Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].keylineColour.g, Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].keylineColour.b);
            InternalKeyline_checkBox.Checked = Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].showInternalKeyline;
            */
        }

        private void JerseyManufacture_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            LicensedJersey_comboBox.Items.Clear();
            LicensedJersey_comboBox.Items.Add("Custom Jersey");

            int index = JerseyManufacture_comboBox.SelectedIndex;
            short LicJersey = Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].licensedId;

            if (index == 0)
            {
                LicensedJersey_comboBox.Items.AddRange(Jerseys.ISC_List);
                LicensedJersey_comboBox.Text = Jerseys.Get_ISC_Jerseys(LicJersey);
                LicensedJersey_comboBox.SelectedIndex = 1;
            }
            else if (index == 1)
            {
                LicensedJersey_comboBox.Items.AddRange(Jerseys.Asics_List);
                LicensedJersey_comboBox.Text = Jerseys.Get_Asics_Jerseys(LicJersey);
                LicensedJersey_comboBox.SelectedIndex = 1;
            }
            else if (index == 2)
            {
                LicensedJersey_comboBox.Items.AddRange(Jerseys.Xblades_List);
                LicensedJersey_comboBox.Text = Jerseys.Get_Xblades_Jerseys(LicJersey);
                LicensedJersey_comboBox.SelectedIndex = 1;
            }
            else if (index == 3)
            {
                LicensedJersey_comboBox.Items.AddRange(Jerseys.Canterbury_List);
                LicensedJersey_comboBox.Text = Jerseys.Get_Canterbury_Jerseys(LicJersey);
                LicensedJersey_comboBox.SelectedIndex = 1;
            }
            else if (index == 4)
            {
                LicensedJersey_comboBox.Items.AddRange(Jerseys.ClassicSports_List);
                LicensedJersey_comboBox.Text = Jerseys.Get_ClassicSports_Jerseys(LicJersey);
                LicensedJersey_comboBox.SelectedIndex = 1;
            }
            else if (index == 5)
            {
                LicensedJersey_comboBox.Items.AddRange(Jerseys.ClassicCollar_List);
                LicensedJersey_comboBox.Text = Jerseys.Get_ClassicCollar_Jerseys(LicJersey);
                LicensedJersey_comboBox.SelectedIndex = 1;
            }
            else if (index == 6)
            {
                LicensedJersey_comboBox.Items.AddRange(Jerseys.Errea_List);
                LicensedJersey_comboBox.Text = Jerseys.Get_Errea_Jerseys(LicJersey);
                LicensedJersey_comboBox.SelectedIndex = 1;
            }
            else if (index == 7)
            {
                LicensedJersey_comboBox.Items.AddRange(Jerseys.FemaleWC_List);
                LicensedJersey_comboBox.Text = Jerseys.Get_FemaleWC_Jerseys(LicJersey);
                LicensedJersey_comboBox.SelectedIndex = 1;
            }

            if (LicJersey == 0)
                LicensedJersey_comboBox.SelectedIndex = 0;
            */
        }

        private void JerseyAmount_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            /*
            JerseySelection_comboBox.Items.Clear();

            for (int i = 0; i < JerseyAmount_numericUpDown.Value; i++)
            {
                int index = i + 1;
                JerseySelection_comboBox.Items.Add("Jersey " + index.ToString());
            }

            JerseySelection_comboBox.SelectedIndex = 0;
            */
        }

        private void JerseyNameColour_button_Click(object sender, EventArgs e)
        {
            team_colorDialog.Color = JerseyNameColour_button.BackColor;

            if (team_colorDialog.ShowDialog() == DialogResult.OK)
                JerseyNameColour_button.BackColor = Color.FromArgb(team_colorDialog.Color.ToArgb());

            team_colorDialog.Dispose();
        }

        private void JerseyNumberColour_button_Click(object sender, EventArgs e)
        {
            team_colorDialog.Color = JerseyNumberColour_button.BackColor;

            if (team_colorDialog.ShowDialog() == DialogResult.OK)
                JerseyNumberColour_button.BackColor = Color.FromArgb(team_colorDialog.Color.ToArgb());

            team_colorDialog.Dispose();
        }

        private void KeylineColour_button_Click(object sender, EventArgs e)
        {
            team_colorDialog.Color = PrimaryKeylineColour_button.BackColor;

            if (team_colorDialog.ShowDialog() == DialogResult.OK)
                PrimaryKeylineColour_button.BackColor = Color.FromArgb(team_colorDialog.Color.ToArgb());

            team_colorDialog.Dispose();
        }

        private void Logo_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (File.Exists(Global.currentPath + @"\Logos\" + StringArrays.LogosPNG[Logo_comboBox.SelectedIndex]))
            {
                largeLogo_pictureBox.ImageLocation = Global.currentPath + @"\Logos\" + StringArrays.LogosPNG[Logo_comboBox.SelectedIndex];
                smallLogo_pictureBox.ImageLocation = Global.currentPath + @"\Logos\" + StringArrays.LogosPNG[Logo_comboBox.SelectedIndex];
            }
        }

        private void PrimaryColour_button_Click(object sender, EventArgs e)
        {
            team_colorDialog.Color = PrimaryColour_button.BackColor;

            if (team_colorDialog.ShowDialog() == DialogResult.OK)
            {
                PrimaryColour_button.BackColor = Color.FromArgb(team_colorDialog.Color.ToArgb());
            }
            team_colorDialog.Dispose();
        }

        private void SecondaryColour_button_Click(object sender, EventArgs e)
        {
            team_colorDialog.Color = SecondaryColour_button.BackColor;

            if (team_colorDialog.ShowDialog() == DialogResult.OK)
            {
                SecondaryColour_button.BackColor = Color.FromArgb(team_colorDialog.Color.ToArgb());
            }
            team_colorDialog.Dispose();
        }

        private void HudTextColour_button_Click(object sender, EventArgs e)
        {
            team_colorDialog.Color = HudTextColour_button.BackColor;

            if (team_colorDialog.ShowDialog() == DialogResult.OK)
            {
                HudTextColour_button.BackColor = Color.FromArgb(team_colorDialog.Color.ToArgb());
            }
            team_colorDialog.Dispose();
        }

        private void Team_Save_Changers_button_Click(object sender, EventArgs e)
        {
            Global.team[Team_Index].id = Convert.ToInt32(TeamID_textBox.Text);

            Global.team[Team_Index].teamEnabled = isTeamEnabled_checkBox.Checked;

            Global.team[Team_Index].isClubType = true;

            if (TeamType_comboBox.SelectedIndex != 0)
                Global.team[Team_Index].clubType = Convert.ToInt32(TeamType_comboBox.SelectedIndex);
            else
                Global.team[Team_Index].clubType = 0;

            Global.team[Team_Index].affiliations = Affiliations_comboBox.SelectedIndex;

            Global.team[Team_Index].fullNameSize = Convert.ToByte(Fullname_textBox.Text.Length);
            Global.team[Team_Index].fullName = Fullname_textBox.Text;

            Global.team[Team_Index].shortNameSize = Convert.ToByte(shortName_textBox.Text.Length);
            Global.team[Team_Index].shortName = shortName_textBox.Text;

            Global.team[Team_Index].nicknameSize = Convert.ToByte(nickname_textBox.Text.Length);
            Global.team[Team_Index].nickname = nickname_textBox.Text;

            Global.team[Team_Index].hudNameSize = Convert.ToByte(hudName_textBox.Text.Length);
            Global.team[Team_Index].hudName = hudName_textBox.Text;

            Global.team[Team_Index].shirtNameSize = Convert.ToByte(shirtName_textBox.Text.Length);
            Global.team[Team_Index].shirtName = hudName_textBox.Text;

            Global.team[Team_Index].isWorldCupTeam = isWorldCup_checkBox.Checked;
            Global.team[Team_Index].WorldCupTeam = isWorldCup_checkBox.Checked;

            Global.team[Team_Index].primaryColour.r = Convert.ToByte(PrimaryColour_button.BackColor.R);
            Global.team[Team_Index].primaryColour.g = Convert.ToByte(PrimaryColour_button.BackColor.G);
            Global.team[Team_Index].primaryColour.b = Convert.ToByte(PrimaryColour_button.BackColor.B);

            Global.team[Team_Index].secondaryColour.r = Convert.ToByte(SecondaryColour_button.BackColor.R);
            Global.team[Team_Index].secondaryColour.g = Convert.ToByte(SecondaryColour_button.BackColor.G);
            Global.team[Team_Index].secondaryColour.b = Convert.ToByte(SecondaryColour_button.BackColor.B);

            Global.team[Team_Index].hudTextColour.r = Convert.ToByte(HudTextColour_button.BackColor.R);
            Global.team[Team_Index].hudTextColour.g = Convert.ToByte(HudTextColour_button.BackColor.G);
            Global.team[Team_Index].hudTextColour.b = Convert.ToByte(HudTextColour_button.BackColor.B);

            Global.team[Team_Index].logoSize = Convert.ToByte(Logo_comboBox.Text.Length);
            Global.team[Team_Index].logo = Logo_comboBox.Text;

            Global.team[Team_Index].wcLogoSize = Convert.ToByte(Logo_comboBox.Text.Length);
            Global.team[Team_Index].wcLogo = Logo_comboBox.Text;

            Global.team[Team_Index].isCommentaryTeamHash = true;

            if (commentaryTeamHash != null)
            {
                uint commTeamHash = CommentaryHashes.SetHashes(CommentaryTeamHash_comboBox.Text.ToLower(), commentaryTeamHash);
                Global.team[Team_Index].commentaryTeamHash = commTeamHash;
            }

            int StadiumAmount = Convert.ToInt32(StadiumAmount_numericUpDown.Value);
            Global.team[Team_Index].stadiumAmount = StadiumAmount;

            if (StadiumType_comboBox.SelectedIndex < StadiumAmount)
            {
                Global.team[Team_Index].stadium[StadiumType_comboBox.SelectedIndex].isId = true;
                Global.team[Team_Index].stadium[StadiumType_comboBox.SelectedIndex].id = Stadium_comboBox.SelectedIndex + 5;

                if (CustomName_checkBox.Checked)
                {
                    Global.team[Team_Index].stadium[StadiumType_comboBox.SelectedIndex].isCustomName = true;
                    Global.team[Team_Index].stadium[StadiumType_comboBox.SelectedIndex].isWantCustomName = true;
                    Global.team[Team_Index].stadium[StadiumType_comboBox.SelectedIndex].wantCustomName = true;
                    Global.team[Team_Index].stadium[StadiumType_comboBox.SelectedIndex].customNameSize = Convert.ToByte(CustomName_textBox.Text.Length);
                    Global.team[Team_Index].stadium[StadiumType_comboBox.SelectedIndex].customName = CustomName_textBox.Text;
                }
                else
                {
                    Global.team[Team_Index].stadium[StadiumType_comboBox.SelectedIndex].isCustomName = false;
                    Global.team[Team_Index].stadium[StadiumType_comboBox.SelectedIndex].isWantCustomName = false;
                    Global.team[Team_Index].stadium[StadiumType_comboBox.SelectedIndex].wantCustomName = false;
                    Global.team[Team_Index].stadium[StadiumType_comboBox.SelectedIndex].customNameSize = 0;
                    Global.team[Team_Index].stadium[StadiumType_comboBox.SelectedIndex].customName = string.Empty;
                }

                Global.team[Team_Index].stadium[StadiumType_comboBox.SelectedIndex].isStadiumIsOnDisk = true;
                Global.team[Team_Index].stadium[StadiumType_comboBox.SelectedIndex].StadiumIsOnDisk = true;
            }
            else
            {
                Global.team[Team_Index].finalStadium.isId = true;
                Global.team[Team_Index].finalStadium.id = Stadium_comboBox.SelectedIndex + 5;

                if (CustomName_checkBox.Checked)
                {
                    Global.team[Team_Index].finalStadium.isCustomName = true;
                    Global.team[Team_Index].finalStadium.isWantCustomName = true;
                    Global.team[Team_Index].finalStadium.wantCustomName = true;
                    Global.team[Team_Index].finalStadium.customNameSize = Convert.ToByte(CustomName_textBox.Text.Length);
                    Global.team[Team_Index].finalStadium.customName = CustomName_textBox.Text;
                }
                else
                {
                    Global.team[Team_Index].finalStadium.isCustomName = false;
                    Global.team[Team_Index].finalStadium.isWantCustomName = false;
                    Global.team[Team_Index].finalStadium.wantCustomName = false;
                    Global.team[Team_Index].finalStadium.customNameSize = 0;
                    Global.team[Team_Index].finalStadium.customName = string.Empty;
                }
            }

            /*
            int Manufacture = JerseyManufacture_comboBox.SelectedIndex;

            if (Manufacture == 0)
            {
                Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].manufactureId = 0;
                Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].licensedId = Convert.ToInt16(Jerseys.Set_ISC_Jersey(LicensedJersey_comboBox.SelectedIndex - 1));
            }
            else if (Manufacture == 1)
            {
                Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].manufactureId = 2;
                Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].licensedId = Convert.ToInt16(Jerseys.Set_Asics_Jersey(LicensedJersey_comboBox.SelectedIndex - 1));
            }
            else if (Manufacture == 2)
            {
                Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].manufactureId = 3;
                Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].licensedId = Convert.ToInt16(Jerseys.Set_Xblades_Jersey(LicensedJersey_comboBox.SelectedIndex - 1));
            }
            else if (Manufacture == 3)
            {
                Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].manufactureId = 4;
                Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].licensedId = Convert.ToInt16(Jerseys.Set_Canterbury_Jersey(LicensedJersey_comboBox.SelectedIndex - 1));
            }
            else if (Manufacture == 4)
            {
                Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].manufactureId = 6;
                Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].licensedId = Convert.ToInt16(Jerseys.Set_ClassicSports_Jersey(LicensedJersey_comboBox.SelectedIndex - 1));
            }
            else if (Manufacture == 5)
            {
                Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].manufactureId = 7;
                Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].licensedId = Convert.ToInt16(Jerseys.Set_ClassicCollar_Jersey(LicensedJersey_comboBox.SelectedIndex - 1));
            }
            else if (Manufacture == 6)
            {
                Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].manufactureId = 8;
                Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].licensedId = Convert.ToInt16(Jerseys.Set_Errea_Jersey(LicensedJersey_comboBox.SelectedIndex - 1));
            }
            else if (Manufacture == 7)
            {
                Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].manufactureId = 14;
                Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].licensedId = Convert.ToInt16(Jerseys.Set_FemaleWC_Jersey(LicensedJersey_comboBox.SelectedIndex - 1));
            }

            Global.team[Team_Index].jerseyAmount = Convert.ToByte(JerseyAmount_numericUpDown.Value);
            Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].name = JerseyName_textBox.Text;

            Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].showName = JerseyNameEnabled_checkBox.Checked;
            Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].nameFont = Convert.ToByte(JerseyNameFont_numericUpDown.Value - 1);

            Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].nameColour.r = Convert.ToByte(JerseyNameColour_button.BackColor.R);
            Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].nameColour.g = Convert.ToByte(JerseyNameColour_button.BackColor.G);
            Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].nameColour.b = Convert.ToByte(JerseyNameColour_button.BackColor.B);

            Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].showNumber = JerseyNumberEnabled_checkBox.Checked;
            Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].numberFont = Convert.ToByte(JerseyNumberFont_numericUpDown.Value - 1);
            Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].showingLeadingZero = ShowLeadingZero_Enabled_checkBox.Checked;

            Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].numberColour.r = Convert.ToByte(JerseyNumberColour_button.BackColor.R);
            Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].numberColour.g = Convert.ToByte(JerseyNumberColour_button.BackColor.G);
            Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].numberColour.b = Convert.ToByte(JerseyNumberColour_button.BackColor.B);

            Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].keylineSize = Convert.ToByte(KeylineSize_numericUpDown.Value);
            Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].keylineOffset = Convert.ToByte(KeylineOffset_numericUpDown.Value);

            Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].keylineColour.r = Convert.ToByte(KeylineColour_button.BackColor.R);
            Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].keylineColour.g = Convert.ToByte(KeylineColour_button.BackColor.G);
            Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].keylineColour.b = Convert.ToByte(KeylineColour_button.BackColor.B);

            Global.team[Team_Index].jerseys[JerseySelection_comboBox.SelectedIndex].showInternalKeyline = InternalKeyline_checkBox.Checked;
            */

            Global.team[Team_Index].playerAmount = Convert.ToByte(playersRoster_dataGridView.Rows.Count);

            if (playersRoster_dataGridView.Rows.Count != 0)
            {
                for (int i = 0; i < Global.MAX_PLAYERS_PER_TEAM; i++)
                {
                    Global.team[Team_Index].players[i].isPlayerId = false;
                }

                for (int i = 0; i < playersRoster_dataGridView.Rows.Count; i++)
                {
                    Global.team[Team_Index].players[i].isPlayerId = true;
                    Global.team[Team_Index].players[i].playerId = Convert.ToInt32(playersRoster_dataGridView.Rows[i].Cells[1].Value);
                }

                for (int i = 0; i < Global.MIN_PLAYERS_PER_TEAM; i++)
                {
                    Global.team[Team_Index].unionLineups[i].isUnionLineupId = false;
                }

                for (int i = 0; i < lineup_dataGridView.Rows.Count; i++)
                {
                    Global.team[Team_Index].unionLineups[i].isUnionLineupId = true;
                    //Global.team[Team_Index].unionLineups[i].shirtNumber = Convert.ToByte(unionLineup_dataGridView.Rows[i].Cells[1].Value);
                    Global.team[Team_Index].unionLineups[i].unionLineupId = Convert.ToInt32(lineup_dataGridView.Rows[i].Cells[1].Value);
                }

                for (int i = 0; i < 4; i++)
                {
                    Global.team[Team_Index].leagueRoles[i].isLeagueRoleId = false;
                }

                for (int i = 0; i < AssignRoles_dataGridView.Rows.Count; i++)
                {
                    Global.team[Team_Index].leagueRoles[i].isLeagueRoleId = true;
                    Global.team[Team_Index].leagueRoles[i].leagueRoleId = Convert.ToInt32(AssignRoles_dataGridView.Rows[i].Cells[1].Value);
                }
            }

            RefreshList.Update_TeamList(Teams_dgv);

            int TeamRating = 0;

            for (int i = 0; i < Global.MIN_PLAYERS_PER_TEAM; i++)
            {
                TeamRating = TeamRating + Rating.PlayerRating(SearchID.PlayersIndex(Global.team[Team_Index].unionLineups[i].unionLineupId));
            }

            TeamRating = TeamRating / Global.MIN_PLAYERS_PER_TEAM;

            team_name_label.Text = Fullname_textBox.Text + " - " + TeamRating.ToString();

            MessageBox.Show("Changers have been saved to this team", "Save Changers Is Complete :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PlayersRoster()
        {
            try
            {
                PlayersRoster_dt = new DataTable();

                PlayersRoster_dt.Columns.Add("Index", typeof(int));
                PlayersRoster_dt.Columns.Add("Player Id", typeof(int));
                PlayersRoster_dt.Columns.Add("First Name", typeof(string));
                PlayersRoster_dt.Columns.Add("Last Name", typeof(string));
                PlayersRoster_dt.Columns.Add("Primary Role", typeof(string));
                PlayersRoster_dt.Columns.Add("Secondary Role", typeof(string));
                PlayersRoster_dt.Columns.Add("Tertiary Role", typeof(string));

                for (int i = 0; i < Global.team[Team_Index].playerAmount; i++)
                {
                    int selectedIndex = SearchID.PlayersIndex(Global.team[Team_Index].players[i].playerId);
                    PlayersRoster_dt.Rows.Add();
                    PlayersRoster_dt.Rows[PlayersRoster_dt.Rows.Count - 1]["Index"] = i;
                    PlayersRoster_dt.Rows[PlayersRoster_dt.Rows.Count - 1]["Player Id"] = Global.player[selectedIndex].id;
                    PlayersRoster_dt.Rows[PlayersRoster_dt.Rows.Count - 1]["First Name"] = Global.player[selectedIndex].firstName;
                    PlayersRoster_dt.Rows[PlayersRoster_dt.Rows.Count - 1]["Last Name"] = Global.player[selectedIndex].lastName;
                    PlayersRoster_dt.Rows[PlayersRoster_dt.Rows.Count - 1]["Primary Role"] = StringArrays.ShortRoles[Global.player[selectedIndex].primaryRole];
                    PlayersRoster_dt.Rows[PlayersRoster_dt.Rows.Count - 1]["Secondary Role"] = StringArrays.ShortRoles[Global.player[selectedIndex].secondaryRole];
                    PlayersRoster_dt.Rows[PlayersRoster_dt.Rows.Count - 1]["Tertiary Role"] = StringArrays.ShortRoles[Global.player[selectedIndex].tertiaryRole];
                }

                playersRoster_dataGridView.DataSource = PlayersRoster_dt;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Lineup()
        {
            DataTable? dt = null;

            try
            {
                dt = new DataTable();

                dt.Columns.Add("Position", typeof(string));
                dt.Columns.Add("Player Id", typeof(int));
                dt.Columns.Add("First Name", typeof(string));
                dt.Columns.Add("Last Name", typeof(string));
                dt.Columns.Add("Primary Role", typeof(string));
                dt.Columns.Add("Secondary Role", typeof(string));
                dt.Columns.Add("Tertiary Role", typeof(string));

                if (Global.team[Team_Index].playerAmount > 22)
                {
                    for (int i = 0; i < Global.MIN_PLAYERS_PER_TEAM; i++)
                    {
                        int selectedIndex = SearchID.PlayersIndex(Global.team[Team_Index].unionLineups[i].unionLineupId);
                        dt.Rows.Add();
                        dt.Rows[dt.Rows.Count - 1]["Position"] = StringArrays.Positions[i];
                        dt.Rows[dt.Rows.Count - 1]["Player Id"] = Global.player[selectedIndex].id;
                        dt.Rows[dt.Rows.Count - 1]["First Name"] = Global.player[selectedIndex].firstName;
                        dt.Rows[dt.Rows.Count - 1]["Last Name"] = Global.player[selectedIndex].lastName;
                        dt.Rows[dt.Rows.Count - 1]["Primary Role"] = StringArrays.ShortRoles[Global.player[selectedIndex].primaryRole];
                        dt.Rows[dt.Rows.Count - 1]["Secondary Role"] = StringArrays.ShortRoles[Global.player[selectedIndex].secondaryRole];
                        dt.Rows[dt.Rows.Count - 1]["Tertiary Role"] = StringArrays.ShortRoles[Global.player[selectedIndex].tertiaryRole];
                    }
                }

                lineup_dataGridView.DataSource = dt;

                for (int i = 0; i < lineup_dataGridView.Columns.Count; i++)
                {
                    lineup_dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Roles()
        {
            DataTable? dt = null;
            string[] PlyRoles = ["Captain", "GoalKicker", "PlayMaker1", "PlayMaker2"];

            try
            {
                dt = new DataTable();

                dt.Columns.Add("Roles", typeof(string));
                dt.Columns.Add("Player Id", typeof(int));
                dt.Columns.Add("First Name", typeof(string));
                dt.Columns.Add("Last Name", typeof(string));
                dt.Columns.Add("Primary Role", typeof(string));
                dt.Columns.Add("Secondary Role", typeof(string));
                dt.Columns.Add("Tertiary Role", typeof(string));

                for (int i = 0; i < 4; i++)
                {
                    int selectedIndex = SearchID.PlayersIndex(Global.team[Team_Index].unionRoles[i].unionRoleId);
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["Roles"] = PlyRoles[i];
                    dt.Rows[dt.Rows.Count - 1]["Player Id"] = Global.player[selectedIndex].id;
                    dt.Rows[dt.Rows.Count - 1]["First Name"] = Global.player[selectedIndex].firstName;
                    dt.Rows[dt.Rows.Count - 1]["Last Name"] = Global.player[selectedIndex].lastName;
                    dt.Rows[dt.Rows.Count - 1]["Primary Role"] = StringArrays.ShortRoles[Global.player[selectedIndex].primaryRole];
                    dt.Rows[dt.Rows.Count - 1]["Secondary Role"] = StringArrays.ShortRoles[Global.player[selectedIndex].secondaryRole];
                    dt.Rows[dt.Rows.Count - 1]["Tertiary Role"] = StringArrays.ShortRoles[Global.player[selectedIndex].tertiaryRole];
                }

                AssignRoles_dataGridView.DataSource = dt;

                for (int i = 0; i < AssignRoles_dataGridView.Columns.Count; i++)
                {
                    AssignRoles_dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void PlayersRoster_dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            playersRoster_dataGridView.BeginEdit(false);
            playersRoster_dataGridView.NotifyCurrentCellDirty(false);
            int rowIndex = playersRoster_dataGridView.CurrentCell.RowIndex;

            if (playersRoster_dataGridView.Rows.Count != 0)
            {
                if (playersRoster_dataGridView.Rows[rowIndex].Cells[1].Value != DBNull.Value)
                {
                    Global.team[Team_Index].players[rowIndex].playerId = Convert.ToInt32(playersRoster_dataGridView.Rows[rowIndex].Cells[1].Value);
                }
            }

            playersRoster_dataGridView.EndEdit();
            PlayersRoster();
        }

        private void Lineup_dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            lineup_dataGridView.BeginEdit(false);
            lineup_dataGridView.NotifyCurrentCellDirty(false);
            int rowIndex = lineup_dataGridView.CurrentCell.RowIndex;

            if (lineup_dataGridView.Rows.Count != 0)
            {
                if (lineup_dataGridView.Rows[rowIndex].Cells[2].Value != DBNull.Value)
                    Global.team[Team_Index].unionLineups[rowIndex].unionLineupId = Convert.ToInt32(lineup_dataGridView.Rows[rowIndex].Cells[1].Value);
            }

            lineup_dataGridView.EndEdit();
            Lineup();
        }

        private void AssignRoles_dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            AssignRoles_dataGridView.BeginEdit(false);
            AssignRoles_dataGridView.NotifyCurrentCellDirty(false);
            int rowIndex = AssignRoles_dataGridView.CurrentCell.RowIndex;

            if (AssignRoles_dataGridView.Rows.Count != 0)
            {
                if (AssignRoles_dataGridView.Rows[rowIndex].Cells[1].Value != DBNull.Value)
                    Global.team[Team_Index].unionRoles[rowIndex].unionRoleId = Convert.ToInt32(AssignRoles_dataGridView.Rows[rowIndex].Cells[1].Value);
            }

            AssignRoles_dataGridView.EndEdit();
            Roles();
        }

        private void PlayersRoster_dataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (playersRoster_dataGridView.Rows.Count > 0)
            {
                int rowIndex = playersRoster_dataGridView.CurrentCell.RowIndex;

                int playerID = Convert.ToInt32(playersRoster_dataGridView.Rows[rowIndex].Cells[1].Value);
                Global.player_index = SearchID.PlayersIndex(playerID);

                Player_Editor form = new(Players_dgv);
                form.Show();
            }
        }

        private void Lineup_dataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lineup_dataGridView.Rows.Count > 0)
            {
                int rowIndex = lineup_dataGridView.CurrentCell.RowIndex;

                int playerID = Convert.ToInt32(lineup_dataGridView.Rows[rowIndex].Cells[1].Value);
                Global.player_index = SearchID.PlayersIndex(playerID);

                Player_Editor form = new(Players_dgv);
                form.Show();
            }
        }

        private void AssignRoles_dataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (AssignRoles_dataGridView.Rows.Count > 0)
            {
                int rowIndex = AssignRoles_dataGridView.CurrentCell.RowIndex;

                int playerID = Convert.ToInt32(AssignRoles_dataGridView.Rows[rowIndex].Cells[1].Value);
                Global.player_index = SearchID.PlayersIndex(playerID);

                Player_Editor form = new(Players_dgv);
                form.Show();
            }
        }

        private void PlayersRoster_dataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                PlayersRoster_contextMenuStrip.Show(Cursor.Position);
        }

        private void Lineup_dataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                Lineup_contextMenuStrip.Show(Cursor.Position);
        }

        private void AssignRoles_dataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                Roles_contextMenuStrip.Show(Cursor.Position);
        }

        private void TeamPlayerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (playersRoster_dataGridView.Rows.Count != 0)
            {
                Team_Player_List form = new(playersRoster_dataGridView, Team_Index);
                bool IsOpen = false;

                foreach (Form f in Application.OpenForms)
                {
                    if (f.Text == "Team Player List")
                    {
                        IsOpen = true;
                        f.Focus();
                        break;
                    }
                }

                if (!IsOpen)
                {
                    form.Show();
                }
            }
        }

        private void TeamLineupList_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lineup_dataGridView.Rows.Count != 0)
            {
                Team_Lineup_List form = new(lineup_dataGridView, Team_Index);
                bool IsOpen = false;

                foreach (Form f in Application.OpenForms)
                {
                    if (f.Text == "Team Lineup List")
                    {
                        IsOpen = true;
                        f.Focus();
                        break;
                    }
                }

                if (!IsOpen)
                {
                    form.Show();
                }
            }
        }

        private void RolesList_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AssignRoles_dataGridView.Rows.Count != 0)
            {
                Team_Roles_List form = new(AssignRoles_dataGridView, Team_Index);
                bool IsOpen = false;

                foreach (Form f in Application.OpenForms)
                {
                    if (f.Text == "Team Roles List")
                    {
                        IsOpen = true;
                        f.Focus();
                        break;
                    }
                }

                if (!IsOpen)
                {
                    form.Show();
                }
            }
        }

        private void Team_Editor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Insert))
            {
                addPlayer();
            }

            if (ModifierKeys == Keys.Control && e.KeyCode == Keys.Z)
            {
                sortAZ();
            }

            if (ModifierKeys == Keys.Control && e.KeyCode == Keys.P)
            {
                if (playersRoster_dataGridView.Rows.Count != 0)
                {
                    Team_Player_List form = new(playersRoster_dataGridView, Team_Index);
                    bool IsOpen = false;

                    foreach (Form f in Application.OpenForms)
                    {
                        if (f.Text == "Player List")
                        {
                            IsOpen = true;
                            f.Focus();
                            break;
                        }
                    }

                    if (!IsOpen)
                    {
                        form.Show();
                    }
                }
            }

            if (ModifierKeys == Keys.Control && e.KeyCode == Keys.L)
            {
                if (lineup_dataGridView.Rows.Count != 0)
                {
                    Team_Lineup_List form = new(lineup_dataGridView, Team_Index);
                    bool IsOpen = false;

                    foreach (Form f in Application.OpenForms)
                    {
                        if (f.Text == "Team Lineup List")
                        {
                            IsOpen = true;
                            f.Focus();
                            break;
                        }
                    }

                    if (!IsOpen)
                    {
                        form.Show();
                    }
                }
            }

            if (ModifierKeys == Keys.Control && e.KeyCode == Keys.R)
            {
                if (AssignRoles_dataGridView.Rows.Count != 0)
                {
                    Team_Roles_List form = new(AssignRoles_dataGridView, Team_Index);
                    bool IsOpen = false;

                    foreach (Form f in Application.OpenForms)
                    {
                        if (f.Text == "Team Roles List")
                        {
                            IsOpen = true;
                            f.Focus();
                            break;
                        }
                    }

                    if (!IsOpen)
                    {
                        form.Show();
                    }
                }
            }
        }

        private void sortAZ()
        {
            if (playersRoster_dataGridView.Rows.Count != 0)
            {
                PlayersRoster();

                DataView dv = PlayersRoster_dt.DefaultView;
                dv.Sort = "Last Name";
                PlayersRoster_dt = dv.ToTable();

                if (playersRoster_dataGridView.Rows.Count != 0)
                {
                    for (int i = 0; i < playersRoster_dataGridView.Rows.Count; i++)
                    {
                        Global.team[Team_Index].players[i].playerId = Convert.ToInt32(playersRoster_dataGridView.Rows[i].Cells[1].Value);
                    }
                }

                PlayersRoster();
            }
        }

        private void sortAZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sortAZ();
        }

        private void addPlayer()
        {
            if (playersRoster_dataGridView.Rows.Count != Global.MAX_PLAYERS_PER_TEAM)
            {
                int Count = playersRoster_dataGridView.Rows.Count;

                Global.team[Team_Index].playerAmount = Convert.ToByte(Count + 1);
                TeamPlayerAmount_textBox.Text = (Count + 1).ToString();
                Global.team[Team_Index].players[Count].isPlayerId = true;
                Global.team[Team_Index].players[Count].playerId = 1;
                PlayersRoster();

                playersRoster_dataGridView.Rows[Count].Selected = true;
                playersRoster_dataGridView.Focus();
                playersRoster_dataGridView.CurrentCell = playersRoster_dataGridView.Rows[Count].Cells[0];
                playersRoster_dataGridView.Rows[Count].Visible = true;
            }
            else
            {
                MessageBox.Show("You have reached the maximum 64 players", "Team Players Maxed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void addPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addPlayer();
        }

        private void deletePlayer(bool UserDeleted)
        {
            if (playersRoster_dataGridView.Rows.Count != 0)
            {
                int RowIndex = playersRoster_dataGridView.CurrentCell.RowIndex;

                if (UserDeleted)
                    RowIndex = playersRoster_dataGridView.CurrentCell.RowIndex + 1;

                int TeamPlayerAmount = Global.team[Team_Index].playerAmount - 1;

                int[] TeamPlayers = new int[Global.MAX_PLAYERS_PER_TEAM];

                for (int i = 0, j = 0; i < TeamPlayerAmount; i++, j++)
                {
                    if (i == RowIndex)
                    {
                        j++;
                    }

                    TeamPlayers[i] = Global.team[Team_Index].players[j].playerId;
                }

                for (int i = 0; i < Global.MAX_PLAYERS_PER_TEAM; i++)
                {
                    Global.team[Team_Index].players[i].playerId = TeamPlayers[i];
                    Global.team[Team_Index].players[i].isPlayerId = false;
                }

                for (int i = 0; i < TeamPlayerAmount; i++)
                {
                    Global.team[Team_Index].players[i].isPlayerId = true;
                }

                Global.team[Team_Index].playerAmount = Convert.ToByte(TeamPlayerAmount);
                TeamPlayerAmount_textBox.Text = TeamPlayerAmount.ToString();

                PlayersRoster();
            }
            else
            {
                TeamPlayerAmount_textBox.Text = "0";
            }
        }

        private void players_dataGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            deletePlayer(true);
        }

        private void deletePlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deletePlayer(false);
        }

        public void JerseyImport(int jersey_index, int team_index)
        {
            Reader? br = null;

            try
            {
                string folder = Path.Combine(Global.currentPath, "Exported_Teams");

                if (Directory.Exists(folder))
                    Jersey_ofd.InitialDirectory = folder;

                if (Jersey_ofd.ShowDialog() == DialogResult.OK)
                {
                    string file = Jersey_ofd.FileName;
                    Jersey_ofd.Dispose();

                    br = new Reader(file, FileMode.Open, Endian.Little);

                    Global.team[team_index].jerseys[jersey_index].name = br.ReadNullTerminatedString();
                    br.ReadBytes(24 - Global.team[team_index].jerseys[jersey_index].name.Length, Endian.Little);

                    /*

                    Global.team[team_index].jerseys[jersey_index].padding1 = br.ReadUInt16(Endian.Little);
                    Global.team[team_index].jerseys[jersey_index].nameColour.g = br.ReadByte();
                    Global.team[team_index].jerseys[jersey_index].padding2 = br.ReadBytes(14, Endian.Little);
                    Global.team[team_index].jerseys[jersey_index].nameColour.r = br.ReadByte();
                    Global.team[team_index].jerseys[jersey_index].padding3 = br.ReadBytes(35, Endian.Little);
                    Global.team[team_index].jerseys[jersey_index].nameColour.b = br.ReadByte();
                    Global.team[team_index].jerseys[jersey_index].padding4 = br.ReadBytes(8, Endian.Little);
                    Global.team[team_index].jerseys[jersey_index].keylineColour.b = br.ReadByte();
                    Global.team[team_index].jerseys[jersey_index].padding5 = br.ReadBytes(57, Endian.Little);
                    Global.team[team_index].jerseys[jersey_index].showNumber = br.ReadBoolean();
                    Global.team[team_index].jerseys[jersey_index].padding6 = br.ReadUInt16(Endian.Little);
                    Global.team[team_index].jerseys[jersey_index].keylineColour.g = br.ReadByte();
                    Global.team[team_index].jerseys[jersey_index].padding7 = br.ReadBytes(5, Endian.Little);
                    Global.team[team_index].jerseys[jersey_index].showInternalKeyline = br.ReadBoolean();
                    Global.team[team_index].jerseys[jersey_index].padding8 = br.ReadBytes(61, Endian.Little);
                    Global.team[team_index].jerseys[jersey_index].numberColour.g = br.ReadByte();
                    Global.team[team_index].jerseys[jersey_index].padding9 = br.ReadBytes(53, Endian.Little);
                    Global.team[team_index].jerseys[jersey_index].numberColour.b = br.ReadByte();
                    Global.team[team_index].jerseys[jersey_index].padding10 = br.ReadBytes(42, Endian.Little);
                    //Global.team[team_index].jerseys[jersey_index].manufactureId = br.ReadByte();
                    Global.team[team_index].jerseys[jersey_index].padding11 = br.ReadBytes(19, Endian.Little);
                    Global.team[team_index].jerseys[jersey_index].licensedId = br.ReadInt16(Endian.Little);
                    Global.team[team_index].jerseys[jersey_index].padding12 = br.ReadBytes(39, Endian.Little);
                    Global.team[team_index].jerseys[jersey_index].keylineSize = br.ReadByte();
                    Global.team[team_index].jerseys[jersey_index].padding13 = br.ReadBytes(48, Endian.Little);
                    Global.team[team_index].jerseys[jersey_index].numberFont = br.ReadByte();
                    Global.team[team_index].jerseys[jersey_index].padding14 = br.ReadBytes(79, Endian.Little);
                    Global.team[team_index].jerseys[jersey_index].nameFont = br.ReadByte();
                    Global.team[team_index].jerseys[jersey_index].padding15 = br.ReadBytes(15, Endian.Little);
                    Global.team[team_index].jerseys[jersey_index].keylineOffset = br.ReadByte();
                    Global.team[team_index].jerseys[jersey_index].showingLeadingZero = br.ReadBoolean();
                    Global.team[team_index].jerseys[jersey_index].padding16 = br.ReadBytes(7, Endian.Little);
                    Global.team[team_index].jerseys[jersey_index].showName = br.ReadBoolean();
                    Global.team[team_index].jerseys[jersey_index].padding17 = br.ReadBytes(39, Endian.Little);
                    Global.team[team_index].jerseys[jersey_index].keylineColour.r = br.ReadByte();
                    Global.team[team_index].jerseys[jersey_index].padding18 = br.ReadBytes(9, Endian.Little);
                    Global.team[team_index].jerseys[jersey_index].numberColour.r = br.ReadByte();
                    Global.team[team_index].jerseys[jersey_index].padding19 = br.ReadBytes(65, Endian.Little);

                    */

                    MessageBox.Show("Team Jersey has finished importing", "Team Jersey Importing Is Complete :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

        private void ImportJersey_button_Click(object sender, EventArgs e)
        {
            JerseyImport(JerseySelection_comboBox.SelectedIndex, Team_Index);
            JerseySelection_comboBox_SelectedIndexChanged(null, null);
        }

        public void JerseyExport(int jersey_index, int team_index)
        {
            Writer? bw = null;

            try
            {
                string currentPath = (Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                string folder = Path.Combine(currentPath, "Exported_Teams");
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                string file = folder + @"\" + Global.team[team_index].fullName + " - " + Global.team[team_index].jerseys[jersey_index].name + ".jsy";

                bw = new Writer(file, FileMode.Create, Endian.Little);

                /*

                bw.Write((Global.team[team_index].jerseys[jersey_index].name + new string(default, 24)).Take(24).Select(ch => (byte)ch).ToArray(), Endian.Little);
                bw.WriteUInt8(0);

                bw.WriteUInt16(Global.team[team_index].jerseys[jersey_index].padding1, Endian.Little);
                bw.WriteUInt8(Global.team[team_index].jerseys[jersey_index].nameColour.g);
                bw.Write(Global.team[team_index].jerseys[jersey_index].padding2, Endian.Little);
                bw.WriteUInt8(Global.team[team_index].jerseys[jersey_index].nameColour.r);
                bw.Write(Global.team[team_index].jerseys[jersey_index].padding3, Endian.Little);
                bw.WriteUInt8(Global.team[team_index].jerseys[jersey_index].nameColour.b);
                bw.Write(Global.team[team_index].jerseys[jersey_index].padding4, Endian.Little);
                bw.WriteUInt8(Global.team[team_index].jerseys[jersey_index].keylineColour.b);
                bw.Write(Global.team[team_index].jerseys[jersey_index].padding5, Endian.Little);
                bw.WriteBool(Global.team[team_index].jerseys[jersey_index].showNumber);
                bw.WriteUInt16(Global.team[team_index].jerseys[jersey_index].padding6, Endian.Little);
                bw.WriteUInt8(Global.team[team_index].jerseys[jersey_index].keylineColour.g);
                bw.Write(Global.team[team_index].jerseys[jersey_index].padding7, Endian.Little);
                bw.WriteBool(Global.team[team_index].jerseys[jersey_index].showInternalKeyline);
                bw.Write(Global.team[team_index].jerseys[jersey_index].padding8, Endian.Little);
                bw.WriteUInt8(Global.team[team_index].jerseys[jersey_index].numberColour.g);
                bw.Write(Global.team[team_index].jerseys[jersey_index].padding9, Endian.Little);
                bw.WriteUInt8(Global.team[team_index].jerseys[jersey_index].numberColour.b);
                bw.Write(Global.team[team_index].jerseys[jersey_index].padding10, Endian.Little);
                //bw.WriteUInt8(Global.team[team_index].jerseys[jersey_index].manufactureId);
                bw.Write(Global.team[team_index].jerseys[jersey_index].padding11, Endian.Little);
                bw.WriteInt16(Global.team[team_index].jerseys[jersey_index].licensedId, Endian.Little);
                bw.Write(Global.team[team_index].jerseys[jersey_index].padding12, Endian.Little);
                bw.WriteUInt8(Global.team[team_index].jerseys[jersey_index].keylineSize);
                bw.Write(Global.team[team_index].jerseys[jersey_index].padding13, Endian.Little);
                bw.WriteUInt8(Global.team[team_index].jerseys[jersey_index].numberFont);
                bw.Write(Global.team[team_index].jerseys[jersey_index].padding14, Endian.Little);
                bw.WriteUInt8(Global.team[team_index].jerseys[jersey_index].nameFont);
                bw.Write(Global.team[team_index].jerseys[jersey_index].padding15, Endian.Little);
                bw.WriteUInt8(Global.team[team_index].jerseys[jersey_index].keylineOffset);
                bw.WriteBool(Global.team[team_index].jerseys[jersey_index].showingLeadingZero);
                bw.Write(Global.team[team_index].jerseys[jersey_index].padding16, Endian.Little);
                bw.WriteBool(Global.team[team_index].jerseys[jersey_index].showName);
                bw.Write(Global.team[team_index].jerseys[jersey_index].padding17, Endian.Little);
                bw.WriteUInt8(Global.team[team_index].jerseys[jersey_index].keylineColour.r);
                bw.Write(Global.team[team_index].jerseys[jersey_index].padding18, Endian.Little);
                bw.WriteUInt8(Global.team[team_index].jerseys[jersey_index].numberColour.r);
                bw.Write(Global.team[team_index].jerseys[jersey_index].padding19, Endian.Little);

                */

                MessageBox.Show("Team Jersey has finished exporting", "Team Jersey Exporting Is Complete :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void ExportJersey_button_Click(object sender, EventArgs e)
        {
            JerseyExport(JerseySelection_comboBox.SelectedIndex, Team_Index);
        }
    }
}