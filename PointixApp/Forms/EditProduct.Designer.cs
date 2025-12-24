namespace PointixApp.Forms
{
    partial class EditProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditProduct));
            iconButton8 = new FontAwesome.Sharp.IconButton();
            label6 = new Label();
            minquapro = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            label5 = new Label();
            label4 = new Label();
            proqua = new TextBox();
            label3 = new Label();
            proprice = new TextBox();
            label2 = new Label();
            ProductName = new TextBox();
            label1 = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // iconButton8
            // 
            resources.ApplyResources(iconButton8, "iconButton8");
            iconButton8.BackColor = Color.FromArgb(22, 100, 192);
            iconButton8.FlatAppearance.BorderColor = Color.FromArgb(88, 86, 214);
            iconButton8.FlatAppearance.BorderSize = 0;
            iconButton8.ForeColor = Color.Transparent;
            iconButton8.IconChar = FontAwesome.Sharp.IconChar.Marker;
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
            // minquapro
            // 
            resources.ApplyResources(minquapro, "minquapro");
            minquapro.Name = "minquapro";
            // 
            // dateTimePicker1
            // 
            resources.ApplyResources(dateTimePicker1, "dateTimePicker1");
            dateTimePicker1.Name = "dateTimePicker1";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.ForeColor = Color.FromArgb(64, 64, 64);
            label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Name = "label4";
            // 
            // proqua
            // 
            resources.ApplyResources(proqua, "proqua");
            proqua.Name = "proqua";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Name = "label3";
            // 
            // proprice
            // 
            resources.ApplyResources(proprice, "proprice");
            proprice.Name = "proprice";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Name = "label2";
            // 
            // ProductName
            // 
            resources.ApplyResources(ProductName, "ProductName");
            ProductName.Name = "ProductName";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.FromArgb(22, 100, 192);
            label1.Name = "label1";
            // 
            // textBox1
            // 
            resources.ApplyResources(textBox1, "textBox1");
            textBox1.ForeColor = SystemColors.ScrollBar;
            textBox1.Name = "textBox1";
            // 
            // EditProduct
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBox1);
            Controls.Add(iconButton8);
            Controls.Add(label6);
            Controls.Add(minquapro);
            Controls.Add(dateTimePicker1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(proqua);
            Controls.Add(label3);
            Controls.Add(proprice);
            Controls.Add(label2);
            Controls.Add(ProductName);
            Controls.Add(label1);
            Name = "EditProduct";
            Load += EditProduct_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton iconButton8;
        private Label label6;
        private TextBox minquapro;
        private DateTimePicker dateTimePicker1;
        private Label label5;
        private Label label4;
        private TextBox proqua;
        private Label label3;
        private TextBox proprice;
        private Label label2;
        private TextBox ProductName;
        private Label label1;
        private TextBox textBox1;
    }
}