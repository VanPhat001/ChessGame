namespace Chess.Forms
{
    partial class ChessBoardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChessBoardForm));
            this.pnlBoard = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxShowTurn = new System.Windows.Forms.TextBox();
            this.pictureBoxNext = new System.Windows.Forms.PictureBox();
            this.pictureBoxUndo = new System.Windows.Forms.PictureBox();
            this.progressBarCountTime = new System.Windows.Forms.ProgressBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUndo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.BackColor = System.Drawing.Color.Transparent;
            this.pnlBoard.Location = new System.Drawing.Point(13, 13);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(498, 417);
            this.pnlBoard.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.textBoxShowTurn);
            this.panel1.Controls.Add(this.pictureBoxNext);
            this.panel1.Controls.Add(this.pictureBoxUndo);
            this.panel1.Controls.Add(this.progressBarCountTime);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Location = new System.Drawing.Point(517, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 417);
            this.panel1.TabIndex = 1;
            // 
            // textBoxShowTurn
            // 
            this.textBoxShowTurn.Enabled = false;
            this.textBoxShowTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxShowTurn.Location = new System.Drawing.Point(3, 236);
            this.textBoxShowTurn.Multiline = true;
            this.textBoxShowTurn.Name = "textBoxShowTurn";
            this.textBoxShowTurn.Size = new System.Drawing.Size(302, 40);
            this.textBoxShowTurn.TabIndex = 4;
            this.textBoxShowTurn.Text = "Turn of Black chess piece";
            this.textBoxShowTurn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBoxNext
            // 
            this.pictureBoxNext.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxNext.Image")));
            this.pictureBoxNext.Location = new System.Drawing.Point(156, 282);
            this.pictureBoxNext.Name = "pictureBoxNext";
            this.pictureBoxNext.Size = new System.Drawing.Size(150, 40);
            this.pictureBoxNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxNext.TabIndex = 3;
            this.pictureBoxNext.TabStop = false;
            this.pictureBoxNext.MouseEnter += new System.EventHandler(this.pictureBoxNext_MouseEnter);
            this.pictureBoxNext.MouseLeave += new System.EventHandler(this.pictureBoxNext_MouseLeave);
            // 
            // pictureBoxUndo
            // 
            this.pictureBoxUndo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxUndo.Image")));
            this.pictureBoxUndo.Location = new System.Drawing.Point(3, 282);
            this.pictureBoxUndo.Name = "pictureBoxUndo";
            this.pictureBoxUndo.Size = new System.Drawing.Size(150, 40);
            this.pictureBoxUndo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxUndo.TabIndex = 2;
            this.pictureBoxUndo.TabStop = false;
            this.pictureBoxUndo.MouseEnter += new System.EventHandler(this.pictureBoxUndo_MouseEnter);
            this.pictureBoxUndo.MouseLeave += new System.EventHandler(this.pictureBoxUndo_MouseLeave);
            // 
            // progressBarCountTime
            // 
            this.progressBarCountTime.Location = new System.Drawing.Point(3, 328);
            this.progressBarCountTime.Name = "progressBarCountTime";
            this.progressBarCountTime.Size = new System.Drawing.Size(303, 40);
            this.progressBarCountTime.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarCountTime.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(3, 374);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(303, 40);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // ChessBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 442);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBoard);
            this.Name = "ChessBoardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUndo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.FlowLayoutPanel pnlBoard;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox textBoxShowTurn;
        public System.Windows.Forms.PictureBox pictureBoxNext;
        public System.Windows.Forms.PictureBox pictureBoxUndo;
        public System.Windows.Forms.ProgressBar progressBarCountTime;
        public System.Windows.Forms.Button btnStart;
    }
}

