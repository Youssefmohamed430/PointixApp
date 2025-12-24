namespace PointixApp.Forms
{
    partial class Inventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventory));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel3 = new Panel();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            label21 = new Label();
            iconButton11 = new FontAwesome.Sharp.IconButton();
            textBox1 = new TextBox();
            iconButton9 = new FontAwesome.Sharp.IconButton();
            iconButton8 = new FontAwesome.Sharp.IconButton();
            iconButton7 = new FontAwesome.Sharp.IconButton();
            dataGridView1 = new DataGridView();
            NotificationPanel = new Panel();
            label3 = new Label();
            label1 = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.Controls.Add(iconButton2);
            panel3.Controls.Add(label21);
            panel3.Controls.Add(iconButton11);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(iconButton9);
            panel3.Controls.Add(iconButton8);
            panel3.Controls.Add(iconButton7);
            resources.ApplyResources(panel3, "panel3");
            panel3.Name = "panel3";
            panel3.Paint += panel3_Paint;
            // 
            // iconButton2
            // 
            iconButton2.BackColor = Color.Transparent;
            iconButton2.FlatAppearance.BorderColor = Color.FromArgb(88, 86, 214);
            iconButton2.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(iconButton2, "iconButton2");
            iconButton2.ForeColor = Color.White;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.Refresh;
            iconButton2.IconColor = Color.FromArgb(22, 100, 192);
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 30;
            iconButton2.Name = "iconButton2";
            iconButton2.UseVisualStyleBackColor = false;
            iconButton2.Click += iconButton2_Click_1;
            // 
            // label21
            // 
            resources.ApplyResources(label21, "label21");
            label21.ForeColor = Color.FromArgb(22, 100, 192);
            label21.Name = "label21";
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
            textBox1.Leave += textBox1_Leave;
            // 
            // iconButton9
            // 
            iconButton9.BackColor = Color.FromArgb(22, 100, 192);
            iconButton9.FlatAppearance.BorderColor = Color.FromArgb(88, 86, 214);
            iconButton9.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(iconButton9, "iconButton9");
            iconButton9.ForeColor = Color.Transparent;
            iconButton9.IconChar = FontAwesome.Sharp.IconChar.Paperclip;
            iconButton9.IconColor = Color.White;
            iconButton9.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton9.IconSize = 23;
            iconButton9.Name = "iconButton9";
            iconButton9.UseVisualStyleBackColor = false;
            iconButton9.Click += iconButton9_Click;
            // 
            // iconButton8
            // 
            iconButton8.BackColor = Color.FromArgb(22, 100, 192);
            iconButton8.FlatAppearance.BorderColor = Color.FromArgb(88, 86, 214);
            iconButton8.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(iconButton8, "iconButton8");
            iconButton8.ForeColor = Color.Transparent;
            iconButton8.IconChar = FontAwesome.Sharp.IconChar.Add;
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
            iconButton7.IconColor = Color.FromArgb(22, 100, 192);
            iconButton7.IconFont = FontAwesome.Sharp.IconFont.Regular;
            iconButton7.IconSize = 30;
            iconButton7.Name = "iconButton7";
            iconButton7.UseVisualStyleBackColor = false;
            iconButton7.Click += iconButton7_Click;
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
            dataGridView1.CellClick += DataGridView1_CellContentClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // NotificationPanel
            // 
            resources.ApplyResources(NotificationPanel, "NotificationPanel");
            NotificationPanel.BackColor = Color.WhiteSmoke;
            NotificationPanel.BorderStyle = BorderStyle.FixedSingle;
            NotificationPanel.Name = "NotificationPanel";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.ForeColor = SystemColors.ButtonShadow;
            label3.Name = "label3";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // Inventory
            // 
            AcceptButton = iconButton11;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(NotificationPanel);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(panel3);
            Controls.Add(label3);
            Name = "Inventory";
            WindowState = FormWindowState.Maximized;
            Load += Inventory_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel3;
        private FontAwesome.Sharp.IconButton iconButton7;
        private DataGridView dataGridView1;
        private FontAwesome.Sharp.IconButton iconButton8;
        private FontAwesome.Sharp.IconButton iconButton9;
        private TextBox textBox1;
        private FontAwesome.Sharp.IconButton iconButton11;
        private Panel NotificationPanel;
        private Label label1;
        private Label label3;
        private Label label21;
        private FontAwesome.Sharp.IconButton iconButton2;
    }
}