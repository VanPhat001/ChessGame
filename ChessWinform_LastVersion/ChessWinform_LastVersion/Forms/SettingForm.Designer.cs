namespace Chess.Forms
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxSelectPiece = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxFirstCell = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBoxSecondCell = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.numericUpDownCurrentValue = new System.Windows.Forms.NumericUpDown();
            this.lblMaxValue = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBarTime = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectPiece)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFirstCell)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSecondCell)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCurrentValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTime)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pictureBoxSelectPiece);
            this.panel2.Location = new System.Drawing.Point(12, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(843, 86);
            this.panel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Background select piece";
            // 
            // pictureBoxSelectPiece
            // 
            this.pictureBoxSelectPiece.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxSelectPiece.BackgroundImage")));
            this.pictureBoxSelectPiece.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxSelectPiece.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxSelectPiece.Location = new System.Drawing.Point(763, 0);
            this.pictureBoxSelectPiece.Name = "pictureBoxSelectPiece";
            this.pictureBoxSelectPiece.Size = new System.Drawing.Size(80, 86);
            this.pictureBoxSelectPiece.TabIndex = 0;
            this.pictureBoxSelectPiece.TabStop = false;
            this.pictureBoxSelectPiece.Click += new System.EventHandler(this.pictureBox_Click_ChangeBackColor);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBoxFirstCell);
            this.panel1.Location = new System.Drawing.Point(12, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 86);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Background first cell";
            // 
            // pictureBoxFirstCell
            // 
            this.pictureBoxFirstCell.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxFirstCell.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxFirstCell.Location = new System.Drawing.Point(763, 0);
            this.pictureBoxFirstCell.Name = "pictureBoxFirstCell";
            this.pictureBoxFirstCell.Size = new System.Drawing.Size(80, 86);
            this.pictureBoxFirstCell.TabIndex = 0;
            this.pictureBoxFirstCell.TabStop = false;
            this.pictureBoxFirstCell.Click += new System.EventHandler(this.pictureBox_Click_ChangeBackColor);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.pictureBoxSecondCell);
            this.panel3.Location = new System.Drawing.Point(12, 212);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(843, 86);
            this.panel3.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Background second cell";
            // 
            // pictureBoxSecondCell
            // 
            this.pictureBoxSecondCell.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxSecondCell.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxSecondCell.Location = new System.Drawing.Point(763, 0);
            this.pictureBoxSecondCell.Name = "pictureBoxSecondCell";
            this.pictureBoxSecondCell.Size = new System.Drawing.Size(80, 86);
            this.pictureBoxSecondCell.TabIndex = 0;
            this.pictureBoxSecondCell.TabStop = false;
            this.pictureBoxSecondCell.Click += new System.EventHandler(this.pictureBox_Click_ChangeBackColor);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.numericUpDownCurrentValue);
            this.panel4.Controls.Add(this.lblMaxValue);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.trackBarTime);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(12, 304);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(843, 86);
            this.panel4.TabIndex = 5;
            // 
            // numericUpDownCurrentValue
            // 
            this.numericUpDownCurrentValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownCurrentValue.Location = new System.Drawing.Point(703, 27);
            this.numericUpDownCurrentValue.Name = "numericUpDownCurrentValue";
            this.numericUpDownCurrentValue.Size = new System.Drawing.Size(57, 32);
            this.numericUpDownCurrentValue.TabIndex = 6;
            this.numericUpDownCurrentValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMaxValue
            // 
            this.lblMaxValue.AutoSize = true;
            this.lblMaxValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxValue.Location = new System.Drawing.Point(790, 29);
            this.lblMaxValue.Name = "lblMaxValue";
            this.lblMaxValue.Size = new System.Drawing.Size(53, 25);
            this.lblMaxValue.TabIndex = 5;
            this.lblMaxValue.Text = "Max";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(766, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "/";
            // 
            // trackBarTime
            // 
            this.trackBarTime.Location = new System.Drawing.Point(194, 20);
            this.trackBarTime.Name = "trackBarTime";
            this.trackBarTime.Size = new System.Drawing.Size(503, 45);
            this.trackBarTime.TabIndex = 2;
            this.trackBarTime.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Total time one turn";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button1.Location = new System.Drawing.Point(0, 420);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(867, 53);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 473);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "SettingForm";
            this.Text = "SettingForm";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectPiece)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFirstCell)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSecondCell)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCurrentValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxSelectPiece;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxFirstCell;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBoxSecondCell;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblMaxValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackBarTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDownCurrentValue;
    }
}