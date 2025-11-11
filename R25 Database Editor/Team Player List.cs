using System.Data;

namespace R25_Database_Editor
{
    public partial class Team_Player_List : Form
    {
        private readonly DataGridView? PlayersRoster_DataGridView;
        private readonly int TeamIndex;

        public Team_Player_List(DataGridView? PlayersRoster_DataGridView, int TeamIndex)
        {
            InitializeComponent();
            this.PlayersRoster_DataGridView = PlayersRoster_DataGridView;
            this.TeamIndex = TeamIndex;
        }

        private void Team_Player_List_Load(object sender, EventArgs e)
        {
            OriginalPlayers();
            Gender_toolStripComboBox.SelectedIndex = 2;
        }

        private void OriginalPlayers()
        {
            DataTable? dt = null;

            try
            {
                dt = new DataTable();

                dt.Columns.Add("Index", typeof(int));
                dt.Columns.Add("Player Id", typeof(int));
                dt.Columns.Add("Rating", typeof(int));
                dt.Columns.Add("First Name", typeof(string));
                dt.Columns.Add("Last Name", typeof(string));
                dt.Columns.Add("Primary Role", typeof(string));
                dt.Columns.Add("Secondary Role", typeof(string));
                dt.Columns.Add("Tertiary Role", typeof(string));
                int index = -1;

                for (int i = 0; i < Global.player_amount; i++)
                {
                    if (Global.player[i].gender == Gender_toolStripComboBox.SelectedIndex)
                    {
                        index++;
                        dt.Rows.Add();
                        dt.Rows[dt.Rows.Count - 1]["Index"] = index;
                        dt.Rows[dt.Rows.Count - 1]["Player Id"] = Global.player[i].id;
                        dt.Rows[dt.Rows.Count - 1]["Rating"] = Rating.PlayerRating(i);
                        dt.Rows[dt.Rows.Count - 1]["First Name"] = Global.player[i].firstName;
                        dt.Rows[dt.Rows.Count - 1]["Last Name"] = Global.player[i].lastName;
                        dt.Rows[dt.Rows.Count - 1]["Primary Role"] = StringArrays.ShortRoles[Global.player[i].primaryRole];
                        dt.Rows[dt.Rows.Count - 1]["Secondary Role"] = StringArrays.ShortRoles[Global.player[i].secondaryRole];
                        dt.Rows[dt.Rows.Count - 1]["Tertiary Role"] = StringArrays.ShortRoles[Global.player[i].tertiaryRole];
                    }
                    else if (Gender_toolStripComboBox.SelectedIndex == 2)
                    {
                        index++;
                        dt.Rows.Add();
                        dt.Rows[dt.Rows.Count - 1]["Index"] = index;
                        dt.Rows[dt.Rows.Count - 1]["Player Id"] = Global.player[i].id;
                        dt.Rows[dt.Rows.Count - 1]["Rating"] = Rating.PlayerRating(i);
                        dt.Rows[dt.Rows.Count - 1]["First Name"] = Global.player[i].firstName;
                        dt.Rows[dt.Rows.Count - 1]["Last Name"] = Global.player[i].lastName;
                        dt.Rows[dt.Rows.Count - 1]["Primary Role"] = StringArrays.ShortRoles[Global.player[i].primaryRole];
                        dt.Rows[dt.Rows.Count - 1]["Secondary Role"] = StringArrays.ShortRoles[Global.player[i].secondaryRole];
                        dt.Rows[dt.Rows.Count - 1]["Tertiary Role"] = StringArrays.ShortRoles[Global.player[i].tertiaryRole];
                    }
                }

                dataGridView.DataSource = dt;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            bool valueResult = true;

            try
            {
                dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                int RowIndex = dataGridView.CurrentCell.RowIndex;
                int ColCount = dataGridView.Columns.Count;
                int RowCount = dataGridView.Rows.Count;
                int index = dataGridView.CurrentCell.RowIndex + 1;

                if (RowIndex == 0)
                    index = 0;

                if (index > RowCount - 1)
                    index = 0;

                for (int j = index; j < RowCount; j++)
                {
                    if ((dataGridView.Rows[j].Cells[3].Value.ToString() + " " + dataGridView.Rows[j].Cells[4].Value.ToString()).Contains(toolStripTextBox1.Text))
                    {
                        dataGridView.Rows[j].Selected = true;
                        dataGridView.Focus();
                        dataGridView.CurrentCell = dataGridView.Rows[j].Cells[0];
                        dataGridView.Rows[j].Visible = true;
                        valueResult = false;
                        break;
                    }
                }

                if (valueResult != false)
                {
                    dataGridView.Focus();
                    dataGridView.Rows[0].Visible = true;
                    dataGridView.Rows[0].Selected = true;
                    dataGridView.CurrentCell = dataGridView.Rows[0].Cells[0];
                    dataGridView.Refresh();
                    MessageBox.Show("Could not find player name.", "No Results Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                Search();
        }

        private class MyDataGridView : DataGridView
        {
            protected override void OnKeyDown(KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                    e = new KeyEventArgs(Keys.Tab);
                base.OnKeyDown(e);
            }
        }

        private void Gender_toolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OriginalPlayers();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count > 0 && PlayersRoster_DataGridView.Rows.Count > 0)
            {
                int index1 = dataGridView.CurrentCell.RowIndex;
                int index2 = PlayersRoster_DataGridView.CurrentCell.RowIndex;

                int SelectedIndex = SearchID.PlayersIndex(Convert.ToInt32(dataGridView.Rows[index1].Cells[1].Value));
                Global.team[TeamIndex].players[index2].playerId = Global.player[SelectedIndex].id;

                Players();

                if (index2 != PlayersRoster_DataGridView.Rows.Count - 1)
                {
                    PlayersRoster_DataGridView.Rows[index2 + 1].Selected = true;
                    PlayersRoster_DataGridView.Focus();
                    PlayersRoster_DataGridView.CurrentCell = PlayersRoster_DataGridView.Rows[index2 + 1].Cells[0];
                    PlayersRoster_DataGridView.Rows[index2 + 1].Visible = true;
                }
            }
        }

        private void Players()
        {
            DataTable? Playersdt = null;

            try
            {
                Playersdt = new DataTable();

                Playersdt.Columns.Add("Index", typeof(int));
                Playersdt.Columns.Add("Player Id", typeof(int));
                Playersdt.Columns.Add("First Name", typeof(string));
                Playersdt.Columns.Add("Last Name", typeof(string));
                Playersdt.Columns.Add("Primary Role", typeof(string));
                Playersdt.Columns.Add("Secondary Role", typeof(string));
                Playersdt.Columns.Add("Tertiary Role", typeof(string));


                for (int i = 0; i < Global.team[TeamIndex].playerAmount; i++)
                {
                    int SelectedIndex = SearchID.PlayersIndex(Global.team[TeamIndex].players[i].playerId);
                    Playersdt.Rows.Add();
                    Playersdt.Rows[Playersdt.Rows.Count - 1]["Index"] = i;
                    Playersdt.Rows[Playersdt.Rows.Count - 1]["Player Id"] = Global.player[SelectedIndex].id;
                    Playersdt.Rows[Playersdt.Rows.Count - 1]["First Name"] = Global.player[SelectedIndex].firstName;
                    Playersdt.Rows[Playersdt.Rows.Count - 1]["Last Name"] = Global.player[SelectedIndex].lastName;
                    Playersdt.Rows[Playersdt.Rows.Count - 1]["Primary Role"] = StringArrays.ShortRoles[Global.player[SelectedIndex].primaryRole];
                    Playersdt.Rows[Playersdt.Rows.Count - 1]["Secondary Role"] = StringArrays.ShortRoles[Global.player[SelectedIndex].secondaryRole];
                    Playersdt.Rows[Playersdt.Rows.Count - 1]["Tertiary Role"] = StringArrays.ShortRoles[Global.player[SelectedIndex].tertiaryRole];
                }

                PlayersRoster_DataGridView.DataSource = Playersdt;

                for (int i = 0; i < PlayersRoster_DataGridView.Columns.Count; i++)
                {
                    PlayersRoster_DataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void refreshPlayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OriginalPlayers();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStrip1.Show(Cursor.Position);
        }
    }
}
