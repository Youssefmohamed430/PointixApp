namespace PointixApp.Forms
{
    partial class UserManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManagement));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel3 = new Panel();
            RefreshiconButton2 = new FontAwesome.Sharp.IconButton();
            label21 = new Label();
            iconButton3 = new FontAwesome.Sharp.IconButton();
            iconButton11 = new FontAwesome.Sharp.IconButton();
            textBox1 = new TextBox();
            iconButton8 = new FontAwesome.Sharp.IconButton();
            iconButton7 = new FontAwesome.Sharp.IconButton();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            NotificationPanel = new Panel();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.Controls.Add(RefreshiconButton2);
            panel3.Controls.Add(label21);
            panel3.Controls.Add(iconButton3);
            panel3.Controls.Add(iconButton11);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(iconButton8);
            panel3.Controls.Add(iconButton7);
            resources.ApplyResources(panel3, "panel3");
            panel3.Name = "panel3";
            panel3.Paint += panel3_Paint;
            // 
            // RefreshiconButton2
            // 
            RefreshiconButton2.BackColor = Color.Transparent;
            RefreshiconButton2.FlatAppearance.BorderColor = Color.FromArgb(88, 86, 214);
            RefreshiconButton2.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(RefreshiconButton2, "RefreshiconButton2");
            RefreshiconButton2.ForeColor = Color.White;
            RefreshiconButton2.IconChar = FontAwesome.Sharp.IconChar.Refresh;
            RefreshiconButton2.IconColor = Color.FromArgb(22, 100, 192);
            RefreshiconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            RefreshiconButton2.IconSize = 30;
            RefreshiconButton2.Name = "RefreshiconButton2";
            RefreshiconButton2.UseVisualStyleBackColor = false;
            RefreshiconButton2.Click += RefreshiconButton2_Click_1;
            // 
            // label21
            // 
            resources.ApplyResources(label21, "label21");
            label21.ForeColor = Color.FromArgb(22, 100, 192);
            label21.Name = "label21";
            // 
            // iconButton3
            // 
            resources.ApplyResources(iconButton3, "iconButton3");
            iconButton3.BackColor = Color.Transparent;
            iconButton3.FlatAppearance.BorderColor = Color.FromArgb(88, 86, 214);
            iconButton3.FlatAppearance.BorderSize = 0;
            iconButton3.IconChar = FontAwesome.Sharp.IconChar.Bell;
            iconButton3.IconColor = Color.FromArgb(22, 100, 192);
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Regular;
            iconButton3.IconSize = 30;
            iconButton3.Name = "iconButton3";
            iconButton3.UseVisualStyleBackColor = false;
            iconButton3.Click += iconButton3_Click;
            // 
            // iconButton11
            // 
            iconButton11.BackColor = Color.FromArgb(22, 100, 192);
            iconButton11.FlatAppearance.BorderColor = Color.FromArgb(88, 86, 214);
            iconButton11.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(iconButton11, "iconButton11");
            iconButton11.ForeColor = Color.White;
            iconButton11.IconChar = FontAwesome.Sharp.IconChar.Search;
            iconButton11.IconColor = Color.White;
            iconButton11.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton11.IconSize = 20;
            iconButton11.Name = "iconButton11";
            iconButton11.UseVisualStyleBackColor = false;
            iconButton11.Click += iconButton11_Click;
            // 
            // textBox1
            // 
            resources.ApplyResources(textBox1, "textBox1");
            textBox1.ForeColor = SystemColors.ScrollBar;
            textBox1.Name = "textBox1";
            textBox1.Click += textBox1_Click;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.Leave += textBox1_Leave;
            // 
            // iconButton8
            // 
            iconButton8.BackColor = Color.FromArgb(22, 100, 192);
            iconButton8.FlatAppearance.BorderColor = Color.FromArgb(88, 86, 214);
            iconButton8.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(iconButton8, "iconButton8");
            iconButton8.ForeColor = Color.Transparent;
            iconButton8.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            iconButton8.IconColor = Color.White;
            iconButton8.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton8.IconSize = 23;
            iconButton8.Name = "iconButton8";
            iconButton8.UseVisualStyleBackColor = false;
            iconButton8.Click += iconButton8_Click;
            // 
            // iconButton7
            // 
            resources.ApplyResources(iconButton7, "iconButton7");
            iconButton7.BackColor = Color.Transparent;
            iconButton7.FlatAppearance.BorderColor = Color.FromArgb(88, 86, 214);
            iconButton7.FlatAppearance.BorderSize = 0;
            iconButton7.IconChar = FontAwesome.Sharp.IconChar.Bell;
            iconButton7.IconColor = Color.FromArgb(88, 86, 214);
            iconButton7.IconFont = FontAwesome.Sharp.IconFont.Regular;
            iconButton7.IconSize = 30;
            iconButton7.Name = "iconButton7";
            iconButton7.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 249, 250);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(dataGridView1, "dataGridView1");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = SystemColors.ButtonFace;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.GrayText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.GrayText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Menu;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.Padding = new Padding(10, 8, 10, 8);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(227, 242, 253);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // NotificationPanel
            // 
            resources.ApplyResources(NotificationPanel, "NotificationPanel");
            NotificationPanel.BackColor = Color.WhiteSmoke;
            NotificationPanel.BorderStyle = BorderStyle.FixedSingle;
            NotificationPanel.Name = "NotificationPanel";
            // 
            // UserManagement
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(NotificationPanel);
            Controls.Add(dataGridView1);
            Controls.Add(panel3);
            Controls.Add(label1);
            Name = "UserManagement";
            WindowState = FormWindowState.Maximized;
            Load += UserManagement_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel3;
        private FontAwesome.Sharp.IconButton iconButton11;
        private TextBox textBox1;
        private FontAwesome.Sharp.IconButton iconButton8;
        private FontAwesome.Sharp.IconButton iconButton7;
        private FontAwesome.Sharp.IconButton iconButton3;
        private DataGridView dataGridView1;
        private Label label1;
        private Panel NotificationPanel;
        private Label label21;
        private FontAwesome.Sharp.IconButton RefreshiconButton2;
    }
}