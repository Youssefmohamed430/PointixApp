namespace PointixApp.Forms
{
    partial class Invoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Invoice));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel3 = new Panel();
            RefreshiconButton = new FontAwesome.Sharp.IconButton();
            label21 = new Label();
            iconButton3 = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            iconButton11 = new FontAwesome.Sharp.IconButton();
            textBox1 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label7 = new Label();
            CustomerName = new TextBox();
            panel4 = new Panel();
            NotesTextBox = new TextBox();
            label12 = new Label();
            PaidAmount = new TextBox();
            iconButton7 = new FontAwesome.Sharp.IconButton();
            button1 = new Button();
            totallabel = new Label();
            ItemsPanel = new Panel();
            label8 = new Label();
            label6 = new Label();
            label5 = new Label();
            NotificationPanel = new Panel();
            saveFileDialog1 = new SaveFileDialog();
            panel5 = new Panel();
            button3 = new Button();
            CustomerPhone = new TextBox();
            label2 = new Label();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel4.SuspendLayout();
            ItemsPanel.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.Controls.Add(RefreshiconButton);
            panel3.Controls.Add(label21);
            panel3.Controls.Add(iconButton3);
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
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Controls.Add(iconButton11);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
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
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.ForeColor = SystemColors.AppWorkspace;
            label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            // 
            // CustomerName
            // 
            resources.ApplyResources(CustomerName, "CustomerName");
            CustomerName.ForeColor = Color.LightGray;
            CustomerName.Name = "CustomerName";
            CustomerName.Click += CustomerName_Click;
            CustomerName.Leave += CustomerName_Leave;
            // 
            // panel4
            // 
            panel4.BackColor = Color.WhiteSmoke;
            panel4.Controls.Add(NotesTextBox);
            panel4.Controls.Add(label12);
            panel4.Controls.Add(PaidAmount);
            panel4.Controls.Add(iconButton7);
            panel4.Controls.Add(button1);
            panel4.Controls.Add(totallabel);
            panel4.Controls.Add(ItemsPanel);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(label5);
            resources.ApplyResources(panel4, "panel4");
            panel4.Name = "panel4";
            // 
            // NotesTextBox
            // 
            resources.ApplyResources(NotesTextBox, "NotesTextBox");
            NotesTextBox.ForeColor = SystemColors.ScrollBar;
            NotesTextBox.Name = "NotesTextBox";
            NotesTextBox.Click += NotesTextBox_Click;
            NotesTextBox.TextChanged += NotesTextBox_TextChanged;
            NotesTextBox.Leave += NotesTextBox_Leave;
            // 
            // label12
            // 
            resources.ApplyResources(label12, "label12");
            label12.ForeColor = SystemColors.AppWorkspace;
            label12.Name = "label12";
            // 
            // PaidAmount
            // 
            resources.ApplyResources(PaidAmount, "PaidAmount");
            PaidAmount.ForeColor = SystemColors.ScrollBar;
            PaidAmount.Name = "PaidAmount";
            PaidAmount.Click += PaidAmount_Click;
            PaidAmount.Leave += PaidAmount_Leave;
            // 
            // iconButton7
            // 
            iconButton7.BackColor = Color.FromArgb(22, 100, 192);
            iconButton7.FlatAppearance.BorderColor = Color.FromArgb(88, 86, 214);
            iconButton7.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(iconButton7, "iconButton7");
            iconButton7.ForeColor = SystemColors.ControlLight;
            iconButton7.IconChar = FontAwesome.Sharp.IconChar.Scroll;
            iconButton7.IconColor = SystemColors.ControlLight;
            iconButton7.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton7.IconSize = 25;
            iconButton7.Name = "iconButton7";
            iconButton7.UseVisualStyleBackColor = false;
            iconButton7.Click += iconButton7_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(30, 17, 20);
            button1.FlatAppearance.BorderColor = Color.Brown;
            button1.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(button1, "button1");
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // totallabel
            // 
            resources.ApplyResources(totallabel, "totallabel");
            totallabel.Name = "totallabel";
            // 
            // ItemsPanel
            // 
            resources.ApplyResources(ItemsPanel, "ItemsPanel");
            ItemsPanel.Controls.Add(label8);
            ItemsPanel.Name = "ItemsPanel";
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.ForeColor = SystemColors.AppWorkspace;
            label8.Name = "label8";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.ForeColor = SystemColors.AppWorkspace;
            label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // NotificationPanel
            // 
            resources.ApplyResources(NotificationPanel, "NotificationPanel");
            NotificationPanel.BackColor = Color.WhiteSmoke;
            NotificationPanel.BorderStyle = BorderStyle.FixedSingle;
            NotificationPanel.Name = "NotificationPanel";
            // 
            // panel5
            // 
            panel5.Controls.Add(button3);
            panel5.Controls.Add(CustomerPhone);
            panel5.Controls.Add(label2);
            panel5.Controls.Add(CustomerName);
            panel5.Controls.Add(label7);
            resources.ApplyResources(panel5, "panel5");
            panel5.Name = "panel5";
            // 
            // button3
            // 
            button3.BackColor = Color.Green;
            button3.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(button3, "button3");
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Name = "button3";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // CustomerPhone
            // 
            resources.ApplyResources(CustomerPhone, "CustomerPhone");
            CustomerPhone.ForeColor = Color.LightGray;
            CustomerPhone.Name = "CustomerPhone";
            CustomerPhone.Click += CustomerPhone_Click;
            CustomerPhone.Leave += CustomerPhone_Leave;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.ForeColor = SystemColors.AppWorkspace;
            label2.Name = "label2";
            // 
            // Invoice
            // 
            AcceptButton = iconButton11;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(NotificationPanel);
            Controls.Add(label1);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Name = "Invoice";
            WindowState = FormWindowState.Maximized;
            Load += Invoice_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ItemsPanel.ResumeLayout(false);
            ItemsPanel.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel3;
        private Label label1;
        private Panel panel2;
        private Label label4;
        private Label label3;
        private FontAwesome.Sharp.IconButton iconButton11;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private Panel panel4;
        private Label label6;
        private Label label5;
        private Panel ItemsPanel;
        private Label totallabel;
        private Label label8;
        private Button button1;
        private FontAwesome.Sharp.IconButton iconButton3;
        private Label label7;
        private TextBox CustomerName;
        private Panel NotificationPanel;
        private FontAwesome.Sharp.IconButton iconButton7;
        private SaveFileDialog saveFileDialog1;
        private Label label21;
        private Panel panel5;
        private TextBox CustomerPhone;
        private Label label2;
        private TextBox PaidAmount;
        private Label label12;
        private Button button3;
        private FontAwesome.Sharp.IconButton RefreshiconButton;
        private TextBox NotesTextBox;
    }
}