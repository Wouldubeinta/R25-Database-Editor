using System.Data;

namespace R25_Database_Editor
{
    public partial class Raw_Player_Skills : Form
    {
        private readonly DataGridView Players_dataGridView;

        public Raw_Player_Skills(DataGridView Players_dataGridView)
        {
            InitializeComponent();
            this.Players_dataGridView = Players_dataGridView;
        }

        private void Raw_Player_Skills_Load(object sender, EventArgs e)
        {
            DataTable? dt = null;

            try
            {
                dt = new DataTable();

                dt.Columns.Add("Index", typeof(string));
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("First Name", typeof(string));
                dt.Columns.Add("Last Name", typeof(string));
                dt.Columns.Add("Gender", typeof(string));
                dt.Columns.Add("Strength", typeof(int));
                dt.Columns.Add("Rucking", typeof(int));
                dt.Columns.Add("Scrummaging", typeof(int));
                dt.Columns.Add("Tackling", typeof(int));
                dt.Columns.Add("Break Tackle", typeof(int));
                dt.Columns.Add("Fending", typeof(int));
                dt.Columns.Add("Agility", typeof(int));
                dt.Columns.Add("Acceleration", typeof(int));
                dt.Columns.Add("Sprint Speed", typeof(int));
                dt.Columns.Add("Balance", typeof(int));
                dt.Columns.Add("Stamina", typeof(int));
                dt.Columns.Add("Evasion", typeof(int));
                dt.Columns.Add("Kicking Accuracy", typeof(int));
                dt.Columns.Add("Kicking Power", typeof(int));
                dt.Columns.Add("Goal Kicking", typeof(int));
                dt.Columns.Add("Toe Poke", typeof(int));
                dt.Columns.Add("Passing", typeof(int));
                dt.Columns.Add("Aerial Skills", typeof(int));
                dt.Columns.Add("Offload", typeof(int));
                dt.Columns.Add("Jackal", typeof(int));
                dt.Columns.Add("Intercepting", typeof(int));
                dt.Columns.Add("Focus", typeof(int));
                dt.Columns.Add("Leadership", typeof(int));
                dt.Columns.Add("Determination", typeof(int));
                dt.Columns.Add("Discipline", typeof(int));
                dt.Columns.Add("Fitness", typeof(int));

                for (int i = 0; i < Global.player_amount; i++)
                {
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["Index"] = i.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Id"] = Global.player[i].id.ToString();
                    dt.Rows[dt.Rows.Count - 1]["First Name"] = Global.player[i].firstName.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Last Name"] = Global.player[i].lastName.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Gender"] = Global.player[i].gender.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Strength"] = Global.player[i].skills.strengthSkills.strength;
                    dt.Rows[dt.Rows.Count - 1]["Rucking"] = Global.player[i].skills.strengthSkills.rucking;
                    dt.Rows[dt.Rows.Count - 1]["Scrummaging"] = Global.player[i].skills.strengthSkills.scrummaging;
                    dt.Rows[dt.Rows.Count - 1]["Tackling"] = Global.player[i].skills.strengthSkills.tackling;
                    dt.Rows[dt.Rows.Count - 1]["Break Tackle"] = Global.player[i].skills.strengthSkills.breakTackling;
                    dt.Rows[dt.Rows.Count - 1]["Fending"] = Global.player[i].skills.strengthSkills.fending;
                    dt.Rows[dt.Rows.Count - 1]["Agility"] = Global.player[i].skills.speedSkills.agility;
                    dt.Rows[dt.Rows.Count - 1]["Acceleration"] = Global.player[i].skills.speedSkills.acceleration;
                    dt.Rows[dt.Rows.Count - 1]["Sprint Speed"] = Global.player[i].skills.speedSkills.sprintSpeed;
                    dt.Rows[dt.Rows.Count - 1]["Balance"] = Global.player[i].skills.speedSkills.balance;
                    dt.Rows[dt.Rows.Count - 1]["Stamina"] = Global.player[i].skills.speedSkills.stamina;
                    dt.Rows[dt.Rows.Count - 1]["Evasion"] = Global.player[i].skills.speedSkills.evasion;
                    dt.Rows[dt.Rows.Count - 1]["Kicking Accuracy"] = Global.player[i].skills.kickingSkills.kickingAccuracy;
                    dt.Rows[dt.Rows.Count - 1]["Kicking Power"] = Global.player[i].skills.kickingSkills.kickingPower;
                    dt.Rows[dt.Rows.Count - 1]["Goal Kicking"] = Global.player[i].skills.kickingSkills.goalKicking;
                    dt.Rows[dt.Rows.Count - 1]["Toe Poke"] = Global.player[i].skills.kickingSkills.toePoke;
                    dt.Rows[dt.Rows.Count - 1]["Passing"] = Global.player[i].skills.handsSkills.passing;
                    dt.Rows[dt.Rows.Count - 1]["Aerial Skills"] = Global.player[i].skills.handsSkills.aerialSkills;
                    dt.Rows[dt.Rows.Count - 1]["Offload"] = Global.player[i].skills.handsSkills.aerialSkills;
                    dt.Rows[dt.Rows.Count - 1]["Jackal"] = Global.player[i].skills.handsSkills.jackal;
                    dt.Rows[dt.Rows.Count - 1]["Intercepting"] = Global.player[i].skills.handsSkills.intercepting;
                    dt.Rows[dt.Rows.Count - 1]["Focus"] = Global.player[i].skills.mentalitySkills.focus;
                    dt.Rows[dt.Rows.Count - 1]["Leadership"] = Global.player[i].skills.mentalitySkills.leadership;
                    dt.Rows[dt.Rows.Count - 1]["Determination"] = Global.player[i].skills.mentalitySkills.determination;
                    dt.Rows[dt.Rows.Count - 1]["Discipline"] = Global.player[i].skills.mentalitySkills.discipline;
                    dt.Rows[dt.Rows.Count - 1]["Fitness"] = Global.player[i].attributes.fitness;
                }

                dataGridView1.DataSource = dt;

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void SaveChangers()
        {
            dataGridView1.Rows[0].Cells[0].Selected = true;

            for (int i = 0; i < Global.player_amount; i++)
            {
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].id = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].firstNameSize = Convert.ToByte(dataGridView1.Rows[i].Cells[2].Value.ToString().Length);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].firstName = dataGridView1.Rows[i].Cells[2].Value.ToString();
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].lastNameSize = Convert.ToByte(dataGridView1.Rows[i].Cells[3].Value.ToString().Length);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].lastName = dataGridView1.Rows[i].Cells[3].Value.ToString();
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].gender = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);

                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.strengthSkills.strength = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.strengthSkills.rucking = Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.strengthSkills.scrummaging = Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.strengthSkills.tackling = Convert.ToInt32(dataGridView1.Rows[i].Cells[8].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.strengthSkills.breakTackling = Convert.ToInt32(dataGridView1.Rows[i].Cells[9].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.strengthSkills.fending = Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value);

                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.speedSkills.agility = Convert.ToInt32(dataGridView1.Rows[i].Cells[11].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.speedSkills.acceleration = Convert.ToInt32(dataGridView1.Rows[i].Cells[12].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.speedSkills.sprintSpeed = Convert.ToInt32(dataGridView1.Rows[i].Cells[13].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.speedSkills.balance = Convert.ToInt32(dataGridView1.Rows[i].Cells[14].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.speedSkills.stamina = Convert.ToInt32(dataGridView1.Rows[i].Cells[15].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.speedSkills.evasion = Convert.ToInt32(dataGridView1.Rows[i].Cells[16].Value);

                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.kickingSkills.kickingAccuracy = Convert.ToInt32(dataGridView1.Rows[i].Cells[17].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.kickingSkills.kickingPower = Convert.ToInt32(dataGridView1.Rows[i].Cells[18].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.kickingSkills.goalKicking = Convert.ToInt32(dataGridView1.Rows[i].Cells[19].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.kickingSkills.toePoke = Convert.ToInt32(dataGridView1.Rows[i].Cells[20].Value);

                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.handsSkills.passing = Convert.ToInt32(dataGridView1.Rows[i].Cells[21].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.handsSkills.aerialSkills = Convert.ToInt32(dataGridView1.Rows[i].Cells[22].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.handsSkills.offload = Convert.ToInt32(dataGridView1.Rows[i].Cells[23].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.handsSkills.jackal = Convert.ToInt32(dataGridView1.Rows[i].Cells[24].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.handsSkills.intercepting = Convert.ToInt32(dataGridView1.Rows[i].Cells[25].Value);

                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.mentalitySkills.focus = Convert.ToInt32(dataGridView1.Rows[i].Cells[26].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.mentalitySkills.leadership = Convert.ToInt32(dataGridView1.Rows[i].Cells[27].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.mentalitySkills.determination = Convert.ToInt32(dataGridView1.Rows[i].Cells[28].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.mentalitySkills.discipline = Convert.ToInt32(dataGridView1.Rows[i].Cells[29].Value);

                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].attributes.fitness = Convert.ToInt32(dataGridView1.Rows[i].Cells[30].Value);

                toolStripProgressBar1.Maximum = dataGridView1.Rows.Count;
                toolStripProgressBar1.Value = i;
                toolStripProgressBar1.PerformStep();
            }

            RefreshList.Update_PlayerList(Players_dataGridView);
            toolStripProgressBar1.Value = 0;
            MessageBox.Show("Changers have been saved to this player", "Save Changers Is Complete :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void importCSVDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Import_CSV_ofd.ShowDialog() == DialogResult.OK)
            {
                CSV.FromCSV(dataGridView1, Import_CSV_ofd.FileName);
            }
        }

        private void exportCSVDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Export_CSV_sfd.ShowDialog() == DialogResult.OK)
            {
                CSV.ToCSV(dataGridView1, Export_CSV_sfd.FileName, toolStripProgressBar1);
            }
        }

        private void Save_Changers_toolStripDropDownButton_Click(object sender, EventArgs e)
        {
            SaveChangers();
        }
    }
}