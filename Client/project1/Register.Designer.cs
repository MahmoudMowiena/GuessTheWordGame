namespace project1
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            label1 = new Label();
            label2 = new Label();
            username_textbox = new TextBox();
            Register_btn = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 50F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(750, 9);
            label1.Name = "label1";
            label1.Size = new Size(411, 112);
            label1.TabIndex = 0;
            label1.Text = "Welcome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(570, 300);
            label2.Name = "label2";
            label2.Size = new Size(177, 57);
            label2.TabIndex = 1;
            label2.Text = "Name : ";
            // 
            // username_textbox
            // 
            username_textbox.Font = new Font("Segoe UI", 25F);
            username_textbox.Location = new Point(800, 300);
            username_textbox.Name = "username_textbox";
            username_textbox.Size = new Size(411, 63);
            username_textbox.TabIndex = 2;
            // 
            // Register_btn
            // 
            Register_btn.AccessibleRole = AccessibleRole.None;
            Register_btn.BackColor = Color.SteelBlue;
            Register_btn.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            Register_btn.ForeColor = SystemColors.ButtonHighlight;
            Register_btn.Location = new Point(808, 750);
            Register_btn.Name = "Register_btn";
            Register_btn.Size = new Size(247, 82);
            Register_btn.TabIndex = 3;
            Register_btn.Text = "Register";
            Register_btn.UseVisualStyleBackColor = false;
            Register_btn.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(304, 195);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DodgerBlue;
            ClientSize = new Size(1223, 1055);
            Controls.Add(pictureBox1);
            Controls.Add(Register_btn);
            Controls.Add(username_textbox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Register";
            Text = "Register";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox username_textbox;
        private Button Register_btn;
        private PictureBox pictureBox1;
    }
}