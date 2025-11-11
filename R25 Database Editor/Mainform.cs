using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace R25_Database_Editor
{
    /// <summary>
    /// MainForm.
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
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();

            Global.version = Assembly.GetEntryAssembly().GetName().Version.ToString();
            Global.currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Text = "Rugby 25 Database Editor - " + Global.version;
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            ReadDatabase.Defaultdata_Clubs(Global.currentPath + @"\defaultdata\defaultdata_clubs", Teams_dataGridView);
            ReadDatabase.Defaultdata_Players(Global.currentPath + @"\defaultdata\defaultdata_players", Players_dataGridView);
        }

        private void SaveDatabase_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WriteDatabase.WriteTeamData(Global.currentPath + @"\defaultdata\defaultdata_clubs");
            WriteDatabase.WritePlayerData(Global.currentPath + @"\defaultdata\defaultdata_players");

            toolStripProgressBar1.Value = 0;
            Progress_toolStripStatusLabel.Text = "Databases has finished saving";
            MessageBox.Show("The databases has finished saving", "All Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CompressDatabase_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WriteDatabase.WriteTeamData(Global.currentPath + @"\defaultdata\defaultdata_clubs");
            WriteDatabase.WritePlayerData(Global.currentPath + @"\defaultdata\defaultdata_players");
            M3MP.CreateM3MP(toolStripProgressBar1, ProgressLabel, statusStrip1);

            toolStripProgressBar1.Value = 0;
            Progress_toolStripStatusLabel.Text = "Databases has finished compressing";
            MessageBox.Show("The databases has finished compressing", "All Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Team_DataGridView_DoubleClick(object sender, MouseEventArgs e)
        {
            if (Teams_dataGridView.RowCount != 0)
            {
                Team_Editor form = new(Teams_dataGridView, Players_dataGridView);
                form.Show();
            }
        }

        private void Players_DataGridView_DoubleClick(object sender, MouseEventArgs e)
        {
            if (Players_dataGridView.RowCount != 0)
            {
                Player_Editor form = new(Players_dataGridView);
                form.Show();
            }
        }

        private void Team_DataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (Teams_dataGridView.RowCount != 0)
            {
                int RowIndex = Teams_dataGridView.CurrentCell.RowIndex;
                Global.team_index = Convert.ToInt32(Teams_dataGridView.Rows[RowIndex].Cells[1].Value);
                Global.teamRowIndex = RowIndex;
            }

            if (e.Button == MouseButtons.Right)
                Team_contextMenuStrip.Show(Cursor.Position);
        }

        private void Players_DataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (Players_dataGridView.RowCount != 0)
            {
                int RowIndex = Players_dataGridView.CurrentCell.RowIndex;
                Global.player_index = Convert.ToInt32(Players_dataGridView.Rows[RowIndex].Cells[1].Value);
                Global.playerRowIndex = RowIndex;
            }

            if (e.Button == MouseButtons.Right)
                Player_contextMenuStrip.Show(Cursor.Position);
        }

        private void Team_ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (Teams_dataGridView.RowCount == 0)
                e.Cancel = true;
        }

        private void Player_ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (Players_dataGridView.RowCount == 0)
                e.Cancel = true;
        }

        private void ExportCSVTeamList_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfd_CSVExportTeamList.ShowDialog() == DialogResult.OK)
                CSV.ToCSV(Teams_dataGridView, sfd_CSVExportTeamList.FileName);
        }

        private void ExportCSVPlayerList_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfd_CSVExportPlayerList.ShowDialog() == DialogResult.OK)
                CSV.ToCSV(Players_dataGridView, sfd_CSVExportPlayerList.FileName);
        }

        private void ExportLeagueTeamList_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfd_DATExportTeamList.ShowDialog() == DialogResult.OK)
                IO.ExtractTeamList(sfd_DATExportTeamList.FileName, Teams_dataGridView);
        }

        private void RawTeamPlayersDB_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Raw_Team_Players form = new(Teams_dataGridView);
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Raw Team Players")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (!IsOpen)
                form.Show();
        }

        private void RawTeamLineupDB_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Raw_Team_Lineup form = new(Teams_dataGridView);
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Raw Team Lineup")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (!IsOpen)
                form.Show();
        }

        private void RawTeamDB_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Raw_Team_Database form = new(Teams_dataGridView);
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Raw Team Database")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (!IsOpen)
                form.Show();
        }

        private void RawPlayerDB_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Raw_Player_Database form = new(Players_dataGridView);
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Raw Player Database")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (!IsOpen)
                form.Show();
        }

        private void RawPlayerSkillsDB_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Raw_Player_Skills form = new(Players_dataGridView);
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Raw Player Skills Database")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (!IsOpen)
                form.Show();
        }

        private void AllPlayerStats_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            All_Player_Stats_Querys form = new();
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "All Player Stats Querys")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (!IsOpen)
                form.Show();
        }

        private void Search()
        {
            bool valueResult = true;

            try
            {
                if (SearchToolStripTextBox.Text == string.Empty)
                    return;

                int RowIndex = Players_dataGridView.CurrentCell.RowIndex;
                int RowCount = Players_dataGridView.Rows.Count;
                int index = Players_dataGridView.CurrentCell.RowIndex + 1;

                if (RowIndex == 0)
                    index = 0;

                if (index > RowCount - 1)
                    index = 0;

                for (int j = index; j < RowCount; j++)
                {
                    if ((Players_dataGridView.Rows[j].Cells[3].Value.ToString() + " " + Players_dataGridView.Rows[j].Cells[4].Value.ToString()).Contains(SearchToolStripTextBox.Text))
                    {
                        Players_dataGridView.Focus();
                        Players_dataGridView.Rows[j].Visible = true;
                        Players_dataGridView.Rows[j].Selected = true;
                        Players_dataGridView.CurrentCell = Players_dataGridView.Rows[j].Cells[0];
                        Players_dataGridView.Refresh();
                        valueResult = false;
                        break;
                    }
                }

                if (valueResult)
                {
                    Players_dataGridView.Focus();
                    Players_dataGridView.Rows[0].Visible = true;
                    Players_dataGridView.Rows[0].Selected = true;
                    Players_dataGridView.CurrentCell = Players_dataGridView.Rows[0].Cells[0];
                    Players_dataGridView.Refresh();
                    MessageBox.Show("Could not find player name.", "No Results Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Search_ToolStripTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                Search();
            }
        }

        private void SearchPlayer_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void AboutDatabase_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void Exit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
