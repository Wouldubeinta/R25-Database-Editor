namespace R25_Database_Editor
{
    partial class Raw_Team_Database
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Raw_Team_Database));
            statusStrip1 = new StatusStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            importCSVDBToolStripMenuItem = new ToolStripMenuItem();
            exportCSVDBToolStripMenuItem = new ToolStripMenuItem();
            toolStripSplitButton1 = new ToolStripSplitButton();
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
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1, toolStripSplitButton1, toolStripStatusLabel1, toolStripProgressBar1 });
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
            toolStripDropDownButton1.Size = new Size(112, 20);
            toolStripDropDownButton1.Text = "Team DB Options";
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
            // toolStripSplitButton1
            // 
            toolStripSplitButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripSplitButton1.Image = (Image)resources.GetObject("toolStripSplitButton1.Image");
            toolStripSplitButton1.ImageTransparentColor = Color.Magenta;
            toolStripSplitButton1.Name = "toolStripSplitButton1";
            toolStripSplitButton1.Size = new Size(100, 20);
            toolStripSplitButton1.Text = "Save Changers";
            toolStripSplitButton1.ButtonClick += toolStripSplitButton1_ButtonClick;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(468, 17);
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
            dataGridView1.TabIndex = 0;
            // 
            // Import_CSV_ofd
            // 
            Import_CSV_ofd.DefaultExt = "csv";
            Import_CSV_ofd.FileName = "TeamDB.csv";
            Import_CSV_ofd.Filter = "Team CSV DB (*.csv)|*.csv";
            // 
            // Export_CSV_sfd
            // 
            Export_CSV_sfd.DefaultExt = "csv";
            Export_CSV_sfd.FileName = "TeamDB.csv";
            Export_CSV_sfd.Filter = "Team CSV DB (*.csv)|*.csv";
            // 
            // Raw_Team_Database
            // 
            ClientSize = new Size(997, 552);
            Controls.Add(dataGridView1);
            Controls.Add(statusStrip1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Raw_Team_Database";
            Text = "Raw Team Database";
            Load += Raw_Team_Database_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripMenuItem importCSVDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportCSVDBToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog Import_CSV_ofd;
        private System.Windows.Forms.SaveFileDialog Export_CSV_sfd;


    }
}