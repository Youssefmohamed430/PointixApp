namespace PointixApp.Forms
{
    partial class AddUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUser));
            iconButton8 = new FontAwesome.Sharp.IconButton();
            label6 = new Label();
            label4 = new Label();
            Password = new TextBox();
            label3 = new Label();
            Name = new TextBox();
            label2 = new Label();
            UserName = new TextBox();
            label1 = new Label();
            comboBox1 = new ComboBox();
            SuspendLayout();
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
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.ForeColor = Color.FromArgb(64, 64, 64);
            label6.Name = "label6";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Name = "label4";
            // 
            // Password
            // 
            resources.ApplyResources(Password, "Password");
            Password.Name = "Password";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Name = "label3";
            // 
            // Name
            // 
            resources.ApplyResources(Name, "Name");
            Name.Name = "Name";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Name = "label2";
            // 
            // UserName
            // 
            resources.ApplyResources(UserName, "UserName");
            UserName.Name = "UserName";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.FromArgb(22, 100, 192);
            label1.Name = "label1";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { resources.GetString("comboBox1.Items"), resources.GetString("comboBox1.Items1") });
            resources.ApplyResources(comboBox1, "comboBox1");
            comboBox1.Name = "comboBox1";
            // 
            // AddUser
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(comboBox1);
            Controls.Add(iconButton8);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(Password);
            Controls.Add(label3);
            Controls.Add(Name);
            Controls.Add(label2);
            Controls.Add(UserName);
            Controls.Add(label1);
            Name.Text = "AddUser";
            Load += AddUser_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton iconButton8;
        private Label label6;
        private Label label4;
        private TextBox Password;
        private Label label3;
        private TextBox Name;
        private Label label2;
        private TextBox UserName;
        private Label label1;
        private ComboBox comboBox1;
    }
}