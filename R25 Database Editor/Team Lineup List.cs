using System.Data;

namespace R25_Database_Editor
{
    public partial class Team_Lineup_List : Form
    {
        private readonly DataGridView? Lineup_DataGridView;
        private readonly int Team_Index;

        public Team_Lineup_List(DataGridView? Lineup_DataGridView, int Team_Index)
        {
            InitializeComponent();
            this.Lineup_DataGridView = Lineup_DataGridView;
            this.Team_Index = Team_Index;
        }

        private void Team_Union_Lineup_List_Load(object sender, EventArgs e)
        {
            TeamLineup();
        }

        private void TeamLineup()
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

                for (int i = 0; i < Global.team[Team_Index].playerAmount; i++)
                {
                    int SelectedIndex = SearchID.PlayersIndex(Global.team[Team_Index].players[i].playerId);
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["Index"] = i;
                    dt.Rows[dt.Rows.Count - 1]["Player Id"] = Global.player[SelectedIndex].id;
                    dt.Rows[dt.Rows.Count - 1]["Rating"] = Rating.PlayerRating(SelectedIndex);
                    dt.Rows[dt.Rows.Count - 1]["First Name"] = Global.player[SelectedIndex].firstName;
                    dt.Rows[dt.Rows.Count - 1]["Last Name"] = Global.player[SelectedIndex].lastName;
                    dt.Rows[dt.Rows.Count - 1]["Primary Role"] = StringArrays.ShortRoles[Global.player[SelectedIndex].primaryRole];
                    dt.Rows[dt.Rows.Count - 1]["Secondary Role"] = StringArrays.ShortRoles[Global.player[SelectedIndex].secondaryRole];
                    dt.Rows[dt.Rows.Count - 1]["Tertiary Role"] = StringArrays.ShortRoles[Global.player[SelectedIndex].tertiaryRole];
                }

                dataGridView.DataSource = dt;
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
                //dt.Columns.Add("Shirt Number", typeof(byte));
                dt.Columns.Add("Player Id", typeof(int));
                dt.Columns.Add("First Name", typeof(string));
                dt.Columns.Add("Last Name", typeof(string));
                dt.Columns.Add("Primary Role", typeof(string));
                dt.Columns.Add("Secondary Role", typeof(string));
                dt.Columns.Add("Tertiary Role", typeof(string));

                if (Lineup_DataGridView.Rows.Count != 0)
                {
                    for (int i = 0; i < Global.MIN_PLAYERS_PER_TEAM; i++)
                    {
                        int SelectedIndex = SearchID.PlayersIndex(Global.team[Team_Index].unionLineups[i].unionLineupId);
                        dt.Rows.Add();
                        dt.Rows[dt.Rows.Count - 1]["Position"] = StringArrays.Positions[i];
                        //dt.Rows[dt.Rows.Count - 1]["Shirt Number"] = Global.team[Team_Index].unionLineups[i].shirtNumber;
                        dt.Rows[dt.Rows.Count - 1]["Player Id"] = Global.player[SelectedIndex].id;
                        dt.Rows[dt.Rows.Count - 1]["First Name"] = Global.player[SelectedIndex].firstName;
                        dt.Rows[dt.Rows.Count - 1]["Last Name"] = Global.player[SelectedIndex].lastName;
                        dt.Rows[dt.Rows.Count - 1]["Primary Role"] = StringArrays.ShortRoles[Global.player[SelectedIndex].primaryRole];
                        dt.Rows[dt.Rows.Count - 1]["Secondary Role"] = StringArrays.ShortRoles[Global.player[SelectedIndex].secondaryRole];
                        dt.Rows[dt.Rows.Count - 1]["Tertiary Role"] = StringArrays.ShortRoles[Global.player[SelectedIndex].tertiaryRole];
                    }
                }

                Lineup_DataGridView.DataSource = dt;

                for (int i = 0; i < Lineup_DataGridView.Columns.Count; i++)
                {
                    Lineup_DataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void DataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView.Rows.Count > 0)
            {
                int index1 = dataGridView.CurrentCell.RowIndex;
                int index2 = Lineup_DataGridView.CurrentCell.RowIndex;

                Global.team[Team_Index].unionLineups[index2].unionLineupId = Convert.ToInt32(dataGridView.Rows[index1].Cells[1].Value);

                Lineup();

                if (index2 != 16)
                {
                    Lineup_DataGridView.Rows[index2 + 1].Selected = true;
                    Lineup_DataGridView.Focus();
                    Lineup_DataGridView.CurrentCell = Lineup_DataGridView.Rows[index2 + 1].Cells[0];
                    Lineup_DataGridView.Rows[index2 + 1].Visible = true;
                }
            }
        }
    }
}
