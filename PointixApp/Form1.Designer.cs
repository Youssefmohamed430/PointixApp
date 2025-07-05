namespace PointixApp
{
    partial class LogInForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInForm));
            label1 = new Label();
            panel1 = new Panel();
            button2 = new Button();
            panel2 = new Panel();
            PasswordField = new TextBox();
            UserNameField = new TextBox();
            button1 = new Button();
            UserNameLabel = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.CornflowerBlue;
            label1.Location = new Point(379, 29);
            label1.Name = "label1";
            label1.Size = new Size(164, 60);
            label1.TabIndex = 1;
            label1.Text = "Pointix";
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1003, 794);
            panel1.TabIndex = 3;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(773, 12);
            button2.Name = "button2";
            button2.Size = new Size(217, 42);
            button2.TabIndex = 11;
            button2.Text = "Change Language";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(PasswordField);
            panel2.Controls.Add(UserNameField);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(UserNameLabel);
            panel2.Controls.Add(label5);
            panel2.Location = new Point(91, 335);
            panel2.Name = "panel2";
            panel2.Size = new Size(899, 459);
            panel2.TabIndex = 10;
            // 
            // PasswordField
            // 
            PasswordField.BorderStyle = BorderStyle.FixedSingle;
            PasswordField.Location = new Point(326, 196);
            PasswordField.Name = "PasswordField";
            PasswordField.Size = new Size(361, 27);
            PasswordField.TabIndex = 10;
            // 
            // UserNameField
            // 
            UserNameField.BorderStyle = BorderStyle.FixedSingle;
            UserNameField.Location = new Point(326, 81);
            UserNameField.Name = "UserNameField";
            UserNameField.Size = new Size(361, 27);
            UserNameField.TabIndex = 3;
            // 
            // button1
            // 
            button1.BackColor = Color.CornflowerBlue;
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(278, 322);
            button1.Name = "button1";
            button1.Size = new Size(379, 44);
            button1.TabIndex = 9;
            button1.Text = "Log In";
            button1.UseVisualStyleBackColor = false;
            // 
            // UserNameLabel
            // 
            UserNameLabel.AutoSize = true;
            UserNameLabel.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UserNameLabel.Location = new Point(149, 70);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(129, 31);
            UserNameLabel.TabIndex = 6;
            UserNameLabel.Text = "User Name";
            UserNameLabel.Click += UserNameLabel_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(149, 187);
            label5.Name = "label5";
            label5.Size = new Size(112, 31);
            label5.TabIndex = 7;
            label5.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonShadow;
            label3.Location = new Point(91, 253);
            label3.Name = "label3";
            label3.Size = new Size(299, 31);
            label3.TabIndex = 5;
            label3.Text = "Your Store, Fully In Control.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(34, 193);
            label2.Name = "label2";
            label2.Size = new Size(529, 60);
            label2.TabIndex = 4;
            label2.Text = "Welcome to Pointix App";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1009, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(777, 794);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // LogInForm
            // 
            AccessibleRole = AccessibleRole.ScrollBar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1783, 794);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LogInForm";
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LogIn";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Panel panel1;
        private Label label5;
        private Label UserNameLabel;
        private Label label3;
        private Label label2;
        private TextBox UserNameField;
        private Panel panel2;
        private Button button1;
        private TextBox PasswordField;
        private PictureBox pictureBox1;
        private Button button2;
    }
}
