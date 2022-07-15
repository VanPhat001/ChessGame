
namespace ChessGame
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
            this.pnlChessBoard = new System.Windows.Forms.Panel();
            this.fpnlTienhoa = new System.Windows.Forms.FlowLayoutPanel();
            this.rbtnXe = new System.Windows.Forms.RadioButton();
            this.rbtnMa = new System.Windows.Forms.RadioButton();
            this.rbtnTuong = new System.Windows.Forms.RadioButton();
            this.rbtnHau = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.txbTurn = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lANToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joinRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fpnlTienhoa.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlChessBoard
            // 
            this.pnlChessBoard.Location = new System.Drawing.Point(12, 47);
            this.pnlChessBoard.Name = "pnlChessBoard";
            this.pnlChessBoard.Size = new System.Drawing.Size(552, 413);
            this.pnlChessBoard.TabIndex = 0;
            // 
            // fpnlTienhoa
            // 
            this.fpnlTienhoa.Controls.Add(this.rbtnXe);
            this.fpnlTienhoa.Controls.Add(this.rbtnMa);
            this.fpnlTienhoa.Controls.Add(this.rbtnTuong);
            this.fpnlTienhoa.Controls.Add(this.rbtnHau);
            this.fpnlTienhoa.Controls.Add(this.btnOK);
            this.fpnlTienhoa.Location = new System.Drawing.Point(599, 37);
            this.fpnlTienhoa.Name = "fpnlTienhoa";
            this.fpnlTienhoa.Size = new System.Drawing.Size(89, 156);
            this.fpnlTienhoa.TabIndex = 1;
            // 
            // rbtnXe
            // 
            this.rbtnXe.AutoSize = true;
            this.rbtnXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnXe.Location = new System.Drawing.Point(3, 3);
            this.rbtnXe.Name = "rbtnXe";
            this.rbtnXe.Size = new System.Drawing.Size(47, 24);
            this.rbtnXe.TabIndex = 0;
            this.rbtnXe.TabStop = true;
            this.rbtnXe.Tag = "5";
            this.rbtnXe.Text = "Xe";
            this.rbtnXe.UseVisualStyleBackColor = true;
            // 
            // rbtnMa
            // 
            this.rbtnMa.AutoSize = true;
            this.rbtnMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnMa.Location = new System.Drawing.Point(3, 33);
            this.rbtnMa.Name = "rbtnMa";
            this.rbtnMa.Size = new System.Drawing.Size(50, 24);
            this.rbtnMa.TabIndex = 1;
            this.rbtnMa.TabStop = true;
            this.rbtnMa.Tag = "4";
            this.rbtnMa.Text = "Mã";
            this.rbtnMa.UseVisualStyleBackColor = true;
            // 
            // rbtnTuong
            // 
            this.rbtnTuong.AutoSize = true;
            this.rbtnTuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTuong.Location = new System.Drawing.Point(3, 63);
            this.rbtnTuong.Name = "rbtnTuong";
            this.rbtnTuong.Size = new System.Drawing.Size(73, 24);
            this.rbtnTuong.TabIndex = 2;
            this.rbtnTuong.TabStop = true;
            this.rbtnTuong.Tag = "3";
            this.rbtnTuong.Text = "Tượng";
            this.rbtnTuong.UseVisualStyleBackColor = true;
            // 
            // rbtnHau
            // 
            this.rbtnHau.AutoSize = true;
            this.rbtnHau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnHau.Location = new System.Drawing.Point(3, 93);
            this.rbtnHau.Name = "rbtnHau";
            this.rbtnHau.Size = new System.Drawing.Size(58, 24);
            this.rbtnHau.TabIndex = 3;
            this.rbtnHau.TabStop = true;
            this.rbtnHau.Tag = "2";
            this.rbtnHau.Text = "Hậu";
            this.rbtnHau.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.AutoSize = true;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(3, 123);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(74, 30);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // txbTurn
            // 
            this.txbTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTurn.Location = new System.Drawing.Point(588, 231);
            this.txbTurn.Multiline = true;
            this.txbTurn.Name = "txbTurn";
            this.txbTurn.ReadOnly = true;
            this.txbTurn.Size = new System.Drawing.Size(163, 41);
            this.txbTurn.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.lANToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // lANToolStripMenuItem
            // 
            this.lANToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createRoomToolStripMenuItem,
            this.joinRoomToolStripMenuItem});
            this.lANToolStripMenuItem.Name = "lANToolStripMenuItem";
            this.lANToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.lANToolStripMenuItem.Text = "LAN";
            // 
            // createRoomToolStripMenuItem
            // 
            this.createRoomToolStripMenuItem.Name = "createRoomToolStripMenuItem";
            this.createRoomToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.createRoomToolStripMenuItem.Text = "Create room";
            this.createRoomToolStripMenuItem.Click += new System.EventHandler(this.createRoomToolStripMenuItem_Click);
            // 
            // joinRoomToolStripMenuItem
            // 
            this.joinRoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.connectToolStripMenuItem});
            this.joinRoomToolStripMenuItem.Name = "joinRoomToolStripMenuItem";
            this.joinRoomToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.joinRoomToolStripMenuItem.Text = "Join room with IP";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.Text = "127.0.0.1";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 472);
            this.Controls.Add(this.txbTurn);
            this.Controls.Add(this.fpnlTienhoa);
            this.Controls.Add(this.pnlChessBoard);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.fpnlTienhoa.ResumeLayout(false);
            this.fpnlTienhoa.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlChessBoard;
        private System.Windows.Forms.FlowLayoutPanel fpnlTienhoa;
        private System.Windows.Forms.RadioButton rbtnXe;
        private System.Windows.Forms.RadioButton rbtnMa;
        private System.Windows.Forms.RadioButton rbtnTuong;
        private System.Windows.Forms.RadioButton rbtnHau;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txbTurn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lANToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem joinRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
    }
}

