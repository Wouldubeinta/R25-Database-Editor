using System.Data;

namespace R25_Database_Editor
{
    public partial class Raw_Team_Lineup : Form
    {
        private readonly DataGridView Teams_dataGridView;

        public Raw_Team_Lineup(DataGridView Teams_dataGridView)
        {
            InitializeComponent();
            this.Teams_dataGridView = Teams_dataGridView;
        }

        private void Raw_Team_Lineup_Load(object sender, EventArgs e)
        {
            DataTable? dt = null;

            try
            {
                dt = new DataTable();

                dt.Columns.Add("Index", typeof(int));
                dt.Columns.Add("Team Id", typeof(int));
                dt.Columns.Add("Full Name", typeof(string));
                dt.Columns.Add("Short Name", typeof(string));
                dt.Columns.Add("Team Captain Id", typeof(int));
                dt.Columns.Add("Team GoalKicker Id", typeof(int));
                dt.Columns.Add("Team PlayMaker1 Id", typeof(int));
                dt.Columns.Add("Team PlayMaker2 Id", typeof(int));

                for (int i = 0; i < Global.MIN_PLAYERS_PER_TEAM; i++)
                {
                    dt.Columns.Add(StringArrays.Positions[i], typeof(int));
                }


                for (int i = 0; i < Global.team_amount; i++)
                {
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["Index"] = i;
                    dt.Rows[dt.Rows.Count - 1]["Team Id"] = Global.team[i].id;
                    dt.Rows[dt.Rows.Count - 1]["Full Name"] = Global.team[i].fullName;
                    dt.Rows[dt.Rows.Count - 1]["Short Name"] = Global.team[i].shortName;
                    dt.Rows[dt.Rows.Count - 1]["Team Captain Id"] = Global.team[i].unionRoles[0].unionRoleId;
                    dt.Rows[dt.Rows.Count - 1]["Team GoalKicker Id"] = Global.team[i].unionRoles[1].unionRoleId;
                    dt.Rows[dt.Rows.Count - 1]["Team PlayMaker1 Id"] = Global.team[i].unionRoles[2].unionRoleId;
                    dt.Rows[dt.Rows.Count - 1]["Team PlayMaker2 Id"] = Global.team[i].unionRoles[3].unionRoleId;

                    for (int j = 0; j < Global.MIN_PLAYERS_PER_TEAM; j++)
                    {
                        if (Global.team[i].unionLineups != null)
                            dt.Rows[dt.Rows.Count - 1][StringArrays.Positions[j]] = Global.team[i].unionLineups[j].unionLineupId;
                        else
                            dt.Rows[dt.Rows.Count - 1][StringArrays.Positions[j]] = 0;

                    }
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
                for (int j = 0; j < 4; j++)
                {
                    Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].unionRoles[j].isUnionRoleId = false;
                }

                for (int j = 0; j < 17; j++)
                {
                    Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].unionLineups[j].isUnionLineupId = false;
                }
            }

            for (int i = 0; i < Global.team_amount; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].unionRoles[j].isUnionRoleId = true;
                    Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].unionRoles[j].unionRoleId = Convert.ToInt32(dataGridView1.Rows[i].Cells[j + 4].Value);
                }

                for (int j = 0; j < 17; j++)
                {
                    if (!(dataGridView1.Rows[i].Cells[j + 8].Value is DBNull))
                    {
                        Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].unionLineups[j].isUnionLineupId = true;
                        Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].unionLineups[j].unionLineupId = Convert.ToInt32(dataGridView1.Rows[i].Cells[j + 8].Value);
                    }
                }

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

        private void SaveChangers_toolStripDropDownButton_Click(object sender, EventArgs e)
        {
            SaveChangers();
        }
    }
}