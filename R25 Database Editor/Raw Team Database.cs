using System.Data;

namespace R25_Database_Editor
{
    public partial class Raw_Team_Database : Form
    {
        private readonly DataGridView Teams_dataGridView;

        public Raw_Team_Database(DataGridView Teams_dataGridView)
        {
            InitializeComponent();
            this.Teams_dataGridView = Teams_dataGridView;
        }

        private void Raw_Team_Database_Load(object sender, EventArgs e)
        {
            DataTable? dt = null;

            try
            {
                dt = new DataTable();

                dt.Columns.Add("Index", typeof(int));
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Team Enabled", typeof(bool));
                dt.Columns.Add("Full Name", typeof(string));
                dt.Columns.Add("Short Name", typeof(string));
                dt.Columns.Add("Nickname", typeof(string));
                dt.Columns.Add("Hud Name", typeof(string));
                dt.Columns.Add("Logo", typeof(string));
                dt.Columns.Add("Primary R Colour", typeof(byte));
                dt.Columns.Add("Primary G Colour", typeof(byte));
                dt.Columns.Add("Primary B Colour", typeof(byte));
                dt.Columns.Add("Secondary R Colour", typeof(byte));
                dt.Columns.Add("Secondary G Colour", typeof(byte));
                dt.Columns.Add("Secondary B Colour", typeof(byte));
                dt.Columns.Add("Hud Text R Colour", typeof(byte));
                dt.Columns.Add("Hud Text G Colour", typeof(byte));
                dt.Columns.Add("Hud Text B Colour", typeof(byte));
                dt.Columns.Add("Team Type", typeof(int));
                dt.Columns.Add("Affiliations", typeof(int));
                dt.Columns.Add("Commentary Team Hash", typeof(uint));
                dt.Columns.Add("World Cup Team", typeof(bool));

                for (int i = 0; i < Global.team_amount; i++)
                {
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["Index"] = i;
                    dt.Rows[dt.Rows.Count - 1]["Id"] = Global.team[i].id;
                    dt.Rows[dt.Rows.Count - 1]["Team Enabled"] = Global.team[i].teamEnabled;
                    dt.Rows[dt.Rows.Count - 1]["Full Name"] = Global.team[i].fullName;
                    dt.Rows[dt.Rows.Count - 1]["Short Name"] = Global.team[i].shortName;
                    dt.Rows[dt.Rows.Count - 1]["Nickname"] = Global.team[i].nickname;
                    dt.Rows[dt.Rows.Count - 1]["Hud Name"] = Global.team[i].hudName;
                    dt.Rows[dt.Rows.Count - 1]["Logo"] = Global.team[i].logo;
                    dt.Rows[dt.Rows.Count - 1]["Primary R Colour"] = Global.team[i].primaryColour.r;
                    dt.Rows[dt.Rows.Count - 1]["Primary G Colour"] = Global.team[i].primaryColour.g;
                    dt.Rows[dt.Rows.Count - 1]["Primary B Colour"] = Global.team[i].primaryColour.b;
                    dt.Rows[dt.Rows.Count - 1]["Secondary R Colour"] = Global.team[i].secondaryColour.r;
                    dt.Rows[dt.Rows.Count - 1]["Secondary G Colour"] = Global.team[i].secondaryColour.g;
                    dt.Rows[dt.Rows.Count - 1]["Secondary B Colour"] = Global.team[i].secondaryColour.b;
                    dt.Rows[dt.Rows.Count - 1]["Hud Text R Colour"] = Global.team[i].hudTextColour.r;
                    dt.Rows[dt.Rows.Count - 1]["Hud Text G Colour"] = Global.team[i].hudTextColour.g;
                    dt.Rows[dt.Rows.Count - 1]["Hud Text B Colour"] = Global.team[i].hudTextColour.b;
                    dt.Rows[dt.Rows.Count - 1]["Team Type"] = Global.team[i].clubType;
                    dt.Rows[dt.Rows.Count - 1]["Affiliations"] = Global.team[i].affiliations;
                    dt.Rows[dt.Rows.Count - 1]["Commentary Team Hash"] = Global.team[i].commentaryTeamHash.ToString();
                    dt.Rows[dt.Rows.Count - 1]["World Cup Team"] = Global.team[i].WorldCupTeam;
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

            for (int i = 0; i < Global.team_amount; i++)
            {
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].id = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].teamEnabled = Convert.ToBoolean(dataGridView1.Rows[i].Cells[2].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].fullNameSize = Convert.ToByte(dataGridView1.Rows[i].Cells[3].Value.ToString().Length);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].fullName = dataGridView1.Rows[i].Cells[3].Value.ToString();
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].shortNameSize = Convert.ToByte(dataGridView1.Rows[i].Cells[4].Value.ToString().Length);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].shortName = dataGridView1.Rows[i].Cells[4].Value.ToString();
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].nicknameSize = Convert.ToByte(dataGridView1.Rows[i].Cells[5].Value.ToString().Length);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].nickname = dataGridView1.Rows[i].Cells[5].Value.ToString();
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].hudNameSize = Convert.ToByte(dataGridView1.Rows[i].Cells[6].Value.ToString().Length);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].hudName = dataGridView1.Rows[i].Cells[6].Value.ToString();
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].primaryColour.r = Convert.ToByte(dataGridView1.Rows[i].Cells[7].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].primaryColour.g = Convert.ToByte(dataGridView1.Rows[i].Cells[8].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].primaryColour.b = Convert.ToByte(dataGridView1.Rows[i].Cells[9].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].secondaryColour.r = Convert.ToByte(dataGridView1.Rows[i].Cells[10].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].secondaryColour.g = Convert.ToByte(dataGridView1.Rows[i].Cells[11].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].secondaryColour.b = Convert.ToByte(dataGridView1.Rows[i].Cells[12].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].hudTextColour.r = Convert.ToByte(dataGridView1.Rows[i].Cells[13].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].hudTextColour.g = Convert.ToByte(dataGridView1.Rows[i].Cells[14].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].hudTextColour.b = Convert.ToByte(dataGridView1.Rows[i].Cells[15].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].clubType = Convert.ToInt32(dataGridView1.Rows[i].Cells[16].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].affiliations = Convert.ToInt32(dataGridView1.Rows[i].Cells[17].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].commentaryTeamHash = Convert.ToUInt32(dataGridView1.Rows[i].Cells[18].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].WorldCupTeam = Convert.ToBoolean(dataGridView1.Rows[i].Cells[19].Value);

                toolStripProgressBar1.Maximum = dataGridView1.Rows.Count;
                toolStripProgressBar1.Value = (i);
                toolStripProgressBar1.PerformStep();
            }

            RefreshList.Update_TeamList(Teams_dataGridView);
            toolStripProgressBar1.Value = 0;
            MessageBox.Show("Changers have been saved to this team", "Save Changers Is Complete :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            SaveChangers();
        }
    }
}