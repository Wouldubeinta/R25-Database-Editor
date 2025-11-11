using System.Data;

namespace R25_Database_Editor
{
    public partial class Raw_Player_Database : Form
    {
        private readonly DataGridView Players_dataGridView;

        public Raw_Player_Database(DataGridView Players_dataGridView)
        {
            InitializeComponent();
            this.Players_dataGridView = Players_dataGridView;
        }

        private void Raw_Player_Database_Load(object sender, EventArgs e)
        {
            DataTable? dt = null;

            try
            {
                dt = new DataTable();

                dt.Columns.Add("Index", typeof(int));
                dt.Columns.Add("Enabled", typeof(bool));
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Licensed", typeof(bool));
                dt.Columns.Add("First Name", typeof(string));
                dt.Columns.Add("Last Name", typeof(string));
                dt.Columns.Add("Gender", typeof(int));
                dt.Columns.Add("Commentary Name Hash", typeof(uint));
                dt.Columns.Add("DOB - Day", typeof(int));
                dt.Columns.Add("DOB - Month", typeof(int));
                dt.Columns.Add("DOB - Year", typeof(int));
                dt.Columns.Add("Age", typeof(int));
                dt.Columns.Add("Jersey Number", typeof(int));
                dt.Columns.Add("Jersey Name", typeof(string));
                dt.Columns.Add("Primary Role", typeof(int));
                dt.Columns.Add("Secondary Role", typeof(int));
                dt.Columns.Add("Tertiary Role", typeof(int));
                dt.Columns.Add("World Cup", typeof(bool));
                dt.Columns.Add("Preferred Hand", typeof(byte));
                dt.Columns.Add("Preferred Foot", typeof(byte));
                dt.Columns.Add("Representative Country", typeof(int));
                dt.Columns.Add("Country Of Birth", typeof(int));
                dt.Columns.Add("Contract Expiry", typeof(int));
                dt.Columns.Add("Height", typeof(int));
                dt.Columns.Add("Weight", typeof(int));
                dt.Columns.Add("Movement Profile", typeof(int));
                dt.Columns.Add("Temperament", typeof(int));
                dt.Columns.Add("Conversion Style", typeof(int));
                dt.Columns.Add("Photogrammetry Status", typeof(int));

                for (int i = 0; i < Global.player_amount; i++)
                {
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["Index"] = i;
                    dt.Rows[dt.Rows.Count - 1]["Enabled"] = Global.player[i].playerEnabled;
                    dt.Rows[dt.Rows.Count - 1]["Id"] = Global.player[i].id;
                    dt.Rows[dt.Rows.Count - 1]["Licensed"] = Global.player[i].licensed;
                    dt.Rows[dt.Rows.Count - 1]["First Name"] = Global.player[i].firstName;
                    dt.Rows[dt.Rows.Count - 1]["Last Name"] = Global.player[i].lastName;
                    dt.Rows[dt.Rows.Count - 1]["Gender"] = Global.player[i].gender;
                    dt.Rows[dt.Rows.Count - 1]["Commentary Name Hash"] = Global.player[i].commentaryNameHash;
                    dt.Rows[dt.Rows.Count - 1]["DOB - Day"] = Global.player[i].dob.day;
                    dt.Rows[dt.Rows.Count - 1]["DOB - Month"] = Global.player[i].dob.month;
                    dt.Rows[dt.Rows.Count - 1]["DOB - Year"] = Global.player[i].dob.year;
                    dt.Rows[dt.Rows.Count - 1]["Age"] = Global.player[i].age;
                    dt.Rows[dt.Rows.Count - 1]["Jersey Number"] = Global.player[i].jerseyNumber;
                    dt.Rows[dt.Rows.Count - 1]["Jersey Name"] = Global.player[i].jerseyName;
                    dt.Rows[dt.Rows.Count - 1]["Primary Role"] = Global.player[i].primaryRole;
                    dt.Rows[dt.Rows.Count - 1]["Secondary Role"] = Global.player[i].secondaryRole;
                    dt.Rows[dt.Rows.Count - 1]["Tertiary Role"] = Global.player[i].tertiaryRole;
                    dt.Rows[dt.Rows.Count - 1]["World Cup"] = Global.player[i].WorldCup;
                    dt.Rows[dt.Rows.Count - 1]["Preferred Hand"] = Global.player[i].preferredHand;
                    dt.Rows[dt.Rows.Count - 1]["Preferred Foot"] = Global.player[i].preferredFoot;
                    dt.Rows[dt.Rows.Count - 1]["Representative Country"] = Global.player[i].repCountry;
                    dt.Rows[dt.Rows.Count - 1]["Country Of Birth"] = Global.player[i].countryOfBirth;
                    dt.Rows[dt.Rows.Count - 1]["Contract Expiry"] = Global.player[i].contractExpiry;
                    dt.Rows[dt.Rows.Count - 1]["Height"] = Global.player[i].appearance.height;
                    dt.Rows[dt.Rows.Count - 1]["Weight"] = Global.player[i].appearance.weight;
                    dt.Rows[dt.Rows.Count - 1]["Movement Profile"] = Global.player[i].attributes.movementProfile;
                    dt.Rows[dt.Rows.Count - 1]["Temperament"] = Global.player[i].attributes.temperament;
                    dt.Rows[dt.Rows.Count - 1]["Conversion Style"] = Global.player[i].skills.kickingSkills.conversionStyle;
                    dt.Rows[dt.Rows.Count - 1]["Photogrammetry Status"] = Global.player[i].appearance.photogrammetryStatus;
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
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].playerEnabled = Convert.ToBoolean(dataGridView1.Rows[i].Cells[1].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].id = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].isLicensed = true;
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].licensed = Convert.ToBoolean(dataGridView1.Rows[i].Cells[3].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].firstNameSize = Convert.ToByte(dataGridView1.Rows[i].Cells[4].Value.ToString().Length);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].firstName = dataGridView1.Rows[i].Cells[4].Value.ToString();
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].lastNameSize = Convert.ToByte(dataGridView1.Rows[i].Cells[5].Value.ToString().Length);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].lastName = dataGridView1.Rows[i].Cells[5].Value.ToString();
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].gender = Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].commentaryNameHash = Convert.ToUInt32(dataGridView1.Rows[i].Cells[7].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].dob.day = Convert.ToInt32(dataGridView1.Rows[i].Cells[8].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].dob.month = Convert.ToInt32(dataGridView1.Rows[i].Cells[9].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].dob.year = Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].age = Convert.ToInt32(dataGridView1.Rows[i].Cells[11].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].jerseyNumber = Convert.ToInt32(dataGridView1.Rows[i].Cells[12].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].jerseyNameSize = Convert.ToByte(dataGridView1.Rows[i].Cells[13].Value.ToString().Length);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].jerseyName = dataGridView1.Rows[i].Cells[13].Value.ToString();
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].primaryRole = Convert.ToInt32(dataGridView1.Rows[i].Cells[14].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].secondaryRole = Convert.ToInt32(dataGridView1.Rows[i].Cells[15].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].tertiaryRole = Convert.ToInt32(dataGridView1.Rows[i].Cells[16].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].WorldCup = Convert.ToBoolean(dataGridView1.Rows[i].Cells[17].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].preferredHand = Convert.ToByte(dataGridView1.Rows[i].Cells[18].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].preferredFoot = Convert.ToByte(dataGridView1.Rows[i].Cells[19].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].repCountry = Convert.ToInt32(dataGridView1.Rows[i].Cells[20].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].countryOfBirth = Convert.ToInt32(dataGridView1.Rows[i].Cells[21].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].contractExpiry = Convert.ToInt32(dataGridView1.Rows[i].Cells[22].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].appearance.height = Convert.ToInt32(dataGridView1.Rows[i].Cells[23].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].appearance.weight = Convert.ToInt32(dataGridView1.Rows[i].Cells[24].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].attributes.movementProfile = Convert.ToInt32(dataGridView1.Rows[i].Cells[25].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].attributes.temperament = Convert.ToInt32(dataGridView1.Rows[i].Cells[26].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.kickingSkills.conversionStyle = Convert.ToInt32(dataGridView1.Rows[i].Cells[27].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].appearance.photogrammetryStatus = Convert.ToInt32(dataGridView1.Rows[i].Cells[28].Value);

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