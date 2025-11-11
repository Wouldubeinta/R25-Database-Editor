namespace R25_Database_Editor
{
    partial class Mainform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            writeDatabaseToolStripMenuItem = new ToolStripMenuItem();
            saveDatabaseToolStripMenuItem = new ToolStripMenuItem();
            compressDatabaseToolStripMenuItem = new ToolStripMenuItem();
            rawDatabasesToolStripMenuItem = new ToolStripMenuItem();
            rawTeamPlayersDBToolStripMenuItem = new ToolStripMenuItem();
            rawTeamLineupDBToolStripMenuItem = new ToolStripMenuItem();
            rawTeamDBToolStripMenuItem = new ToolStripMenuItem();
            rawPlayerDBToolStripMenuItem = new ToolStripMenuItem();
            rawPlayerSkillsDBToolStripMenuItem = new ToolStripMenuItem();
            SearchToolStripTextBox = new ToolStripTextBox();
            searchPlayerToolStripMenuItem = new ToolStripMenuItem();
            databaseQuerysToolStripMenuItem = new ToolStripMenuItem();
            allPlayerStatsToolStripMenuItem = new ToolStripMenuItem();
            aboutDatabaseToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            Progress_toolStripStatusLabel = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            ProgressLabel = new ToolStripStatusLabel();
            toolStripProgressBar1 = new ToolStripProgressBar();
            splitContainer1 = new SplitContainer();
            Teams_dataGridView = new DataGridView();
            Players_dataGridView = new DataGridView();
            Team_contextMenuStrip = new ContextMenuStrip(components);
            ExportCSVTeamList_ToolStripMenuItem = new ToolStripMenuItem();
            exportLeagueTeamListToolStripMenuItem = new ToolStripMenuItem();
            Player_contextMenuStrip = new ContextMenuStrip(components);
            ExportCSVPlayerList_ToolStripMenuItem = new ToolStripMenuItem();
            sfd_CSVExportTeamList = new SaveFileDialog();
            sfd_CSVExportPlayerList = new SaveFileDialog();
            sfd_DATExportTeamList = new SaveFileDialog();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Teams_dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Players_dataGridView).BeginInit();
            Team_contextMenuStrip.SuspendLayout();
            Player_contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, writeDatabaseToolStripMenuItem, rawDatabasesToolStripMenuItem, SearchToolStripTextBox, searchPlayerToolStripMenuItem, databaseQuerysToolStripMenuItem, aboutDatabaseToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1387, 27);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 23);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Image = Properties.Resources.close_16;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(92, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += Exit_ToolStripMenuItem_Click;
            // 
            // writeDatabaseToolStripMenuItem
            // 
            writeDatabaseToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveDatabaseToolStripMenuItem, compressDatabaseToolStripMenuItem });
            writeDatabaseToolStripMenuItem.Name = "writeDatabaseToolStripMenuItem";
            writeDatabaseToolStripMenuItem.Size = new Size(88, 23);
            writeDatabaseToolStripMenuItem.Text = "Save Options";
            // 
            // saveDatabaseToolStripMenuItem
            // 
            saveDatabaseToolStripMenuItem.Image = (Image)resources.GetObject("saveDatabaseToolStripMenuItem.Image");
            saveDatabaseToolStripMenuItem.Name = "saveDatabaseToolStripMenuItem";
            saveDatabaseToolStripMenuItem.Size = new Size(178, 22);
            saveDatabaseToolStripMenuItem.Text = "Save Database";
            saveDatabaseToolStripMenuItem.Click += SaveDatabase_ToolStripMenuItem_Click;
            // 
            // compressDatabaseToolStripMenuItem
            // 
            compressDatabaseToolStripMenuItem.Image = Properties.Resources.winzip;
            compressDatabaseToolStripMenuItem.Name = "compressDatabaseToolStripMenuItem";
            compressDatabaseToolStripMenuItem.Size = new Size(178, 22);
            compressDatabaseToolStripMenuItem.Text = "Compress Database";
            compressDatabaseToolStripMenuItem.Click += CompressDatabase_ToolStripMenuItem_Click;
            // 
            // rawDatabasesToolStripMenuItem
            // 
            rawDatabasesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rawTeamPlayersDBToolStripMenuItem, rawTeamLineupDBToolStripMenuItem, rawTeamDBToolStripMenuItem, rawPlayerDBToolStripMenuItem, rawPlayerSkillsDBToolStripMenuItem });
            rawDatabasesToolStripMenuItem.Name = "rawDatabasesToolStripMenuItem";
            rawDatabasesToolStripMenuItem.Size = new Size(97, 23);
            rawDatabasesToolStripMenuItem.Text = "Raw Databases";
            // 
            // rawTeamPlayersDBToolStripMenuItem
            // 
            rawTeamPlayersDBToolStripMenuItem.Image = Properties.Resources.RawDatabase;
            rawTeamPlayersDBToolStripMenuItem.Name = "rawTeamPlayersDBToolStripMenuItem";
            rawTeamPlayersDBToolStripMenuItem.Size = new Size(186, 22);
            rawTeamPlayersDBToolStripMenuItem.Text = "Raw Team Players DB";
            rawTeamPlayersDBToolStripMenuItem.Click += RawTeamPlayersDB_ToolStripMenuItem_Click;
            // 
            // rawTeamLineupDBToolStripMenuItem
            // 
            rawTeamLineupDBToolStripMenuItem.Image = Properties.Resources.RawDatabase;
            rawTeamLineupDBToolStripMenuItem.Name = "rawTeamLineupDBToolStripMenuItem";
            rawTeamLineupDBToolStripMenuItem.Size = new Size(186, 22);
            rawTeamLineupDBToolStripMenuItem.Text = "Raw Team Lineup DB";
            rawTeamLineupDBToolStripMenuItem.Click += RawTeamLineupDB_ToolStripMenuItem_Click;
            // 
            // rawTeamDBToolStripMenuItem
            // 
            rawTeamDBToolStripMenuItem.Image = Properties.Resources.RawDatabase;
            rawTeamDBToolStripMenuItem.Name = "rawTeamDBToolStripMenuItem";
            rawTeamDBToolStripMenuItem.Size = new Size(186, 22);
            rawTeamDBToolStripMenuItem.Text = "Raw Team DB";
            rawTeamDBToolStripMenuItem.Click += RawTeamDB_ToolStripMenuItem_Click;
            // 
            // rawPlayerDBToolStripMenuItem
            // 
            rawPlayerDBToolStripMenuItem.Image = Properties.Resources.RawDatabase;
            rawPlayerDBToolStripMenuItem.Name = "rawPlayerDBToolStripMenuItem";
            rawPlayerDBToolStripMenuItem.Size = new Size(186, 22);
            rawPlayerDBToolStripMenuItem.Text = "Raw Player DB";
            rawPlayerDBToolStripMenuItem.Click += RawPlayerDB_ToolStripMenuItem_Click;
            // 
            // rawPlayerSkillsDBToolStripMenuItem
            // 
            rawPlayerSkillsDBToolStripMenuItem.Image = Properties.Resources.RawDatabase;
            rawPlayerSkillsDBToolStripMenuItem.Name = "rawPlayerSkillsDBToolStripMenuItem";
            rawPlayerSkillsDBToolStripMenuItem.Size = new Size(186, 22);
            rawPlayerSkillsDBToolStripMenuItem.Text = "Raw Player Skills DB";
            rawPlayerSkillsDBToolStripMenuItem.Click += RawPlayerSkillsDB_ToolStripMenuItem_Click;
            // 
            // SearchToolStripTextBox
            // 
            SearchToolStripTextBox.Alignment = ToolStripItemAlignment.Right;
            SearchToolStripTextBox.Name = "SearchToolStripTextBox";
            SearchToolStripTextBox.Size = new Size(349, 23);
            SearchToolStripTextBox.KeyDown += Search_ToolStripTextBox_KeyDown;
            // 
            // searchPlayerToolStripMenuItem
            // 
            searchPlayerToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            searchPlayerToolStripMenuItem.Name = "searchPlayerToolStripMenuItem";
            searchPlayerToolStripMenuItem.Size = new Size(89, 23);
            searchPlayerToolStripMenuItem.Text = "Search Player";
            searchPlayerToolStripMenuItem.Click += SearchPlayer_ToolStripMenuItem_Click;
            // 
            // databaseQuerysToolStripMenuItem
            // 
            databaseQuerysToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { allPlayerStatsToolStripMenuItem });
            databaseQuerysToolStripMenuItem.Name = "databaseQuerysToolStripMenuItem";
            databaseQuerysToolStripMenuItem.Size = new Size(107, 23);
            databaseQuerysToolStripMenuItem.Text = "Database Querys";
            // 
            // allPlayerStatsToolStripMenuItem
            // 
            allPlayerStatsToolStripMenuItem.Image = Properties.Resources.PlusMinus;
            allPlayerStatsToolStripMenuItem.Name = "allPlayerStatsToolStripMenuItem";
            allPlayerStatsToolStripMenuItem.Size = new Size(151, 22);
            allPlayerStatsToolStripMenuItem.Text = "All Player Stats";
            allPlayerStatsToolStripMenuItem.Click += AllPlayerStats_ToolStripMenuItem_Click;
            // 
            // aboutDatabaseToolStripMenuItem
            // 
            aboutDatabaseToolStripMenuItem.Name = "aboutDatabaseToolStripMenuItem";
            aboutDatabaseToolStripMenuItem.Size = new Size(52, 23);
            aboutDatabaseToolStripMenuItem.Text = "About";
            aboutDatabaseToolStripMenuItem.Click += AboutDatabase_ToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { Progress_toolStripStatusLabel, toolStripStatusLabel2, ProgressLabel, toolStripProgressBar1 });
            statusStrip1.Location = new Point(0, 577);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(1387, 24);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // Progress_toolStripStatusLabel
            // 
            Progress_toolStripStatusLabel.ForeColor = Color.DarkGreen;
            Progress_toolStripStatusLabel.Name = "Progress_toolStripStatusLabel";
            Progress_toolStripStatusLabel.Size = new Size(0, 19);
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(1018, 19);
            toolStripStatusLabel2.Spring = true;
            // 
            // ProgressLabel
            // 
            ProgressLabel.Name = "ProgressLabel";
            ProgressLabel.Size = new Size(0, 19);
            ProgressLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(350, 18);
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 27);
            splitContainer1.Margin = new Padding(4, 3, 4, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(Teams_dataGridView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(Players_dataGridView);
            splitContainer1.Size = new Size(1387, 550);
            splitContainer1.SplitterDistance = 702;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 3;
            // 
            // Teams_dataGridView
            // 
            Teams_dataGridView.AllowUserToAddRows = false;
            Teams_dataGridView.AllowUserToDeleteRows = false;
            Teams_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Teams_dataGridView.Dock = DockStyle.Fill;
            Teams_dataGridView.Location = new Point(0, 0);
            Teams_dataGridView.Margin = new Padding(4, 3, 4, 3);
            Teams_dataGridView.MultiSelect = false;
            Teams_dataGridView.Name = "Teams_dataGridView";
            Teams_dataGridView.ReadOnly = true;
            Teams_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Teams_dataGridView.Size = new Size(702, 550);
            Teams_dataGridView.TabIndex = 0;
            Teams_dataGridView.MouseClick += Team_DataGridView_MouseClick;
            Teams_dataGridView.MouseDoubleClick += Team_DataGridView_DoubleClick;
            // 
            // Players_dataGridView
            // 
            Players_dataGridView.AllowUserToAddRows = false;
            Players_dataGridView.AllowUserToDeleteRows = false;
            Players_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Players_dataGridView.Dock = DockStyle.Fill;
            Players_dataGridView.Location = new Point(0, 0);
            Players_dataGridView.Margin = new Padding(4, 3, 4, 3);
            Players_dataGridView.MultiSelect = false;
            Players_dataGridView.Name = "Players_dataGridView";
            Players_dataGridView.ReadOnly = true;
            Players_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Players_dataGridView.Size = new Size(680, 550);
            Players_dataGridView.TabIndex = 0;
            Players_dataGridView.MouseClick += Players_DataGridView_MouseClick;
            Players_dataGridView.MouseDoubleClick += Players_DataGridView_DoubleClick;
            // 
            // Team_contextMenuStrip
            // 
            Team_contextMenuStrip.Items.AddRange(new ToolStripItem[] { ExportCSVTeamList_ToolStripMenuItem, exportLeagueTeamListToolStripMenuItem });
            Team_contextMenuStrip.Name = "contextMenuStrip1";
            Team_contextMenuStrip.Size = new Size(202, 48);
            Team_contextMenuStrip.Opening += Team_ContextMenuStrip_Opening;
            // 
            // ExportCSVTeamList_ToolStripMenuItem
            // 
            ExportCSVTeamList_ToolStripMenuItem.Image = Properties.Resources.list_16;
            ExportCSVTeamList_ToolStripMenuItem.Name = "ExportCSVTeamList_ToolStripMenuItem";
            ExportCSVTeamList_ToolStripMenuItem.Size = new Size(201, 22);
            ExportCSVTeamList_ToolStripMenuItem.Text = "Export CSV Team List";
            ExportCSVTeamList_ToolStripMenuItem.Click += ExportCSVTeamList_ToolStripMenuItem_Click;
            // 
            // exportLeagueTeamListToolStripMenuItem
            // 
            exportLeagueTeamListToolStripMenuItem.Image = Properties.Resources.list_16;
            exportLeagueTeamListToolStripMenuItem.Name = "exportLeagueTeamListToolStripMenuItem";
            exportLeagueTeamListToolStripMenuItem.Size = new Size(201, 22);
            exportLeagueTeamListToolStripMenuItem.Text = "Export League Team List";
            exportLeagueTeamListToolStripMenuItem.ToolTipText = "Use this TeamList.dat file for the Default League Editor.";
            exportLeagueTeamListToolStripMenuItem.Click += ExportLeagueTeamList_ToolStripMenuItem_Click;
            // 
            // Player_contextMenuStrip
            // 
            Player_contextMenuStrip.Items.AddRange(new ToolStripItem[] { ExportCSVPlayerList_ToolStripMenuItem });
            Player_contextMenuStrip.Name = "contextMenuStrip2";
            Player_contextMenuStrip.Size = new Size(164, 26);
            Player_contextMenuStrip.Opening += Player_ContextMenuStrip_Opening;
            // 
            // ExportCSVPlayerList_ToolStripMenuItem
            // 
            ExportCSVPlayerList_ToolStripMenuItem.Image = Properties.Resources.list_16;
            ExportCSVPlayerList_ToolStripMenuItem.Name = "ExportCSVPlayerList_ToolStripMenuItem";
            ExportCSVPlayerList_ToolStripMenuItem.Size = new Size(163, 22);
            ExportCSVPlayerList_ToolStripMenuItem.Text = "Export Player List";
            ExportCSVPlayerList_ToolStripMenuItem.Click += ExportCSVPlayerList_ToolStripMenuItem_Click;
            // 
            // sfd_CSVExportTeamList
            // 
            sfd_CSVExportTeamList.DefaultExt = "csv";
            sfd_CSVExportTeamList.FileName = "TeamList.csv";
            sfd_CSVExportTeamList.Filter = "Team List CSV (*.csv)|*.csv";
            // 
            // sfd_CSVExportPlayerList
            // 
            sfd_CSVExportPlayerList.DefaultExt = "csv";
            sfd_CSVExportPlayerList.FileName = "PlayerList.csv";
            sfd_CSVExportPlayerList.Filter = "Player List CSV (*.csv)|*.csv";
            // 
            // sfd_DATExportTeamList
            // 
            sfd_DATExportTeamList.DefaultExt = "dat";
            sfd_DATExportTeamList.FileName = "TeamList.dat";
            sfd_DATExportTeamList.Filter = "Team List DAT (*.dat)|*.dat";
            // 
            // Mainform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1387, 601);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Mainform";
            Text = "R25 Database Editor";
            Load += Mainform_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Teams_dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)Players_dataGridView).EndInit();
            Team_contextMenuStrip.ResumeLayout(false);
            Player_contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutDatabaseToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Progress_toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripTextBox SearchToolStripTextBox;
        private System.Windows.Forms.ToolStripMenuItem searchPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawDatabasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawTeamDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawTeamLineupDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawTeamPlayersDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawPlayerDBToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip Team_contextMenuStrip;
        private System.Windows.Forms.ContextMenuStrip Player_contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ExportCSVTeamList_ToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfd_CSVExportTeamList;
        private System.Windows.Forms.ToolStripMenuItem ExportCSVPlayerList_ToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfd_CSVExportPlayerList;
        private System.Windows.Forms.ToolStripStatusLabel ProgressLabel;
        private System.Windows.Forms.ToolStripMenuItem saveDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compressDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawPlayerSkillsDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseQuerysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allPlayerStatsToolStripMenuItem;
        private System.Windows.Forms.DataGridView Teams_dataGridView;
        private System.Windows.Forms.DataGridView Players_dataGridView;
        private SaveFileDialog sfd_DATExportTeamList;
        private ToolStripMenuItem exportLeagueTeamListToolStripMenuItem;
    }
}

