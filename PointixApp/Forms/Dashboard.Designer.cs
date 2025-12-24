namespace PointixApp
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel2 = new Panel();
            NotificationPanel = new Panel();
            SalesTablePanel = new Panel();
            iconButton9 = new FontAwesome.Sharp.IconButton();
            label4 = new Label();
            EndDate = new DateTimePicker();
            label5 = new Label();
            StartDate = new DateTimePicker();
            label3 = new Label();
            iconButton8 = new FontAwesome.Sharp.IconButton();
            iconButton11 = new FontAwesome.Sharp.IconButton();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            panel3 = new Panel();
            RefreshiconButton = new FontAwesome.Sharp.IconButton();
            label21 = new Label();
            iconButton7 = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            panel2.SuspendLayout();
            SalesTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(NotificationPanel);
            panel2.Controls.Add(SalesTablePanel);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(label1);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            panel2.Paint += panel2_Paint;
            // 
            // NotificationPanel
            // 
            resources.ApplyResources(NotificationPanel, "NotificationPanel");
            NotificationPanel.BackColor = Color.WhiteSmoke;
            NotificationPanel.BorderStyle = BorderStyle.FixedSingle;
            NotificationPanel.Name = "NotificationPanel";
            // 
            // SalesTablePanel
            // 
            SalesTablePanel.Controls.Add(iconButton9);
            SalesTablePanel.Controls.Add(label4);
            SalesTablePanel.Controls.Add(EndDate);
            SalesTablePanel.Controls.Add(label5);
            SalesTablePanel.Controls.Add(StartDate);
            SalesTablePanel.Controls.Add(label3);
            SalesTablePanel.Controls.Add(iconButton8);
            SalesTablePanel.Controls.Add(iconButton11);
            SalesTablePanel.Controls.Add(textBox1);
            SalesTablePanel.Controls.Add(dataGridView1);
            resources.ApplyResources(SalesTablePanel, "SalesTablePanel");
            SalesTablePanel.Name = "SalesTablePanel";
            SalesTablePanel.Paint += SalesTablePanel_Paint;
            // 
            // iconButton9
            // 
            iconButton9.BackColor = Color.FromArgb(22, 100, 192);
            iconButton9.FlatAppearance.BorderColor = Color.FromArgb(88, 86, 214);
            iconButton9.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(iconButton9, "iconButton9");
            iconButton9.ForeColor = Color.White;
            iconButton9.IconChar = FontAwesome.Sharp.IconChar.Tasks;
            iconButton9.IconColor = Color.White;
            iconButton9.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton9.IconSize = 20;
            iconButton9.Name = "iconButton9";
            iconButton9.UseVisualStyleBackColor = false;
            iconButton9.Click += iconButton9_Click;
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.ForeColor = SystemColors.ControlDark;
            label4.Name = "label4";
            // 
            // EndDate
            // 
            resources.ApplyResources(EndDate, "EndDate");
            EndDate.Name = "EndDate";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.ForeColor = SystemColors.ControlDark;
            label5.Name = "label5";
            // 
            // StartDate
            // 
            resources.ApplyResources(StartDate, "StartDate");
            StartDate.Name = "StartDate";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.ForeColor = SystemColors.AppWorkspace;
            label3.Name = "label3";
            // 
            // iconButton8
            // 
            iconButton8.BackColor = Color.FromArgb(22, 100, 192);
            iconButton8.FlatAppearance.BorderColor = Color.FromArgb(88, 86, 214);
            iconButton8.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(iconButton8, "iconButton8");
            iconButton8.ForeColor = Color.White;
            iconButton8.IconChar = FontAwesome.Sharp.IconChar.Sliders;
            iconButton8.IconColor = Color.White;
            iconButton8.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton8.IconSize = 20;
            iconButton8.Name = "iconButton8";
            iconButton8.UseVisualStyleBackColor = false;
            iconButton8.Click += iconButton8_Click;
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
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 249, 250);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            resources.ApplyResources(dataGridView1, "dataGridView1");
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
            // panel3
            // 
            panel3.Controls.Add(RefreshiconButton);
            panel3.Controls.Add(label21);
            panel3.Controls.Add(iconButton7);
            resources.ApplyResources(panel3, "panel3");
            panel3.Name = "panel3";
            panel3.Paint += panel3_Paint;
            // 
            // RefreshiconButton
            // 
            RefreshiconButton.BackColor = Color.Transparent;
            RefreshiconButton.FlatAppearance.BorderColor = Color.FromArgb(88, 86, 214);
            RefreshiconButton.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(RefreshiconButton, "RefreshiconButton");
            RefreshiconButton.ForeColor = Color.White;
            RefreshiconButton.IconChar = FontAwesome.Sharp.IconChar.Refresh;
            RefreshiconButton.IconColor = Color.FromArgb(22, 100, 192);
            RefreshiconButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            RefreshiconButton.IconSize = 30;
            RefreshiconButton.Name = "RefreshiconButton";
            RefreshiconButton.UseVisualStyleBackColor = false;
            RefreshiconButton.Click += RefreshiconButton_Click_1;
            // 
            // label21
            // 
            resources.ApplyResources(label21, "label21");
            label21.ForeColor = Color.FromArgb(22, 100, 192);
            label21.Name = "label21";
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
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // Dashboard
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Dashboard";
            WindowState = FormWindowState.Maximized;
            Load += Dashboard_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            SalesTablePanel.ResumeLayout(false);
            SalesTablePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private Label label3;
        private FontAwesome.Sharp.IconButton iconButton7;
        private Panel NotificationPanel;
        private FontAwesome.Sharp.IconButton iconButton11;
        private TextBox textBox1;
        private Panel SalesTablePanel;
        private Label label21;
        private FontAwesome.Sharp.IconButton iconButton8;
        private FontAwesome.Sharp.IconButton RefreshiconButton;
        private FontAwesome.Sharp.IconButton iconButton9;
        private Label label4;
        private DateTimePicker EndDate;
        private Label label5;
        private DateTimePicker StartDate;
    }
}