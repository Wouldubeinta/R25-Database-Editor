namespace R25_Database_Editor
{
    partial class Raw_Player_Skills
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Raw_Player_Skills));
            dataGridView1 = new DataGridView();
            statusStrip1 = new StatusStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            importCSVDBToolStripMenuItem = new ToolStripMenuItem();
            exportCSVDBToolStripMenuItem = new ToolStripMenuItem();
            Save_Changers_toolStripDropDownButton = new ToolStripDropDownButton();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripProgressBar1 = new ToolStripProgressBar();
            Export_CSV_sfd = new SaveFileDialog();
            Import_CSV_ofd = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
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
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1, Save_Changers_toolStripDropDownButton, toolStripStatusLabel1, toolStripProgressBar1 });
            statusStrip1.Location = new Point(0, 530);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(997, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { importCSVDBToolStripMenuItem, exportCSVDBToolStripMenuItem });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(144, 20);
            toolStripDropDownButton1.Text = "Player Skills DB Options";
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
            // Save_Changers_toolStripDropDownButton
            // 
            Save_Changers_toolStripDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            Save_Changers_toolStripDropDownButton.Image = (Image)resources.GetObject("Save_Changers_toolStripDropDownButton.Image");
            Save_Changers_toolStripDropDownButton.ImageTransparentColor = Color.Magenta;
            Save_Changers_toolStripDropDownButton.Name = "Save_Changers_toolStripDropDownButton";
            Save_Changers_toolStripDropDownButton.Size = new Size(97, 20);
            Save_Changers_toolStripDropDownButton.Text = "Save Changers";
            Save_Changers_toolStripDropDownButton.Click += Save_Changers_toolStripDropDownButton_Click;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(439, 17);
            toolStripStatusLabel1.Spring = true;
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Alignment = ToolStripItemAlignment.Right;
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(300, 16);
            // 
            // Export_CSV_sfd
            // 
            Export_CSV_sfd.DefaultExt = "csv";
            Export_CSV_sfd.FileName = "PlayerSkillsDB.csv";
            Export_CSV_sfd.Filter = "Player Skills CSV DB (*.csv)|*.csv";
            // 
            // Import_CSV_ofd
            // 
            Import_CSV_ofd.DefaultExt = "csv";
            Import_CSV_ofd.FileName = "PlayerSkillsDB.csv";
            Import_CSV_ofd.Filter = "Player Skills CSV DB (*.csv)|*.csv";
            // 
            // Raw_Player_Skills
            // 
            ClientSize = new Size(997, 552);
            Controls.Add(dataGridView1);
            Controls.Add(statusStrip1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Raw_Player_Skills";
            Text = "Raw Player Skills Database";
            Load += Raw_Player_Skills_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripDropDownButton Save_Changers_toolStripDropDownButton;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripMenuItem importCSVDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportCSVDBToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog Export_CSV_sfd;
        private System.Windows.Forms.OpenFileDialog Import_CSV_ofd;
    }
}