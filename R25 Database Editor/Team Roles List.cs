using System.Data;

namespace R25_Database_Editor
{
    public partial class Team_Roles_List : Form
    {
        private readonly DataGridView? Roles_DataGridView;
        private readonly int TeamIndex;

        public Team_Roles_List(DataGridView? Roles_DataGridView, int TeamIndex)
        {
            InitializeComponent();
            this.Roles_DataGridView = Roles_DataGridView;
            this.TeamIndex = TeamIndex;
        }

        private void Team_Roles_List_Load(object sender, EventArgs e)
        {
            TeamRoles();
        }

        private void TeamRoles()
        {
            DataTable? dt = null;

            try
            {
                dt = new DataTable();
                dt.Columns.Add("Position", typeof(string));
                dt.Columns.Add("Player Id", typeof(int));
                dt.Columns.Add("Rating", typeof(int));
                dt.Columns.Add("First Name", typeof(string));
                dt.Columns.Add("Last Name", typeof(string));
                dt.Columns.Add("Primary Role", typeof(string));
                dt.Columns.Add("Secondary Role", typeof(string));
                dt.Columns.Add("Tertiary Role", typeof(string));

                for (int i = 0; i < 23; i++)
                {
                    int SelectedIndex = SearchID.PlayersIndex(Global.team[TeamIndex].unionLineups[i].unionLineupId);
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["Position"] = StringArrays.Positions[i];
                    dt.Rows[dt.Rows.Count - 1]["Player Id"] = Global.player[SelectedIndex].id;
                    dt.Rows[dt.Rows.Count - 1]["Rating"] = Rating.PlayerRating(SelectedIndex);
                    dt.Rows[dt.Rows.Count - 1]["First Name"] = Global.player[SelectedIndex].firstName;
                    dt.Rows[dt.Rows.Count - 1]["Last Name"] = Global.player[SelectedIndex].lastName;
                    dt.Rows[dt.Rows.Count - 1]["Primary Role"] = StringArrays.ShortRoles[Global.player[SelectedIndex].primaryRole];
                    dt.Rows[dt.Rows.Count - 1]["Secondary Role"] = StringArrays.ShortRoles[Global.player[SelectedIndex].secondaryRole];
                    dt.Rows[dt.Rows.Count - 1]["Tertiary Role"] = StringArrays.ShortRoles[Global.player[SelectedIndex].tertiaryRole];
                }

                dataGridView.DataSource = dt;

                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void PlayerRoles()
        {
            DataTable? dt = null;

            try
            {
                string[] PlyRoles = ["Captain", "GoalKicker", "PlayMaker1", "PlayMaker2"];

                dt = new DataTable();

                dt.Columns.Add("Roles", typeof(string));
                dt.Columns.Add("Player Id", typeof(int));
                dt.Columns.Add("First Name", typeof(string));
                dt.Columns.Add("Last Name", typeof(string));
                dt.Columns.Add("Primary Role", typeof(string));
                dt.Columns.Add("Secondary Role", typeof(string));
                dt.Columns.Add("Tertiary Role", typeof(string));

                if (Roles_DataGridView.Rows.Count != 0)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        int SelectedIndex = SearchID.PlayersIndex(Global.team[TeamIndex].unionRoles[i].unionRoleId);
                        dt.Rows.Add();
                        dt.Rows[dt.Rows.Count - 1]["Roles"] = PlyRoles[i];
                        dt.Rows[dt.Rows.Count - 1]["Player Id"] = Global.player[SelectedIndex].id;
                        dt.Rows[dt.Rows.Count - 1]["First Name"] = Global.player[SelectedIndex].firstName;
                        dt.Rows[dt.Rows.Count - 1]["Last Name"] = Global.player[SelectedIndex].lastName;
                        dt.Rows[dt.Rows.Count - 1]["Primary Role"] = StringArrays.ShortRoles[Global.player[SelectedIndex].primaryRole];
                        dt.Rows[dt.Rows.Count - 1]["Secondary Role"] = StringArrays.ShortRoles[Global.player[SelectedIndex].secondaryRole];
                        dt.Rows[dt.Rows.Count - 1]["Tertiary Role"] = StringArrays.ShortRoles[Global.player[SelectedIndex].tertiaryRole];
                    }
                }

                Roles_DataGridView.DataSource = dt;

                for (int i = 0; i < Roles_DataGridView.Columns.Count; i++)
                {
                    Roles_DataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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
                int index2 = Roles_DataGridView.CurrentCell.RowIndex;

                Global.team[TeamIndex].unionRoles[index2].unionRoleId = Convert.ToInt32(dataGridView.Rows[index1].Cells[1].Value);

                PlayerRoles();

                if (index2 != 3)
                {
                    Roles_DataGridView.Rows[index2 + 1].Selected = true;
                    Roles_DataGridView.Focus();
                    Roles_DataGridView.CurrentCell = Roles_DataGridView.Rows[index2 + 1].Cells[0];
                    Roles_DataGridView.Rows[index2 + 1].Visible = true;
                }
            }
        }
    }
}
