namespace WPTHoldem2
{
    partial class Form1
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
            this.lblImageLocation = new System.Windows.Forms.Label();
            this.nudAnte = new System.Windows.Forms.NumericUpDown();
            this.lblAnte = new System.Windows.Forms.Label();
            this.nudHoleCards = new System.Windows.Forms.NumericUpDown();
            this.nudFinalHand = new System.Windows.Forms.NumericUpDown();
            this.lblHoleCards = new System.Windows.Forms.Label();
            this.lblFinalHand = new System.Windows.Forms.Label();
            this.btnFold = new System.Windows.Forms.Button();
            this.btnRaise = new System.Windows.Forms.Button();
            this.btnAllIn = new System.Windows.Forms.Button();
            this.btnDeal = new System.Windows.Forms.Button();
            this.pbPlayerCard1 = new System.Windows.Forms.PictureBox();
            this.pbPlayerCard2 = new System.Windows.Forms.PictureBox();
            this.pbCommCard1 = new System.Windows.Forms.PictureBox();
            this.pbCommCard2 = new System.Windows.Forms.PictureBox();
            this.pbCommCard3 = new System.Windows.Forms.PictureBox();
            this.pbCommCard4 = new System.Windows.Forms.PictureBox();
            this.pbCommCard5 = new System.Windows.Forms.PictureBox();
            this.pbDealerCard1 = new System.Windows.Forms.PictureBox();
            this.pbDealerCard2 = new System.Windows.Forms.PictureBox();
            this.lblBankrollLabel = new System.Windows.Forms.Label();
            this.lblBankroll = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRebuy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEVTable = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoleCards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFinalHand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCommCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCommCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCommCard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCommCard4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCommCard5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDealerCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDealerCard2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblImageLocation
            // 
            this.lblImageLocation.AutoSize = true;
            this.lblImageLocation.Location = new System.Drawing.Point(12, 320);
            this.lblImageLocation.Name = "lblImageLocation";
            this.lblImageLocation.Size = new System.Drawing.Size(0, 13);
            this.lblImageLocation.TabIndex = 3;
            // 
            // nudAnte
            // 
            this.nudAnte.Location = new System.Drawing.Point(46, 176);
            this.nudAnte.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.nudAnte.Name = "nudAnte";
            this.nudAnte.Size = new System.Drawing.Size(65, 20);
            this.nudAnte.TabIndex = 7;
            this.nudAnte.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudAnte.ValueChanged += new System.EventHandler(this.nudAnte_ValueChanged);
            this.nudAnte.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nudAnte_KeyUp);
            // 
            // lblAnte
            // 
            this.lblAnte.AutoSize = true;
            this.lblAnte.Location = new System.Drawing.Point(5, 178);
            this.lblAnte.Name = "lblAnte";
            this.lblAnte.Size = new System.Drawing.Size(32, 13);
            this.lblAnte.TabIndex = 8;
            this.lblAnte.Text = "Ante:";
            // 
            // nudHoleCards
            // 
            this.nudHoleCards.Location = new System.Drawing.Point(195, 176);
            this.nudHoleCards.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudHoleCards.Name = "nudHoleCards";
            this.nudHoleCards.Size = new System.Drawing.Size(65, 20);
            this.nudHoleCards.TabIndex = 9;
            this.nudHoleCards.ValueChanged += new System.EventHandler(this.nudHoleCards_ValueChanged);
            // 
            // nudFinalHand
            // 
            this.nudFinalHand.Location = new System.Drawing.Point(195, 202);
            this.nudFinalHand.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudFinalHand.Name = "nudFinalHand";
            this.nudFinalHand.Size = new System.Drawing.Size(65, 20);
            this.nudFinalHand.TabIndex = 10;
            this.nudFinalHand.ValueChanged += new System.EventHandler(this.nudFinalHand_ValueChanged);
            // 
            // lblHoleCards
            // 
            this.lblHoleCards.AutoSize = true;
            this.lblHoleCards.Location = new System.Drawing.Point(127, 178);
            this.lblHoleCards.Name = "lblHoleCards";
            this.lblHoleCards.Size = new System.Drawing.Size(62, 13);
            this.lblHoleCards.TabIndex = 11;
            this.lblHoleCards.Text = "Hole Cards:";
            // 
            // lblFinalHand
            // 
            this.lblFinalHand.AutoSize = true;
            this.lblFinalHand.Location = new System.Drawing.Point(127, 204);
            this.lblFinalHand.Name = "lblFinalHand";
            this.lblFinalHand.Size = new System.Drawing.Size(61, 13);
            this.lblFinalHand.TabIndex = 12;
            this.lblFinalHand.Text = "Final Hand:";
            // 
            // btnFold
            // 
            this.btnFold.Location = new System.Drawing.Point(8, 239);
            this.btnFold.Name = "btnFold";
            this.btnFold.Size = new System.Drawing.Size(80, 23);
            this.btnFold.TabIndex = 13;
            this.btnFold.Text = "Fold";
            this.btnFold.UseVisualStyleBackColor = true;
            this.btnFold.Click += new System.EventHandler(this.btnFold_Click);
            // 
            // btnRaise
            // 
            this.btnRaise.Location = new System.Drawing.Point(94, 239);
            this.btnRaise.Name = "btnRaise";
            this.btnRaise.Size = new System.Drawing.Size(80, 23);
            this.btnRaise.TabIndex = 14;
            this.btnRaise.Text = "Raise";
            this.btnRaise.UseVisualStyleBackColor = true;
            this.btnRaise.Click += new System.EventHandler(this.btnRaise_Click);
            // 
            // btnAllIn
            // 
            this.btnAllIn.Location = new System.Drawing.Point(180, 239);
            this.btnAllIn.Name = "btnAllIn";
            this.btnAllIn.Size = new System.Drawing.Size(80, 23);
            this.btnAllIn.TabIndex = 15;
            this.btnAllIn.Text = "All In";
            this.btnAllIn.UseVisualStyleBackColor = true;
            this.btnAllIn.Click += new System.EventHandler(this.btnAllIn_Click);
            // 
            // btnDeal
            // 
            this.btnDeal.Location = new System.Drawing.Point(8, 268);
            this.btnDeal.Name = "btnDeal";
            this.btnDeal.Size = new System.Drawing.Size(252, 32);
            this.btnDeal.TabIndex = 16;
            this.btnDeal.Text = "Deal";
            this.btnDeal.UseVisualStyleBackColor = true;
            this.btnDeal.Click += new System.EventHandler(this.btnDeal_Click);
            // 
            // pbPlayerCard1
            // 
            this.pbPlayerCard1.InitialImage = null;
            this.pbPlayerCard1.Location = new System.Drawing.Point(165, 22);
            this.pbPlayerCard1.Name = "pbPlayerCard1";
            this.pbPlayerCard1.Size = new System.Drawing.Size(105, 147);
            this.pbPlayerCard1.TabIndex = 17;
            this.pbPlayerCard1.TabStop = false;
            // 
            // pbPlayerCard2
            // 
            this.pbPlayerCard2.InitialImage = null;
            this.pbPlayerCard2.Location = new System.Drawing.Point(276, 22);
            this.pbPlayerCard2.Name = "pbPlayerCard2";
            this.pbPlayerCard2.Size = new System.Drawing.Size(105, 147);
            this.pbPlayerCard2.TabIndex = 18;
            this.pbPlayerCard2.TabStop = false;
            // 
            // pbCommCard1
            // 
            this.pbCommCard1.InitialImage = null;
            this.pbCommCard1.Location = new System.Drawing.Point(16, 21);
            this.pbCommCard1.Name = "pbCommCard1";
            this.pbCommCard1.Size = new System.Drawing.Size(105, 147);
            this.pbCommCard1.TabIndex = 19;
            this.pbCommCard1.TabStop = false;
            // 
            // pbCommCard2
            // 
            this.pbCommCard2.InitialImage = null;
            this.pbCommCard2.Location = new System.Drawing.Point(127, 21);
            this.pbCommCard2.Name = "pbCommCard2";
            this.pbCommCard2.Size = new System.Drawing.Size(105, 147);
            this.pbCommCard2.TabIndex = 20;
            this.pbCommCard2.TabStop = false;
            // 
            // pbCommCard3
            // 
            this.pbCommCard3.InitialImage = null;
            this.pbCommCard3.Location = new System.Drawing.Point(238, 21);
            this.pbCommCard3.Name = "pbCommCard3";
            this.pbCommCard3.Size = new System.Drawing.Size(105, 147);
            this.pbCommCard3.TabIndex = 21;
            this.pbCommCard3.TabStop = false;
            // 
            // pbCommCard4
            // 
            this.pbCommCard4.InitialImage = null;
            this.pbCommCard4.Location = new System.Drawing.Point(349, 21);
            this.pbCommCard4.Name = "pbCommCard4";
            this.pbCommCard4.Size = new System.Drawing.Size(105, 147);
            this.pbCommCard4.TabIndex = 22;
            this.pbCommCard4.TabStop = false;
            // 
            // pbCommCard5
            // 
            this.pbCommCard5.InitialImage = null;
            this.pbCommCard5.Location = new System.Drawing.Point(460, 21);
            this.pbCommCard5.Name = "pbCommCard5";
            this.pbCommCard5.Size = new System.Drawing.Size(105, 147);
            this.pbCommCard5.TabIndex = 23;
            this.pbCommCard5.TabStop = false;
            // 
            // pbDealerCard1
            // 
            this.pbDealerCard1.InitialImage = null;
            this.pbDealerCard1.Location = new System.Drawing.Point(18, 20);
            this.pbDealerCard1.Name = "pbDealerCard1";
            this.pbDealerCard1.Size = new System.Drawing.Size(105, 147);
            this.pbDealerCard1.TabIndex = 24;
            this.pbDealerCard1.TabStop = false;
            // 
            // pbDealerCard2
            // 
            this.pbDealerCard2.InitialImage = null;
            this.pbDealerCard2.Location = new System.Drawing.Point(129, 20);
            this.pbDealerCard2.Name = "pbDealerCard2";
            this.pbDealerCard2.Size = new System.Drawing.Size(105, 147);
            this.pbDealerCard2.TabIndex = 25;
            this.pbDealerCard2.TabStop = false;
            // 
            // lblBankrollLabel
            // 
            this.lblBankrollLabel.AutoSize = true;
            this.lblBankrollLabel.Location = new System.Drawing.Point(5, 204);
            this.lblBankrollLabel.Name = "lblBankrollLabel";
            this.lblBankrollLabel.Size = new System.Drawing.Size(48, 13);
            this.lblBankrollLabel.TabIndex = 26;
            this.lblBankrollLabel.Text = "Bankroll:";
            // 
            // lblBankroll
            // 
            this.lblBankroll.AutoSize = true;
            this.lblBankroll.Location = new System.Drawing.Point(52, 204);
            this.lblBankroll.Name = "lblBankroll";
            this.lblBankroll.Size = new System.Drawing.Size(0, 13);
            this.lblBankroll.TabIndex = 27;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(275, 175);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(290, 125);
            this.txtMessage.TabIndex = 28;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnRebuy);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pbPlayerCard2);
            this.panel1.Controls.Add(this.txtMessage);
            this.panel1.Controls.Add(this.nudAnte);
            this.panel1.Controls.Add(this.lblBankroll);
            this.panel1.Controls.Add(this.lblAnte);
            this.panel1.Controls.Add(this.lblBankrollLabel);
            this.panel1.Controls.Add(this.nudHoleCards);
            this.panel1.Controls.Add(this.nudFinalHand);
            this.panel1.Controls.Add(this.lblHoleCards);
            this.panel1.Controls.Add(this.lblFinalHand);
            this.panel1.Controls.Add(this.btnFold);
            this.panel1.Controls.Add(this.btnRaise);
            this.panel1.Controls.Add(this.btnAllIn);
            this.panel1.Controls.Add(this.btnDeal);
            this.panel1.Controls.Add(this.pbPlayerCard1);
            this.panel1.Location = new System.Drawing.Point(12, 381);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 311);
            this.panel1.TabIndex = 29;
            // 
            // btnRebuy
            // 
            this.btnRebuy.Location = new System.Drawing.Point(8, 146);
            this.btnRebuy.Name = "btnRebuy";
            this.btnRebuy.Size = new System.Drawing.Size(103, 23);
            this.btnRebuy.TabIndex = 30;
            this.btnRebuy.Text = "Rebuy (+$60)";
            this.btnRebuy.UseVisualStyleBackColor = true;
            this.btnRebuy.Visible = false;
            this.btnRebuy.Click += new System.EventHandler(this.btnRebuy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Player\'s Cards";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pbCommCard1);
            this.panel2.Controls.Add(this.pbCommCard2);
            this.panel2.Controls.Add(this.pbCommCard3);
            this.panel2.Controls.Add(this.pbCommCard4);
            this.panel2.Controls.Add(this.pbCommCard5);
            this.panel2.Location = new System.Drawing.Point(12, 195);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(580, 180);
            this.panel2.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Community Cards";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.pbDealerCard2);
            this.panel3.Controls.Add(this.pbDealerCard1);
            this.panel3.Location = new System.Drawing.Point(161, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(247, 177);
            this.panel3.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Dealer\'s Cards";
            // 
            // btnEVTable
            // 
            this.btnEVTable.Location = new System.Drawing.Point(517, 8);
            this.btnEVTable.Name = "btnEVTable";
            this.btnEVTable.Size = new System.Drawing.Size(75, 23);
            this.btnEVTable.TabIndex = 32;
            this.btnEVTable.Text = "EV Table";
            this.btnEVTable.UseVisualStyleBackColor = true;
            this.btnEVTable.Click += new System.EventHandler(this.btnEVTable_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 703);
            this.Controls.Add(this.btnEVTable);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblImageLocation);
            this.Name = "Form1";
            this.Text = "World Poker Tour All-In Texas Hold\'em - Programmed by Rich Mays";
            ((System.ComponentModel.ISupportInitialize)(this.nudAnte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoleCards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFinalHand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCommCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCommCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCommCard3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCommCard4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCommCard5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDealerCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDealerCard2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblImageLocation;
        private System.Windows.Forms.NumericUpDown nudAnte;
        private System.Windows.Forms.Label lblAnte;
        private System.Windows.Forms.NumericUpDown nudHoleCards;
        private System.Windows.Forms.NumericUpDown nudFinalHand;
        private System.Windows.Forms.Label lblHoleCards;
        private System.Windows.Forms.Label lblFinalHand;
        private System.Windows.Forms.Button btnFold;
        private System.Windows.Forms.Button btnRaise;
        private System.Windows.Forms.Button btnAllIn;
        private System.Windows.Forms.Button btnDeal;
        private System.Windows.Forms.PictureBox pbPlayerCard1;
        private System.Windows.Forms.PictureBox pbPlayerCard2;
        private System.Windows.Forms.PictureBox pbCommCard1;
        private System.Windows.Forms.PictureBox pbCommCard2;
        private System.Windows.Forms.PictureBox pbCommCard3;
        private System.Windows.Forms.PictureBox pbCommCard4;
        private System.Windows.Forms.PictureBox pbCommCard5;
        private System.Windows.Forms.PictureBox pbDealerCard1;
        private System.Windows.Forms.PictureBox pbDealerCard2;
        private System.Windows.Forms.Label lblBankrollLabel;
        private System.Windows.Forms.Label lblBankroll;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRebuy;
        private System.Windows.Forms.Button btnEVTable;
    }
}

