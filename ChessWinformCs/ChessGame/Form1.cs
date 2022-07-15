using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class Form1 : Form
    {
        #region Properties
        Process xuli = null;
        socketClass socket = null;
        List<Button> chessBoard = null;
        #endregion

        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();

            NewGame();
        }


        #region Methods
        /// <summary>
        /// Khởi tạo thông số và bản đồ chơi
        /// </summary>
        void NewGame()
        {
            pnlChessBoard.Controls.Clear();
            fpnlTienhoa.Hide();
            chessBoard = new List<Button>();
            CreateChessBoard();
            xuli = new Process(chessBoard, pnlChessBoard, fpnlTienhoa, btnOK, txbTurn, socket, true);
        }

        /// <summary>
        /// Lấy chỉ số của button tương ứng với cột y hàng x
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        int GetIndex(int x, int y)
        {
            return y * Constant.col + x;
        }

        /// <summary>
        /// Lấy toạ độ hàng cột của button tương ứng với chỉ số index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        Point GetPoint(int index)
        {
            return new Point(index % Constant.col, index / Constant.col);
        }

        /// <summary>
        /// Lấy button tại hàng y cột x
        /// </summary>
        /// <param name="x_index"></param>
        /// <param name="y_index"></param>
        /// <returns></returns>
        Button CreateButton(int x_index, int y_index)
        {
            Button btn = new Button()
            {
                Location = new Point(x_index * Constant.btnWidth, y_index * Constant.btnHeight),
                Width = Constant.btnWidth,
                Height = Constant.btnHeight,
                Font = new System.Drawing.Font("Microsoft Sans Serif", Constant.fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Tag = GetIndex(x_index, y_index)
            };

            btn.Click += Btn_Click;

            return btn;
        }

        /// <summary>
        /// Khởi tạo bàn cờ
        /// </summary>
        void CreateChessBoard()
        {
            for (int i = 0; i < Constant.row; i++)
            {
                for (int j = 0; j < Constant.col; j++)
                {
                    chessBoard.Add(CreateButton(j, i));
                    pnlChessBoard.Controls.Add(chessBoard.Last());
                }
            }
        }
        #endregion


        #region Control_Event
        /// <summary>
        /// Xử lí sự kiện chọn quân cờ để di chuyển
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Click(object sender, EventArgs e)
        {
            //Point toado = GetPoint((int)(sender as Button).Tag);
            //string message = toado.Y + " " + toado.X;
            //MessageBox.Show(message);

            Point toado = GetPoint(chessBoard.IndexOf(sender as Button));
            xuli.Connect(toado.X, toado.Y);
        }

        /// <summary>
        /// Xử lí sự kiện thoát game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát trò chơi?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            switch (result)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:
                    Application.Exit();
                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// Xử lí sự kiện chơi mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
            pnlChessBoard.Enabled = true;
        }

        /// <summary>
        /// Tạo phòng/server (kết nối mạng LAN)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            socket = new socketClass();
            socket.CreateServer();
            xuli = new Process(chessBoard, pnlChessBoard, fpnlTienhoa, btnOK, txbTurn, socket, true);
            (sender as ToolStripMenuItem).Enabled = false;
        }

        /// <summary>
        /// Đóng kết nối mạng LAN (nếu có)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (socket != null)
            {
                socket.CloseSocket();
            }
        }

        /// <summary>
        /// Kết nối client đến server/ vào phòng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            socket = new socketClass();
            socket.ConnectServer();
            xuli = new Process(chessBoard, pnlChessBoard, fpnlTienhoa, btnOK, txbTurn, socket, false);
        }
        #endregion
    }
}
