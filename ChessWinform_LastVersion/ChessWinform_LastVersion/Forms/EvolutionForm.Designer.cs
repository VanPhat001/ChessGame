namespace Chess.Forms
{
    partial class EvolutionForm
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
            this.pictureBoxShowPiece = new System.Windows.Forms.PictureBox();
            this.btnEvolution = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowPiece)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxShowPiece
            // 
            this.pictureBoxShowPiece.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxShowPiece.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxShowPiece.Name = "pictureBoxShowPiece";
            this.pictureBoxShowPiece.Size = new System.Drawing.Size(50, 41);
            this.pictureBoxShowPiece.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxShowPiece.TabIndex = 0;
            this.pictureBoxShowPiece.TabStop = false;
            // 
            // btnEvolution
            // 
            this.btnEvolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEvolution.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnEvolution.Location = new System.Drawing.Point(75, 41);
            this.btnEvolution.Name = "btnEvolution";
            this.btnEvolution.Size = new System.Drawing.Size(98, 30);
            this.btnEvolution.TabIndex = 1;
            this.btnEvolution.Text = "Evolution";
            this.btnEvolution.UseVisualStyleBackColor = true;
            this.btnEvolution.Click += new System.EventHandler(this.btnEvolution_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrev.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnPrev.Location = new System.Drawing.Point(75, 12);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(46, 27);
            this.btnPrev.TabIndex = 2;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnNext.Location = new System.Drawing.Point(127, 12);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(46, 27);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(12, 56);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(50, 13);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "label1";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EvolutionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 83);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnEvolution);
            this.Controls.Add(this.pictureBoxShowPiece);
            this.Name = "EvolutionForm";
            this.Text = "EvolutionForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowPiece)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxShowPiece;
        private System.Windows.Forms.Button btnEvolution;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblName;
    }
}