namespace WPTHoldem2
{
    partial class EVTable
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
            this.btnStart1 = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnStart2 = new System.Windows.Forms.Button();
            this.btnStart3 = new System.Windows.Forms.Button();
            this.btnStart4 = new System.Windows.Forms.Button();
            this.btnStart5 = new System.Windows.Forms.Button();
            this.btnStart6 = new System.Windows.Forms.Button();
            this.btnStart7 = new System.Windows.Forms.Button();
            this.btnStart8 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStatus3 = new System.Windows.Forms.Label();
            this.lblStatus2 = new System.Windows.Forms.Label();
            this.lblTotalHands = new System.Windows.Forms.Label();
            this.btnAll = new System.Windows.Forms.Button();
            this.lblOverallEV = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart1
            // 
            this.btnStart1.BackColor = System.Drawing.SystemColors.Control;
            this.btnStart1.Location = new System.Drawing.Point(12, 12);
            this.btnStart1.Name = "btnStart1";
            this.btnStart1.Size = new System.Drawing.Size(21, 23);
            this.btnStart1.TabIndex = 1;
            this.btnStart1.Text = "1";
            this.btnStart1.UseVisualStyleBackColor = false;
            this.btnStart1.Click += new System.EventHandler(this.btnStart1_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(3, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(18, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "s1";
            // 
            // btnStart2
            // 
            this.btnStart2.BackColor = System.Drawing.SystemColors.Control;
            this.btnStart2.Location = new System.Drawing.Point(39, 12);
            this.btnStart2.Name = "btnStart2";
            this.btnStart2.Size = new System.Drawing.Size(27, 23);
            this.btnStart2.TabIndex = 3;
            this.btnStart2.Text = "10";
            this.btnStart2.UseVisualStyleBackColor = false;
            this.btnStart2.Click += new System.EventHandler(this.btnStart2_Click);
            // 
            // btnStart3
            // 
            this.btnStart3.BackColor = System.Drawing.SystemColors.Control;
            this.btnStart3.Location = new System.Drawing.Point(72, 12);
            this.btnStart3.Name = "btnStart3";
            this.btnStart3.Size = new System.Drawing.Size(33, 23);
            this.btnStart3.TabIndex = 4;
            this.btnStart3.Text = "100";
            this.btnStart3.UseVisualStyleBackColor = false;
            this.btnStart3.Click += new System.EventHandler(this.btnStart3_Click);
            // 
            // btnStart4
            // 
            this.btnStart4.BackColor = System.Drawing.SystemColors.Control;
            this.btnStart4.Location = new System.Drawing.Point(111, 12);
            this.btnStart4.Name = "btnStart4";
            this.btnStart4.Size = new System.Drawing.Size(42, 23);
            this.btnStart4.TabIndex = 5;
            this.btnStart4.Text = "1,000";
            this.btnStart4.UseVisualStyleBackColor = false;
            this.btnStart4.Click += new System.EventHandler(this.btnStart4_Click);
            // 
            // btnStart5
            // 
            this.btnStart5.BackColor = System.Drawing.SystemColors.Control;
            this.btnStart5.Location = new System.Drawing.Point(159, 12);
            this.btnStart5.Name = "btnStart5";
            this.btnStart5.Size = new System.Drawing.Size(48, 23);
            this.btnStart5.TabIndex = 6;
            this.btnStart5.Text = "10,000";
            this.btnStart5.UseVisualStyleBackColor = false;
            this.btnStart5.Click += new System.EventHandler(this.btnStart5_Click);
            // 
            // btnStart6
            // 
            this.btnStart6.BackColor = System.Drawing.SystemColors.Control;
            this.btnStart6.Location = new System.Drawing.Point(213, 12);
            this.btnStart6.Name = "btnStart6";
            this.btnStart6.Size = new System.Drawing.Size(54, 23);
            this.btnStart6.TabIndex = 7;
            this.btnStart6.Text = "100,000";
            this.btnStart6.UseVisualStyleBackColor = false;
            this.btnStart6.Click += new System.EventHandler(this.btnStart6_Click);
            // 
            // btnStart7
            // 
            this.btnStart7.BackColor = System.Drawing.SystemColors.Control;
            this.btnStart7.Location = new System.Drawing.Point(273, 12);
            this.btnStart7.Name = "btnStart7";
            this.btnStart7.Size = new System.Drawing.Size(63, 23);
            this.btnStart7.TabIndex = 8;
            this.btnStart7.Text = "1,000,000";
            this.btnStart7.UseVisualStyleBackColor = false;
            this.btnStart7.Click += new System.EventHandler(this.btnStart7_Click);
            // 
            // btnStart8
            // 
            this.btnStart8.BackColor = System.Drawing.SystemColors.Control;
            this.btnStart8.Location = new System.Drawing.Point(342, 12);
            this.btnStart8.Name = "btnStart8";
            this.btnStart8.Size = new System.Drawing.Size(69, 23);
            this.btnStart8.TabIndex = 9;
            this.btnStart8.Text = "10,000,000";
            this.btnStart8.UseVisualStyleBackColor = false;
            this.btnStart8.Click += new System.EventHandler(this.btnStart8_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblStatus3);
            this.panel1.Controls.Add(this.lblStatus2);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Location = new System.Drawing.Point(12, 325);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 72);
            this.panel1.TabIndex = 10;
            // 
            // lblStatus3
            // 
            this.lblStatus3.AutoSize = true;
            this.lblStatus3.Location = new System.Drawing.Point(142, 0);
            this.lblStatus3.Name = "lblStatus3";
            this.lblStatus3.Size = new System.Drawing.Size(18, 13);
            this.lblStatus3.TabIndex = 12;
            this.lblStatus3.Text = "s3";
            // 
            // lblStatus2
            // 
            this.lblStatus2.AutoSize = true;
            this.lblStatus2.Location = new System.Drawing.Point(73, 0);
            this.lblStatus2.Name = "lblStatus2";
            this.lblStatus2.Size = new System.Drawing.Size(18, 13);
            this.lblStatus2.TabIndex = 11;
            this.lblStatus2.Text = "s2";
            // 
            // lblTotalHands
            // 
            this.lblTotalHands.AutoSize = true;
            this.lblTotalHands.Location = new System.Drawing.Point(12, 309);
            this.lblTotalHands.Name = "lblTotalHands";
            this.lblTotalHands.Size = new System.Drawing.Size(0, 13);
            this.lblTotalHands.TabIndex = 11;
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.SystemColors.Control;
            this.btnAll.Location = new System.Drawing.Point(417, 12);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(69, 23);
            this.btnAll.TabIndex = 12;
            this.btnAll.Text = "Do All";
            this.btnAll.UseVisualStyleBackColor = false;
            this.btnAll.Visible = false;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // lblOverallEV
            // 
            this.lblOverallEV.AutoSize = true;
            this.lblOverallEV.Location = new System.Drawing.Point(17, 407);
            this.lblOverallEV.Name = "lblOverallEV";
            this.lblOverallEV.Size = new System.Drawing.Size(35, 13);
            this.lblOverallEV.TabIndex = 13;
            this.lblOverallEV.Text = "label1";
            // 
            // EVTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(494, 445);
            this.Controls.Add(this.lblOverallEV);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.lblTotalHands);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnStart8);
            this.Controls.Add(this.btnStart7);
            this.Controls.Add(this.btnStart6);
            this.Controls.Add(this.btnStart5);
            this.Controls.Add(this.btnStart4);
            this.Controls.Add(this.btnStart3);
            this.Controls.Add(this.btnStart2);
            this.Controls.Add(this.btnStart1);
            this.Name = "EVTable";
            this.Text = "EVTable";
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.EVTable_MouseDoubleClick);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EVTable_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EVTable_MouseMove);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnStart2;
        private System.Windows.Forms.Button btnStart3;
        private System.Windows.Forms.Button btnStart4;
        private System.Windows.Forms.Button btnStart5;
        private System.Windows.Forms.Button btnStart6;
        private System.Windows.Forms.Button btnStart7;
        private System.Windows.Forms.Button btnStart8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStatus3;
        private System.Windows.Forms.Label lblStatus2;
        private System.Windows.Forms.Label lblTotalHands;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Label lblOverallEV;
    }
}