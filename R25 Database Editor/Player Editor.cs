namespace R25_Database_Editor
{
    public partial class Player_Editor : Form
    {
        private readonly DataGridView Players_dataGridView;

        public Player_Editor(DataGridView Players_dataGridView)
        {
            InitializeComponent();
            this.Players_dataGridView = Players_dataGridView;
        }

        private int Player_Index = 0;
        private Random? random = null;
        private Dialogue_Wildcardhash.WildcardHash[]? commentaryNameHash = null;

        private void Player_Editor_Load(object sender, EventArgs e)
        {
            PlayerIndex_textBox.Text = Global.player_index.ToString();
            Player_Index = Global.player_index;
            PlayerId_textBox.Text = Global.player[Player_Index].id.ToString();

            Enabled_checkBox.Checked = Global.player[Player_Index].playerEnabled;
            Licensed_checkBox.Checked = Global.player[Player_Index].licensed;

            FirstName_textBox.Text = Global.player[Player_Index].firstName;
            LastName_textBox.Text = Global.player[Player_Index].lastName;

            string commentaryDataPath = Global.currentPath + @"\commentary_data\";

            commentaryNameHash = CommentaryHashes.Read(commentaryDataPath + "dialogue_wildcardhash_surnames");

            string[] commNames = new string[commentaryNameHash.Length];

            for (int i = 0; i < commentaryNameHash.Length; i++)
            {
                commNames[i] = commentaryNameHash[i].name.ToTitleCase();
            }

            commentaryNameHash_comboBox.Items.AddRange(commNames);
            int commentaryIndex = CommentaryHashes.GetHashes(Global.player[Player_Index].commentaryNameHash, commentaryNameHash);

            if (commentaryIndex != -1)
                commentaryNameHash_comboBox.SelectedIndex = commentaryIndex;
            else
                commentaryNameHash_comboBox.SelectedIndex = 0;

            PlayerGender_textBox.Text = "Male";
            PlayerGenderImage_label.Image = Properties.Resources.Male;

            if (Global.player[Player_Index].gender == 1)
            {
                PlayerGender_textBox.Text = "Female";
                PlayerGenderImage_label.Image = Properties.Resources.Female;
            }

            Day_numericUpDown.Value = Global.player[Player_Index].dob.day;
            Month_numericUpDown.Value = Global.player[Player_Index].dob.month;
            Year_numericUpDown.Value = Global.player[Player_Index].dob.year;

            if (Global.player[Player_Index].jerseyNumber < 1 || Global.player[Player_Index].jerseyNumber > 99)
                JerseyNumber_numericUpDown.Value = 1;
            else
                JerseyNumber_numericUpDown.Value = Global.player[Player_Index].jerseyNumber;

            isWordCup_checkBox.Checked = Global.player[Player_Index].WorldCup;
            JerseyName_textBox.Text = Global.player[Player_Index].jerseyName;

            PrimaryRole_comboBox.Items.AddRange(StringArrays.UnionRoles);
            SecondaryRole_comboBox.Items.AddRange(StringArrays.UnionRoles);
            TertiaryRole_comboBox.Items.AddRange(StringArrays.UnionRoles);

            PrimaryRole_comboBox.Text = StringArrays.Roles[Global.player[Player_Index].primaryRole];
            SecondaryRole_comboBox.Text = StringArrays.Roles[Global.player[Player_Index].secondaryRole];
            TertiaryRole_comboBox.Text = StringArrays.Roles[Global.player[Player_Index].tertiaryRole];

            PreferredHand_comboBox.Items.AddRange(StringArrays.Chirality);
            PreferredFoot_comboBox.Items.AddRange(StringArrays.Chirality);

            PreferredHand_comboBox.SelectedIndex = Global.player[Player_Index].preferredHand;
            PreferredFoot_comboBox.SelectedIndex = Global.player[Player_Index].preferredFoot;

            RepresentativeCountry_comboBox.Items.AddRange(StringArrays.CountryOfBirth);
            CountryOfBirth_comboBox.Items.AddRange(StringArrays.CountryOfBirth);
            RepresentativeCountry_comboBox.SelectedIndex = Global.player[Player_Index].repCountry;
            CountryOfBirth_comboBox.SelectedIndex = Global.player[Player_Index].countryOfBirth;

            Height_numericUpDown.Value = Global.player[Player_Index].appearance.height;
            Weight_numericUpDown.Value = Global.player[Player_Index].appearance.weight;

            PhotogrammetryStatus_comboBox.SelectedIndex = Global.player[Player_Index].appearance.photogrammetryStatus;

            if (Global.player[Player_Index].isContractExpiry == false || Global.player[Player_Index].contractExpiry == 0)
                ContractExpiry_comboBox.SelectedIndex = 26;
            else
                ContractExpiry_comboBox.Text = Global.player[Player_Index].contractExpiry.ToString();

            // Attributes
            MovementProfile_comboBox.SelectedIndex = Global.player[Player_Index].attributes.movementProfile;
            Temperament_comboBox.SelectedIndex = Global.player[Player_Index].attributes.temperament;
            Fitness_numericUpDown.Value = Global.player[Player_Index].attributes.fitness;

            // Strength
            Strength_numericUpDown.Value = Global.player[Player_Index].skills.strengthSkills.strength;
            Rucking_numericUpDown.Value = Global.player[Player_Index].skills.strengthSkills.rucking;
            Scrummaging_numericUpDown.Value = Global.player[Player_Index].skills.strengthSkills.scrummaging;
            Tackling_numericUpDown.Value = Global.player[Player_Index].skills.strengthSkills.tackling;
            BreakTackle_numericUpDown.Value = Global.player[Player_Index].skills.strengthSkills.breakTackling;
            Fending_numericUpDown.Value = Global.player[Player_Index].skills.strengthSkills.fending;

            // Speed
            Agility_numericUpDown.Value = Global.player[Player_Index].skills.speedSkills.agility;
            Acceleration_numericUpDown.Value = Global.player[Player_Index].skills.speedSkills.acceleration;
            SprintSpeed_numericUpDown.Value = Global.player[Player_Index].skills.speedSkills.sprintSpeed;
            Balance_numericUpDown.Value = Global.player[Player_Index].skills.speedSkills.balance;
            Stamina_numericUpDown.Value = Global.player[Player_Index].skills.speedSkills.stamina;
            Evasion_numericUpDown.Value = Global.player[Player_Index].skills.speedSkills.evasion;

            // Kicking
            KickingAccuracy_numericUpDown.Value = Global.player[Player_Index].skills.kickingSkills.kickingAccuracy;
            KickingPower_numericUpDown.Value = Global.player[Player_Index].skills.kickingSkills.kickingPower;
            GoalKicking_numericUpDown.Value = Global.player[Player_Index].skills.kickingSkills.goalKicking;
            ToePoke_numericUpDown.Value = Global.player[Player_Index].skills.kickingSkills.toePoke;

            // Hands
            Passing_numericUpDown.Value = Global.player[Player_Index].skills.handsSkills.passing;
            AerialSkills_numericUpDown.Value = Global.player[Player_Index].skills.handsSkills.aerialSkills;
            Offload_numericUpDown.Value = Global.player[Player_Index].skills.handsSkills.offload;
            Jackal_numericUpDown.Value = Global.player[Player_Index].skills.handsSkills.jackal;
            Intercepting_numericUpDown.Value = Global.player[Player_Index].skills.handsSkills.intercepting;

            // Mentality
            Focus_numericUpDown.Value = Global.player[Player_Index].skills.mentalitySkills.focus;
            Leadership_numericUpDown.Value = Global.player[Player_Index].skills.mentalitySkills.leadership;
            Determination_numericUpDown.Value = Global.player[Player_Index].skills.mentalitySkills.determination;
            Discipline_numericUpDown.Value = Global.player[Player_Index].skills.mentalitySkills.discipline;

            ConversionStyle_comboBox.Items.AddRange(StringArrays.ConversionStyle);
            ConversionStyle_comboBox.SelectedIndex = Global.player[Player_Index].skills.kickingSkills.conversionStyle;

            UnionMatchEnabled_checkBox.Checked = Global.player[Player_Index].unionMatchStats.isStatisticsStats;

            if (UnionMatchEnabled_checkBox.Checked)
            {
                Tries_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.tries;
                TryAssists_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.tryAssists;
                FieldGoalAttempts_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.fieldGoalAttempts;
                TackleBreaks_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.tackleBreaks;
                PenaltyGoalAttempts_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.penaltyGoalAttempts;
                Runs_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.runs;
                BallStrips_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.ballStrips;
                FieldGoals_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.fieldGoals;
                MatchesPlayed_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.matchesPlayed;
                MatchesWon_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.matchesWon;
                MetresRun_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.metresRun;
                Interceptions_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.interceptions;
                FortyTwenties_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.fortyTwenties;
                InterceptedPasses_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.interceptedPasses;
                Fends_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.fends;
                Tackles_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.tackles;
                HandlingErrors_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.handlingErrors;
                Hitups_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.hitups;
                Conversions_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.conversions;
                MatchesDrawn_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.matchesDrawn;
                MissedTackles_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.missedTackles;
                PenaltiesConceded_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.penaltiesConceded;
                LineBreakAssists_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.lineBreakAssists;
                ConversionAttempts_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.conversionAttempts;
                OneOnOneTackles_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.oneOnOneTackles;
                MinutesPlayed_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.minutesPlayed;
                Passes_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.passes;
                KicksInPlay_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.kicksInPlay;
                KickMetresGained_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.kickMetresGained;
                LineBreaks_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.lineBreaks;
                Offloads_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.offloads;
                KnockOns_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.knockOns;
                PenaltyGoals_numericUpDown.Value = Global.player[Player_Index].unionMatchStats.penaltyGoals;
            }

            int playerRating = Rating.PlayerRating(Player_Index);
            player_name_label.Text = FirstName_textBox.Text + " " + LastName_textBox.Text + " - " + playerRating.ToString();

            if (playerRating >= 83)
                RandomizeStats_comboBox.SelectedIndex = 0;
            else if (playerRating <= 82 && playerRating >= 70)
                RandomizeStats_comboBox.SelectedIndex = 1;
            else if (playerRating <= 69)
                RandomizeStats_comboBox.SelectedIndex = 2;
        }

        private void Player_Save_Changers_button_Click(object sender, EventArgs e)
        {
            Global.player[Player_Index].playerEnabled = Enabled_checkBox.Checked;

            Global.player[Player_Index].id = Convert.ToInt32(PlayerId_textBox.Text);

            Global.player[Player_Index].firstNameSize = Convert.ToByte(FirstName_textBox.Text.Length);
            Global.player[Player_Index].firstName = FirstName_textBox.Text;

            Global.player[Player_Index].lastNameSize = Convert.ToByte(LastName_textBox.Text.Length);
            Global.player[Player_Index].lastName = LastName_textBox.Text;

            Global.player[Player_Index].isLicensed = true;
            Global.player[Player_Index].licensed = Licensed_checkBox.Checked;

            Global.player[Player_Index].jerseyNameSize = Convert.ToByte(JerseyName_textBox.Text.Length);
            Global.player[Player_Index].jerseyName = JerseyName_textBox.Text;

            Global.player[Player_Index].jerseyNumber = Convert.ToInt32(JerseyNumber_numericUpDown.Value);

            Global.player[Player_Index].dob.day = Convert.ToInt32(Day_numericUpDown.Value);
            Global.player[Player_Index].dob.month = Convert.ToInt32(Month_numericUpDown.Value);
            Global.player[Player_Index].dob.year = Convert.ToInt32(Year_numericUpDown.Value);

            Global.player[Player_Index].isAge = true;

            DateTime dateOfBirth = new DateTime(Convert.ToInt32(Year_numericUpDown.Value), Convert.ToInt32(Month_numericUpDown.Value), Convert.ToInt32(Day_numericUpDown.Value));

            DateTime today = DateTime.Today;
            int age = today.Year - dateOfBirth.Year;

            // Adjust age if the birthday has not yet occurred this year
            if (dateOfBirth.Date > today.AddYears(-age))
                age--;

            Global.player[Player_Index].age = age;

            Global.player[Player_Index].isCountryOfBirth = true;
            Global.player[Player_Index].countryOfBirth = CountryOfBirth_comboBox.SelectedIndex;

            Global.player[Player_Index].isRepCountry = true;
            Global.player[Player_Index].repCountry = RepresentativeCountry_comboBox.SelectedIndex;

            Global.player[Player_Index].isWorldCup = true;
            Global.player[Player_Index].WorldCup = isWordCup_checkBox.Checked;

            Global.player[Player_Index].isContractExpiry = true;

            if (ContractExpiry_comboBox.SelectedIndex != 26)
                Global.player[Player_Index].contractExpiry = Convert.ToInt32(ContractExpiry_comboBox.Text);
            else
                Global.player[Player_Index].contractExpiry = 0;

            Global.player[Player_Index].isPrimaryRole = true;
            Global.player[Player_Index].primaryRole = SearchID.RolesIndex(PrimaryRole_comboBox.Text);

            Global.player[Player_Index].isSecondaryRole = true;
            Global.player[Player_Index].secondaryRole = SearchID.RolesIndex(SecondaryRole_comboBox.Text);

            Global.player[Player_Index].isTertiaryRole = true;
            Global.player[Player_Index].tertiaryRole = SearchID.RolesIndex(TertiaryRole_comboBox.Text);

            Global.player[Player_Index].isCommentaryNameHash = true;

            if (commentaryNameHash != null)
            {
                uint commNameHash = CommentaryHashes.SetHashes(commentaryNameHash_comboBox.Text.ToLower(), commentaryNameHash);
                Global.player[Player_Index].commentaryNameHash = commNameHash;
            }

            Global.player[Player_Index].isPreferredHand = true;
            Global.player[Player_Index].preferredHand = Convert.ToByte(PreferredHand_comboBox.SelectedIndex);

            Global.player[Player_Index].isPreferredFoot = true;
            Global.player[Player_Index].preferredFoot = Convert.ToByte(PreferredFoot_comboBox.SelectedIndex);

            Global.player[Player_Index].appearance.height = Convert.ToInt32(Height_numericUpDown.Value);
            Global.player[Player_Index].appearance.weight = Convert.ToInt32(Weight_numericUpDown.Value);

            Global.player[Player_Index].appearance.isPhotogrammetryStatus = true;
            Global.player[Player_Index].appearance.photogrammetryStatus = Convert.ToInt32(PhotogrammetryStatus_comboBox.SelectedIndex);

            // Attributes
            Global.player[Player_Index].attributes.isMovementProfile = true;
            Global.player[Player_Index].attributes.movementProfile = Convert.ToInt32(MovementProfile_comboBox.SelectedIndex);

            Global.player[Player_Index].attributes.isTemperament = true;
            Global.player[Player_Index].attributes.temperament = Convert.ToInt32(Temperament_comboBox.SelectedIndex);

            Global.player[Player_Index].attributes.isFitness = true;
            Global.player[Player_Index].attributes.fitness = Convert.ToInt32(Fitness_numericUpDown.Value);

            // Strength
            Global.player[Player_Index].skills.strengthSkills.strength = Convert.ToInt32(Strength_numericUpDown.Value);
            Global.player[Player_Index].skills.strengthSkills.rucking = Convert.ToInt32(Rucking_numericUpDown.Value);
            Global.player[Player_Index].skills.strengthSkills.scrummaging = Convert.ToInt32(Scrummaging_numericUpDown.Value);
            Global.player[Player_Index].skills.strengthSkills.tackling = Convert.ToInt32(Tackling_numericUpDown.Value);
            Global.player[Player_Index].skills.strengthSkills.breakTackling = Convert.ToInt32(BreakTackle_numericUpDown.Value);
            Global.player[Player_Index].skills.strengthSkills.fending = Convert.ToInt32(Fending_numericUpDown.Value);

            // Speed
            Global.player[Player_Index].skills.speedSkills.agility = Convert.ToInt32(Agility_numericUpDown.Value);
            Global.player[Player_Index].skills.speedSkills.acceleration = Convert.ToInt32(Acceleration_numericUpDown.Value);
            Global.player[Player_Index].skills.speedSkills.sprintSpeed = Convert.ToInt32(SprintSpeed_numericUpDown.Value);
            Global.player[Player_Index].skills.speedSkills.balance = Convert.ToInt32(Balance_numericUpDown.Value);
            Global.player[Player_Index].skills.speedSkills.stamina = Convert.ToInt32(Stamina_numericUpDown.Value);
            Global.player[Player_Index].skills.speedSkills.evasion = Convert.ToInt32(Evasion_numericUpDown.Value);

            // Kicking
            Global.player[Player_Index].skills.kickingSkills.kickingAccuracy = Convert.ToInt32(KickingAccuracy_numericUpDown.Value);
            Global.player[Player_Index].skills.kickingSkills.kickingPower = Convert.ToInt32(KickingPower_numericUpDown.Value);
            Global.player[Player_Index].skills.kickingSkills.goalKicking = Convert.ToInt32(GoalKicking_numericUpDown.Value);
            Global.player[Player_Index].skills.kickingSkills.toePoke = Convert.ToInt32(ToePoke_numericUpDown.Value);

            Global.player[Player_Index].skills.kickingSkills.isConversionStyle = false;

            if (ConversionStyle_comboBox.SelectedIndex > 0)
                Global.player[Player_Index].skills.kickingSkills.isConversionStyle = true;

            Global.player[Player_Index].skills.kickingSkills.conversionStyle = Convert.ToInt32(ConversionStyle_comboBox.SelectedIndex);

            // Hands
            Global.player[Player_Index].skills.handsSkills.passing = Convert.ToInt32(Passing_numericUpDown.Value);
            Global.player[Player_Index].skills.handsSkills.aerialSkills = Convert.ToInt32(AerialSkills_numericUpDown.Value);
            Global.player[Player_Index].skills.handsSkills.offload = Convert.ToInt32(Offload_numericUpDown.Value);
            Global.player[Player_Index].skills.handsSkills.jackal = Convert.ToInt32(Jackal_numericUpDown.Value);
            Global.player[Player_Index].skills.handsSkills.intercepting = Convert.ToInt32(Intercepting_numericUpDown.Value);

            // Mentality
            Global.player[Player_Index].skills.mentalitySkills.focus = Convert.ToInt32(Focus_numericUpDown.Value);
            Global.player[Player_Index].skills.mentalitySkills.leadership = Convert.ToInt32(Leadership_numericUpDown.Value);
            Global.player[Player_Index].skills.mentalitySkills.determination = Convert.ToInt32(Determination_numericUpDown.Value);
            Global.player[Player_Index].skills.mentalitySkills.discipline = Convert.ToInt32(Discipline_numericUpDown.Value);

            // Player Stats - Not sure if this is used in Rugby 25
            if (UnionMatchEnabled_checkBox.Checked)
            {
                Global.player[Player_Index].unionMatchStats.isStatisticsStats = true;

                Global.player[Player_Index].unionMatchStats.isMatchesPlayed = true;
                Global.player[Player_Index].unionMatchStats.matchesPlayed = Convert.ToInt32(MatchesPlayed_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isMatchesWon = true;
                Global.player[Player_Index].unionMatchStats.matchesWon = Convert.ToInt32(MatchesWon_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isMatchesDrawn = true;
                Global.player[Player_Index].unionMatchStats.matchesDrawn = Convert.ToInt32(MatchesDrawn_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isBallStrips = true;
                Global.player[Player_Index].unionMatchStats.ballStrips = Convert.ToInt32(BallStrips_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isConversions = true;
                Global.player[Player_Index].unionMatchStats.conversions = Convert.ToInt32(Conversions_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isConversionAttempts = true;
                Global.player[Player_Index].unionMatchStats.conversionAttempts = Convert.ToInt32(ConversionAttempts_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isFends = true;
                Global.player[Player_Index].unionMatchStats.fends = Convert.ToInt32(Fends_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isFieldGoalAttempts = true;
                Global.player[Player_Index].unionMatchStats.fieldGoalAttempts = Convert.ToInt32(FieldGoalAttempts_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isFieldGoals = true;
                Global.player[Player_Index].unionMatchStats.fieldGoals = Convert.ToInt32(FieldGoals_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isFortyTwenties = true;
                Global.player[Player_Index].unionMatchStats.fortyTwenties = Convert.ToInt32(FortyTwenties_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isHandlingErrors = true;
                Global.player[Player_Index].unionMatchStats.handlingErrors = Convert.ToInt32(HandlingErrors_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isHitups = true;
                Global.player[Player_Index].unionMatchStats.hitups = Convert.ToInt32(Hitups_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isInterceptedPasses = true;
                Global.player[Player_Index].unionMatchStats.interceptedPasses = Convert.ToInt32(InterceptedPasses_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isInterceptions = true;
                Global.player[Player_Index].unionMatchStats.interceptions = Convert.ToInt32(Interceptions_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isKickMetresGained = true;
                Global.player[Player_Index].unionMatchStats.kickMetresGained = Convert.ToInt32(KickMetresGained_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isKicksInPlay = true;
                Global.player[Player_Index].unionMatchStats.kicksInPlay = Convert.ToInt32(KicksInPlay_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isKnockOns = true;
                Global.player[Player_Index].unionMatchStats.knockOns = Convert.ToInt32(KnockOns_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.islineBreakAssists = true;
                Global.player[Player_Index].unionMatchStats.lineBreakAssists = Convert.ToInt32(LineBreakAssists_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isLineBreaks = true;
                Global.player[Player_Index].unionMatchStats.lineBreaks = Convert.ToInt32(LineBreaks_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isMetresRun = true;
                Global.player[Player_Index].unionMatchStats.metresRun = Convert.ToInt32(MetresRun_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isMinutesPlayed = true;
                Global.player[Player_Index].unionMatchStats.minutesPlayed = Convert.ToInt32(MinutesPlayed_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isMissedTackles = true;
                Global.player[Player_Index].unionMatchStats.missedTackles = Convert.ToInt32(MissedTackles_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isOffloads = true;
                Global.player[Player_Index].unionMatchStats.offloads = Convert.ToInt32(Offloads_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isOneOnOneTackles = true;
                Global.player[Player_Index].unionMatchStats.oneOnOneTackles = Convert.ToInt32(OneOnOneTackles_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isPasses = true;
                Global.player[Player_Index].unionMatchStats.passes = Convert.ToInt32(Passes_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isPenaltiesConceded = true;
                Global.player[Player_Index].unionMatchStats.penaltiesConceded = Convert.ToInt32(PenaltiesConceded_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isPenaltyGoals = true;
                Global.player[Player_Index].unionMatchStats.penaltyGoals = Convert.ToInt32(PenaltyGoals_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isPenaltyGoalAttempts = true;
                Global.player[Player_Index].unionMatchStats.penaltyGoalAttempts = Convert.ToInt32(PenaltyGoalAttempts_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isRuns = true;
                Global.player[Player_Index].unionMatchStats.runs = Convert.ToInt32(Runs_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isTackleBreaks = true;
                Global.player[Player_Index].unionMatchStats.tackleBreaks = Convert.ToInt32(TackleBreaks_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isTackles = true;
                Global.player[Player_Index].unionMatchStats.tackles = Convert.ToInt32(Tackles_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isTries = true;
                Global.player[Player_Index].unionMatchStats.tries = Convert.ToInt32(Tries_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isTryAssists = true;
                Global.player[Player_Index].unionMatchStats.tryAssists = Convert.ToInt32(TryAssists_numericUpDown.Value);
                Global.player[Player_Index].unionMatchStats.isBonusTries = true;
                Global.player[Player_Index].unionMatchStats.bonusTries = Convert.ToInt32(BonusTries_numericUpDown.Value);
            }
            else
                Global.player[Player_Index].unionMatchStats.isStatisticsStats = false;

            int playerRating = Rating.PlayerRating(Player_Index);

            player_name_label.Text = FirstName_textBox.Text + " " + LastName_textBox.Text + " - " + playerRating.ToString();

            RefreshList.Update_PlayerList(Players_dataGridView);

            MessageBox.Show("Changers have been saved to this player", "Save Changers Is Complete :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int RandomizeStats(int min, int max)
        {
            if (random == null)
                random = new Random();
            return random.Next(min, max);
        }

        private void RandomizeStats_button_Click(object sender, EventArgs e)
        {
            int Role = PrimaryRole_comboBox.SelectedIndex;
            int Level = RandomizeStats_comboBox.SelectedIndex;

            if (Role == 0 || Role == 2 || Role == 3 || Role == 5 || Role == 6)
            {
                if (Level == 0)
                {
                    Fitness_numericUpDown.Value = RandomizeStats(80, 95);

                    Strength_numericUpDown.Value = RandomizeStats(75, 95);
                    Rucking_numericUpDown.Value = RandomizeStats(60, 75);
                    Scrummaging_numericUpDown.Value = RandomizeStats(60, 75);
                    Tackling_numericUpDown.Value = RandomizeStats(60, 85);
                    BreakTackle_numericUpDown.Value = RandomizeStats(75, 90);
                    Fending_numericUpDown.Value = RandomizeStats(60, 85);

                    Agility_numericUpDown.Value = RandomizeStats(80, 95);
                    Acceleration_numericUpDown.Value = RandomizeStats(85, 99);
                    SprintSpeed_numericUpDown.Value = RandomizeStats(80, 99);
                    Balance_numericUpDown.Value = RandomizeStats(75, 90);
                    Stamina_numericUpDown.Value = RandomizeStats(80, 95);
                    Evasion_numericUpDown.Value = RandomizeStats(85, 99);

                    KickingAccuracy_numericUpDown.Value = RandomizeStats(50, 75);
                    KickingPower_numericUpDown.Value = RandomizeStats(50, 80);
                    GoalKicking_numericUpDown.Value = RandomizeStats(50, 80);

                    Passing_numericUpDown.Value = RandomizeStats(65, 80);
                    AerialSkills_numericUpDown.Value = RandomizeStats(78, 92);
                    Offload_numericUpDown.Value = RandomizeStats(50, 70);
                    Jackal_numericUpDown.Value = RandomizeStats(70, 85);
                    Intercepting_numericUpDown.Value = RandomizeStats(70, 90);

                    Focus_numericUpDown.Value = RandomizeStats(50, 70);
                    Leadership_numericUpDown.Value = RandomizeStats(50, 80);
                    Determination_numericUpDown.Value = RandomizeStats(55, 80);
                    Discipline_numericUpDown.Value = RandomizeStats(50, 80);
                }
                if (Level == 1)
                {
                    Fitness_numericUpDown.Value = RandomizeStats(80, 95);

                    Strength_numericUpDown.Value = RandomizeStats(75, 95);
                    Rucking_numericUpDown.Value = RandomizeStats(60, 75);
                    Scrummaging_numericUpDown.Value = RandomizeStats(60, 80);
                    Tackling_numericUpDown.Value = RandomizeStats(50, 75);
                    BreakTackle_numericUpDown.Value = RandomizeStats(50, 75);
                    Fending_numericUpDown.Value = RandomizeStats(50, 75);

                    Agility_numericUpDown.Value = RandomizeStats(80, 95);
                    Acceleration_numericUpDown.Value = RandomizeStats(85, 99);
                    SprintSpeed_numericUpDown.Value = RandomizeStats(80, 99);
                    Balance_numericUpDown.Value = RandomizeStats(65, 85);
                    Stamina_numericUpDown.Value = RandomizeStats(80, 95);
                    Evasion_numericUpDown.Value = RandomizeStats(85, 99);

                    KickingAccuracy_numericUpDown.Value = RandomizeStats(85, 99);
                    KickingPower_numericUpDown.Value = RandomizeStats(85, 99);
                    GoalKicking_numericUpDown.Value = RandomizeStats(85, 99);

                    Passing_numericUpDown.Value = RandomizeStats(85, 99);
                    AerialSkills_numericUpDown.Value = RandomizeStats(78, 92);
                    Offload_numericUpDown.Value = RandomizeStats(70, 85);
                    Jackal_numericUpDown.Value = RandomizeStats(70, 85);
                    Intercepting_numericUpDown.Value = RandomizeStats(70, 85);

                    Focus_numericUpDown.Value = RandomizeStats(60, 80);
                    Leadership_numericUpDown.Value = RandomizeStats(75, 95);
                    Determination_numericUpDown.Value = RandomizeStats(75, 95);
                    Discipline_numericUpDown.Value = RandomizeStats(80, 95);
                }
                if (Level == 2)
                {
                    Fitness_numericUpDown.Value = RandomizeStats(80, 95);

                    Strength_numericUpDown.Value = RandomizeStats(75, 95);
                    Rucking_numericUpDown.Value = RandomizeStats(60, 75);
                    Scrummaging_numericUpDown.Value = RandomizeStats(60, 80);
                    Tackling_numericUpDown.Value = RandomizeStats(50, 75);
                    BreakTackle_numericUpDown.Value = RandomizeStats(50, 75);
                    Fending_numericUpDown.Value = RandomizeStats(50, 75);

                    Agility_numericUpDown.Value = RandomizeStats(80, 95);
                    Acceleration_numericUpDown.Value = RandomizeStats(85, 99);
                    SprintSpeed_numericUpDown.Value = RandomizeStats(80, 99);
                    Balance_numericUpDown.Value = RandomizeStats(65, 85);
                    Stamina_numericUpDown.Value = RandomizeStats(80, 95);
                    Evasion_numericUpDown.Value = RandomizeStats(85, 99);

                    KickingAccuracy_numericUpDown.Value = RandomizeStats(85, 99);
                    KickingPower_numericUpDown.Value = RandomizeStats(85, 99);
                    GoalKicking_numericUpDown.Value = RandomizeStats(85, 99);

                    Passing_numericUpDown.Value = RandomizeStats(85, 99);
                    AerialSkills_numericUpDown.Value = RandomizeStats(78, 92);
                    Offload_numericUpDown.Value = RandomizeStats(70, 85);
                    Jackal_numericUpDown.Value = RandomizeStats(70, 85);
                    Intercepting_numericUpDown.Value = RandomizeStats(70, 85);

                    Focus_numericUpDown.Value = RandomizeStats(60, 80);
                    Leadership_numericUpDown.Value = RandomizeStats(75, 95);
                    Determination_numericUpDown.Value = RandomizeStats(75, 95);
                    Discipline_numericUpDown.Value = RandomizeStats(80, 95);
                }
            }
            else if (Role == 9 || Role == 10 || Role == 14)
            {
                if (Level == 0)
                {
                    Fitness_numericUpDown.Value = RandomizeStats(70, 86);

                    Strength_numericUpDown.Value = RandomizeStats(65, 80);
                    Rucking_numericUpDown.Value = RandomizeStats(70, 90);
                    Scrummaging_numericUpDown.Value = RandomizeStats(75, 95);
                    Tackling_numericUpDown.Value = RandomizeStats(60, 80);
                    BreakTackle_numericUpDown.Value = RandomizeStats(55, 80);
                    Fending_numericUpDown.Value = RandomizeStats(50, 75);

                    Agility_numericUpDown.Value = RandomizeStats(65, 80);
                    Acceleration_numericUpDown.Value = RandomizeStats(65, 85);
                    SprintSpeed_numericUpDown.Value = RandomizeStats(70, 85);
                    Balance_numericUpDown.Value = RandomizeStats(65, 85);
                    Stamina_numericUpDown.Value = RandomizeStats(55, 85);
                    Evasion_numericUpDown.Value = RandomizeStats(55, 75);

                    KickingAccuracy_numericUpDown.Value = RandomizeStats(85, 99);
                    KickingPower_numericUpDown.Value = RandomizeStats(85, 99);
                    GoalKicking_numericUpDown.Value = RandomizeStats(85, 99);

                    Passing_numericUpDown.Value = RandomizeStats(85, 99);
                    AerialSkills_numericUpDown.Value = RandomizeStats(65, 85);
                    Offload_numericUpDown.Value = RandomizeStats(65, 80);
                    Jackal_numericUpDown.Value = RandomizeStats(70, 85);
                    Intercepting_numericUpDown.Value = RandomizeStats(70, 85);

                    Focus_numericUpDown.Value = RandomizeStats(65, 99);
                    Leadership_numericUpDown.Value = RandomizeStats(75, 99);
                    Determination_numericUpDown.Value = RandomizeStats(75, 95);
                    Discipline_numericUpDown.Value = RandomizeStats(65, 95);
                }
                if (Level == 1)
                {
                    Fitness_numericUpDown.Value = RandomizeStats(80, 95);

                    Strength_numericUpDown.Value = RandomizeStats(75, 95);
                    Rucking_numericUpDown.Value = RandomizeStats(60, 75);
                    Scrummaging_numericUpDown.Value = RandomizeStats(60, 80);
                    Tackling_numericUpDown.Value = RandomizeStats(50, 75);
                    BreakTackle_numericUpDown.Value = RandomizeStats(50, 75);
                    Fending_numericUpDown.Value = RandomizeStats(50, 75);

                    Agility_numericUpDown.Value = RandomizeStats(80, 95);
                    Acceleration_numericUpDown.Value = RandomizeStats(85, 99);
                    SprintSpeed_numericUpDown.Value = RandomizeStats(80, 99);
                    Balance_numericUpDown.Value = RandomizeStats(65, 85);
                    Stamina_numericUpDown.Value = RandomizeStats(80, 95);
                    Evasion_numericUpDown.Value = RandomizeStats(85, 99);

                    KickingAccuracy_numericUpDown.Value = RandomizeStats(85, 99);
                    KickingPower_numericUpDown.Value = RandomizeStats(85, 99);
                    GoalKicking_numericUpDown.Value = RandomizeStats(85, 99);

                    Passing_numericUpDown.Value = RandomizeStats(85, 99);
                    AerialSkills_numericUpDown.Value = RandomizeStats(78, 92);
                    Offload_numericUpDown.Value = RandomizeStats(70, 85);
                    Jackal_numericUpDown.Value = RandomizeStats(70, 85);
                    Intercepting_numericUpDown.Value = RandomizeStats(70, 85);

                    Focus_numericUpDown.Value = RandomizeStats(60, 80);
                    Leadership_numericUpDown.Value = RandomizeStats(75, 95);
                    Determination_numericUpDown.Value = RandomizeStats(75, 95);
                    Discipline_numericUpDown.Value = RandomizeStats(80, 95);
                }
                if (Level == 2)
                {
                    Fitness_numericUpDown.Value = RandomizeStats(80, 95);

                    Strength_numericUpDown.Value = RandomizeStats(75, 95);
                    Rucking_numericUpDown.Value = RandomizeStats(60, 75);
                    Scrummaging_numericUpDown.Value = RandomizeStats(60, 80);
                    Tackling_numericUpDown.Value = RandomizeStats(50, 75);
                    BreakTackle_numericUpDown.Value = RandomizeStats(50, 75);
                    Fending_numericUpDown.Value = RandomizeStats(50, 75);

                    Agility_numericUpDown.Value = RandomizeStats(80, 95);
                    Acceleration_numericUpDown.Value = RandomizeStats(85, 99);
                    SprintSpeed_numericUpDown.Value = RandomizeStats(80, 99);
                    Balance_numericUpDown.Value = RandomizeStats(65, 85);
                    Stamina_numericUpDown.Value = RandomizeStats(80, 95);
                    Evasion_numericUpDown.Value = RandomizeStats(85, 99);

                    KickingAccuracy_numericUpDown.Value = RandomizeStats(85, 99);
                    KickingPower_numericUpDown.Value = RandomizeStats(85, 99);
                    GoalKicking_numericUpDown.Value = RandomizeStats(85, 99);

                    Passing_numericUpDown.Value = RandomizeStats(85, 99);
                    AerialSkills_numericUpDown.Value = RandomizeStats(78, 92);
                    Offload_numericUpDown.Value = RandomizeStats(70, 85);
                    Jackal_numericUpDown.Value = RandomizeStats(70, 85);
                    Intercepting_numericUpDown.Value = RandomizeStats(70, 85);

                    Focus_numericUpDown.Value = RandomizeStats(60, 80);
                    Leadership_numericUpDown.Value = RandomizeStats(75, 95);
                    Determination_numericUpDown.Value = RandomizeStats(75, 95);
                    Discipline_numericUpDown.Value = RandomizeStats(80, 95);
                }
            }
            else if (Role == 5)
            {
                if (Level == 0)
                {
                    Fitness_numericUpDown.Value = RandomizeStats(80, 95);

                    Strength_numericUpDown.Value = RandomizeStats(75, 95);
                    Rucking_numericUpDown.Value = RandomizeStats(60, 75);
                    Scrummaging_numericUpDown.Value = RandomizeStats(60, 80);
                    Tackling_numericUpDown.Value = RandomizeStats(50, 75);
                    BreakTackle_numericUpDown.Value = RandomizeStats(50, 75);
                    Fending_numericUpDown.Value = RandomizeStats(50, 75);

                    Agility_numericUpDown.Value = RandomizeStats(80, 95);
                    Acceleration_numericUpDown.Value = RandomizeStats(85, 99);
                    SprintSpeed_numericUpDown.Value = RandomizeStats(80, 99);
                    Balance_numericUpDown.Value = RandomizeStats(65, 85);
                    Stamina_numericUpDown.Value = RandomizeStats(80, 95);
                    Evasion_numericUpDown.Value = RandomizeStats(85, 99);

                    KickingAccuracy_numericUpDown.Value = RandomizeStats(85, 99);
                    KickingPower_numericUpDown.Value = RandomizeStats(85, 99);
                    GoalKicking_numericUpDown.Value = RandomizeStats(85, 99);

                    Passing_numericUpDown.Value = RandomizeStats(85, 99);
                    AerialSkills_numericUpDown.Value = RandomizeStats(78, 92);
                    Offload_numericUpDown.Value = RandomizeStats(70, 85);
                    Jackal_numericUpDown.Value = RandomizeStats(70, 85);
                    Intercepting_numericUpDown.Value = RandomizeStats(70, 85);

                    Focus_numericUpDown.Value = RandomizeStats(60, 80);
                    Leadership_numericUpDown.Value = RandomizeStats(75, 95);
                    Determination_numericUpDown.Value = RandomizeStats(75, 95);
                    Discipline_numericUpDown.Value = RandomizeStats(80, 95);
                }
                if (Level == 1)
                {
                    Fitness_numericUpDown.Value = RandomizeStats(80, 95);

                    Strength_numericUpDown.Value = RandomizeStats(75, 95);
                    Rucking_numericUpDown.Value = RandomizeStats(60, 75);
                    Scrummaging_numericUpDown.Value = RandomizeStats(60, 80);
                    Tackling_numericUpDown.Value = RandomizeStats(50, 75);
                    BreakTackle_numericUpDown.Value = RandomizeStats(50, 75);
                    Fending_numericUpDown.Value = RandomizeStats(50, 75);

                    Agility_numericUpDown.Value = RandomizeStats(80, 95);
                    Acceleration_numericUpDown.Value = RandomizeStats(85, 99);
                    SprintSpeed_numericUpDown.Value = RandomizeStats(80, 99);
                    Balance_numericUpDown.Value = RandomizeStats(65, 85);
                    Stamina_numericUpDown.Value = RandomizeStats(80, 95);
                    Evasion_numericUpDown.Value = RandomizeStats(85, 99);

                    KickingAccuracy_numericUpDown.Value = RandomizeStats(85, 99);
                    KickingPower_numericUpDown.Value = RandomizeStats(85, 99);
                    GoalKicking_numericUpDown.Value = RandomizeStats(85, 99);

                    Passing_numericUpDown.Value = RandomizeStats(85, 99);
                    AerialSkills_numericUpDown.Value = RandomizeStats(78, 92);
                    Offload_numericUpDown.Value = RandomizeStats(70, 85);
                    Jackal_numericUpDown.Value = RandomizeStats(70, 85);
                    Intercepting_numericUpDown.Value = RandomizeStats(70, 85);

                    Focus_numericUpDown.Value = RandomizeStats(60, 80);
                    Leadership_numericUpDown.Value = RandomizeStats(75, 95);
                    Determination_numericUpDown.Value = RandomizeStats(75, 95);
                    Discipline_numericUpDown.Value = RandomizeStats(80, 95);
                }
                if (Level == 2)
                {
                    Fitness_numericUpDown.Value = RandomizeStats(80, 95);

                    Strength_numericUpDown.Value = RandomizeStats(75, 95);
                    Rucking_numericUpDown.Value = RandomizeStats(60, 75);
                    Scrummaging_numericUpDown.Value = RandomizeStats(60, 80);
                    Tackling_numericUpDown.Value = RandomizeStats(50, 75);
                    BreakTackle_numericUpDown.Value = RandomizeStats(50, 75);
                    Fending_numericUpDown.Value = RandomizeStats(50, 75);

                    Agility_numericUpDown.Value = RandomizeStats(80, 95);
                    Acceleration_numericUpDown.Value = RandomizeStats(85, 99);
                    SprintSpeed_numericUpDown.Value = RandomizeStats(80, 99);
                    Balance_numericUpDown.Value = RandomizeStats(65, 85);
                    Stamina_numericUpDown.Value = RandomizeStats(80, 95);
                    Evasion_numericUpDown.Value = RandomizeStats(85, 99);

                    KickingAccuracy_numericUpDown.Value = RandomizeStats(85, 99);
                    KickingPower_numericUpDown.Value = RandomizeStats(85, 99);
                    GoalKicking_numericUpDown.Value = RandomizeStats(85, 99);

                    Passing_numericUpDown.Value = RandomizeStats(85, 99);
                    AerialSkills_numericUpDown.Value = RandomizeStats(78, 92);
                    Offload_numericUpDown.Value = RandomizeStats(70, 85);
                    Jackal_numericUpDown.Value = RandomizeStats(70, 85);
                    Intercepting_numericUpDown.Value = RandomizeStats(70, 85);

                    Focus_numericUpDown.Value = RandomizeStats(60, 80);
                    Leadership_numericUpDown.Value = RandomizeStats(75, 95);
                    Determination_numericUpDown.Value = RandomizeStats(75, 95);
                    Discipline_numericUpDown.Value = RandomizeStats(80, 95);
                }
            }
            else if (Role == 7 || Role == 8)
            {
                if (Level == 0)
                {
                    Fitness_numericUpDown.Value = RandomizeStats(80, 95);

                    Strength_numericUpDown.Value = RandomizeStats(75, 95);
                    Rucking_numericUpDown.Value = RandomizeStats(60, 75);
                    Scrummaging_numericUpDown.Value = RandomizeStats(60, 80);
                    Tackling_numericUpDown.Value = RandomizeStats(50, 75);
                    BreakTackle_numericUpDown.Value = RandomizeStats(50, 75);
                    Fending_numericUpDown.Value = RandomizeStats(50, 75);

                    Agility_numericUpDown.Value = RandomizeStats(80, 95);
                    Acceleration_numericUpDown.Value = RandomizeStats(85, 99);
                    SprintSpeed_numericUpDown.Value = RandomizeStats(80, 99);
                    Balance_numericUpDown.Value = RandomizeStats(65, 85);
                    Stamina_numericUpDown.Value = RandomizeStats(80, 95);
                    Evasion_numericUpDown.Value = RandomizeStats(85, 99);

                    KickingAccuracy_numericUpDown.Value = RandomizeStats(85, 99);
                    KickingPower_numericUpDown.Value = RandomizeStats(85, 99);
                    GoalKicking_numericUpDown.Value = RandomizeStats(85, 99);

                    Passing_numericUpDown.Value = RandomizeStats(85, 99);
                    AerialSkills_numericUpDown.Value = RandomizeStats(78, 92);
                    Offload_numericUpDown.Value = RandomizeStats(70, 85);
                    Jackal_numericUpDown.Value = RandomizeStats(70, 85);
                    Intercepting_numericUpDown.Value = RandomizeStats(70, 85);

                    Focus_numericUpDown.Value = RandomizeStats(60, 80);
                    Leadership_numericUpDown.Value = RandomizeStats(75, 95);
                    Determination_numericUpDown.Value = RandomizeStats(75, 95);
                    Discipline_numericUpDown.Value = RandomizeStats(80, 95);
                }
                if (Level == 1)
                {
                    Fitness_numericUpDown.Value = RandomizeStats(80, 95);

                    Strength_numericUpDown.Value = RandomizeStats(75, 95);
                    Rucking_numericUpDown.Value = RandomizeStats(60, 75);
                    Scrummaging_numericUpDown.Value = RandomizeStats(60, 80);
                    Tackling_numericUpDown.Value = RandomizeStats(50, 75);
                    BreakTackle_numericUpDown.Value = RandomizeStats(50, 75);
                    Fending_numericUpDown.Value = RandomizeStats(50, 75);

                    Agility_numericUpDown.Value = RandomizeStats(80, 95);
                    Acceleration_numericUpDown.Value = RandomizeStats(85, 99);
                    SprintSpeed_numericUpDown.Value = RandomizeStats(80, 99);
                    Balance_numericUpDown.Value = RandomizeStats(65, 85);
                    Stamina_numericUpDown.Value = RandomizeStats(80, 95);
                    Evasion_numericUpDown.Value = RandomizeStats(85, 99);

                    KickingAccuracy_numericUpDown.Value = RandomizeStats(85, 99);
                    KickingPower_numericUpDown.Value = RandomizeStats(85, 99);
                    GoalKicking_numericUpDown.Value = RandomizeStats(85, 99);

                    Passing_numericUpDown.Value = RandomizeStats(85, 99);
                    AerialSkills_numericUpDown.Value = RandomizeStats(78, 92);
                    Offload_numericUpDown.Value = RandomizeStats(70, 85);
                    Jackal_numericUpDown.Value = RandomizeStats(70, 85);
                    Intercepting_numericUpDown.Value = RandomizeStats(70, 85);

                    Focus_numericUpDown.Value = RandomizeStats(60, 80);
                    Leadership_numericUpDown.Value = RandomizeStats(75, 95);
                    Determination_numericUpDown.Value = RandomizeStats(75, 95);
                    Discipline_numericUpDown.Value = RandomizeStats(80, 95);
                }
                if (Level == 2)
                {
                    Fitness_numericUpDown.Value = RandomizeStats(80, 95);

                    Strength_numericUpDown.Value = RandomizeStats(75, 95);
                    Rucking_numericUpDown.Value = RandomizeStats(60, 75);
                    Scrummaging_numericUpDown.Value = RandomizeStats(60, 80);
                    Tackling_numericUpDown.Value = RandomizeStats(50, 75);
                    BreakTackle_numericUpDown.Value = RandomizeStats(50, 75);
                    Fending_numericUpDown.Value = RandomizeStats(50, 75);

                    Agility_numericUpDown.Value = RandomizeStats(80, 95);
                    Acceleration_numericUpDown.Value = RandomizeStats(85, 99);
                    SprintSpeed_numericUpDown.Value = RandomizeStats(80, 99);
                    Balance_numericUpDown.Value = RandomizeStats(65, 85);
                    Stamina_numericUpDown.Value = RandomizeStats(80, 95);
                    Evasion_numericUpDown.Value = RandomizeStats(85, 99);

                    KickingAccuracy_numericUpDown.Value = RandomizeStats(85, 99);
                    KickingPower_numericUpDown.Value = RandomizeStats(85, 99);
                    GoalKicking_numericUpDown.Value = RandomizeStats(85, 99);

                    Passing_numericUpDown.Value = RandomizeStats(85, 99);
                    AerialSkills_numericUpDown.Value = RandomizeStats(78, 92);
                    Offload_numericUpDown.Value = RandomizeStats(70, 85);
                    Jackal_numericUpDown.Value = RandomizeStats(70, 85);
                    Intercepting_numericUpDown.Value = RandomizeStats(70, 85);

                    Focus_numericUpDown.Value = RandomizeStats(60, 80);
                    Leadership_numericUpDown.Value = RandomizeStats(75, 95);
                    Determination_numericUpDown.Value = RandomizeStats(75, 95);
                    Discipline_numericUpDown.Value = RandomizeStats(80, 95);
                }
            }
        }
    }
}