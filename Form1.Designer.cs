namespace C__Typing_Game
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpBoard = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.grpPresentScore = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pScore = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pTotal = new System.Windows.Forms.Label();
            this.pMiss = new System.Windows.Forms.Label();
            this.presentPgBar = new System.Windows.Forms.ProgressBar();
            this.grpBestScore = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bMiss = new System.Windows.Forms.Label();
            this.bTotal = new System.Windows.Forms.Label();
            this.bScore = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.wordCreationTimer = new System.Windows.Forms.Timer(this.components);
            this.grpBoard.SuspendLayout();
            this.grpPresentScore.SuspendLayout();
            this.grpBestScore.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoard
            // 
            this.grpBoard.Controls.Add(this.textBox1);
            this.grpBoard.Location = new System.Drawing.Point(10, 10);
            this.grpBoard.Name = "grpBoard";
            this.grpBoard.Size = new System.Drawing.Size(540, 540);
            this.grpBoard.TabIndex = 0;
            this.grpBoard.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 513);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(528, 21);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // grpPresentScore
            // 
            this.grpPresentScore.Controls.Add(this.presentPgBar);
            this.grpPresentScore.Controls.Add(this.label4);
            this.grpPresentScore.Controls.Add(this.label3);
            this.grpPresentScore.Controls.Add(this.label2);
            this.grpPresentScore.Controls.Add(this.pMiss);
            this.grpPresentScore.Controls.Add(this.pTotal);
            this.grpPresentScore.Controls.Add(this.pScore);
            this.grpPresentScore.Controls.Add(this.label1);
            this.grpPresentScore.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.grpPresentScore.Location = new System.Drawing.Point(570, 10);
            this.grpPresentScore.Name = "grpPresentScore";
            this.grpPresentScore.Size = new System.Drawing.Size(200, 200);
            this.grpPresentScore.TabIndex = 1;
            this.grpPresentScore.TabStop = false;
            this.grpPresentScore.Text = "Present Score";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "HP :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Miss :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total :";
            // 
            // pScore
            // 
            this.pScore.AutoSize = true;
            this.pScore.Location = new System.Drawing.Point(130, 35);
            this.pScore.Name = "pScore";
            this.pScore.Size = new System.Drawing.Size(17, 19);
            this.pScore.TabIndex = 0;
            this.pScore.Text = "0";
            this.pScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Score :";
            // 
            // pTotal
            // 
            this.pTotal.AutoSize = true;
            this.pTotal.Location = new System.Drawing.Point(130, 75);
            this.pTotal.Name = "pTotal";
            this.pTotal.Size = new System.Drawing.Size(17, 19);
            this.pTotal.TabIndex = 0;
            this.pTotal.Text = "0";
            this.pTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pMiss
            // 
            this.pMiss.AutoSize = true;
            this.pMiss.Location = new System.Drawing.Point(130, 115);
            this.pMiss.Name = "pMiss";
            this.pMiss.Size = new System.Drawing.Size(17, 19);
            this.pMiss.TabIndex = 0;
            this.pMiss.Text = "0";
            this.pMiss.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // presentPgBar
            // 
            this.presentPgBar.Location = new System.Drawing.Point(59, 152);
            this.presentPgBar.Name = "presentPgBar";
            this.presentPgBar.Size = new System.Drawing.Size(130, 24);
            this.presentPgBar.TabIndex = 0;
            this.presentPgBar.Value = 100;
            // 
            // grpBestScore
            // 
            this.grpBestScore.Controls.Add(this.label8);
            this.grpBestScore.Controls.Add(this.label6);
            this.grpBestScore.Controls.Add(this.bMiss);
            this.grpBestScore.Controls.Add(this.bTotal);
            this.grpBestScore.Controls.Add(this.bScore);
            this.grpBestScore.Controls.Add(this.label5);
            this.grpBestScore.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.grpBestScore.Location = new System.Drawing.Point(570, 240);
            this.grpBestScore.Name = "grpBestScore";
            this.grpBestScore.Size = new System.Drawing.Size(200, 200);
            this.grpBestScore.TabIndex = 2;
            this.grpBestScore.TabStop = false;
            this.grpBestScore.Text = "Best Score";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Miss :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Total :";
            // 
            // bMiss
            // 
            this.bMiss.AutoSize = true;
            this.bMiss.BackColor = System.Drawing.SystemColors.Control;
            this.bMiss.ForeColor = System.Drawing.Color.Red;
            this.bMiss.Location = new System.Drawing.Point(130, 155);
            this.bMiss.Name = "bMiss";
            this.bMiss.Size = new System.Drawing.Size(17, 19);
            this.bMiss.TabIndex = 0;
            this.bMiss.Text = "0";
            this.bMiss.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bTotal
            // 
            this.bTotal.AutoSize = true;
            this.bTotal.BackColor = System.Drawing.SystemColors.Control;
            this.bTotal.ForeColor = System.Drawing.Color.Red;
            this.bTotal.Location = new System.Drawing.Point(130, 100);
            this.bTotal.Name = "bTotal";
            this.bTotal.Size = new System.Drawing.Size(17, 19);
            this.bTotal.TabIndex = 0;
            this.bTotal.Text = "0";
            this.bTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bScore
            // 
            this.bScore.AutoSize = true;
            this.bScore.BackColor = System.Drawing.SystemColors.Control;
            this.bScore.ForeColor = System.Drawing.Color.Red;
            this.bScore.Location = new System.Drawing.Point(130, 45);
            this.bScore.Name = "bScore";
            this.bScore.Size = new System.Drawing.Size(17, 19);
            this.bScore.TabIndex = 0;
            this.bScore.Text = "0";
            this.bScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Score :";
            // 
            // btnRestart
            // 
            this.btnRestart.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnRestart.Location = new System.Drawing.Point(570, 458);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(90, 92);
            this.btnRestart.TabIndex = 1;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuit.Location = new System.Drawing.Point(680, 458);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(90, 92);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // wordCreationTimer
            // 
            this.wordCreationTimer.Enabled = true;
            this.wordCreationTimer.Interval = 3000;
            this.wordCreationTimer.Tick += new System.EventHandler(this.wordCreationTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 557);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.grpBestScore);
            this.Controls.Add(this.grpPresentScore);
            this.Controls.Add(this.grpBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "산성비 게임";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.grpBoard.ResumeLayout(false);
            this.grpBoard.PerformLayout();
            this.grpPresentScore.ResumeLayout(false);
            this.grpPresentScore.PerformLayout();
            this.grpBestScore.ResumeLayout(false);
            this.grpBestScore.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoard;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox grpPresentScore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label pScore;
        private System.Windows.Forms.Label pMiss;
        private System.Windows.Forms.Label pTotal;
        private System.Windows.Forms.ProgressBar presentPgBar;
        private System.Windows.Forms.GroupBox grpBestScore;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label bMiss;
        private System.Windows.Forms.Label bTotal;
        private System.Windows.Forms.Label bScore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer wordCreationTimer;
    }
}

