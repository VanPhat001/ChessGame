using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public enum ChessMan
    {
        EMPTY,
        KING,
        QUEEN,
        BISHOP, // Quân tượng
        KNIGHT, // Quân mã
        ROCK,   // Quân xe
        PAWN    // Quân tốt
    }

    public class Process
    {
        // bottom chơi trước, bottom mã là 1 (friend), top mã là -1 (enemy);
        // server(tạo phòng) đi trước, client(truy cập vào phòng) đi sau
        // chessmate còn vấn đề

        #region Properties
        int[,] BanCo =
        {
            { -5, -4, -3, -2, -1, -3, -4, -5 },
            { -6, -6, -6, -6, -6, -6, -6, -6 },
            {  0,  0,  0,  0,  0,  0,  0,  0 },
            {  0,  0,  0,  0,  0,  0,  0,  0 },
            {  0,  0,  0,  0,  0,  0,  0,  0 },
            {  0,  0,  0,  0,  0,  0,  0,  0 },
            {  6,  6,  6,  6,  6,  6,  6,  6 },
            {  5,  4,  3,  2,  1,  3,  4,  5 }
        };
        socketClass socket = null;
        Panel pnlChessBoard;
        FlowLayoutPanel fpnlTienHoa;
        Button btnTienHoa;
        List<Button> Map = null;
        Point toado = new Point(-1, -1);
        Point toadoTienHoa = new Point(-1, -1);
        TextBox txbTurn;
        bool myTurn = false;
        bool isServer = false;
        bool datienhoa = false;
        #endregion

        public Process(List<Button> chessBoard, Panel pnlChessBoard, FlowLayoutPanel fpnlTienHoa, Button btnTienHoa, TextBox txbTurn, socketClass socket, bool MyTurn)
        {
            this.Map = chessBoard;
            this.pnlChessBoard = pnlChessBoard;
            this.fpnlTienHoa = fpnlTienHoa;
            this.btnTienHoa = btnTienHoa;
            this.txbTurn = txbTurn;
            this.socket = socket;
            this.myTurn = MyTurn;
            this.isServer = myTurn;

            UpdateTurn();


            //Thread btnclicktienhoa = new Thread(() => { this.btnTienHoa.Click += BtnTienHoa_Click; });
            //btnclicktienhoa.IsBackground = true;
            //btnclicktienhoa.Start();
            this.btnTienHoa.Click += BtnTienHoa_Click;


            for (int i = 0; i < Constant.row; i++)
            {
                for (int j = 0; j < Constant.col; j++)
                {
                    //if (i == 1 || i == 6) BanCo[i, j] = 0;

                    int quanco = BanCo[i, j];
                    int friend = quanco < 0 ? 1 : -1;
                    SetChessManAt(j, i, GetChessMan(Math.Abs(quanco)), friend);
                }
            }

            //Thread whoTurnThread = new Thread(() =>
            //{
            //    while (true)
            //    {
            //        UpdateTurn();
            //        Thread.Sleep(300);
            //    }
            //});
            //whoTurnThread.IsBackground = true;
            //whoTurnThread.Start();

            Thread listenSocket = new Thread(() =>
            {
                while (true)
                {
                    if (!myTurn)
                    {
                        dataClass dulieu = socket.ReceiveData();
                        SetChessmanFromStartToEnd(dulieu.Start, dulieu.End);
                        myTurn = !myTurn;
                        UpdateTurn();

                        if (dulieu.Chessmate)
                        {
                            pnlChessBoard.Enabled = true;
                        }
                        else if (dulieu.Evolution)
                        {
                            ChessMan quanco = GetChessMan(dulieu.chessman);
                            int friend = !isServer ? -1 : 1;
                            SetChessManAt(dulieu.End.X, dulieu.End.Y, quanco, friend);
                        }

                    }
                    Thread.Sleep(100);
                }
            });
            listenSocket.IsBackground = true;
            listenSocket.Start();



            //for (int i = 0; i < Constant.row; i++)
            //{
            //    for (int j = 0; j < Constant.col; j++)
            //    {
            //        SetChessManAt(j, i, ChessMan.EMPTY, 1);
            //    }
            //}

            //SetChessManAt(3, 3, ChessMan.QUEEN, 1);

            //SetChessManAt(5, 5, ChessMan.ROCK, -1);

            ////SetChessManAt(3, 3, ChessMan.KING, 1);
            ////SetChessManAt(2, 5, ChessMan.PAWN, -1);
            ////SetChessManAt(6, 5, ChessMan.QUEEN, -1);
        }

        /// <summary>
        /// Cập nhật và hiển thị trạng thái lượt chơi
        /// </summary>
        void UpdateTurn()
        {
            string message = myTurn ? "My turn" : "Someone's turn";
            txbTurn.Text = message;
        }

        /// <summary>
        /// Accept Evolution Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTienHoa_Click(object sender, EventArgs e)
        {
            int quanco = 0;
            foreach (RadioButton radio in fpnlTienHoa.Controls)
            {
                if (radio != null)
                {
                    if (radio.Checked)
                    {
                        quanco = int.Parse(radio.Tag.ToString());
                        int friend = (int)GetButton(toadoTienHoa.X, toadoTienHoa.Y).Tag > 0 ? 1 : -1;
                        SetChessManAt(toadoTienHoa.X, toadoTienHoa.Y, GetChessMan(quanco), friend);
                        break;
                    }
                }
            }

            fpnlTienHoa.Hide();
            pnlChessBoard.Enabled = true;

            dataClass dulieu = new dataClass(toado, toadoTienHoa, !myTurn, true, quanco, false);
            socket.SendData(dulieu);
            myTurn = !myTurn;
            UpdateTurn();

            datienhoa = true;
            //toadoTienHoa.X = toadoTienHoa.Y = -1;
        }

        #region Methods

        #region InitChessBoard
        /// <summary>
        /// Thiết lập quân cờ chessman tại vị trí hàng y cột x
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="chessman"></param>
        /// <param name="friend">-1 nếu là kẻ thù, 1 nếu là đồng minh</param>
        void SetChessManAt(int x, int y, ChessMan chessman, int friend)
        {
            Button btn = GetButton(x, y);

            btn.Tag = (int)chessman * friend;
            btn.Text = ConvertChessManName((int)chessman);
            btn.ForeColor = (friend == 1 ? Color.Black : Color.Red);
            btn.BackColor = (x + y) % 2 == 1 ? Color.White : Color.SandyBrown;
        }

        /// <summary>
        /// Kiểm tra 2 quân cờ chessmanX và chessmanY có phải là kẻ thù
        /// </summary>
        /// <param name="chessmanX"></param>
        /// <param name="chessmanY"></param>
        /// <returns></returns>
        bool IsEnemy(int chessmanX, int chessmanY)
        {
            return (chessmanX * chessmanY) <= 0;
        }

        /// <summary>
        /// Chuyển đổi từ kí hiệu chessman thành tên tương ứng
        /// </summary>
        /// <param name="chessman"></param>
        /// <returns></returns>
        string ConvertChessManName(int chessman)
        {
            switch (Math.Abs(chessman))
            {
                case (int)ChessMan.EMPTY:
                    return "";
                case (int)ChessMan.KING:
                    return "vua";
                case (int)ChessMan.QUEEN:
                    return "hậu";
                case (int)ChessMan.BISHOP:
                    return "tượng";
                case (int)ChessMan.KNIGHT:
                    return "mã";
                case (int)ChessMan.ROCK:
                    return "xe";
                case (int)ChessMan.PAWN:
                    return "tốt";
                default:
                    break;
            }
            return "";
        }

        /// <summary>
        /// Chuyển đổi kí hiệu chessman về enum tương ứng
        /// </summary>
        /// <param name="chessman"></param>
        /// <returns></returns>
        ChessMan GetChessMan(int chessman)
        {
            switch (chessman)
            {
                case (int)ChessMan.EMPTY:
                    return ChessMan.EMPTY;

                case (int)ChessMan.KING:
                    return ChessMan.KING;

                case (int)ChessMan.QUEEN:
                    return ChessMan.QUEEN;

                case (int)ChessMan.BISHOP:
                    return ChessMan.BISHOP;

                case (int)ChessMan.KNIGHT:
                    return ChessMan.KNIGHT;

                case (int)ChessMan.ROCK:
                    return ChessMan.ROCK;

                case (int)ChessMan.PAWN:
                    return ChessMan.PAWN;
            }
            return ChessMan.EMPTY;
        }
        #endregion

        #region ProcessPlayGame
        /// <summary>
        /// Lẩy chỉ số của hàng y cột x
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int GetIndex(int x, int y)
        {
            return y * Constant.col + x;
        }

        /// <summary>
        /// Chuyển chỉ số về toạ độ
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Point GetPoint(int index)
        {
            return new Point(index % Constant.col, index / Constant.col);
        }

        /// <summary>
        /// Lấy button tại hàng y cột x
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Button GetButton(int x, int y)
        {
            return Map.ElementAt(GetIndex(x, y));
        }

        void SetChessmanFromStartToEnd(Point start, Point end)
        {
            // di chuyển quân cờ
            int temp = (int)GetButton(start.X, start.Y).Tag;
            ChessMan quanco = GetChessMan(Math.Abs(temp));
            int friend = temp > 0 ? 1 : -1;
            SetChessManAt(end.X, end.Y, quanco, friend);

            SetChessManAt(start.X, start.Y, ChessMan.EMPTY, 1);
        }

        /// <summary>
        /// Xử lí sự kiện chọn và di chuyển quân cờ
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Connect(int x, int y)
        {
            // khoá bàn cờ cho đến khi đến lượt chơi
            if (!myTurn) return;

            if (toado.X == -1)
            {
                // bottom(1) server/dưới
                if (isServer && (int)GetButton(x, y).Tag > 0) return;

                //// top(-1) client/trên
                if (!isServer && (int)GetButton(x, y).Tag < 0) return;

                if ((int)GetButton(x, y).Tag == (int)ChessMan.EMPTY) return;

                toado.X = x;
                toado.Y = y;
                GetButton(x, y).BackColor = Color.Aqua;

                for (int i = 0; i < Constant.row; i++)
                {
                    for (int j = 0; j < Constant.col; j++)
                    {
                        if (CheckMove(toado, new Point(j, i)))
                            GetButton(j, i).BackColor = Color.Aqua;
                    }
                }

                return;
            }
            else
            {
                bool moveLegal = true;
                // kiểm tra di chuyển và di chuyển
                if (CheckMove(toado, new Point(x, y)))
                {
                    SetChessmanFromStartToEnd(toado, new Point(x, y));

                    if (Chessmate())
                    {
                        MessageBox.Show("Chessmate");
                        pnlChessBoard.Enabled = false;

                        dataClass data = new dataClass(toado, new Point(x, y), !myTurn, false, 0, true);

                        socket.SendData(data);

                        return;
                    }

                    if ((y == 0 || y == Constant.row - 1) && Math.Abs((int)GetButton(x, y).Tag) == (int)ChessMan.PAWN) // tiến hoá
                    {
                        toadoTienHoa.X = x;
                        toadoTienHoa.Y = y;

                        Evolution(x, y);

                        //while (true)
                        //{
                        //    if (datienhoa) break;
                        //}
                        //datienhoa = false;

                        //moveLegal = false; // để socket không phải gửi tin 2 lần
                    }
                }
                else
                {
                    moveLegal = false;
                }

                // huỷ trạng thái (đổi màu ô)
                for (int i = 0; i < Constant.row; i++)
                {
                    for (int j = 0; j < Constant.col; j++)
                    {
                        GetButton(j, i).BackColor = (j + i) % 2 == 1 ? Color.White : Color.SandyBrown;
                    }
                }

                // thiết lập lại toạ độ và lượt chơi - di chuyển tại chỗ
                if (toado.X != x || toado.Y != y)
                {
                    if (moveLegal)
                    {
                        dataClass data = new dataClass(toado, new Point(x, y), !myTurn, false, 0, false);

                        socket.SendData(data);

                        myTurn = !myTurn;
                        UpdateTurn();
                    }
                }
                toado.X = toado.Y = -1;
            }
        }

        /// <summary>
        /// Tiến hoá quân tốt thành quân tương ứng được chọn
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void Evolution(int x, int y)
        {
            MessageBox.Show("Chọn quân cờ bạn muốn tiến hoá!");

            toadoTienHoa.X = x;
            toadoTienHoa.Y = y;
            fpnlTienHoa.Show();
            pnlChessBoard.Enabled = false;
        }

        /// <summary>
        /// Kiểm tra quân vua có được phép di chuyển
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public bool CheckKingMove(Point start, Point end)
        {
            int[,] kingMove =
            {
                {-1, -1}, {-1, 0}, {-1, 1}, {0, -1}, {0, 1}, {1, -1}, {1, 0}, {1, 1}
            };
            for (int i = 0; i < 8; i++)
            {
                if (end.X == start.X + kingMove[i, 1] && end.Y == start.Y + kingMove[i, 0]) return true;
            }

            return false;
        }

        /// <summary>
        /// Kiểm tra quân hậu có được phép di chuyển
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public bool CheckQueenMove(Point start, Point end)
        {
            return CheckBishopMove(start, end) || CheckRockMove(start, end);
        }

        /// <summary>
        /// Tính khoảng cách từ điểm a đến điểm b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double Distance(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        /// <summary>
        /// Kiểm tra quân tượng có được phép di chuyển
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public bool CheckBishopMove(Point start, Point end)
        {
            if (Math.Abs(start.X - end.X) != Math.Abs(start.Y - end.Y)) return false;

            int[,] bishopMove =
            {
                {-1, -1}, {-1, 1}, {1, -1}, {1, 1}
            };

            int iMin = 0;
            double minDistance = 1000;

            for (int i = 0; i < 4; i++)
            {
                double d = Distance(new Point(start.X + bishopMove[i, 1], start.Y + bishopMove[i, 0]), end);
                if (d < minDistance)
                {
                    iMin = i;
                    minDistance = d;
                }

            }

            return CountWallInPath(start, end, bishopMove[iMin, 1], bishopMove[iMin, 0]) == 0;
        }

        /// <summary>
        /// Kiểm tra quân mã có được phép di chuyển
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public bool CheckKnightMove(Point start, Point end)
        {
            int[,] knightMove = {
                {-2, -1}, {-2, 1}, {-1, -2}, {-1, 2}, {1, -2}, {1, 2}, {2, -1}, {2, 1}
            };

            for (int i = 0; i < 8; i++)
            {
                if (start.X + knightMove[i, 1] == end.X && start.Y + knightMove[i, 0] == end.Y) return true;
            }
            //if (Math.Abs(start.X - end.X) + Math.Abs(start.Y - end.Y) == 3) return true;

            return false;
        }

        /// <summary>
        /// Kiểm tra quân xe có được phép di chuyển
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public bool CheckRockMove(Point start, Point end)
        {
            if (start.X == end.X)
            {
                if (end.Y < start.Y && CountWallInPath(start, end, 0, -1) == 0)
                    return true;
                if (end.Y > start.Y && CountWallInPath(start, end, 0, 1) == 0)
                    return true;
            }
            else if (start.Y == end.Y)
            {
                if (end.X < start.X && CountWallInPath(start, end, -1, 0) == 0)
                    return true;
                if (end.X > start.X && CountWallInPath(start, end, 1, 0) == 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra tính hợp lệ trong di chuyển của quân tốt trên top 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public bool CheckPawnTop(Point start, Point end)
        {
            if (start.X == end.X) //di chuyển thẳng hàng, đến ô trống
            {
                if ((int)GetButton(end.X, end.Y).Tag != (int)ChessMan.EMPTY) return false;

                if (start.Y + 1 == end.Y) return true;

                if (start.Y + 2 == end.Y && start.Y == 1) return true;
            }
            else if (Math.Abs(start.X - end.X) == 1) // di chuyển đến vị trí kẻ thù
            {
                int startchessman = (int)GetButton(start.X, start.Y).Tag;
                int endchessman = (int)GetButton(end.X, end.Y).Tag;

                if (endchessman == 0) return false;

                if (!IsEnemy(startchessman, endchessman)) return false;

                if (start.Y + 1 != end.Y) return false;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Kiểm tra tính hợp lệ trong di chuyển của quân tốt dưới bottom
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public bool CheckPawnBottom(Point start, Point end)
        {
            if (start.X == end.X) //di chuyển thẳng hàng, đến ô trống
            {
                if ((int)GetButton(end.X, end.Y).Tag != (int)ChessMan.EMPTY) return false;

                if (start.Y - 1 == end.Y) return true;

                if (start.Y - 2 == end.Y && start.Y == 6) return true;
            }
            else if (Math.Abs(start.X - end.X) == 1) // di chuyển đến vị trí kẻ thù
            {
                int startchessman = (int)GetButton(start.X, start.Y).Tag;
                int endchessman = (int)GetButton(end.X, end.Y).Tag;

                if (endchessman == 0) return false;

                if (!IsEnemy(startchessman, endchessman)) return false;

                if (start.Y - 1 != end.Y) return false;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Kiểm tra quân tốt có được phép di chuyển 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public bool CheckPawnMove(Point start, Point end)
        {
            int temp = (int)GetButton(start.X, start.Y).Tag;
            bool isTop = temp > 0 ? true : false;

            if (isTop)
            {
                return CheckPawnTop(start, end);
            }
            else
            {
                return CheckPawnBottom(start, end);
            }
            //return false;
        }

        /// <summary>
        /// Đếm số vật cản trên đường đi từ (start, end), không lấy 2 đầu mút
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="moveX"></param>
        /// <param name="moveY"></param>
        /// <returns></returns>
        public int CountWallInPath(Point start, Point end, int moveX, int moveY)
        {
            //đếm số vật cản trên đường đi
            if (start.X == end.X && start.Y == end.Y) return 0;
            int count = 0;

            while (true)
            {
                int X = start.X + moveX;
                int Y = start.Y + moveY;

                if (X == end.X && Y == end.Y) break;

                if (X < 0 || Y < 0 || X >= Constant.col || Y >= Constant.row) break;


                if ((int)GetButton(X, Y).Tag != 0)
                {
                    count++;
                }

                start.X = X;
                start.Y = Y;
            }

            return count;
        }

        /// <summary>
        /// Kiểm tra một quân cờ bất kì có được phép di chuyển
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public bool CheckMove(Point start, Point end)
        {
            if (start.X == end.X && start.Y == end.Y) return false;

            int quanco1 = (int)GetButton(start.X, start.Y).Tag;
            int quanco2 = (int)GetButton(end.X, end.Y).Tag;

            if (!IsEnemy(quanco1, quanco2)) return false;

            int quanco = Math.Abs((int)GetButton(start.X, start.Y).Tag);
            switch (quanco)
            {
                case (int)ChessMan.EMPTY:
                    break;
                case (int)ChessMan.KING:
                    return CheckKingMove(start, end);
                case (int)ChessMan.QUEEN:
                    return CheckQueenMove(start, end);
                case (int)ChessMan.BISHOP:
                    return CheckBishopMove(start, end);
                case (int)ChessMan.KNIGHT:
                    return CheckKnightMove(start, end);
                case (int)ChessMan.ROCK:
                    return CheckRockMove(start, end);
                case (int)ChessMan.PAWN:
                    return CheckPawnMove(start, end);
            }

            return false;
        }

        /// <summary>
        /// Kiểm tra trò chơi kết thúc chưa
        /// </summary>
        /// <returns></returns>
        public bool Chessmate()
        {
            int countKing = 0;

            foreach (var item in Map)
            {
                if (Math.Abs((int)item.Tag) == (int)ChessMan.KING)
                {
                    countKing++;
                }
            }

            return countKing == 1;
        }
        #endregion

        #endregion
    }
}
