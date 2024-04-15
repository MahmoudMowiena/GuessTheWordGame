namespace project1
{
    partial class Lobby
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
            Join_btn = new Button();
            W_Btn = new Button();
            panel1 = new Panel();
            Create_btn = new Button();
            listBox1 = new ListBox();
            Exit_btn = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Join_btn
            // 
            Join_btn.BackColor = Color.SteelBlue;
            Join_btn.Enabled = false;
            Join_btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            Join_btn.ForeColor = SystemColors.ButtonHighlight;
            Join_btn.Location = new Point(870, 5);
            Join_btn.Margin = new Padding(5);
            Join_btn.Name = "Join_btn";
            Join_btn.Size = new Size(282, 133);
            Join_btn.TabIndex = 1;
            Join_btn.Text = "Join";
            Join_btn.UseVisualStyleBackColor = false;
            Join_btn.Click += Join_btn_Click;
            // 
            // W_Btn
            // 
            W_Btn.BackColor = Color.SteelBlue;
            W_Btn.Enabled = false;
            W_Btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            W_Btn.ForeColor = SystemColors.ButtonHighlight;
            W_Btn.Location = new Point(1301, 5);
            W_Btn.Margin = new Padding(5);
            W_Btn.Name = "W_Btn";
            W_Btn.Size = new Size(282, 133);
            W_Btn.TabIndex = 2;
            W_Btn.Text = "Watch";
            W_Btn.UseVisualStyleBackColor = false;
            W_Btn.Click += Watch_btn_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(Create_btn);
            panel1.Controls.Add(listBox1);
            panel1.Controls.Add(W_Btn);
            panel1.Controls.Add(Join_btn);
            panel1.Location = new Point(150, 329);
            panel1.Margin = new Padding(5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1583, 1102);
            panel1.TabIndex = 3;
            // 
            // Create_btn
            // 
            Create_btn.BackColor = Color.SteelBlue;
            Create_btn.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            Create_btn.ForeColor = SystemColors.ButtonHighlight;
            Create_btn.Location = new Point(870, 325);
            Create_btn.Margin = new Padding(5);
            Create_btn.Name = "Create_btn";
            Create_btn.Size = new Size(713, 131);
            Create_btn.TabIndex = 4;
            Create_btn.Text = "Create";
            Create_btn.UseVisualStyleBackColor = false;
            Create_btn.Click += Create_btn_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(0, 0);
            listBox1.Margin = new Padding(5);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(609, 804);
            listBox1.TabIndex = 3;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // Exit_btn
            // 
            Exit_btn.BackColor = Color.SteelBlue;
            Exit_btn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Exit_btn.ForeColor = SystemColors.ButtonHighlight;
            Exit_btn.Location = new Point(1817, 1503);
            Exit_btn.Name = "Exit_btn";
            Exit_btn.Size = new Size(243, 117);
            Exit_btn.TabIndex = 5;
            Exit_btn.Text = "Exit";
            Exit_btn.UseVisualStyleBackColor = false;
            Exit_btn.Click += Exit_btn_Click;
            // 
            // Lobby
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DodgerBlue;
            ClientSize = new Size(2129, 1688);
            Controls.Add(Exit_btn);
            Controls.Add(panel1);
            Margin = new Padding(5);
            Name = "Lobby";
            Text = "RoomInfo";
            WindowState = FormWindowState.Maximized;
            FormClosing += Lobby_FormClosing;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button Join_btn;
        private Button W_Btn;
        private Panel panel1;
        private Button Create_btn;
        private ListBox listBox1;
        private Button Exit_btn;
    }
}