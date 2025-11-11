namespace R25_Database_Editor
{
    partial class Raw_Team_Players
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Raw_Team_Players));
            statusStrip1 = new StatusStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            importCSVDBToolStripMenuItem = new ToolStripMenuItem();
            exportCSVDBToolStripMenuItem = new ToolStripMenuItem();
            SaveChangers_toolStripDropDownButton = new ToolStripDropDownButton();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripProgressBar1 = new ToolStripProgressBar();
            dataGridView1 = new DataGridView();
            Import_CSV_ofd = new OpenFileDialog();
            Export_CSV_sfd = new SaveFileDialog();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1, SaveChangers_toolStripDropDownButton, toolStripStatusLabel1, toolStripProgressBar1 });
            statusStrip1.Location = new Point(0, 530);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(997, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { importCSVDBToolStripMenuItem, exportCSVDBToolStripMenuItem });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(152, 20);
            toolStripDropDownButton1.Text = "Team Players DB Options";
            // 
            // importCSVDBToolStripMenuItem
            // 
            importCSVDBToolStripMenuItem.Name = "importCSVDBToolStripMenuItem";
            importCSVDBToolStripMenuItem.Size = new Size(152, 22);
            importCSVDBToolStripMenuItem.Text = "Import CSV DB";
            importCSVDBToolStripMenuItem.Click += importCSVDBToolStripMenuItem_Click;
            // 
            // exportCSVDBToolStripMenuItem
            // 
            exportCSVDBToolStripMenuItem.Name = "exportCSVDBToolStripMenuItem";
            exportCSVDBToolStripMenuItem.Size = new Size(152, 22);
            exportCSVDBToolStripMenuItem.Text = "Export CSV DB";
            exportCSVDBToolStripMenuItem.Click += exportCSVDBToolStripMenuItem_Click;
            // 
            // SaveChangers_toolStripDropDownButton
            // 
            SaveChangers_toolStripDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            SaveChangers_toolStripDropDownButton.Image = (Image)resources.GetObject("SaveChangers_toolStripDropDownButton.Image");
            SaveChangers_toolStripDropDownButton.ImageTransparentColor = Color.Magenta;
            SaveChangers_toolStripDropDownButton.Name = "SaveChangers_toolStripDropDownButton";
            SaveChangers_toolStripDropDownButton.Size = new Size(97, 20);
            SaveChangers_toolStripDropDownButton.Text = "Save Changers";
            SaveChangers_toolStripDropDownButton.Click += SaveChangers_toolStripDropDownButton_Click;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(431, 17);
            toolStripStatusLabel1.Spring = true;
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(300, 16);
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(997, 530);
            dataGridView1.TabIndex = 1;
            // 
            // Import_CSV_ofd
            // 
            Import_CSV_ofd.DefaultExt = "csv";
            Import_CSV_ofd.FileName = "TeamPlayersDB.csv";
            Import_CSV_ofd.Filter = "Team Players CSV DB (*.csv)|*.csv";
            // 
            // Export_CSV_sfd
            // 
            Export_CSV_sfd.DefaultExt = "csv";
            Export_CSV_sfd.FileName = "TeamPlayersDB.csv";
            Export_CSV_sfd.Filter = "Team Players CSV DB (*.csv)|*.csv";
            // 
            // Raw_Team_Players
            // 
            ClientSize = new Size(997, 552);
            Controls.Add(dataGridView1);
            Controls.Add(statusStrip1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Raw_Team_Players";
            Text = "Raw Team Players";
            Load += Raw_Team_Players_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripDropDownButton SaveChangers_toolStripDropDownButton;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripMenuItem importCSVDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportCSVDBToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog Import_CSV_ofd;
        private System.Windows.Forms.SaveFileDialog Export_CSV_sfd;
    }
}