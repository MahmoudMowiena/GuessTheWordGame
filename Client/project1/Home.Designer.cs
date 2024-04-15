namespace project1
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            Start_btn = new Button();
            SuspendLayout();
            // 
            // Start_btn
            // 
            Start_btn.BackColor = Color.DodgerBlue;
            Start_btn.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            Start_btn.ForeColor = SystemColors.Control;
            Start_btn.Location = new Point(850, 850);
            Start_btn.Name = "Start_btn";
            Start_btn.Size = new Size(200, 50);
            Start_btn.TabIndex = 0;
            Start_btn.Text = "Start";
            Start_btn.UseVisualStyleBackColor = false;
            Start_btn.Click += Start_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1193, 972);
            Controls.Add(Start_btn);
            DoubleBuffered = true;
            Name = "Home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }

        #endregion

        private Button Start_btn;
    }
}
